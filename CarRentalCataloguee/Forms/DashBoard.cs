using CarRentalCataloguee.Forms;  // Assuming this is correct for your project
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalCataloguee
{
    public partial class DashBoard : Form
    {
        VehicleForm vehicleForm;
        DashBoard dashBoardForm;  // Note: This is declared but never used—consider removing if not needed.

        public DashBoard()
        {
            InitializeComponent();
            // Only create child forms here — do NOT create another DashBoard instance.

            vehicleForm = new VehicleForm();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            // Show a simple home/dashboard view on startup
            AddFormToPanel(CreateHomeForm());
        }

        private Form CreateHomeForm()
        {
            // Create a lightweight Form to act as the dashboard home content
            var home = new Form();
            

            // Add some basic content to the home form (so it's not blank)
            // This prevents the dashboard from looking empty on startup
            
            welcomeLabel.Text = "Welcome to the Car Rental Catalogue Dashboard!";
            welcomeLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            welcomeLabel.Location = new Point(20, 20);  // Position it nicely
            welcomeLabel.AutoSize = true;
            home.Controls.Add(welcomeLabel);

            // You can add more controls here, like buttons or images, for a richer home view
            // Example: Add a button to navigate to vehicles
            // var quickButton = new Button { Text = "Quick View Vehicles", Location = new Point(20, 60) };
            // quickButton.Click += (s, e) => btnVehicles_Click(s, e);  // Reuse existing handler
            // home.Controls.Add(quickButton);

            return home;
        }

        private void AddFormToPanel(Form form)
        {
            pnlMain.Controls.Clear();  // This clears any existing controls in pnlMain (including misplaced buttons/labels)
            form.TopLevel = false;
            form.AutoScroll = true;
            pnlMain.Controls.Add(form);
            pnlMain.AutoScroll = true;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Show();
        }

        private void EnsureVehicleForm()
        {
            if (vehicleForm == null || vehicleForm.IsDisposed)
                vehicleForm = new VehicleForm();
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            EnsureVehicleForm();
            AddFormToPanel(vehicleForm);
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            AddFormToPanel(CreateHomeForm());
        }

        private void label2_Click(object sender, EventArgs e)
        {
           

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            // Confirm with the user before exiting the application
            var result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                // Close the application cleanly
                Application.Exit();
            }
        }
    }
}
