public class Rental
{
    public int RentalId { get; set; }
    // Add this property to fix CS1061
    public DateTime ReturnDate { get; set; }
}
