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

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            btnAdd = new Button();
            btnRefresh = new Button();
            dgvVehicles = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1068, 48);
            pnlTop.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Left;
            btnAdd.Location = new Point(176, 78);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 30);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add vehicle";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Left;
            btnRefresh.Location = new Point(282, 78);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // dgvVehicles
            // 
            dgvVehicles.AllowUserToAddRows = false;
            dgvVehicles.AllowUserToDeleteRows = false;
            dgvVehicles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehicles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehicles.Dock = DockStyle.Fill;
            dgvVehicles.Location = new Point(0, 48);
            dgvVehicles.MultiSelect = false;
            dgvVehicles.Name = "dgvVehicles";
            dgvVehicles.ReadOnly = true;
            dgvVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehicles.Size = new Size(1068, 582);
            dgvVehicles.TabIndex = 2;
            // 
            // VehicleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1068, 630);
            Controls.Add(btnRefresh);
            Controls.Add(btnAdd);
            Controls.Add(dgvVehicles);
            Controls.Add(pnlTop);
            Name = "VehicleForm";
            Text = "Vehicles";
            Load += VehicleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVehicles).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvVehicles;
    }
}