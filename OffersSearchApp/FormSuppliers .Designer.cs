namespace OffersSearchApp
{
    partial class FormSuppliers
    {
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            mainLayout = new TableLayoutPanel();
            searchPanelFlow = new FlowLayoutPanel();
            lblTitle = new Label();
            label1 = new Label();
            panel_SupplierName = new Panel();
            tb_SupplierName = new TextBox();
            lbl_SupplierName = new Label();
            panel_ProductName = new Panel();
            tb_GoodsOrService = new TextBox();
            lbl_ProductName = new Label();
            suppliersGrid = new DataGridView();
            buttonsFlow = new FlowLayoutPanel();
            btnToggleTheme = new Button();
            btnImportExcel = new Button();
            btnExportExcel = new Button();
            btnDeleteAll = new Button();
            btnItemDetails = new Button();
            BtnDeleteSupplier = new Button();
            btnSave = new Button();
            mainLayout.SuspendLayout();
            searchPanelFlow.SuspendLayout();
            panel_SupplierName.SuspendLayout();
            panel_ProductName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)suppliersGrid).BeginInit();
            buttonsFlow.SuspendLayout();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.BackColor = Color.AliceBlue;
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(searchPanelFlow, 0, 0);
            mainLayout.Controls.Add(suppliersGrid, 0, 1);
            mainLayout.Controls.Add(buttonsFlow, 0, 2);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(0, 0);
            mainLayout.Name = "mainLayout";
            mainLayout.Padding = new Padding(10);
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 85F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainLayout.Size = new Size(1400, 700);
            mainLayout.TabIndex = 0;
            // 
            // searchPanelFlow
            // 
            searchPanelFlow.AutoScroll = true;
            searchPanelFlow.AutoSize = true;
            searchPanelFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            searchPanelFlow.BackColor = Color.AliceBlue;
            searchPanelFlow.Controls.Add(lblTitle);
            searchPanelFlow.Controls.Add(label1);
            searchPanelFlow.Controls.Add(panel_SupplierName);
            searchPanelFlow.Controls.Add(panel_ProductName);
            searchPanelFlow.Dock = DockStyle.Fill;
            searchPanelFlow.Location = new Point(13, 13);
            searchPanelFlow.Name = "searchPanelFlow";
            searchPanelFlow.Padding = new Padding(3);
            searchPanelFlow.Size = new Size(1374, 79);
            searchPanelFlow.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblTitle.Location = new Point(6, 8);
            lblTitle.Margin = new Padding(3, 5, 10, 3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(240, 35);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "➕ Suppliers Management";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(52, 152, 219);
            label1.Location = new Point(259, 8);
            label1.Margin = new Padding(3, 5, 10, 3);
            label1.Name = "label1";
            label1.Size = new Size(70, 35);
            label1.TabIndex = 3;
            label1.Text = "Search:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_SupplierName
            // 
            panel_SupplierName.AutoSize = true;
            panel_SupplierName.Controls.Add(tb_SupplierName);
            panel_SupplierName.Controls.Add(lbl_SupplierName);
            panel_SupplierName.Location = new Point(342, 11);
            panel_SupplierName.Margin = new Padding(3, 8, 5, 3);
            panel_SupplierName.MinimumSize = new Size(150, 55);
            panel_SupplierName.Name = "panel_SupplierName";
            panel_SupplierName.Size = new Size(160, 55);
            panel_SupplierName.TabIndex = 1;
            // 
            // tb_SupplierName
            // 
            tb_SupplierName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tb_SupplierName.Font = new Font("Segoe UI", 10F);
            tb_SupplierName.Location = new Point(0, 24);
            tb_SupplierName.Name = "tb_SupplierName";
            tb_SupplierName.Size = new Size(160, 25);
            tb_SupplierName.TabIndex = 0;
            // 
            // lbl_SupplierName
            // 
            lbl_SupplierName.Dock = DockStyle.Top;
            lbl_SupplierName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_SupplierName.Location = new Point(0, 0);
            lbl_SupplierName.Name = "lbl_SupplierName";
            lbl_SupplierName.Size = new Size(160, 22);
            lbl_SupplierName.TabIndex = 1;
            lbl_SupplierName.Text = "Supplier Name";
            lbl_SupplierName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_ProductName
            // 
            panel_ProductName.AutoSize = true;
            panel_ProductName.Controls.Add(tb_GoodsOrService);
            panel_ProductName.Controls.Add(lbl_ProductName);
            panel_ProductName.Location = new Point(510, 11);
            panel_ProductName.Margin = new Padding(3, 8, 5, 3);
            panel_ProductName.MinimumSize = new Size(150, 55);
            panel_ProductName.Name = "panel_ProductName";
            panel_ProductName.Size = new Size(160, 55);
            panel_ProductName.TabIndex = 4;
            // 
            // tb_GoodsOrService
            // 
            tb_GoodsOrService.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tb_GoodsOrService.Font = new Font("Segoe UI", 10F);
            tb_GoodsOrService.Location = new Point(0, 24);
            tb_GoodsOrService.Name = "tb_GoodsOrService";
            tb_GoodsOrService.Size = new Size(160, 25);
            tb_GoodsOrService.TabIndex = 0;
            // 
            // lbl_ProductName
            // 
            lbl_ProductName.Dock = DockStyle.Top;
            lbl_ProductName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_ProductName.Location = new Point(0, 0);
            lbl_ProductName.Name = "lbl_ProductName";
            lbl_ProductName.Size = new Size(160, 22);
            lbl_ProductName.TabIndex = 1;
            lbl_ProductName.Text = "Product Name";
            lbl_ProductName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // suppliersGrid
            // 
            suppliersGrid.AllowDrop = true;
            suppliersGrid.AllowUserToAddRows = false;
            suppliersGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
            suppliersGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            suppliersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            suppliersGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            suppliersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new Padding(2);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            suppliersGrid.DefaultCellStyle = dataGridViewCellStyle6;
            suppliersGrid.Dock = DockStyle.Fill;
            suppliersGrid.EnableHeadersVisualStyles = false;
            suppliersGrid.Location = new Point(13, 98);
            suppliersGrid.MultiSelect = false;
            suppliersGrid.Name = "suppliersGrid";
            suppliersGrid.RowHeadersVisible = false;
            suppliersGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            suppliersGrid.RowTemplate.Height = 35;
            suppliersGrid.ScrollBars = ScrollBars.Vertical;
            suppliersGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            suppliersGrid.Size = new Size(1374, 529);
            suppliersGrid.TabIndex = 1;
            // 
            // buttonsFlow
            // 
            buttonsFlow.AutoSize = true;
            buttonsFlow.Controls.Add(btnToggleTheme);
            buttonsFlow.Controls.Add(btnImportExcel);
            buttonsFlow.Controls.Add(btnExportExcel);
            buttonsFlow.Controls.Add(btnDeleteAll);
            buttonsFlow.Controls.Add(btnItemDetails);
            buttonsFlow.Controls.Add(BtnDeleteSupplier);
            buttonsFlow.Controls.Add(btnSave);
            buttonsFlow.Dock = DockStyle.Fill;
            buttonsFlow.Location = new Point(13, 633);
            buttonsFlow.Name = "buttonsFlow";
            buttonsFlow.Padding = new Padding(0, 5, 0, 5);
            buttonsFlow.Size = new Size(1374, 54);
            buttonsFlow.TabIndex = 2;
            // 
            // btnToggleTheme
            // 
            btnToggleTheme.AutoSize = true;
            btnToggleTheme.BackColor = Color.FromArgb(52, 73, 94);
            btnToggleTheme.FlatStyle = FlatStyle.Flat;
            btnToggleTheme.ForeColor = Color.White;
            btnToggleTheme.Location = new Point(5, 8);
            btnToggleTheme.Margin = new Padding(5, 3, 5, 3);
            btnToggleTheme.Name = "btnToggleTheme";
            btnToggleTheme.Size = new Size(110, 30);
            btnToggleTheme.TabIndex = 0;
            btnToggleTheme.Text = "🌙 Dark Mode";
            btnToggleTheme.UseVisualStyleBackColor = false;
            btnToggleTheme.Click += BtnToggleTheme_Click;
            // 
            // btnImportExcel
            // 
            btnImportExcel.AutoSize = true;
            btnImportExcel.BackColor = Color.SeaGreen;
            btnImportExcel.FlatStyle = FlatStyle.Flat;
            btnImportExcel.ForeColor = Color.White;
            btnImportExcel.Location = new Point(125, 8);
            btnImportExcel.Margin = new Padding(5, 3, 5, 3);
            btnImportExcel.Name = "btnImportExcel";
            btnImportExcel.Size = new Size(110, 30);
            btnImportExcel.TabIndex = 1;
            btnImportExcel.Text = "📂 Import Excel";
            btnImportExcel.UseVisualStyleBackColor = false;
            btnImportExcel.Click += BtnImportExcel_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.AutoSize = true;
            btnExportExcel.BackColor = Color.SeaGreen;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(245, 8);
            btnExportExcel.Margin = new Padding(5, 3, 5, 3);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(110, 30);
            btnExportExcel.TabIndex = 2;
            btnExportExcel.Text = "📊 Export Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += BtnExportExcel_Click;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.AutoSize = true;
            btnDeleteAll.BackColor = Color.Crimson;
            btnDeleteAll.FlatStyle = FlatStyle.Flat;
            btnDeleteAll.ForeColor = Color.White;
            btnDeleteAll.Location = new Point(365, 8);
            btnDeleteAll.Margin = new Padding(5, 3, 5, 3);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(110, 30);
            btnDeleteAll.TabIndex = 4;
            btnDeleteAll.Text = "🗑️ Delete All";
            btnDeleteAll.UseVisualStyleBackColor = false;
            btnDeleteAll.Click += BtnDeleteAll_Click;
            // 
            // btnItemDetails
            // 
            btnItemDetails.AutoSize = true;
            btnItemDetails.BackColor = Color.FromArgb(255, 193, 7);
            btnItemDetails.FlatStyle = FlatStyle.Flat;
            btnItemDetails.ForeColor = Color.White;
            btnItemDetails.Location = new Point(485, 8);
            btnItemDetails.Margin = new Padding(5, 3, 5, 3);
            btnItemDetails.Name = "btnItemDetails";
            btnItemDetails.Size = new Size(110, 30);
            btnItemDetails.TabIndex = 13;
            btnItemDetails.Text = "🔍 Item Details";
            btnItemDetails.UseVisualStyleBackColor = false;
            btnItemDetails.Click += btnItemDetails_Click;
            // 
            // BtnDeleteSupplier
            // 
            BtnDeleteSupplier.AutoSize = true;
            BtnDeleteSupplier.BackColor = Color.Crimson;
            BtnDeleteSupplier.FlatStyle = FlatStyle.Flat;
            BtnDeleteSupplier.ForeColor = Color.White;
            BtnDeleteSupplier.Location = new Point(605, 8);
            BtnDeleteSupplier.Margin = new Padding(5, 3, 5, 3);
            BtnDeleteSupplier.Name = "BtnDeleteSupplier";
            BtnDeleteSupplier.Size = new Size(113, 30);
            BtnDeleteSupplier.TabIndex = 3;
            BtnDeleteSupplier.Text = "❌ Delete Supplier";
            BtnDeleteSupplier.UseVisualStyleBackColor = false;
            BtnDeleteSupplier.Click += BtnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.SeaGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(728, 8);
            btnSave.Margin = new Padding(5, 3, 5, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 30);
            btnSave.TabIndex = 5;
            btnSave.Text = "💾 Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // FormSuppliers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 700);
            Controls.Add(mainLayout);
            MinimumSize = new Size(800, 550);
            Name = "FormSuppliers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Suppliers Management";
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            searchPanelFlow.ResumeLayout(false);
            searchPanelFlow.PerformLayout();
            panel_SupplierName.ResumeLayout(false);
            panel_SupplierName.PerformLayout();
            panel_ProductName.ResumeLayout(false);
            panel_ProductName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)suppliersGrid).EndInit();
            buttonsFlow.ResumeLayout(false);
            buttonsFlow.PerformLayout();
            ResumeLayout(false);
        }

        private TableLayoutPanel mainLayout;
        private FlowLayoutPanel searchPanelFlow;
        private FlowLayoutPanel buttonsFlow;
        private TextBox tb_GoodsOrService;
        private Panel panel_SupplierName;
        private TextBox tb_SupplierName;
        private Label lbl_SupplierName;
        private DataGridView suppliersGrid;
        private Button btnToggleTheme;
        private Button btnDeleteAll;
        private Button BtnDeleteSupplier;
        private Button btnImportExcel;
        private Button btnExportExcel;
        private Panel panel_ProductName;
        private Label lbl_ProductName;
        private Button btnSave;
        private Label lblTitle;
        private Label label1;
        private Button btnItemDetails;
    }
}