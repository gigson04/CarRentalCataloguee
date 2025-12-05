namespace CarRentalCataloguee.Forms
{
    partial class DashboardForm
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
            panel8 = new Panel();
            label4 = new Label();
            label3 = new Label();
            panel7 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            label5 = new Label();
            panel9 = new Panel();
            label6 = new Label();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(45, 69, 90);
            panel8.Controls.Add(label4);
            panel8.Controls.Add(label3);
            panel8.Location = new Point(520, 174);
            panel8.Name = "panel8";
            panel8.Size = new Size(200, 76);
            panel8.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Control;
            label4.Location = new Point(27, 49);
            label4.Name = "label4";
            label4.Size = new Size(10, 15);
            label4.TabIndex = 6;
            label4.Text = ":";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.Control;
            label3.Location = new Point(27, 14);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 6;
            label3.Text = "Users ";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(20, 78, 60);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(label1);
            panel7.Location = new Point(215, 174);
            panel7.Name = "panel7";
            panel7.Size = new Size(200, 76);
            panel7.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(19, 49);
            label2.Name = "label2";
            label2.Size = new Size(10, 15);
            label2.TabIndex = 1;
            label2.Text = ":";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(19, 14);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 0;
            label1.Text = "Available Units";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(178, 443);
            panel1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.Control;
            label5.Location = new Point(26, 14);
            label5.Name = "label5";
            label5.Size = new Size(81, 15);
            label5.TabIndex = 7;
            label5.Text = "Cars Returned";
            // 
            // panel9
            // 
            panel9.BackColor = Color.SteelBlue;
            panel9.Controls.Add(label6);
            panel9.Controls.Add(label5);
            panel9.Location = new Point(828, 174);
            panel9.Name = "panel9";
            panel9.Size = new Size(200, 76);
            panel9.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.Control;
            label6.Location = new Point(26, 49);
            label6.Name = "label6";
            label6.Size = new Size(10, 15);
            label6.TabIndex = 8;
            label6.Text = ":";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1052, 443);
            Controls.Add(panel1);
            Controls.Add(panel9);
            Controls.Add(panel8);
            Controls.Add(panel7);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DashboardForm";
            Text = "DashboardForm";
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel8;
        private Panel panel7;
        private Panel panel1;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private Panel panel9;
        private Label label6;
    }
}