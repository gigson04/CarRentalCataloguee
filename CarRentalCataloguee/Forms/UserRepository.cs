using SQLite;
namespace CarRentalCataloguee.Forms
{
    internal class UserRepository
    {
        private readonly SQLiteConnection _connection;

        public UserRepository()
        {
            string dataBasepath = Path.Combine(
                Environment.GetFolderPath
                (Environment.SpecialFolder.MyDocuments),
                "UserDatabaseCarRental");
            _connection = new SQLiteConnection(dataBasepath);
            _connection.CreateTable<UserModel>();
        }

    }
}
