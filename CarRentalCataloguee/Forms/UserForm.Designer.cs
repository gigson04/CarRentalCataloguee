namespace CarRentalCataloguee.Forms
{
    partial class UserForm
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
            dgvRentals = new DataGridView();
            btnRemoveUser = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRentals).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(178, 443);
            panel1.TabIndex = 1;
            // 
            // dgvRentals
            // 
            dgvRentals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRentals.BackgroundColor = Color.FromArgb(45, 69, 90);
            dgvRentals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRentals.Location = new Point(222, 68);
            dgvRentals.Name = "dgvRentals";
            dgvRentals.Size = new Size(791, 313);
            dgvRentals.TabIndex = 2;
            dgvRentals.CellContentClick += dgvRentals_CellContentClick;
            // 
            // btnRemoveUser
            // 
            btnRemoveUser.BackColor = Color.FromArgb(64, 109, 167);
            btnRemoveUser.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveUser.ForeColor = SystemColors.ButtonHighlight;
            btnRemoveUser.Location = new Point(790, 388);
            btnRemoveUser.Name = "btnRemoveUser";
            btnRemoveUser.Size = new Size(223, 43);
            btnRemoveUser.TabIndex = 8;
            btnRemoveUser.Text = "Remove User";
            btnRemoveUser.UseVisualStyleBackColor = false;
            btnRemoveUser.Click += btnRemoveUser_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(213, 21);
            label1.Name = "label1";
            label1.Size = new Size(219, 35);
            label1.TabIndex = 11;
            label1.Text = "Users Rented!";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1052, 443);
            Controls.Add(label1);
            Controls.Add(btnRemoveUser);
            Controls.Add(dgvRentals);
            Controls.Add(panel1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "UserForm";
            Text = "UserForm";
            ((System.ComponentModel.ISupportInitialize)dgvRentals).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvRentals;
        private Button btnRemoveUser;
        private Label label1;
    }
}