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
        public bool Add(string username, string password, string email, string name, int age)//bday missing
        {
            UserModel userModel = new UserModel()
            {
                UserName = username,
                Password = password,
                Email = email,
                Age = age,
                Name = name,
                Birthday = DateTime.Now // Placeholder for birthday
            };

            _connection.Insert(userModel);

            return true;

        }
        public List<UserModel> GetAllUsers()
        {
            return _connection.Table<UserModel>().ToList();
        }

    }
}
