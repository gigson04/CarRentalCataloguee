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

            // Subscribe to repository notifications so grid updates automatically
            RentalsRepository.RentalsChanged += RentalsRepository_RentalsChanged;
        }

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

                if (dgvRentals.Columns["RentalId"] != null)
                    dgvRentals.Columns["RentalId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load rentals: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RentalsRepository_RentalsChanged(object? sender, EventArgs e)
        {
            // Ensure UI update on UI thread
            if (InvokeRequired)
            {
                BeginInvoke(new Action(LoadRentals));
                return;
            }
            LoadRentals();
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadRentals();
            MessageBox.Show("Rentals refreshed.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            RentalsRepository.RentalsChanged -= RentalsRepository_RentalsChanged;
            base.OnFormClosed(e);
        }

        private void dgvRentals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    // Ensure Rental model has full public properties used by repositories/forms
    namespace Classes
    {
        public class Rental
        {
            public string RentalId { get; set; } = Guid.NewGuid().ToString();
            public string? CarId { get; set; }
            public string? RenterName { get; set; }
            public string? DriverLicense { get; set; }
            public string? RenterAddress { get; set; }
            public DateTime RenterBirthdate { get; set; }
            public DateTime RentDate { get; set; }
            public DateTime ReturnDate { get; set; }
            public double EstimatedCost { get; set; }
        }
    }
}