using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CarRentalCataloguee.Forms.Classes;

namespace CarRentalCataloguee.Forms
{
    public class EditForm : Form
    {
        private readonly Car car;

        private TextBox txtCarID;
        private TextBox txtCarName;
        private TextBox txtColor;
        private TextBox txtPricePerHour;
        private CheckBox chkAvailability;
        private Button btnSave;
        private Button btnCancel;

        public EditForm(Car carToEdit)
        {
            car = carToEdit ?? throw new ArgumentNullException(nameof(carToEdit));
            InitializeComponent();
            PopulateFields();
        }

        private void InitializeComponent()
        {
            this.Text = "Edit Car";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(360, 220);
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblId = new Label { Text = "Car ID:", AutoSize = true, Location = new Point(12, 18) };
            txtCarID = new TextBox { Location = new Point(120, 14), Width = 210, ReadOnly = true };

            Label lblName = new Label { Text = "Car Name:", AutoSize = true, Location = new Point(12, 50) };
            txtCarName = new TextBox { Location = new Point(120, 46), Width = 210 };

            Label lblColor = new Label { Text = "Color:", AutoSize = true, Location = new Point(12, 82) };
            txtColor = new TextBox { Location = new Point(120, 78), Width = 210 };

            Label lblPrice = new Label { Text = "Price per Hour:", AutoSize = true, Location = new Point(12, 114) };
            txtPricePerHour = new TextBox { Location = new Point(120, 110), Width = 210 };

            chkAvailability = new CheckBox { Text = "Available", Location = new Point(120, 142), AutoSize = true };

            btnSave = new Button { Text = "Save", Location = new Point(170, 170), Width = 75 };
            btnCancel = new Button { Text = "Cancel", Location = new Point(255, 170), Width = 75 };

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.AddRange(new Control[] { lblId, txtCarID, lblName, txtCarName, lblColor, txtColor, lblPrice, txtPricePerHour, chkAvailability, btnSave, btnCancel });

            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
        }

        private void PopulateFields()
        {
            txtCarID.Text = car.CarID ?? string.Empty;
            txtCarName.Text = car.CarName ?? string.Empty;
            txtColor.Text = car.Color ?? string.Empty;
            txtPricePerHour.Text = car.PricePerHour.ToString(CultureInfo.InvariantCulture);
            chkAvailability.Checked = car.Availability;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                string name = txtCarName.Text.Trim();
                string color = txtColor.Text.Trim();
                string priceText = txtPricePerHour.Text.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please enter a Car Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCarName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(color))
                {
                    MessageBox.Show("Please enter a Color.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtColor.Focus();
                    return;
                }

                if (!decimal.TryParse(priceText, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price) || price < 0m)
                {
                    MessageBox.Show("Please enter a valid non-negative Price per Hour.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPricePerHour.Focus();
                    return;
                }

                // Apply changes to the shared car object
                car.CarName = name;
                car.Color = color;
                car.PricePerHour = price;
                car.Availability = chkAvailability.Checked;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save changes: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}