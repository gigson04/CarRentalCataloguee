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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
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
            lblTitle.BackColor = SystemColors.GradientInactiveCaption;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(200, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(229, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Car Information:";
            // 
            // lblCarId
            // 
            lblCarId.AutoSize = true;
            lblCarId.BackColor = SystemColors.GradientInactiveCaption;
            lblCarId.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            lblCarId.Location = new Point(205, 58);
            lblCarId.Name = "lblCarId";
            lblCarId.Size = new Size(67, 19);
            lblCarId.TabIndex = 2;
            lblCarId.Text = "Car ID:";
            // 
            // lblCarName
            // 
            lblCarName.AutoSize = true;
            lblCarName.BackColor = SystemColors.GradientInactiveCaption;
            lblCarName.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            lblCarName.Location = new Point(205, 83);
            lblCarName.Name = "lblCarName";
            lblCarName.Size = new Size(95, 19);
            lblCarName.TabIndex = 3;
            lblCarName.Text = "Car Name:";
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.BackColor = SystemColors.GradientInactiveCaption;
            lblColor.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            lblColor.Location = new Point(205, 108);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(58, 19);
            lblColor.TabIndex = 4;
            lblColor.Text = "Color:";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.BackColor = SystemColors.GradientInactiveCaption;
            lblPrice.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            lblPrice.Location = new Point(205, 133);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(132, 19);
            lblPrice.TabIndex = 5;
            lblPrice.Text = "Price per Hour:";
            // 
            // lblAvailability
            // 
            lblAvailability.AutoSize = true;
            lblAvailability.BackColor = SystemColors.GradientInactiveCaption;
            lblAvailability.Font = new Font("Tahoma", 12F, FontStyle.Bold);
            lblAvailability.Location = new Point(205, 158);
            lblAvailability.Name = "lblAvailability";
            lblAvailability.Size = new Size(107, 19);
            lblAvailability.TabIndex = 6;
            lblAvailability.Text = "Availability:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            label1.Location = new Point(707, 235);
            label1.Name = "label1";
            label1.Size = new Size(91, 18);
            label1.TabIndex = 11;
            label1.Text = "Return in?:";
            // 
            // dtpWhenToReturn
            // 
            dtpWhenToReturn.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            dtpWhenToReturn.Format = DateTimePickerFormat.Short;
            dtpWhenToReturn.Location = new Point(804, 229);
            dtpWhenToReturn.Name = "dtpWhenToReturn";
            dtpWhenToReturn.Size = new Size(136, 26);
            dtpWhenToReturn.TabIndex = 10;
            dtpWhenToReturn.ValueChanged += dtpWhenToReturn_ValueChanged;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            lblFullName.Location = new Point(250, 205);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(85, 18);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full name:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            txtFullName.Location = new Point(339, 197);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(288, 26);
            txtFullName.TabIndex = 1;
            // 
            // lblDriverLicense
            // 
            lblDriverLicense.AutoSize = true;
            lblDriverLicense.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            lblDriverLicense.Location = new Point(228, 301);
            lblDriverLicense.Name = "lblDriverLicense";
            lblDriverLicense.Size = new Size(130, 18);
            lblDriverLicense.TabIndex = 2;
            lblDriverLicense.Text = "Driver's license:";
            // 
            // txtDriverLicense
            // 
            txtDriverLicense.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            txtDriverLicense.Location = new Point(364, 298);
            txtDriverLicense.Name = "txtDriverLicense";
            txtDriverLicense.Size = new Size(263, 26);
            txtDriverLicense.TabIndex = 3;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            lblAddress.Location = new Point(250, 247);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(73, 18);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            txtAddress.Location = new Point(329, 242);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(288, 26);
            txtAddress.TabIndex = 5;
            // 
            // lblBirthday
            // 
            lblBirthday.AutoSize = true;
            lblBirthday.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            lblBirthday.Location = new Point(721, 197);
            lblBirthday.Name = "lblBirthday";
            lblBirthday.Size = new Size(77, 18);
            lblBirthday.TabIndex = 6;
            lblBirthday.Text = "Birthday:";
            // 
            // dtpBirthday
            // 
            dtpBirthday.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            dtpBirthday.Format = DateTimePickerFormat.Short;
            dtpBirthday.Location = new Point(804, 192);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(135, 26);
            dtpBirthday.TabIndex = 7;
            dtpBirthday.ValueChanged += dtpBirthday_ValueChanged;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            lblAge.Location = new Point(748, 275);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(41, 18);
            lblAge.TabIndex = 8;
            lblAge.Text = "Age:";
            // 
            // nudAge
            // 
            nudAge.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            nudAge.Location = new Point(804, 273);
            nudAge.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            nudAge.Name = "nudAge";
            nudAge.Size = new Size(54, 26);
            nudAge.TabIndex = 9;
            nudAge.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // btnConfirmRent
            // 
            btnConfirmRent.BackColor = Color.FromArgb(64, 109, 167);
            btnConfirmRent.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            btnConfirmRent.ForeColor = SystemColors.Control;
            btnConfirmRent.Location = new Point(804, 388);
            btnConfirmRent.Name = "btnConfirmRent";
            btnConfirmRent.Size = new Size(223, 43);
            btnConfirmRent.TabIndex = 8;
            btnConfirmRent.Text = "Confirm Rent";
            btnConfirmRent.UseVisualStyleBackColor = false;
            btnConfirmRent.Click += btnConfirmRent_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(64, 109, 167);
            btnCancel.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            btnCancel.ForeColor = SystemColors.Control;
            btnCancel.Location = new Point(200, 388);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(223, 43);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.id_card_fotor_20251215223435;
            pictureBox1.Location = new Point(200, 192);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(5, 0, 0, 0);
            pictureBox1.Size = new Size(44, 31);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.location_fotor_202512152237471;
            pictureBox2.Location = new Point(201, 235);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Padding = new Padding(5, 0, 0, 0);
            pictureBox2.Size = new Size(43, 41);
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.paper_fotor_20251215223920;
            pictureBox3.Location = new Point(184, 289);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Padding = new Padding(5, 0, 0, 0);
            pictureBox3.Size = new Size(38, 38);
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.birthday_fotor_20251215224426;
            pictureBox4.Location = new Point(676, 187);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Padding = new Padding(5, 0, 0, 0);
            pictureBox4.Size = new Size(39, 36);
            pictureBox4.TabIndex = 15;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.return_fotor_20251215224754;
            pictureBox5.Location = new Point(662, 229);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Padding = new Padding(5, 0, 0, 0);
            pictureBox5.Size = new Size(39, 36);
            pictureBox5.TabIndex = 16;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.adult_fotor_202512152249411;
            pictureBox6.Location = new Point(703, 263);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Padding = new Padding(5, 0, 0, 0);
            pictureBox6.Size = new Size(39, 36);
            pictureBox6.TabIndex = 17;
            pictureBox6.TabStop = false;
            // 
            // RentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1052, 443);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(dtpWhenToReturn);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirmRent);
            Controls.Add(nudAge);
            Controls.Add(lblAge);
            Controls.Add(dtpBirthday);
            Controls.Add(lblBirthday);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtDriverLicense);
            Controls.Add(lblDriverLicense);
            Controls.Add(txtFullName);
            Controls.Add(lblFullName);
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
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
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
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
    }
}