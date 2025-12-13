namespace CarRentalCataloguee.Forms
{
    partial class RentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblTitle = new Label();
            lblCarId = new Label();
            lblCarName = new Label();
            lblColor = new Label();
            lblPrice = new Label();
            lblAvailability = new Label();
            groupBoxRenter = new GroupBox();
            label1 = new Label();
            dtpWhenToReturn = new DateTimePicker();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblDriverLicense = new Label();
            txtDriverLicense = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblBirthday = new Label();
            dtpBirthday = new DateTimePicker();
            lblAge = new Label();
            nudAge = new NumericUpDown();
            btnConfirmRent = new Button();
            btnCancel = new Button();
            groupBoxRenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(178, 443);
            panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = SystemColors.ButtonHighlight;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(200, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(74, 21);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Rent Car";
            // 
            // lblCarId
            // 
            lblCarId.AutoSize = true;
            lblCarId.BackColor = SystemColors.ButtonHighlight;
            lblCarId.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            lblCarId.Location = new Point(200, 55);
            lblCarId.Name = "lblCarId";
            lblCarId.Size = new Size(52, 16);
            lblCarId.TabIndex = 2;
            lblCarId.Text = "Car ID:";
            // 
            // lblCarName
            // 
            lblCarName.AutoSize = true;
            lblCarName.BackColor = SystemColors.ButtonHighlight;
            lblCarName.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            lblCarName.Location = new Point(200, 80);
            lblCarName.Name = "lblCarName";
            lblCarName.Size = new Size(73, 16);
            lblCarName.TabIndex = 3;
            lblCarName.Text = "Car Name:";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.BackColor = SystemColors.ButtonHighlight;
            lblColor.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            lblColor.Location = new Point(200, 105);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(45, 16);
            lblColor.TabIndex = 4;
            lblColor.Text = "Color:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.BackColor = SystemColors.ButtonHighlight;
            lblPrice.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            lblPrice.Location = new Point(200, 130);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(105, 16);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price per Hour:";
            // 
            // lblAvailability
            // 
            lblAvailability.AutoSize = true;
            lblAvailability.BackColor = SystemColors.ButtonHighlight;
            lblAvailability.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            lblAvailability.Location = new Point(200, 155);
            lblAvailability.Name = "lblAvailability";
            lblAvailability.Size = new Size(83, 16);
            lblAvailability.TabIndex = 6;
            lblAvailability.Text = "Availability:";
            // 
            // groupBoxRenter
            // 
            groupBoxRenter.BackColor = SystemColors.ButtonHighlight;
            groupBoxRenter.Controls.Add(label1);
            groupBoxRenter.Controls.Add(dtpWhenToReturn);
            groupBoxRenter.Controls.Add(lblFullName);
            groupBoxRenter.Controls.Add(txtFullName);
            groupBoxRenter.Controls.Add(lblDriverLicense);
            groupBoxRenter.Controls.Add(txtDriverLicense);
            groupBoxRenter.Controls.Add(lblAddress);
            groupBoxRenter.Controls.Add(txtAddress);
            groupBoxRenter.Controls.Add(lblBirthday);
            groupBoxRenter.Controls.Add(dtpBirthday);
            groupBoxRenter.Controls.Add(lblAge);
            groupBoxRenter.Controls.Add(nudAge);
            groupBoxRenter.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxRenter.Location = new Point(200, 174);
            groupBoxRenter.Name = "groupBoxRenter";
            groupBoxRenter.Size = new Size(420, 230);
            groupBoxRenter.TabIndex = 7;
            groupBoxRenter.TabStop = false;
            groupBoxRenter.Text = "Renter Information";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 186);
            label1.Name = "label1";
            label1.Size = new Size(79, 16);
            label1.TabIndex = 11;
            label1.Text = "Return in?:";
            // 
            // dtpWhenToReturn
            // 
            dtpWhenToReturn.Format = DateTimePickerFormat.Short;
            dtpWhenToReturn.Location = new Point(120, 181);
            dtpWhenToReturn.Name = "dtpWhenToReturn";
            dtpWhenToReturn.Size = new Size(120, 23);
            dtpWhenToReturn.TabIndex = 10;
            dtpWhenToReturn.ValueChanged += dtpWhenToReturn_ValueChanged;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(15, 28);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(71, 16);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full name:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(132, 25);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(280, 23);
            txtFullName.TabIndex = 1;
            // 
            // lblDriverLicense
            // 
            lblDriverLicense.AutoSize = true;
            lblDriverLicense.Location = new Point(15, 60);
            lblDriverLicense.Name = "lblDriverLicense";
            lblDriverLicense.Size = new Size(111, 16);
            lblDriverLicense.TabIndex = 2;
            lblDriverLicense.Text = "Driver's license:";
            // 
            // txtDriverLicense
            // 
            txtDriverLicense.Location = new Point(132, 57);
            txtDriverLicense.Name = "txtDriverLicense";
            txtDriverLicense.Size = new Size(280, 23);
            txtDriverLicense.TabIndex = 3;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(15, 92);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(66, 16);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(132, 89);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(280, 23);
            txtAddress.TabIndex = 5;
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Location = new Point(15, 124);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(67, 16);
            lblBirthday.TabIndex = 6;
            lblBirthday.Text = "Birthday:";
            // 
            // dtpBirthday
            // 
            dtpBirthday.Format = DateTimePickerFormat.Short;
            dtpBirthday.Location = new Point(120, 120);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(120, 23);
            dtpBirthday.TabIndex = 7;
            dtpBirthday.ValueChanged += dtpBirthday_ValueChanged;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(15, 156);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(38, 16);
            lblAge.TabIndex = 8;
            lblAge.Text = "Age:";
            // 
            // nudAge
            // 
            nudAge.Location = new Point(120, 152);
            nudAge.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            nudAge.Name = "nudAge";
            nudAge.Size = new Size(60, 23);
            nudAge.TabIndex = 9;
            nudAge.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // btnConfirmRent
            // 
            btnConfirmRent.BackColor = SystemColors.ButtonHighlight;
            btnConfirmRent.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            btnConfirmRent.Location = new Point(200, 410);
            btnConfirmRent.Name = "btnConfirmRent";
            btnConfirmRent.Size = new Size(100, 25);
            btnConfirmRent.TabIndex = 8;
            btnConfirmRent.Text = "Confirm Rent";
            btnConfirmRent.UseVisualStyleBackColor = false;
            btnConfirmRent.Click += btnConfirmRent_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ButtonHighlight;
            btnCancel.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            btnCancel.Location = new Point(310, 410);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 25);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // RentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1052, 443);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirmRent);
            Controls.Add(groupBoxRenter);
            Controls.Add(lblAvailability);
            Controls.Add(lblPrice);
            Controls.Add(lblColor);
            Controls.Add(lblCarName);
            Controls.Add(lblCarId);
            Controls.Add(lblTitle);
            Controls.Add(panel1);
            Name = "RentForm";
            Text = "Rent Car";
            Load += RentForm_Load;
            groupBoxRenter.ResumeLayout(false);
            groupBoxRenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private Label lblCarId;
        private Label lblCarName;
        private Label lblColor;
        private Label lblPrice;
        private Label lblAvailability;
        private GroupBox groupBoxRenter;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblDriverLicense;
        private TextBox txtDriverLicense;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblBirthday;
        private DateTimePicker dtpBirthday;
        private Label lblAge;
        private NumericUpDown nudAge;
        private Button btnConfirmRent;
        private Button btnCancel;
        private Label label1;
        private DateTimePicker dtpWhenToReturn;
    }
}