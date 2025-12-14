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
        private BindingList<RentalGridItem>? rentalsBindingList;

        private Rental? selectedRental;

        public UserForm()
        {
            InitializeComponent();

            if (dgvRentals != null)
                dgvRentals.AutoGenerateColumns = true;

            RentalsRepository.RentalsChanged += RentalsRepository_RentalsChanged;

            this.Load += UserForm_Load;
        }

        private void UserForm_Load(object? sender, EventArgs e)
        {
            LoadRentals();
        }

        private void LoadRentals()
        {
            try
            {
                var rentals = RentalsRepository.LoadAll() ?? new List<Rental>();
                var cars = CarsRepository.LoadAll() ?? new List<Car>();

                var items = rentals.Select(r =>
                {
                    var car = cars.FirstOrDefault(c => string.Equals(c.CarID, r.CarId, StringComparison.OrdinalIgnoreCase));
                    return new RentalGridItem
                    {
                        RentalId = r.RentalId,
                        CarId = r.CarId,
                        CarName = car?.CarName,
                        CarColor = car?.Color,
                        RenterName = r.RenterName,
                        DriverLicense = r.DriverLicense,
                        RenterAddress = r.RenterAddress,
                        RentDate = r.RentDate,
                        ReturnDate = r.ReturnDate,
                        EstimatedCost = r.EstimatedCost
                    };
                }).ToList();

                rentalsBindingList = new BindingList<RentalGridItem>(items);

                if (dgvRentals == null)
                {
                    MessageBox.Show("Rentals grid is not available.", "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dgvRentals.DataSource = rentalsBindingList;
                dgvRentals.Refresh();
                dgvRentals.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

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

        private void dgvRentals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                var row = dgvRentals.Rows[e.RowIndex];
                if (row.DataBoundItem is not RentalGridItem gridItem)
                {
                    MessageBox.Show("Selected row does not contain a valid rental.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedRental = RentalsRepository.LoadAll()
                    .FirstOrDefault(r => string.Equals(r.RentalId, gridItem.RentalId, StringComparison.OrdinalIgnoreCase));

                string summary =
                    $"Rental ID: {gridItem.RentalId}\n" +
                    $"Car ID: {gridItem.CarId ?? "<unknown>"}\n" +
                    $"Car Name: {gridItem.CarName ?? "<unknown>"}\n" +
                    $"Car Color: {gridItem.CarColor ?? "<unknown>"}\n" +
                    $"Renter Name: {gridItem.RenterName ?? "<unknown>"}\n" +
                    $"Driver License: {gridItem.DriverLicense ?? "<unknown>"}\n" +
                    $"Address: {gridItem.RenterAddress ?? "<unknown>"}\n" +
                    $"Return Date: {gridItem.ReturnDate:yyyy-MM-dd}";

                Clipboard.SetText(summary);
                MessageBox.Show("Rental selected and details copied to clipboard.", "Rental Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to store selected rental: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RentalsRepository_RentalsChanged(object? sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(LoadRentals));
                return;
            }
            LoadRentals();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            RentalsRepository.RentalsChanged -= RentalsRepository_RentalsChanged;
            base.OnFormClosed(e);
        }

        private class RentalGridItem
        {
            public string RentalId { get; set; } = string.Empty;
            public string? CarId { get; set; }
            public string? CarName { get; set; }
            public string? CarColor { get; set; }
            public string? RenterName { get; set; }
            public string? DriverLicense { get; set; }
            public string? RenterAddress { get; set; }
            public DateTime RentDate { get; set; }
            public DateTime ReturnDate { get; set; }
            public double EstimatedCost { get; set; }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (selectedRental == null)
            {
                MessageBox.Show("Please select a rental to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    RentalsRepository.DeleteRental(selectedRental.RentalId);
                    MessageBox.Show("Rental removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedRental = null;
                    LoadRentals();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to remove rental: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
