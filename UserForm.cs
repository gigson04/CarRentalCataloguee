csharp CarRentalCataloguee\Forms\UserForm.cs
using CarRentalCataloguee.Forms.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    }
}