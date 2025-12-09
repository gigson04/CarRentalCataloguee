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
            SuspendLayout();
            // 
            // txtCarID
            // 
            txtCarID.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            txtCarID.Location = new Point(189, 48);
            txtCarID.Name = "txtCarID";
            txtCarID.Size = new Size(360, 33);
            txtCarID.TabIndex = 0;
            // 
            // txtColor
            // 
            txtColor.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            txtColor.Location = new Point(189, 77);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(360, 33);
            txtColor.TabIndex = 1;
            // 
            // txtPricePerHour
            // 
            txtPricePerHour.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            txtPricePerHour.Location = new Point(189, 106);
            txtPricePerHour.Name = "txtPricePerHour";
            txtPricePerHour.Size = new Size(360, 33);
            txtPricePerHour.TabIndex = 2;
            // 
            // chkAvailability
            // 
            chkAvailability.AutoSize = true;
            chkAvailability.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkAvailability.Location = new Point(189, 154);
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
            label1.Location = new Point(60, 47);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 6;
            label1.Text = "Car Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            label2.Location = new Point(60, 114);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 7;
            label2.Text = "Price/hr:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 15.75F, FontStyle.Bold);
            label3.Location = new Point(60, 80);
            label3.Name = "label3";
            label3.Size = new Size(75, 25);
            label3.TabIndex = 8;
            label3.Text = "Color:";
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Highlight;
            btnSave.ForeColor = SystemColors.ButtonHighlight;
            btnSave.Location = new Point(474, 236);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 31);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.Highlight;
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(60, 236);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 31);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(621, 310);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chkAvailability);
            Controls.Add(txtPricePerHour);
            Controls.Add(txtColor);
            Controls.Add(txtCarID);
            Name = "AddForm";
            Text = "AddCar";
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
    }
}