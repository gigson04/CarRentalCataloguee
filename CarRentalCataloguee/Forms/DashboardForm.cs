using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalCataloguee.Forms.Classes;

namespace CarRentalCataloguee.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();

            UpdateDashboardLabels();
            this.Activated += (s, e) => UpdateDashboardLabels();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            UpdateDashboardLabels();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            UpdateDashboardLabels();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UpdateDashboardLabels();
        }

        private void UpdateDashboardLabels()
        {
            try
            {
                var cars = CarsRepository.LoadAll() ?? new List<Car>();
                int totalCars = cars.Count;
                int available = cars.Count(c => c.Availability);

                label2.Text = $"Available Cars: {available} / {totalCars}";

                var rentals = RentalsRepository.LoadAll() ?? new List<Rental>();

                var distinctUsers = rentals
                    .Select(r => r.RenterName ?? string.Empty)
                    .Where(n => !string.IsNullOrEmpty(n))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(n => n)
                    .ToList();

                int userCount = distinctUsers.Count;
                string usersPreview = userCount == 0 ? "None" : string.Join(", ", distinctUsers.Take(3)) + (userCount > 3 ? $" (+{userCount - 3})" : "");
                label6.Text = $"Users who rented cars: {userCount} — {usersPreview}";

                var now = DateTime.Now;
                var activeRentals = rentals
                    .Where(r => r.ReturnDate > now)
                    .ToList();

                int rentedOutCount = activeRentals.Count;
                var previewLines = activeRentals
                    .Take(3)
                    .Select(r => $"{r.CarId ?? "<unknown>"}->{(r.RenterName ?? "<unknown>")}")
                    .ToArray();
                string activePreview = rentedOutCount == 0 ? "None" : string.Join(", ", previewLines) + (rentedOutCount > 3 ? $" (+{rentedOutCount - 3})" : "");
                label4.Text = $"Cars Rented Out: {rentedOutCount} — {activePreview}";
            }
            catch (Exception)
            {
                label2.Text = "Available Cars: —";
                label6.Text = "Users who rented cars: —";
                label4.Text = "Cars Rented Out: —";
            }
        }

        private void btnRefreshDashBoard_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateDashboardLabels();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to refresh dashboard: {ex.Message}", "Refresh Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
