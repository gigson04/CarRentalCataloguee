using CarRentalCataloguee.Forms;
using System;
using System.Windows.Forms;

namespace CarRentalCataloguee
{
    public partial class DashBoard : Form
    {
        private VehicleForm vehicleForm;

        public DashBoard()
        {
            InitializeComponent();
            // Do NOT create a new DashBoard here — that causes infinite recursion/StackOverflow.
            vehicleForm = new VehicleForm();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            // Show vehicle form (or another child) inside the panel on load
            AddFormToPanel(vehicleForm);
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

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            AddFormToPanel(vehicleForm);
        }
    }
}
