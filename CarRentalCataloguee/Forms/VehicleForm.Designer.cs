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
            button1 = new Button();
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
            btnAddCar.BackColor = SystemColors.Highlight;
            btnAddCar.ForeColor = SystemColors.ButtonHighlight;
            btnAddCar.Location = new Point(888, 394);
            btnAddCar.Name = "btnAddCar";
            btnAddCar.Size = new Size(133, 43);
            btnAddCar.TabIndex = 7;
            btnAddCar.Text = "Add Car";
            btnAddCar.UseVisualStyleBackColor = false;
            btnAddCar.Click += btnAddCar_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.Highlight;
            btnRefresh.ForeColor = SystemColors.ButtonHighlight;
            btnRefresh.Location = new Point(220, 394);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(133, 43);
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
            dataGridView1.Location = new Point(220, 55);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(801, 324);
            dataGridView1.TabIndex = 9;
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
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Highlight;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(562, 394);
            button1.Name = "button1";
            button1.Size = new Size(133, 43);
            button1.TabIndex = 11;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = false;
            // 
            // VehicleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1052, 443);
            Controls.Add(button1);
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
        private Button button1;
    }
}