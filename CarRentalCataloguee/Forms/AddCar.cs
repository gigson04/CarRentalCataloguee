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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string carId = txtCarID.Text.Trim();
            string color = txtColor.Text.Trim();
            decimal pricePerHour = 0;
            bool availability = chkAvailability.Checked;
            // Validate inputs
            if (string.IsNullOrEmpty(carId))
            {
                MessageBox.Show("Please enter a Car ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // Add the new car to the shared list
            cars.Add(new Car
            {
                CarID = carId,
                Color = color,
                PricePerHour = pricePerHour,
                Availability = availability
            });

            txtCarID.Clear();
            txtColor.Clear();
            txtPricePerHour.Clear();
            chkAvailability.Checked = false;
            MessageBox.Show("Car added successfully.", "Add Car", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
