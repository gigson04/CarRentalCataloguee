using CarRentalCataloguee.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarRentalCataloguee
{
    public partial class DashBoard : Form
    {
        private VehicleForm vehicleForm;

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
            home.BackColor = pnlMain.BackColor;
            return home;
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
    }
}
