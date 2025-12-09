using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalCataloguee.Forms.Classes
{
    public class Car
    {
        public string CarID { get; set; }
        public string Color { get; set; }
        public decimal PricePerHour { get; set; }
        public bool Availability { get; set; }
    }
}
