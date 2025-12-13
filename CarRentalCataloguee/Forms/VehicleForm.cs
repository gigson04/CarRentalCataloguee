using CarRentalCataloguee.Forms.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace CarRentalCataloguee.Forms
{
    public partial class VehicleForm : Form
    {
        // Event raised when the user requests to rent a selected car.
        // MainForm will subscribe and show the RentForm inside the main panel.
        public event EventHandler<RentRequestedEventArgs>? RentRequested;

        private readonly List<Car> cars = new List<Car>();
        private readonly BindingSource bindingSource = new BindingSource();  // For stable data binding
        private readonly string dataFilePath;

        public VehicleForm()
        {
            InitializeComponent();

            // Prepare data file path: %AppData%\CarRentalCataloguee\cars.json
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appData, "CarRentalCataloguee");
            Directory.CreateDirectory(folder);
            dataFilePath = Path.Combine(folder, "cars.json");

            // Use ONLY auto-generated columns
            dataGridView1.AutoGenerateColumns = true;

            // Bind the BindingSource to the DataGridView once (don't change it later)
            bindingSource.DataSource = cars;
            dataGridView1.DataSource = bindingSource;

            // Load persisted data (if any). If none, seed sample data and persist it.
            LoadFromDisk();

            if (cars.Count == 0)
            {
                // Seed sample data
                cars.Add(new Car { CarID = "C001", CarName = "Toyota Camry", Color = "Red", PricePerHour = 10.50m, Availability = true });
                cars.Add(new Car { CarID = "C002", CarName = "Honda Civic", Color = "Blue", PricePerHour = 12.00m, Availability = false });
                SaveToDisk();
            }

            // Ensure UI shows current data
            LoadCarData();

            // Save on close to guarantee persistence
            this.FormClosing += VehicleForm_FormClosing;
        }

        // EventArgs type for RentRequested (public so MainForm can reference it)
        public class RentRequestedEventArgs : EventArgs
        {
            public List<Car> Cars { get; }
            public Car SelectedCar { get; }

            public RentRequestedEventArgs(List<Car> cars, Car selectedCar)
            {
                Cars = cars;
                SelectedCar = selectedCar;
            }
        }

        private void LoadFromDisk()
        {
            try
            {
                if (File.Exists(dataFilePath))
                {
                    string json = File.ReadAllText(dataFilePath);
                    var loaded = JsonSerializer.Deserialize<List<Car>>(json);
                    if (loaded != null)
                    {
                        cars.Clear();
                        cars.AddRange(loaded);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load saved cars: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveToDisk()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(cars, options);
                File.WriteAllText(dataFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save cars: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCarData()
        {
            // Refresh binding without replacing the list instance
            bindingSource.ResetBindings(false);
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                MessageBox.Show(
                    $"Car ID: {row.Cells["CarID"].Value}\n" +
                    $"Car Name: {row.Cells["CarName"].Value}\n" +
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

            // Persist changes
            SaveToDisk();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCarData();
            MessageBox.Show("Data refreshed successfully.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRentCar_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure a row is selected
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Please select a car to rent.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Get the selected Car from the DataGridView binding
                if (dataGridView1.CurrentRow.DataBoundItem is not Car selectedCar)
                {
                    MessageBox.Show("Selected item is not a valid car.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If somebody is subscribed (MainForm), raise the event so the main form can host the RentForm
                if (RentRequested != null)
                {
                    RentRequested.Invoke(this, new RentRequestedEventArgs(cars, selectedCar));
                    return;
                }

                // Fallback: show RentForm as dialog (existing behavior if no subscriber)
                using RentForm rentForm = new RentForm(cars, selectedCar);
                var result = rentForm.ShowDialog();

                // If rent succeeded, refresh and persist changes
                if (result == DialogResult.OK)
                {
                    LoadCarData();
                    SaveToDisk();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "RentForm Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void VehicleForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            SaveToDisk();
        }
    }
}