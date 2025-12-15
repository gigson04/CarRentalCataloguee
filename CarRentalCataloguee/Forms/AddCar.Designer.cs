namespace CarRentalCataloguee.Forms
{
    partial class AddForm
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
            txtCarID = new TextBox();
            txtColor = new TextBox();
            txtPricePerHour = new TextBox();
            chkAvailability = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            txtCarName = new TextBox();
            label4 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtCarID
            // 
            txtCarID.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            txtCarID.Location = new Point(190, 202);
            txtCarID.Name = "txtCarID";
            txtCarID.Size = new Size(371, 33);
            txtCarID.TabIndex = 0;
            // 
            // txtColor
            // 
            txtColor.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            txtColor.Location = new Point(190, 124);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(371, 33);
            txtColor.TabIndex = 1;
            // 
            // txtPricePerHour
            // 
            txtPricePerHour.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            txtPricePerHour.Location = new Point(190, 163);
            txtPricePerHour.Name = "txtPricePerHour";
            txtPricePerHour.Size = new Size(371, 33);
            txtPricePerHour.TabIndex = 2;
            // 
            // chkAvailability
            // 
            chkAvailability.AutoSize = true;
            chkAvailability.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkAvailability.Location = new Point(190, 241);
            chkAvailability.Name = "chkAvailability";
            chkAvailability.Size = new Size(92, 18);
            chkAvailability.TabIndex = 3;
            chkAvailability.Text = "Availability";
            chkAvailability.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            label1.Location = new Point(61, 93);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 6;
            label1.Text = "Car Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            label2.Location = new Point(61, 163);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 7;
            label2.Text = "Price/hr:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            label3.Location = new Point(61, 127);
            label3.Name = "label3";
            label3.Size = new Size(75, 25);
            label3.TabIndex = 8;
            label3.Text = "Color:";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Highlight;
            btnSave.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            btnSave.ForeColor = SystemColors.ButtonHighlight;
            btnSave.Image = Properties.Resources.diskette_fotor_20251215215648;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(438, 264);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(133, 53);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.Highlight;
            btnCancel.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Image = Properties.Resources.cancel_fotor_202512152152581;
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.Location = new Point(51, 264);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new Padding(2, 0, 0, 0);
            btnCancel.Size = new Size(133, 54);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "   Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtCarName
            // 
            txtCarName.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            txtCarName.Location = new Point(190, 85);
            txtCarName.Name = "txtCarName";
            txtCarName.Size = new Size(371, 33);
            txtCarName.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            label4.Location = new Point(61, 205);
            label4.Name = "label4";
            label4.Size = new Size(88, 25);
            label4.TabIndex = 12;
            label4.Text = "Car ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(98, 30);
            label5.Name = "label5";
            label5.Size = new Size(144, 33);
            label5.TabIndex = 13;
            label5.Text = "Add Cars!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.transport_fotor_2025121521243;
            pictureBox1.Location = new Point(48, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(55, 51);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(621, 340);
            Controls.Add(pictureBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtCarName);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chkAvailability);
            Controls.Add(txtPricePerHour);
            Controls.Add(txtColor);
            Controls.Add(txtCarID);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AddForm";
            Text = "AddCar";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCarID;
        private TextBox txtColor;
        private TextBox txtPricePerHour;
        private CheckBox chkAvailability;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSave;
        private Button btnCancel;
        private TextBox txtCarName;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox1;
    }
}