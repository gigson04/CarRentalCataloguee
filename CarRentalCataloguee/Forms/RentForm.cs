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
    public partial class RentForm : Form
    {
       
        public RentForm()
        {
            InitializeComponent();
           
        }

        public RentForm(List<Car> cars)
        {
        }

        private void RentForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
