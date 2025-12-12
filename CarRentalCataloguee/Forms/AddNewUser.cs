using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CarRentalCataloguee
{
    public partial class AddNewUser : Form
    {
        private readonly string _usersFilePath;
        public string? CreatedUserName { get; private set; }

        public AddNewUser()
        {
            InitializeComponent();

            _usersFilePath = Path.Combine(Application.LocalUserAppDataPath, "users.json");

            // Wire up events
            btnCreateAccount.Click += BtnCreateAccount_Click;
            btnClose.Click += BtnClose_Click;

            // Mask password
            txtPassword.UseSystemPasswordChar = true;
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCreateAccount_Click(object? sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            var ageText = txtAge.Text.Trim();
            var email = txtEmail.Text.Trim();
            var username = txtUserName.Text.Trim();
            var password = txtPassword.Text;

            // Basic validation
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name is required.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(ageText, out var age) || age <= 0 || age > 120)
            {
                MessageBox.Show("Please enter a valid age.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(username) || username.Length < 3 || username.Length > 20 || !Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Username must be 3-20 characters and contain only letters, numbers, and underscores.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 8 || !Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
            {
                MessageBox.Show("Password must be at least 8 characters and include lower, upper, and a digit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var users = LoadUsers();

                if (users.Any(u => string.Equals(u.UserName, username, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Username already exists.", "Sign-up Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                users.Add(new UserRecord(username, ComputeHash(password)));
                SaveUsers(users);

                CreatedUserName = username;
                MessageBox.Show("Account created successfully. You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not create account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // maka pa bagtit
        private List<UserRecord> LoadUsers()
        {
            try
            {
                if (!File.Exists(_usersFilePath))
                    return new List<UserRecord>();

                var json = File.ReadAllText(_usersFilePath, Encoding.UTF8);
                var users = JsonSerializer.Deserialize<List<UserRecord>>(json);
                return users ?? new List<UserRecord>();
            }
            catch
            {
                return new List<UserRecord>();
            }
        }

        private void SaveUsers(List<UserRecord> users)
        {
            var dir = Path.GetDirectoryName(_usersFilePath);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_usersFilePath, json, Encoding.UTF8);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = SHA256.HashData(bytes);
            return Convert.ToBase64String(hash);
        }

        private record UserRecord(string UserName, string PasswordHash);
    }
}
