using CarRentalCataloguee.Forms.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CarRentalCataloguee.Forms
{
    public partial class UserForm : Form
    {
        private BindingList<Rental>? rentalsBindingList;

        public UserForm()
        {
            InitializeComponent();
        }

        // Use standard event signature so the designer can wire this reliably.
        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadRentals();
        }

        private void LoadRentals()
        {
            try
            {
                var rentals = RentalsRepository.LoadAll();
                rentalsBindingList = new BindingList<Rental>(rentals);

                if (dgvRentals == null)
                {
                    MessageBox.Show("Rentals grid is not available.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dgvRentals.DataSource = rentalsBindingList;

                // Optional: hide internal fields
                if (dgvRentals.Columns["RentalId"] != null)
                    dgvRentals.Columns["RentalId"].Visible = false;

                if (dgvRentals.Columns["Address"] != null)
                    dgvRentals.Columns["Address"].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load rentals: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadRentals();
            MessageBox.Show("Rentals refreshed.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnMarkReturned_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvRentals == null || dgvRentals.CurrentRow == null)
                {
                    MessageBox.Show("Please select a rental to mark returned.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dgvRentals.CurrentRow.DataBoundItem is not Rental rental)
                {
                    MessageBox.Show("Selected item is not a rental.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (rental.Returned)
                {
                    MessageBox.Show("This rental is already marked returned.", "Already Returned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var confirm = MessageBox.Show($"Mark rental of {rental.CarName} by {rental.RenterName} as returned?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;

                // Mark rental returned
                rental.Returned = true;
                rental.ReturnDate = DateTime.Now; // update actual return timestamp

                // Persist rentals
                var list = rentalsBindingList?.ToList() ?? new List<Rental>();
                RentalsRepository.SaveAll(list);

                // Update car availability
                var cars = CarsRepository.LoadAll();
                var car = cars.FirstOrDefault(c => c.CarID == rental.CarID);
                if (car != null)
                {
                    car.Availability = true;
                    CarsRepository.SaveAll(cars);
                }

                // Refresh UI
                dgvRentals.Refresh();
                MessageBox.Show("Rental marked returned and car availability restored.", "Returned", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to mark returned: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}