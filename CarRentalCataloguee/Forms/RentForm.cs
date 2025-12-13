using CarRentalCataloguee.Forms.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRentalCataloguee.Forms
{
    public partial class RentForm : Form
    {
        private readonly List<Car>? cars;
        private readonly Car? selectedCar;
        private const int MinimumRentAge = 18;

        // Return / cost helpers
        private DateTime? selectedReturnDate;
        private double estimatedCost;

        public RentForm()
        {
            InitializeComponent();
        }

        // Keeps compatibility when called with the whole list only
        public RentForm(List<Car> cars) : this()
        {
            this.cars = cars;
        }

        // Accept the list and the selected car to operate on
        public RentForm(List<Car> cars, Car selectedCar) : this(cars)
        {
            this.selectedCar = selectedCar;
            PopulateFields();
        }

        private void RentForm_Load(object sender, EventArgs e)
        {
            // Nothing required here; PopulateFields is called from ctor when appropriate.
        }

        private void PopulateFields()
        {
            if (selectedCar == null)
            {
                // Disable renter inputs if no car selected
                txtFullName.Enabled = txtDriverLicense.Enabled = txtAddress.Enabled = dtpBirthday.Enabled = nudAge.Enabled = btnConfirmRent.Enabled = dtpWhenToReturn.Enabled = false;
                lblTitle.Text = "Rent Car";
                return;
            }

            lblTitle.Text = "Rent Car";
            lblCarId.Text = $"Car ID: {selectedCar.CarID}";
            lblCarName.Text = $"Car Name: {selectedCar.CarName}";
            lblColor.Text = $"Color: {selectedCar.Color}";
            lblPrice.Text = $"Price per Hour: {selectedCar.PricePerHour:C}";
            lblAvailability.Text = $"Available: {selectedCar.Availability}";

            // default age from birthday if possible
            dtpBirthday.Value = DateTime.Today.AddYears(-MinimumRentAge);
            nudAge.Value = MinimumRentAge;

            // Configure return date picker: minimum is tomorrow
            dtpWhenToReturn.MinDate = DateTime.Today.AddDays(1);
            dtpWhenToReturn.Value = dtpWhenToReturn.MinDate;
            selectedReturnDate = dtpWhenToReturn.Value;

            // If car not available, disable confirm
            btnConfirmRent.Enabled = selectedCar.Availability;

            UpdateReturnInfo();
        }

        private void dtpBirthday_ValueChanged(object? sender, EventArgs e)
        {
            // Update nudAge to match birthday
            var today = DateTime.Today;
            int age = today.Year - dtpBirthday.Value.Year;
            if (dtpBirthday.Value.Date > today.AddYears(-age)) age--;
            if (age < 0) age = 0;
            nudAge.Value = age <= nudAge.Maximum ? age : nudAge.Maximum;
        }

        private void dtpWhenToReturn_ValueChanged(object sender, EventArgs e)
        {
            // Ensure return date is in the future (at least tomorrow)
            if (dtpWhenToReturn.Value.Date <= DateTime.Today)
            {
                MessageBox.Show("Return date must be after today. Setting to tomorrow.", "Invalid Return Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpWhenToReturn.Value = dtpWhenToReturn.MinDate;
                return;
            }

            selectedReturnDate = dtpWhenToReturn.Value;
            UpdateReturnInfo();
        }

        // Calculate estimated cost and update availability label with a short summary
        private void UpdateReturnInfo()
        {
            if (selectedCar == null || selectedReturnDate == null)
                return;

            // Calculate total hours from now until chosen return time; at least 1 hour
            double hours = (selectedReturnDate.Value - DateTime.Now).TotalHours;
            if (hours < 1) hours = 1;

            // Round up to nearest whole hour
            double billableHours = Math.Ceiling(hours);

            estimatedCost = billableHours * (double)selectedCar.PricePerHour;

            lblAvailability.Text = $"Available: {selectedCar.Availability} — Est. cost: {estimatedCost:C} ({billableHours} hr) Return: {selectedReturnDate.Value:yyyy-MM-dd}";
        }

        private void btnConfirmRent_Click(object? sender, EventArgs e)
        {
            try
            {
                if (selectedCar == null)
                {
                    MessageBox.Show("No car selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!selectedCar.Availability)
                {
                    MessageBox.Show("This car is not available for rent.", "Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Validation
                string fullName = txtFullName.Text.Trim();
                string license = txtDriverLicense.Text.Trim();
                string address = txtAddress.Text.Trim();
                int age = (int)nudAge.Value;

                if (string.IsNullOrEmpty(fullName))
                {
                    MessageBox.Show("Full name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFullName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(license))
                {
                    MessageBox.Show("Driver's license is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDriverLicense.Focus();
                    return;
                }

                if (age < MinimumRentAge)
                {
                    MessageBox.Show($"Renter must be at least {MinimumRentAge} years old to rent a car.", "Age Requirement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudAge.Focus();
                    return;
                }

                if (selectedReturnDate == null || selectedReturnDate.Value.Date <= DateTime.Today)
                {
                    MessageBox.Show("Please select a valid return date (after today).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // All validations passed — mark car as rented
                selectedCar.Availability = false;

                // Optional: record renter info and rental period to a log or datastore here.
                MessageBox.Show($"Car {selectedCar.CarName} ({selectedCar.CarID}) has been rented to {fullName}.\nEstimated cost: {estimatedCost:C}", "Rented", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during rent: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
