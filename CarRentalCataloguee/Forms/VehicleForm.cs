using CarRentalCataloguee.Forms.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CarRentalCataloguee.Forms
{
    public partial class VehicleForm : Form
    {
        private List<Car> cars = new List<Car>();
        private BindingSource bindingSource = new BindingSource();  // New: For stable data binding

        public VehicleForm()
        {
            InitializeComponent();
            // Use ONLY auto-generated columns
            dataGridView1.AutoGenerateColumns = true;

            // Bind the BindingSource to the DataGridView once (don't change it later)
            bindingSource.DataSource = cars;
            dataGridView1.DataSource = bindingSource;

            // Updated sample data with CarName
            cars.Add(new Car { CarID = "C001", CarName = "Toyota Camry", Color = "Red", PricePerHour = 10.50m, Availability = true });
            cars.Add(new Car { CarID = "C002", CarName = "Honda Civic", Color = "Blue", PricePerHour = 12.00m, Availability = false });

            // No need to call LoadCarData here anymore; binding is set
        }

        private void LoadCarData()
        {
            // Reset the BindingSource's data source to refresh the grid
            bindingSource.DataSource = null;
            bindingSource.DataSource = cars;
            dataGridView1.Refresh();  // Force UI refresh

            // Debug: Show count to verify
            MessageBox.Show($"Loaded {cars.Count} cars.", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Updated to include CarName
                MessageBox.Show(
                    $"Car ID: {row.Cells["CarID"].Value}\n" +
                    $"Car Name: {row.Cells["CarName"].Value}\n" +  // New: Display CarName
                    $"Color: {row.Cells["Color"].Value}\n" +
                    $"Price per Hour: {row.Cells["PricePerHour"].Value}\n" +
                    $"Available: {row.Cells["Availability"].Value}",
                    "Car Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(cars);
            addForm.ShowDialog();

            // Refresh the grid after adding
            LoadCarData();

            // Debug: Confirm addition
            MessageBox.Show($"After adding, cars count: {cars.Count}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCarData();
            MessageBox.Show("Data refreshed successfully.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}