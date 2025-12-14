using SQLite;
using System;

namespace CarRentalCataloguee.Forms.Classes
{
    public class Rental
    {
        [PrimaryKey]
        public string RentalId { get; set; } = Guid.NewGuid().ToString();

        public string? CarId { get; set; }
        public string? RenterName { get; set; }
        public string? DriverLicense { get; set; }
        public string? RenterAddress { get; set; }
        public DateTime RenterBirthdate { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double EstimatedCost { get; set; }
    }
}