using CarRentalCataloguee.Forms;  // Assuming this is correct for your project
using System;
using System.Drawing;
using System.Windows.Forms;
using CarRentalCataloguee.Forms.Classes;

namespace CarRentalCataloguee
{
    public partial class MainForm : Form
    {
        VehicleForm vehicleForm;
        DashboardForm dashboardForm;
        RentForm rentForm;
        UserForm userForm;
        NotificationForm notificationForm;

        public MainForm()
        {
            InitializeComponent();
            // Only create child forms here — do NOT create another DashBoard instance.
            vehicleForm = new VehicleForm();
            dashboardForm = new DashboardForm();
            rentForm = new RentForm();
            userForm = new UserForm();
            notificationForm = new NotificationForm();

            // Subscribe to VehicleForm's RentRequested so the main form can host the RentForm
            vehicleForm.RentRequested += VehicleForm_RentRequested;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Show a simple home/dashboard view on startup
            AddFormToPanel(dashboardForm);
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
            {
                vehicleForm = new VehicleForm();
                vehicleForm.RentRequested += VehicleForm_RentRequested; // re-subscribe when new instance is created
            }
        }

        private void VehicleForm_RentRequested(object? sender, VehicleForm.RentRequestedEventArgs e)
        {
            // Create rent form with the same list and selected car and add it into the main panel
            var hostedRentForm = new RentForm(e.Cars, e.SelectedCar);
            AddFormToPanel(hostedRentForm);
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            EnsureVehicleForm();
            AddFormToPanel(vehicleForm);
        }

        // Add this event handler for btnDashBoard (assuming you add the button in the designer)
        private void btnMainForm_Click(object sender, EventArgs e)
        {
            // Reload the home/dashboard view in the panel
            AddFormToPanel(dashboardForm);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // This seems unused—consider removing if not needed.
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

        private void EnsureRentForm()
        {
            if (rentForm == null || rentForm.IsDisposed)
                rentForm = new RentForm();
        }
        private void btnRentCar_Click(object sender, EventArgs e)
        {
            EnsureRentForm();
            AddFormToPanel(rentForm);
        }

        private void EnsureUserForm()
        {
            if (rentForm == null || rentForm.IsDisposed)
                rentForm = new RentForm();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            AddFormToPanel(new UserForm());
        }

        private void EnsureNotificationForm()
        {
            if (rentForm == null || rentForm.IsDisposed)
                rentForm = new RentForm();
        }
        private void btnNotification_Click(object sender, EventArgs e)
        {
            AddFormToPanel(new NotificationForm());
        }
    }
}
