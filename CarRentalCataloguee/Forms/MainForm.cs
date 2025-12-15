using CarRentalCataloguee.Forms; 
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
            vehicleForm = new VehicleForm();
            dashboardForm = new DashboardForm();
            rentForm = new RentForm();
            userForm = new UserForm();
            notificationForm = new NotificationForm();

            vehicleForm.RentRequested += VehicleForm_RentRequested;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AddFormToPanel(dashboardForm);
        }

        private void AddFormToPanel(Form form)
        {
            pnlMain.Controls.Clear();
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
                vehicleForm.RentRequested += VehicleForm_RentRequested;
            }
        }

        private void VehicleForm_RentRequested(object? sender, VehicleForm.RentRequestedEventArgs e)
        {
            var hostedRentForm = new RentForm(e.Cars, e.SelectedCar);
            AddFormToPanel(hostedRentForm);
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            EnsureVehicleForm();
            AddFormToPanel(vehicleForm);
        }

        private void btnMainForm_Click(object sender, EventArgs e)
        {
            AddFormToPanel(dashboardForm);
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to exit the application?",
                "Confirm Exit",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
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


        private void btnUser_Click(object sender, EventArgs e)
        {
            AddFormToPanel(new UserForm());
        }
        private void EnsureUserForm()
        {
            if (rentForm == null || rentForm.IsDisposed)
                rentForm = new RentForm();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
