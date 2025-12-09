using CarRentalCataloguee.Forms.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalCataloguee.Forms
{
    public partial class AddForm : Form
    {
        private List<Car> cars;

        public AddForm(List<Car> sharedCars)
        {
            InitializeComponent();
            cars = sharedCars;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Retrieve inputs, including new CarName
                string carId = txtCarID.Text.Trim();
                string carName = txtCarName.Text.Trim();  // New: Get CarName
                string color = txtColor.Text.Trim();
                decimal pricePerHour = 0;
                bool availability = chkAvailability.Checked;

                // Validation (add for CarName if required)
                if (string.IsNullOrEmpty(carId))
                {
                    MessageBox.Show("Please enter a Car ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(carName))  // Optional: Make it required
                {
                    MessageBox.Show("Please enter a Car Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(color))
                {
                    MessageBox.Show("Please enter a Color.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtPricePerHour.Text.Trim(), out pricePerHour) || pricePerHour <= 0)
                {
                    MessageBox.Show("Please enter a valid Price per Hour (positive number).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Add the new car with CarName
                cars.Add(new Car
                {
                    CarID = carId,
                    CarName = carName,  // New: Include CarName
                    Color = color,
                    PricePerHour = pricePerHour,
                    Availability = availability
                });

                // Clear fields, including new one
                txtCarID.Clear();
                txtCarName.Clear();  // New: Clear CarName
                txtColor.Clear();
                txtPricePerHour.Clear();
                chkAvailability.Checked = false;
                MessageBox.Show("Car added successfully.", "Add Car", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}