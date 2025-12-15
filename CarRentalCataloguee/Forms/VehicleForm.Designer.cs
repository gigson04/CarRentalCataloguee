namespace CarRentalCataloguee.Forms
{
    partial class VehicleForm
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
            btnAddCar = new Button();
            btnRefresh = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            btnRentCar = new Button();
            btnEditCars = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(178, 443);
            panel1.TabIndex = 6;
            // 
            // btnAddCar
            // 
            btnAddCar.BackColor = Color.FromArgb(64, 109, 167);
            btnAddCar.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnAddCar.ForeColor = SystemColors.ButtonHighlight;
            btnAddCar.Location = new Point(845, 394);
            btnAddCar.Name = "btnAddCar";
            btnAddCar.Size = new Size(176, 43);
            btnAddCar.TabIndex = 7;
            btnAddCar.Text = "Add Car";
            btnAddCar.UseVisualStyleBackColor = false;
            btnAddCar.Click += btnAddCar_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(64, 109, 167);
            btnRefresh.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = SystemColors.ButtonHighlight;
            btnRefresh.Location = new Point(220, 394);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(198, 43);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.SteelBlue;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(220, 64);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(801, 324);
            dataGridView1.TabIndex = 9;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(220, 20);
            label1.Name = "label1";
            label1.Size = new Size(398, 29);
            label1.TabIndex = 10;
            label1.Text = "Pick a car that you want to rent!";
            label1.Click += label1_Click;
            // 
            // btnRentCar
            // 
            btnRentCar.BackColor = Color.FromArgb(64, 109, 167);
            btnRentCar.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnRentCar.ForeColor = SystemColors.ButtonHighlight;
            btnRentCar.Location = new Point(424, 394);
            btnRentCar.Name = "btnRentCar";
            btnRentCar.Size = new Size(194, 43);
            btnRentCar.TabIndex = 11;
            btnRentCar.Text = "Rent Car";
            btnRentCar.UseVisualStyleBackColor = false;
            btnRentCar.Click += btnRentCar_Click;
            // 
            // btnEditCars
            // 
            btnEditCars.BackColor = Color.FromArgb(64, 109, 167);
            btnEditCars.Font = new Font("Tahoma", 9F, FontStyle.Bold);
            btnEditCars.ForeColor = SystemColors.ButtonHighlight;
            btnEditCars.Location = new Point(624, 394);
            btnEditCars.Name = "btnEditCars";
            btnEditCars.Size = new Size(215, 43);
            btnEditCars.TabIndex = 12;
            btnEditCars.Text = "Edit Cars";
            btnEditCars.UseVisualStyleBackColor = false;
            btnEditCars.Click += btnEditCars_Click;
            // 
            // VehicleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1052, 443);
            Controls.Add(btnEditCars);
            Controls.Add(btnRentCar);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(btnRefresh);
            Controls.Add(btnAddCar);
            Controls.Add(panel1);
            Name = "VehicleForm";
            Text = "VehicleForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Button btnAddCar;
        private Button btnRefresh;
        private DataGridView dataGridView1;
        private Label label1;
        private Button btnRentCar;
        private Button btnEditCars;
    }
}