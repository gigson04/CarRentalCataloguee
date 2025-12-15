namespace CarRentalCataloguee
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            btnExit = new Button();
            btnThankYou = new Button();
            btnUser = new Button();
            btnRentCar = new Button();
            btnVehicles = new Button();
            btnDashBoard = new Button();
            panel2 = new Panel();
            pnlMain = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            pnlMain.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnThankYou);
            panel1.Controls.Add(btnUser);
            panel1.Controls.Add(btnRentCar);
            panel1.Controls.Add(btnVehicles);
            panel1.Controls.Add(btnDashBoard);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(178, 630);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(69, 25);
            label1.Name = "label1";
            label1.Size = new Size(57, 19);
            label1.TabIndex = 7;
            label1.Text = "HOME";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(23, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 45);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            btnExit.FlatStyle = FlatStyle.Popup;
            btnExit.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageAlign = ContentAlignment.MiddleLeft;
            btnExit.Location = new Point(0, 481);
            btnExit.Name = "btnExit";
            btnExit.Padding = new Padding(12, 0, 0, 0);
            btnExit.Size = new Size(178, 75);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnThankYou
            // 
            btnThankYou.FlatStyle = FlatStyle.Popup;
            btnThankYou.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThankYou.Image = (Image)resources.GetObject("btnThankYou.Image");
            btnThankYou.ImageAlign = ContentAlignment.MiddleLeft;
            btnThankYou.Location = new Point(0, 400);
            btnThankYou.Name = "btnThankYou";
            btnThankYou.Padding = new Padding(12, 0, 0, 0);
            btnThankYou.Size = new Size(178, 75);
            btnThankYou.TabIndex = 4;
            btnThankYou.Text = "Thank You";
            btnThankYou.UseVisualStyleBackColor = true;
            btnThankYou.Click += btnThankYou_Click;
            // 
            // btnUser
            // 
            btnUser.FlatStyle = FlatStyle.Popup;
            btnUser.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUser.Image = (Image)resources.GetObject("btnUser.Image");
            btnUser.ImageAlign = ContentAlignment.MiddleLeft;
            btnUser.Location = new Point(0, 319);
            btnUser.Name = "btnUser";
            btnUser.Padding = new Padding(12, 0, 0, 0);
            btnUser.Size = new Size(178, 75);
            btnUser.TabIndex = 3;
            btnUser.Text = "User";
            btnUser.UseVisualStyleBackColor = true;
            btnUser.Click += btnUser_Click;
            // 
            // btnRentCar
            // 
            btnRentCar.FlatStyle = FlatStyle.Popup;
            btnRentCar.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRentCar.ForeColor = SystemColors.ButtonHighlight;
            btnRentCar.Image = (Image)resources.GetObject("btnRentCar.Image");
            btnRentCar.ImageAlign = ContentAlignment.MiddleLeft;
            btnRentCar.Location = new Point(0, 238);
            btnRentCar.Name = "btnRentCar";
            btnRentCar.Padding = new Padding(12, 0, 0, 0);
            btnRentCar.Size = new Size(178, 75);
            btnRentCar.TabIndex = 2;
            btnRentCar.Text = "Rent Car";
            btnRentCar.UseVisualStyleBackColor = true;
            btnRentCar.Click += btnRentCar_Click;
            // 
            // btnVehicles
            // 
            btnVehicles.FlatStyle = FlatStyle.Popup;
            btnVehicles.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVehicles.ForeColor = SystemColors.ButtonHighlight;
            btnVehicles.Image = (Image)resources.GetObject("btnVehicles.Image");
            btnVehicles.ImageAlign = ContentAlignment.MiddleLeft;
            btnVehicles.Location = new Point(0, 155);
            btnVehicles.Name = "btnVehicles";
            btnVehicles.Padding = new Padding(12, 0, 0, 0);
            btnVehicles.Size = new Size(178, 75);
            btnVehicles.TabIndex = 1;
            btnVehicles.Text = "Vehicles";
            btnVehicles.UseVisualStyleBackColor = true;
            btnVehicles.Click += btnVehicles_Click;
            // 
            // btnDashBoard
            // 
            btnDashBoard.CausesValidation = false;
            btnDashBoard.FlatStyle = FlatStyle.Popup;
            btnDashBoard.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashBoard.ForeColor = SystemColors.ButtonHighlight;
            btnDashBoard.Image = (Image)resources.GetObject("btnDashBoard.Image");
            btnDashBoard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashBoard.Location = new Point(0, 74);
            btnDashBoard.Name = "btnDashBoard";
            btnDashBoard.Padding = new Padding(12, 0, 0, 0);
            btnDashBoard.Size = new Size(178, 75);
            btnDashBoard.TabIndex = 0;
            btnDashBoard.Text = "DashBoard";
            btnDashBoard.UseVisualStyleBackColor = true;
            btnDashBoard.Click += btnMainForm_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(pnlMain);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1068, 630);
            panel2.TabIndex = 3;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(panel6);
            pnlMain.Controls.Add(panel5);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.ForeColor = SystemColors.ActiveCaption;
            pnlMain.Location = new Point(0, 74);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1068, 482);
            pnlMain.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.AutoSize = true;
            panel6.BackColor = Color.White;
            panel6.Dock = DockStyle.Fill;
            panel6.ForeColor = SystemColors.ActiveCaption;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1068, 482);
            panel6.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(20, 78, 60);
            panel5.Location = new Point(211, 20);
            panel5.Name = "panel5";
            panel5.Size = new Size(200, 76);
            panel5.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.SteelBlue;
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 556);
            panel4.Name = "panel4";
            panel4.Size = new Size(1068, 74);
            panel4.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.SteelBlue;
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.ForeColor = Color.BlueViolet;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1068, 74);
            panel3.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.car_key_fotor_20251215154541;
            pictureBox2.Location = new Point(685, 7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(51, 50);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(464, 12);
            label2.Name = "label2";
            label2.Size = new Size(215, 45);
            label2.TabIndex = 0;
            label2.Text = "Car Rental";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 630);
            Controls.Add(panel1);
            Controls.Add(panel2);
            ForeColor = SystemColors.ButtonHighlight;
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "DashBoard";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button btnUser;
        private Button btnRentCar;
        private Button btnVehicles;
        private Button btnDashBoard;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private Button btnExit;
        private Panel pnlMain;
        private Panel panel5;
        private Panel panel6;
        private Label label2;
        private PictureBox pictureBox2;
        private Button btnThankYou;
    }
}