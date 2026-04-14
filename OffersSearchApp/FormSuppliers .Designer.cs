namespace OffersSearchApp
{
    partial class FormSuppliers
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
            mainLayout.Padding = new Padding(20, 15, 20, 15);
            mainLayout.RowCount = 3;
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.RowStyles.Add(new RowStyle());
            mainLayout.Size = new Size(1474, 756);
            mainLayout.TabIndex = 0;
            // 
            // searchPanelFlow
            // 
            searchPanelFlow.AutoScroll = true;
            searchPanelFlow.BackColor = Color.AliceBlue;
            searchPanelFlow.Controls.Add(lblTitle);
            searchPanelFlow.Controls.Add(label1);
            searchPanelFlow.Controls.Add(panel_SupplierName);
            searchPanelFlow.Controls.Add(panel_ProductName);
            searchPanelFlow.Dock = DockStyle.Fill;
            searchPanelFlow.Location = new Point(23, 18);
            searchPanelFlow.Name = "searchPanelFlow";
            searchPanelFlow.Padding = new Padding(5);
            searchPanelFlow.Size = new Size(1428, 100);
            searchPanelFlow.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(52, 152, 219);
            lblTitle.Location = new Point(8, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 32);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "➕ Suppliers Management";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(52, 152, 219);
            label1.Location = new Point(414, 35);
            label1.Margin = new Padding(3, 30, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(161, 32);
            label1.TabIndex = 3;
            label1.Text = "Search:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_SupplierName
            // 
            panel_SupplierName.Controls.Add(tb_SupplierName);
            panel_SupplierName.Controls.Add(lbl_SupplierName);
            panel_SupplierName.Location = new Point(581, 20);
            panel_SupplierName.Margin = new Padding(3, 15, 3, 3);
            panel_SupplierName.Name = "panel_SupplierName";
            panel_SupplierName.Size = new Size(130, 60);
            panel_SupplierName.TabIndex = 1;
            // 
            // tb_SupplierName
            // 
            tb_SupplierName.Location = new Point(0, 25);
            tb_SupplierName.Name = "tb_SupplierName";
            tb_SupplierName.Size = new Size(130, 23);
            tb_SupplierName.TabIndex = 0;
            // 
            // lbl_SupplierName
            // 
            lbl_SupplierName.Dock = DockStyle.Top;
            lbl_SupplierName.Location = new Point(0, 0);
            lbl_SupplierName.Name = "lbl_SupplierName";
            lbl_SupplierName.Size = new Size(130, 23);
            lbl_SupplierName.TabIndex = 1;
            lbl_SupplierName.Text = "Supplier Name";
            lbl_SupplierName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_ProductName
            // 
            panel_ProductName.Controls.Add(tb_GoodsOrService);
            panel_ProductName.Controls.Add(lbl_ProductName);
            panel_ProductName.Location = new Point(717, 20);
            panel_ProductName.Margin = new Padding(3, 15, 3, 3);
            panel_ProductName.Name = "panel_ProductName";
            panel_ProductName.Size = new Size(130, 60);
            panel_ProductName.TabIndex = 4;
            // 
            // tb_GoodsOrService
            // 
            tb_GoodsOrService.Location = new Point(0, 25);
            tb_GoodsOrService.Name = "tb_GoodsOrService";
            tb_GoodsOrService.Size = new Size(130, 23);
            tb_GoodsOrService.TabIndex = 0;
            // 
            // lbl_ProductName
            // 
            lbl_ProductName.Dock = DockStyle.Top;
            lbl_ProductName.Location = new Point(0, 0);
            lbl_ProductName.Name = "lbl_ProductName";
            lbl_ProductName.Size = new Size(130, 23);
            lbl_ProductName.TabIndex = 1;
            lbl_ProductName.Text = "Product Name";
            lbl_ProductName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // suppliersGrid
            // 
            suppliersGrid.AllowDrop = true;
            suppliersGrid.AllowUserToAddRows = false;
            suppliersGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            suppliersGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            suppliersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            suppliersGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            suppliersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            suppliersGrid.DefaultCellStyle = dataGridViewCellStyle3;
            suppliersGrid.Dock = DockStyle.Fill;
            suppliersGrid.EnableHeadersVisualStyles = false;
            suppliersGrid.Location = new Point(23, 124);
            suppliersGrid.MultiSelect = false;
            suppliersGrid.Name = "suppliersGrid";
            suppliersGrid.RowHeadersVisible = false;
            suppliersGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            suppliersGrid.RowTemplate.Height = 40;
            suppliersGrid.ScrollBars = ScrollBars.Vertical;
            suppliersGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            suppliersGrid.Size = new Size(1428, 572);
            suppliersGrid.TabIndex = 1;
            suppliersGrid.DragDrop += SuppliersGrid_DragDrop;
            suppliersGrid.DragEnter += SuppliersGrid_DragEnter;
            suppliersGrid.KeyDown += SuppliersGrid_KeyDown;
            // 
            // buttonsFlow
            // 
            buttonsFlow.Anchor = AnchorStyles.None;
            buttonsFlow.AutoSize = true;
            buttonsFlow.Controls.Add(btnToggleTheme);
            buttonsFlow.Controls.Add(btnImportExcel);
            buttonsFlow.Controls.Add(btnExportExcel);
            buttonsFlow.Controls.Add(btnDeleteAll);
            buttonsFlow.Controls.Add(btnItemDetails);
            buttonsFlow.Controls.Add(BtnDeleteSupplier);
            buttonsFlow.Controls.Add(btnSave);
            buttonsFlow.Location = new Point(23, 702);
            buttonsFlow.Name = "buttonsFlow";
            buttonsFlow.Size = new Size(1428, 36);
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
            btnToggleTheme.Margin = new Padding(3, 3, 300, 3);
            btnToggleTheme.Name = "btnToggleTheme";
            btnToggleTheme.Size = new Size(130, 30);
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
            btnImportExcel.Location = new Point(436, 3);
            btnImportExcel.Name = "btnImportExcel";
            btnImportExcel.Size = new Size(130, 30);
            btnImportExcel.TabIndex = 1;
            btnImportExcel.Text = "Import from Excel";
            btnImportExcel.UseVisualStyleBackColor = false;
            btnImportExcel.Click += BtnImportExcel_Click;
            // 
            // btnExportExcel
            // 
            btnExportExcel.AutoSize = true;
            btnExportExcel.BackColor = Color.SeaGreen;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(572, 3);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(130, 30);
            btnExportExcel.TabIndex = 2;
            btnExportExcel.Text = "Export To Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += BtnExportExcel_Click;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.AutoSize = true;
            btnDeleteAll.BackColor = Color.Crimson;
            btnDeleteAll.FlatStyle = FlatStyle.Flat;
            btnDeleteAll.ForeColor = Color.White;
            btnDeleteAll.Location = new Point(708, 3);
            btnDeleteAll.Margin = new Padding(3, 3, 180, 3);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(130, 30);
            btnDeleteAll.TabIndex = 4;
            btnDeleteAll.Text = "Delete All";
            btnDeleteAll.UseVisualStyleBackColor = false;
            btnDeleteAll.Click += BtnDeleteAll_Click;
            // 
            // btnItemDetails
            // 
            btnItemDetails.AutoSize = true;
            btnItemDetails.BackColor = Color.FromArgb(255, 193, 7);
            btnItemDetails.FlatStyle = FlatStyle.Flat;
            btnItemDetails.ForeColor = Color.White;
            btnItemDetails.Location = new Point(1021, 3);
            btnItemDetails.Name = "btnItemDetails";
            btnItemDetails.Size = new Size(140, 30);
            btnItemDetails.TabIndex = 13;
            btnItemDetails.Text = "Item Details";
            btnItemDetails.UseVisualStyleBackColor = false;
            btnItemDetails.Click += btnItemDetails_Click;
            // 
            // BtnDeleteSupplier
            // 
            BtnDeleteSupplier.AutoSize = true;
            BtnDeleteSupplier.BackColor = Color.Crimson;
            BtnDeleteSupplier.FlatStyle = FlatStyle.Flat;
            BtnDeleteSupplier.ForeColor = Color.White;
            BtnDeleteSupplier.Location = new Point(1167, 3);
            BtnDeleteSupplier.Name = "BtnDeleteSupplier";
            BtnDeleteSupplier.Size = new Size(130, 30);
            BtnDeleteSupplier.TabIndex = 3;
            BtnDeleteSupplier.Text = "Delete Supplier";
            BtnDeleteSupplier.UseVisualStyleBackColor = false;
            BtnDeleteSupplier.Click += BtnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.BackColor = Color.SeaGreen;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(1303, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(130, 30);
            btnSave.TabIndex = 5;
            btnSave.Text = "💾 Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // FormSuppliers
            // 
            ClientSize = new Size(1474, 756);
            Controls.Add(mainLayout);
            Name = "FormSuppliers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Suppliers Management";
            mainLayout.ResumeLayout(false);
            mainLayout.PerformLayout();
            searchPanelFlow.ResumeLayout(false);
            panel_SupplierName.ResumeLayout(false);
            panel_SupplierName.PerformLayout();
            panel_ProductName.ResumeLayout(false);
            panel_ProductName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)suppliersGrid).EndInit();
            buttonsFlow.ResumeLayout(false);
            buttonsFlow.PerformLayout();
            ResumeLayout(false);
        }

        // Controls
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