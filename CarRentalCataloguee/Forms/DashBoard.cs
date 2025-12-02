using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalCataloguee
{
    public partial class DashBoard : Form
    {
        AddNewUser newUserForm;
       // VehiclesForm vehiclesForm;
        public DashBoard()
        {
            InitializeComponent();
            newUserForm = new AddNewUser();
          //  vehiclesForm = new VehiclesForm();

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            AddFormToPanel(newUserForm);
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
           // AddFormToPanel(vehiclesForm);
        }
    }
}
