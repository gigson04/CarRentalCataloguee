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
        private readonly BindingSource bindingSource = new BindingSource();
        private readonly string dataFilePath;

        public VehicleForm()
        {
            InitializeComponent();

            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folder = Path.Combine(appData, "CarRentalCataloguee");
            Directory.CreateDirectory(folder);
            dataFilePath = Path.Combine(folder, "cars.json");


            dataGridView1.AutoGenerateColumns = true;


            bindingSource.DataSource = cars;
            dataGridView1.DataSource = bindingSource;

            LoadFromDisk();

            if (cars.Count == 0)
            {
                cars.Add(new Car { CarID = "C001", CarName = "Toyota Camry", Color = "Red", PricePerHour = 10.50m, Availability = true });
                cars.Add(new Car { CarID = "C002", CarName = "Honda Civic", Color = "Blue", PricePerHour = 12.00m, Availability = false });
                SaveToDisk();
            }


            LoadCarData();


            this.FormClosing += VehicleForm_FormClosing;
        }

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

            LoadCarData();

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
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Please select a car to rent.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dataGridView1.CurrentRow.DataBoundItem is not Car selectedCar)
                {
                    MessageBox.Show("Selected item is not a valid car.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (RentRequested != null)
                {
                    RentRequested.Invoke(this, new RentRequestedEventArgs(cars, selectedCar));
                    return;
                }

                using RentForm rentForm = new RentForm(cars, selectedCar);
                var result = rentForm.ShowDialog();

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

        private void btnEditCars_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Please select a car to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dataGridView1.CurrentRow.DataBoundItem is not Car selectedCar)
                {
                    MessageBox.Show("Selected item is not a valid car.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using EditForm editForm = new EditForm(selectedCar);
                var result = editForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadCarData();
                    SaveToDisk();
                    MessageBox.Show("Car updated successfully.", "Edit Car", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing car: {ex.Message}", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
         
            MessageBox.Show("Label clicked.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            System.Diagnostics.Debug.WriteLine("label1_Click fired at " + DateTime.Now.ToString("o"));
            

        }
    }
}