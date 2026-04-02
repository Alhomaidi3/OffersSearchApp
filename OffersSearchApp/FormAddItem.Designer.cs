namespace OffersSearchApp
{
    partial class FormAddItem
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddItem));
            panelButtons = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            dgvOffers = new DataGridView();
            panelTitle = new Panel();
            lblTitle = new Label();
            mainFlow = new FlowLayoutPanel();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOffers).BeginInit();
            panelTitle.SuspendLayout();
            mainFlow.SuspendLayout();
            SuspendLayout();
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.AliceBlue;
            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Location = new Point(13, 685);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(1448, 55);
            panelButtons.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.SeaGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(600, 13);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 30);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾 Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(750, 13);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 30);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "✖ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // dgvOffers
            // 
            dgvOffers.AllowUserToAddRows = false;
            dgvOffers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvOffers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvOffers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvOffers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvOffers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvOffers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvOffers.Dock = DockStyle.Fill;
            dgvOffers.EnableHeadersVisualStyles = false;
            dgvOffers.Location = new Point(13, 59);
            dgvOffers.MultiSelect = false;
            dgvOffers.Name = "dgvOffers";
            dgvOffers.RowHeadersVisible = false;
            dgvOffers.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvOffers.ScrollBars = ScrollBars.Vertical;
            dgvOffers.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvOffers.Size = new Size(1448, 620);
            dgvOffers.TabIndex = 1;
            dgvOffers.KeyDown += DgvOffers_KeyDown;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.AliceBlue;
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Location = new Point(13, 13);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1448, 40);
            panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblTitle.Location = new Point(0, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "➕ Add New Offers";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mainFlow
            // 
            mainFlow.BackColor = Color.AliceBlue;
            mainFlow.Controls.Add(panelTitle);
            mainFlow.Controls.Add(dgvOffers);
            mainFlow.Controls.Add(panelButtons);
            mainFlow.Dock = DockStyle.Fill;
            mainFlow.FlowDirection = FlowDirection.TopDown;
            mainFlow.Location = new Point(0, 0);
            mainFlow.Name = "mainFlow";
            mainFlow.Padding = new Padding(10);
            mainFlow.Size = new Size(1474, 756);
            mainFlow.TabIndex = 0;
            mainFlow.WrapContents = false;
            // 
            // FormAddItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 756);
            Controls.Add(mainFlow);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAddItem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add / Edit Offers";
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOffers).EndInit();
            panelTitle.ResumeLayout(false);
            mainFlow.ResumeLayout(false);
            ResumeLayout(false);

        }
        private Panel panelButtons;
        private Button btnSave;
        private Button btnCancel;
        private DataGridView dgvOffers;
        private Panel panelTitle;
        private Label lblTitle;
        private FlowLayoutPanel mainFlow;
    }
}
