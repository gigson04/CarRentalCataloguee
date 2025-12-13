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

            // Populate labels immediately and whenever the form becomes active
            UpdateDashboardLabels();
            this.Activated += (s, e) => UpdateDashboardLabels();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Available Cars - clicking will refresh the label
            UpdateDashboardLabels();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Users who rented cars - clicking will refresh the label
            UpdateDashboardLabels();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Cars Rented Out - clicking will refresh the label
            UpdateDashboardLabels();
        }

        // Updates the three labels with counts and short previews so the user does not
        // need to click the labels to see current info.
        private void UpdateDashboardLabels()
        {
            try
            {
                // Load cars (via repository)
                var cars = CarsRepository.LoadAll() ?? new List<Car>();
                int totalCars = cars.Count;
                int available = cars.Count(c => c.Availability);

                // Update label for available cars. Keep the label text concise.
                label2.Text = $"Available Cars: {available} / {totalCars}";

                // Load rentals (via repository)
                var rentals = RentalsRepository.LoadAll() ?? new List<Rental>();

                // Users who rented cars (distinct by name)
                var distinctUsers = rentals
                    .Select(r => r.RenterName ?? string.Empty)
                    .Where(n => !string.IsNullOrEmpty(n))
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .OrderBy(n => n)
                    .ToList();

                int userCount = distinctUsers.Count;
                // Show up to 3 user names as a short preview in the label
                string usersPreview = userCount == 0 ? "None" : string.Join(", ", distinctUsers.Take(3)) + (userCount > 3 ? $" (+{userCount - 3})" : "");
                label6.Text = $"Users who rented cars: {userCount} — {usersPreview}";

                // Cars currently rented out: rentals with ReturnDate in the future
                var now = DateTime.Now;
                var activeRentals = rentals
                    .Where(r => r.ReturnDate > now)
                    .ToList();

                int rentedOutCount = activeRentals.Count;
                // Short preview: show up to 3 CarId -> RenterName
                var previewLines = activeRentals
                    .Take(3)
                    .Select(r => $"{r.CarId ?? "<unknown>"}->{(r.RenterName ?? "<unknown>")}")
                    .ToArray();
                string activePreview = rentedOutCount == 0 ? "None" : string.Join(", ", previewLines) + (rentedOutCount > 3 ? $" (+{rentedOutCount - 3})" : "");
                label4.Text = $"Cars Rented Out: {rentedOutCount} — {activePreview}";
            }
            catch (Exception)
            {
                // Keep labels readable on error; don't throw exceptions from UI update.
                label2.Text = "Available Cars: —";
                label6.Text = "Users who rented cars: —";
                label4.Text = "Cars Rented Out: —";
            }
        }

        private void btnRefreshDashBoard_Click(object sender, EventArgs e)
        {
            // Refresh dashboard labels
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
