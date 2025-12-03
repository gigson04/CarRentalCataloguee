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
            // Create a simple runtime sign-up dialog so user can create a local account.
            using var form = new Form()
            {
                Text = "Sign Up",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                ClientSize = new System.Drawing.Size(360, 220),
                MinimizeBox = false,
                MaximizeBox = false
            };

            var lblUser = new Label() { Text = "Username", Left = 12, Top = 16, AutoSize = true };
            var txtNewUser = new TextBox() { Left = 12, Top = 36, Width = 320, Font = txtUserName.Font };

            var lblPass = new Label() { Text = "Password", Left = 12, Top = 72, AutoSize = true };
            var txtNewPass = new TextBox() { Left = 12, Top = 92, Width = 320, UseSystemPasswordChar = true, Font = txtPassword.Font };

            var lblConfirm = new Label() { Text = "Confirm Password", Left = 12, Top = 128, AutoSize = true };
            var txtConfirm = new TextBox() { Left = 12, Top = 148, Width = 320, UseSystemPasswordChar = true, Font = txtPassword.Font };

            var btnCreate = new Button() { Text = "Create", Left = 170, Width = 75, Top = 180, DialogResult = DialogResult.None };
            var btnCancel = new Button() { Text = "Cancel", Left = 255, Width = 75, Top = 180, DialogResult = DialogResult.Cancel };

            form.Controls.AddRange(new Control[] { lblUser, txtNewUser, lblPass, txtNewPass, lblConfirm, txtConfirm, btnCreate, btnCancel });
            form.AcceptButton = btnCreate;
            form.CancelButton = btnCancel;

            btnCreate.Click += (s, ea) =>
            {
                var newUser = txtNewUser.Text.Trim();
                var newPass = txtNewPass.Text;
                var confirm = txtConfirm.Text;

                // Reuse validation rules
                if (string.IsNullOrWhiteSpace(newUser) || newUser.Length < 3 || newUser.Length > 20 || !Regex.IsMatch(newUser, @"^[a-zA-Z0-9_]+$"))
                {
                    MessageBox.Show("Username must be 3-20 characters and contain only letters, numbers, and underscores.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(newPass) || newPass.Length < 8 || !Regex.IsMatch(newPass, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"))
                {
                    MessageBox.Show("Password must be at least 8 characters and include lower, upper, and a digit.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (newPass != confirm)
                {
                    MessageBox.Show("Passwords do not match.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Save user
                try
                {
                    var users = LoadUsers();
                    if (users.Any(u => string.Equals(u.UserName, newUser, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("Username already exists.", "Sign-up Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    users.Add(new UserRecord(newUser, ComputeHash(newPass)));
                    SaveUsers(users);
                    MessageBox.Show("Account created successfully. You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not create account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            form.ShowDialog(this);
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
            const string builtInPassword = "Admin123!";
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
