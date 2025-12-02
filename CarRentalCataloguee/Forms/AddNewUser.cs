using CarRentalCataloguee.Forms;
namespace CarRentalCataloguee
{
    public partial class AddNewUser : Form
    {
        public AddNewUser()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string email = txtName.Text;
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string name = txtName.Text;
            int age = Convert.ToInt32(txtAge.Text);
            DateTime birthaday = mnthBirthDay.MaxDate;//dont know how to get date time picker value

            int maxAgeValue = 120;
            int minAgeValue = 18;

            bool isIvalidnput = string.IsNullOrWhiteSpace(email)
                || string.IsNullOrWhiteSpace(username)
                    || string.IsNullOrWhiteSpace(password)
                        || string.IsNullOrEmpty(name)
                            || age == maxAgeValue|| age == minAgeValue;

            if (isIvalidnput)
            {
                MessageBox.Show("All fields are required",
                    "Validation Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                UserRepository repository = new UserRepository();
                bool isUserAdded = repository.Add(username, password, email, name, age);

                if (isUserAdded)
                {
                    MessageBox.Show($"User {username} created successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create user",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
