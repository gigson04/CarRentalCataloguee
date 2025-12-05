using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions; // For regex validation
using System.Windows.Forms;

namespace CarRentalCataloguee
{
    public partial class LogInForm : Form
    {
        private readonly string _usersFilePath;
        private readonly string _rememberFilePath;

        public LogInForm()
        {
            InitializeComponent();

            _usersFilePath = Path.Combine(Application.LocalUserAppDataPath, "users.json");
            _rememberFilePath = Path.Combine(Application.LocalUserAppDataPath, "remembered_user.txt");

            // Mask password by default
            txtPassword.UseSystemPasswordChar = true;

            // Restore remembered username if present
            var remembered = LoadRememberedUser();
            if (!string.IsNullOrEmpty(remembered))
            {
                txtUserName.Text = remembered;
                checkBox1.Checked = true;
            }

            // Initialize button state
            btnLogin.Enabled = !string.IsNullOrWhiteSpace(txtUserName.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrWhiteSpace(txtUserName.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrWhiteSpace(txtUserName.Text) && !string.IsNullOrWhiteSpace(txtPassword.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // "Keep me Sign-in" -> remember username locally (not password)
            try
            {
                if (checkBox1.Checked)
                {
                    SaveRememberedUser(txtUserName.Text.Trim());
                }
                else
                {
                    DeleteRememberedUser();
                }
            }
            catch
            {
                // swallow storage errors; not critical for login
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text;

            // Basic validation
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Username cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Authenticate
            try
            {
                if (Authenticate(userName, password))
                {
                    // Persist remembered username if checkbox is checked
                    if (checkBox1.Checked)
                        SaveRememberedUser(userName);
                    else
                        DeleteRememberedUser();

                    // Signal success to caller
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Authentication error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            using var addForm = new AddNewUser();
            var result = addForm.ShowDialog(this);
            if (result == DialogResult.OK && !string.IsNullOrEmpty(addForm.CreatedUserName))
            {
                // Prefill the created username so the user can enter password and login
                txtUserName.Text = addForm.CreatedUserName;
                txtPassword.Text = string.Empty;
                txtPassword.Focus();
                MessageBox.Show("Account created. Please enter your password to log in.", "Sign-up Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- Helpers: authentication, persistence ---

        private bool Authenticate(string userName, string password)
        {
            var hash = ComputeHash(password);

            var users = LoadUsers();

            if (users.Any(u => string.Equals(u.UserName, userName, StringComparison.OrdinalIgnoreCase) &&
                               string.Equals(u.PasswordHash, hash, StringComparison.Ordinal)))
            {
                return true;
            }

            // Fallback built-in account for first-run convenience
            const string builtInUser = "admin";
            const string builtInPassword = "1234";
            if (string.Equals(userName, builtInUser, StringComparison.OrdinalIgnoreCase)
                && string.Equals(hash, ComputeHash(builtInPassword), StringComparison.Ordinal))
            {
                return true;
            }

            return false;
        }

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

        private void SaveRememberedUser(string userName)
        {
            try
            {
                var dir = Path.GetDirectoryName(_rememberFilePath);
                if (!string.IsNullOrEmpty(dir))
                    Directory.CreateDirectory(dir);

                File.WriteAllText(_rememberFilePath, userName ?? string.Empty, Encoding.UTF8);
            }
            catch { }
        }

        private string? LoadRememberedUser()
        {
            try
            {
                if (File.Exists(_rememberFilePath))
                    return File.ReadAllText(_rememberFilePath, Encoding.UTF8).Trim();
            }
            catch { }
            return null;
        }

        private void DeleteRememberedUser()
        {
            try
            {
                if (File.Exists(_rememberFilePath))
                    File.Delete(_rememberFilePath);
            }
            catch { }
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
