using SQLite;
namespace CarRentalCataloguee
{
    internal class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
    }

}
