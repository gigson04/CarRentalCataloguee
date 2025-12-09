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
    public partial class VehicleForm : Form
    {
        private List<Car> cars = new List<Car>();

        public VehicleForm()
        {
            InitializeComponent();
            

            //LocalCarData();
        }

        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            // Add columns if not already in designer
            dataGridView1.Columns.Add("CarID", "Car ID");
            dataGridView1.Columns.Add("Color", "Color");
            dataGridView1.Columns.Add("PricePerHour", "Price per Hour");
            dataGridView1.Columns.Add("Availability", "Availability");
            // Make it read-only for display (edit via forms if needed)
            dataGridView1.ReadOnly = true;
        }

        private void LoadCarData()
        {
            // Bind the list to the DataGridView
            dataGridView1.DataSource = null;  // Clear binding
            dataGridView1.DataSource = new BindingList<Car>(cars);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the clicked row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Retrieve values from the row
                string carId = row.Cells["CarID"].Value?.ToString() ?? "N/A";
                string color = row.Cells["Color"].Value?.ToString() ?? "N/A";
                decimal pricePerHour = 0;
                if (decimal.TryParse(row.Cells["PricePerHour"].Value?.ToString(), out decimal parsedPrice))
                {
                    pricePerHour = parsedPrice;
                }
                bool availability = false;
                if (bool.TryParse(row.Cells["Availability"].Value?.ToString(), out bool parsedAvail))
                {
                    availability = parsedAvail;
                }

                // Example: Display the retrieved data in a message box
                MessageBox.Show($"Car ID: {carId}\nColor: {color}\nPrice per Hour: {pricePerHour:C}\nAvailable: {availability}",
                                "Car Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(cars);
            addForm.ShowDialog();
            LoadCarData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCarData();  // Correct method call
            MessageBox.Show("Data refreshed successfully.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
