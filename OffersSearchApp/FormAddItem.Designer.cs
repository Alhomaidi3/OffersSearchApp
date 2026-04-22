using System.Windows.Forms;

namespace OffersSearchApp
{
    partial class FormAddItem
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddItem));
            buttonsFlow = new FlowLayoutPanel();
            btnToggleTheme = new Button();
            btnToggleSelect = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            dgvOffers = new DataGridView();
            panelTitle = new Panel();
            lblTitle = new Label();
            mainLayout = new TableLayoutPanel();
            buttonsFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOffers).BeginInit();
            panelTitle.SuspendLayout();
            mainLayout.SuspendLayout();
            SuspendLayout();
            // 
            // buttonsFlow
            // 
            buttonsFlow.Anchor = AnchorStyles.None;
            buttonsFlow.AutoSize = true;
            buttonsFlow.Controls.Add(btnToggleTheme);
            buttonsFlow.Controls.Add(btnToggleSelect);
            buttonsFlow.Controls.Add(btnCancel);
            buttonsFlow.Controls.Add(btnSave);
            buttonsFlow.Location = new Point(24, 702);
            buttonsFlow.Name = "buttonsFlow";
            buttonsFlow.Size = new Size(1426, 36);
            buttonsFlow.TabIndex = 2;
            buttonsFlow.WrapContents = false;
            // 
            // btnToggleTheme
            // 
            btnToggleTheme.AutoSize = true;
            btnToggleTheme.BackColor = Color.FromArgb(128, 128, 255);
            btnToggleTheme.FlatStyle = FlatStyle.Flat;
            btnToggleTheme.ForeColor = Color.White;
            btnToggleTheme.Location = new Point(3, 3);
            btnToggleTheme.Margin = new Padding(3, 3, 815, 3);
            btnToggleTheme.Name = "btnToggleTheme";
            btnToggleTheme.Size = new Size(130, 27);
            btnToggleTheme.TabIndex = 11;
            btnToggleTheme.Text = "🌙 Dark Mode";
            btnToggleTheme.UseVisualStyleBackColor = false;
            btnToggleTheme.Click += BtnToggleTheme_Click;
            // 
            // btnToggleSelect
            // 
            btnToggleSelect.AutoSize = true;
            btnToggleSelect.BackColor = Color.FromArgb(255, 193, 7);
            btnToggleSelect.FlatStyle = FlatStyle.Flat;
            btnToggleSelect.ForeColor = Color.White;
            btnToggleSelect.Location = new Point(963, 3);
            btnToggleSelect.Margin = new Padding(15, 3, 15, 3);
            btnToggleSelect.Name = "btnToggleSelect";
            btnToggleSelect.Size = new Size(140, 30);
            btnToggleSelect.TabIndex = 12;
            btnToggleSelect.Text = "⭐ Select/Unselect";
            btnToggleSelect.UseVisualStyleBackColor = false;
            btnToggleSelect.Click += BtnToggleSelect_Click;
            // 
            // btnCancel
            // 
            btnCancel.AutoSize = true;
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(1133, 3);
            btnCancel.Margin = new Padding(15, 3, 15, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(130, 30);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "✖ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.SeaGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(1293, 3);
            btnSave.Margin = new Padding(15, 3, 3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 30);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾 Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // dgvOffers
            // 
            dgvOffers.AllowDrop = true;
            dgvOffers.AllowUserToAddRows = false;
            dgvOffers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dgvOffers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvOffers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvOffers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvOffers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvOffers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvOffers.Dock = DockStyle.Fill;
            dgvOffers.EnableHeadersVisualStyles = false;
            dgvOffers.Location = new Point(23, 61);
            dgvOffers.MultiSelect = false;
            dgvOffers.Name = "dgvOffers";
            dgvOffers.RowHeadersVisible = false;
            dgvOffers.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvOffers.RowTemplate.Height = 40;
            dgvOffers.ScrollBars = ScrollBars.Vertical;
            dgvOffers.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvOffers.Size = new Size(1428, 635);
            dgvOffers.TabIndex = 1;
            dgvOffers.DragDrop += DgvOffers_DragDrop;
            dgvOffers.DragEnter += DgvOffers_DragEnter;
            dgvOffers.KeyDown += DgvOffers_KeyDown;
            dgvOffers.DataBindingComplete += DgvOffers_DataBindingComplete;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.AliceBlue;
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Dock = DockStyle.Fill;
            panelTitle.Location = new Point(23, 15);
            panelTitle.Margin = new Padding(3, 0, 3, 3);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1428, 40);
            panelTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblTitle.Location = new Point(9, -1);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "➕ Add New Offers";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mainLayout
            // 
            mainLayout.BackColor = Color.AliceBlue;
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            mainLayout.Controls.Add(panelTitle, 0, 0);
            mainLayout.Controls.Add(dgvOffers, 0, 1);
            mainLayout.Controls.Add(buttonsFlow, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(20, 15, 20, 15);
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainLayout.Size = new Size(1474, 756);
            mainLayout.TabIndex = 0;
            // 
            // FormAddItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 756);
            Controls.Add(mainLayout);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAddItem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add / Edit Offers";
            buttonsFlow.ResumeLayout(false);
            buttonsFlow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOffers).EndInit();
            panelTitle.ResumeLayout(false);
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            ResumeLayout(false);

        }
        private FlowLayoutPanel buttonsFlow;
        private Button btnSave;
        private Button btnCancel;
        private DataGridView dgvOffers;
        private Panel panelTitle;
        private Label lblTitle;
        private TableLayoutPanel mainLayout;
        private Button btnToggleTheme;
        private Button btnToggleSelect;

    }
}
