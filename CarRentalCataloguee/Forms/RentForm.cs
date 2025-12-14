using CarRentalCataloguee.Forms.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalCataloguee.Forms
{
    public partial class RentForm : Form
    {
        private readonly List<Car>? cars;
        private readonly Car? selectedCar;
        private const int MinimumRentAge = 18;

        private DateTime? selectedReturnDate;
        private double estimatedCost;

        public RentForm()
        {
            InitializeComponent();
        }

        public RentForm(List<Car> cars) : this()
        {
            this.cars = cars;
        }

        public RentForm(List<Car> cars, Car selectedCar) : this(cars)
        {
            this.selectedCar = selectedCar;
            PopulateFields();
        }

        private void RentForm_Load(object sender, EventArgs e)
        {
        }

        private void PopulateFields()
        {
            if (selectedCar == null)
            {
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

            dtpBirthday.Value = DateTime.Today.AddYears(-MinimumRentAge);
            nudAge.Value = MinimumRentAge;

            dtpWhenToReturn.MinDate = DateTime.Today.AddDays(1);
            dtpWhenToReturn.Value = dtpWhenToReturn.MinDate;
            selectedReturnDate = dtpWhenToReturn.Value;

            btnConfirmRent.Enabled = selectedCar.Availability;

            UpdateReturnInfo();
        }

        private void dtpBirthday_ValueChanged(object? sender, EventArgs e)
        {
            var today = DateTime.Today;
            int age = today.Year - dtpBirthday.Value.Year;
            if (dtpBirthday.Value.Date > today.AddYears(-age)) age--;
            if (age < 0) age = 0;
            nudAge.Value = age <= nudAge.Maximum ? age : nudAge.Maximum;
        }

        private void dtpWhenToReturn_ValueChanged(object sender, EventArgs e)
        {
            if (dtpWhenToReturn.Value.Date <= DateTime.Today)
            {
                MessageBox.Show("Return date must be after today. Setting to tomorrow.", "Invalid Return Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpWhenToReturn.Value = dtpWhenToReturn.MinDate;
                return;
            }

            selectedReturnDate = dtpWhenToReturn.Value;
            UpdateReturnInfo();
        }

        private void UpdateReturnInfo()
        {
            if (selectedCar == null || selectedReturnDate == null)
                return;

            double hours = (selectedReturnDate.Value - DateTime.Now).TotalHours;
            if (hours < 1) hours = 1;

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

                selectedCar.Availability = false;

                try
                {
                    var allCars = cars ?? CarsRepository.LoadAll();
                    int idx = allCars.FindIndex(c => c.CarID == selectedCar.CarID);
                    if (idx >= 0) allCars[idx] = selectedCar;
                    else allCars.Add(selectedCar);

                    CarsRepository.SaveAll(allCars);
                }
                catch
                {

                }

                var rentalType = typeof(CarRentalCataloguee.Forms.Classes.Rental);
                var rentalObj = Activator.CreateInstance(rentalType);
                if (rentalObj != null)
                {
                    void SetIfExists(string propName, object? value)
                    {
                        var p = rentalType.GetProperty(propName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                        if (p == null || !p.CanWrite) return;
                        try
                        {
                            if (value != null && !p.PropertyType.IsAssignableFrom(value.GetType()))
                            {
                                var conv = Convert.ChangeType(value, p.PropertyType);
                                p.SetValue(rentalObj, conv);
                            }
                            else
                            {
                                p.SetValue(rentalObj, value);
                            }
                        }
                        catch
                        {

                        }
                    }

                    SetIfExists("CarId", selectedCar.CarID);
                    SetIfExists("RenterName", fullName);
                    SetIfExists("DriverLicense", license);
                    SetIfExists("RenterAddress", address);
                    SetIfExists("RenterBirthdate", dtpBirthday.Value);
                    SetIfExists("RentDate", DateTime.Now);
                    SetIfExists("ReturnDate", selectedReturnDate.Value);
                    SetIfExists("EstimatedCost", estimatedCost);

                    // If RentalId exists and is int, auto-increment it based on existing records
                    var idProp = rentalType.GetProperty("RentalId", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    if (idProp != null && idProp.CanWrite && idProp.PropertyType == typeof(int))
                    {
                        try
                        {
                            var existing = CarRentalCataloguee.Forms.Classes.RentalsRepository.LoadAll() ?? new List<CarRentalCataloguee.Forms.Classes.Rental>();
                            int maxId = 0;
                            foreach (var r in existing)
                            {
                                var v = idProp.GetValue(r);
                                if (v is int i && i > maxId) maxId = i;
                            }
                            idProp.SetValue(rentalObj, maxId + 1);
                        }
                        catch
                        {
                        }
                    }
                }

                try
                {
                    CarRentalCataloguee.Forms.Classes.RentalsRepository.AddRental((CarRentalCataloguee.Forms.Classes.Rental)rentalObj!);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Warning: rental was not saved to repository: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

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
