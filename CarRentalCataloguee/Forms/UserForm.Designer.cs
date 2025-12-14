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
            button2 = new Button();
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
            dgvRentals.BackgroundColor = Color.SteelBlue;
            dgvRentals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRentals.Location = new Point(222, 43);
            dgvRentals.Name = "dgvRentals";
            dgvRentals.Size = new Size(791, 360);
            dgvRentals.TabIndex = 2;
            dgvRentals.CellContentClick += dgvRentals_CellContentClick;
            // 
            // btnRemoveUser
            // 
            btnRemoveUser.BackColor = SystemColors.Highlight;
            btnRemoveUser.ForeColor = SystemColors.ButtonHighlight;
            btnRemoveUser.Location = new Point(880, 400);
            btnRemoveUser.Name = "btnRemoveUser";
            btnRemoveUser.Size = new Size(133, 43);
            btnRemoveUser.TabIndex = 8;
            btnRemoveUser.Text = "Remove User";
            btnRemoveUser.UseVisualStyleBackColor = false;
            btnRemoveUser.Click += btnRemoveUser_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.Highlight;
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(222, 400);
            button2.Name = "button2";
            button2.Size = new Size(133, 43);
            button2.TabIndex = 10;
            button2.Text = "Add Car";
            button2.UseVisualStyleBackColor = false;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1052, 443);
            Controls.Add(button2);
            Controls.Add(btnRemoveUser);
            Controls.Add(dgvRentals);
            Controls.Add(panel1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "UserForm";
            Text = "UserForm";
            ((System.ComponentModel.ISupportInitialize)dgvRentals).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvRentals;
        private Button btnRemoveUser;
        private Button button2;
    }
}