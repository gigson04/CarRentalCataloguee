namespace CarRentalCataloguee
{
    partial class LogInForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            label3 = new Label();
            btnSignUp = new Button();
            label4 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.SteelBlue;
            flowLayoutPanel1.Dock = DockStyle.Left;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(311, 450);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUserName);
            panel1.Font = new Font("Tahoma", 12F);
            panel1.Location = new Point(368, 98);
            panel1.Name = "panel1";
            panel1.Size = new Size(381, 263);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(43, 118);
            label2.Name = "label2";
            label2.Size = new Size(70, 16);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(43, 43);
            label1.Name = "label1";
            label1.Size = new Size(71, 16);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Highlight;
            btnLogin.ForeColor = SystemColors.ButtonHighlight;
            btnLogin.Location = new Point(154, 203);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 31);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Log-in";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Tahoma", 13F);
            txtPassword.Location = new Point(43, 137);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(296, 28);
            txtPassword.TabIndex = 1;
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Tahoma", 13F);
            txtUserName.Location = new Point(43, 62);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(296, 28);
            txtUserName.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(420, 422);
            label3.Name = "label3";
            label3.Size = new Size(161, 14);
            label3.TabIndex = 2;
            label3.Text = "You dont have account? ";
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = SystemColors.Highlight;
            btnSignUp.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSignUp.ForeColor = Color.Snow;
            btnSignUp.Location = new Point(587, 418);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(75, 23);
            btnSignUp.TabIndex = 5;
            btnSignUp.Text = "Sign-up";
            btnSignUp.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 23F, FontStyle.Bold);
            label4.Location = new Point(422, 30);
            label4.Name = "label4";
            label4.Size = new Size(254, 37);
            label4.TabIndex = 6;
            label4.Text = "Welcome Back!";
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(btnSignUp);
            Controls.Add(label3);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Name = "LogInForm";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private TextBox txtUserName;
        private Label label2;
        private Label label1;
        private Button btnLogin;
        private TextBox txtPassword;
        private Label label3;
        private Button btnSignUp;
        private Label label4;
    }
}
