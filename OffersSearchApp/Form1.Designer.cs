namespace OffersSearchApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        
        private Button btnMenu;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            recordsCountLabel = new Label();
            Panel_recordsCount = new Panel();
            panel1 = new Panel();
            btnMenu = new Button();
            btnDeleteAll = new Button();
            groupBox2 = new GroupBox();
            BtnDeleteOffer = new Button();
            btnAddOffer = new Button();
            btnEditOffer = new Button();
            groupBox1 = new GroupBox();
            btnImportExcel = new Button();
            cbQuarter = new ComboBox();
            btnExportExcel = new Button();
            btnWordReport = new Button();
            searchPanelFlow = new FlowLayoutPanel();
            panel_ProductName = new Panel();
            tb_ProductName = new TextBox();
            lbl_ProductName = new Label();
            panel_SupplierName = new Panel();
            tb_SupplierName = new TextBox();
            lbl_SupplierName = new Label();
            panel_Material = new Panel();
            tb_Material = new TextBox();
            lbl_Material = new Label();
            panel_Size = new Panel();
            tb_Size = new TextBox();
            lbl_Size = new Label();
            panel_Price = new Panel();
            tb_Price = new TextBox();
            lbl_Price = new Label();
            panel_Contact = new Panel();
            tb_Contact = new TextBox();
            lbl_Contact = new Label();
            panel_Quarter = new Panel();
            tb_Quarter = new TextBox();
            lbl_Quarter = new Label();
            btnClearSearch = new Button();
            offersGrid = new DataGridView();
            Panel_recordsCount.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            searchPanelFlow.SuspendLayout();
            panel_ProductName.SuspendLayout();
            panel_SupplierName.SuspendLayout();
            panel_Material.SuspendLayout();
            panel_Size.SuspendLayout();
            panel_Price.SuspendLayout();
            panel_Contact.SuspendLayout();
            panel_Quarter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)offersGrid).BeginInit();
            SuspendLayout();
            // 
            // recordsCountLabel
            // 
            recordsCountLabel.Dock = DockStyle.Right;
            recordsCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            recordsCountLabel.Location = new Point(1204, 0);
            recordsCountLabel.Name = "recordsCountLabel";
            recordsCountLabel.Size = new Size(250, 20);
            recordsCountLabel.TabIndex = 2;
            recordsCountLabel.Text = "عدد النتائج: 0 / إجمالي";
            recordsCountLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Panel_recordsCount
            // 
            Panel_recordsCount.BackColor = Color.AliceBlue;
            Panel_recordsCount.Controls.Add(recordsCountLabel);
            Panel_recordsCount.Dock = DockStyle.Bottom;
            Panel_recordsCount.Location = new Point(10, 726);
            Panel_recordsCount.Name = "Panel_recordsCount";
            Panel_recordsCount.Size = new Size(1454, 20);
            Panel_recordsCount.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = Color.AliceBlue;
            panel1.Controls.Add(btnMenu);
            panel1.Controls.Add(btnDeleteAll);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(10, 10);
            panel1.MaximumSize = new Size(160, 0);
            panel1.MinimumSize = new Size(40, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(40, 716);
            panel1.TabIndex = 11;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.AliceBlue;
            btnMenu.Dock = DockStyle.Top;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnMenu.Location = new Point(0, 0);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(40, 50);
            btnMenu.TabIndex = 4;
            btnMenu.Text = "☰";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += BtnMenu_Click;
            // 
            // btnDeleteAll
            // 
            btnDeleteAll.AutoSize = true;
            btnDeleteAll.BackColor = Color.Crimson;
            btnDeleteAll.FlatStyle = FlatStyle.Flat;
            btnDeleteAll.ForeColor = Color.White;
            btnDeleteAll.Location = new Point(10, 466);
            btnDeleteAll.Name = "btnDeleteAll";
            btnDeleteAll.Size = new Size(130, 30);
            btnDeleteAll.TabIndex = 1;
            btnDeleteAll.Text = "Delete All";
            btnDeleteAll.UseVisualStyleBackColor = false;
            btnDeleteAll.Visible = false;
            btnDeleteAll.Click += BtnDeleteAll_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(BtnDeleteOffer);
            groupBox2.Controls.Add(btnAddOffer);
            groupBox2.Controls.Add(btnEditOffer);
            groupBox2.Location = new Point(0, 120);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(150, 140);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Offers Management";
            groupBox2.Visible = false;
            // 
            // BtnDeleteOffer
            // 
            BtnDeleteOffer.AutoSize = true;
            BtnDeleteOffer.BackColor = Color.Crimson;
            BtnDeleteOffer.FlatStyle = FlatStyle.Flat;
            BtnDeleteOffer.ForeColor = Color.White;
            BtnDeleteOffer.Location = new Point(10, 100);
            BtnDeleteOffer.Name = "BtnDeleteOffer";
            BtnDeleteOffer.Size = new Size(130, 30);
            BtnDeleteOffer.TabIndex = 7;
            BtnDeleteOffer.Text = "Delete Offer";
            BtnDeleteOffer.UseVisualStyleBackColor = false;
            BtnDeleteOffer.Click += BtnDeleteOffer_Click;
            // 
            // btnAddOffer
            // 
            btnAddOffer.AutoSize = true;
            btnAddOffer.BackColor = Color.FromArgb(52, 152, 219);
            btnAddOffer.FlatStyle = FlatStyle.Flat;
            btnAddOffer.ForeColor = Color.White;
            btnAddOffer.Location = new Point(10, 20);
            btnAddOffer.Name = "btnAddOffer";
            btnAddOffer.Size = new Size(130, 30);
            btnAddOffer.TabIndex = 2;
            btnAddOffer.Text = "Add Offer";
            btnAddOffer.UseVisualStyleBackColor = false;
            btnAddOffer.Click += BtnAddSupplier_Click;
            // 
            // btnEditOffer
            // 
            btnEditOffer.AutoSize = true;
            btnEditOffer.BackColor = Color.FromArgb(52, 152, 219);
            btnEditOffer.FlatStyle = FlatStyle.Flat;
            btnEditOffer.ForeColor = Color.White;
            btnEditOffer.Location = new Point(10, 60);
            btnEditOffer.Name = "btnEditOffer";
            btnEditOffer.Size = new Size(130, 30);
            btnEditOffer.TabIndex = 0;
            btnEditOffer.Text = "Edit Offer";
            btnEditOffer.UseVisualStyleBackColor = false;
            btnEditOffer.Click += BtnEditOffer_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnImportExcel);
            groupBox1.Controls.Add(cbQuarter);
            groupBox1.Controls.Add(btnExportExcel);
            groupBox1.Controls.Add(btnWordReport);
            groupBox1.Location = new Point(0, 276);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(150, 175);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Display and Export Data";
            groupBox1.Visible = false;
            // 
            // btnImportExcel
            // 
            btnImportExcel.AutoSize = true;
            btnImportExcel.BackColor = Color.SeaGreen;
            btnImportExcel.FlatStyle = FlatStyle.Flat;
            btnImportExcel.ForeColor = Color.White;
            btnImportExcel.Location = new Point(10, 20);
            btnImportExcel.Name = "btnImportExcel";
            btnImportExcel.Size = new Size(130, 30);
            btnImportExcel.TabIndex = 3;
            btnImportExcel.Text = "Import from Excel";
            btnImportExcel.UseVisualStyleBackColor = false;
            btnImportExcel.Click += BtnImportExcel_Click;
            // 
            // cbQuarter
            // 
            cbQuarter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbQuarter.FormattingEnabled = true;
            cbQuarter.Items.AddRange(new object[] { "Q1", "Q2", "Q3", "Q4" });
            cbQuarter.Location = new Point(10, 140);
            cbQuarter.Name = "cbQuarter";
            cbQuarter.Size = new Size(130, 23);
            cbQuarter.TabIndex = 6;
            cbQuarter.Text = "Quarter";
            // 
            // btnExportExcel
            // 
            btnExportExcel.AutoSize = true;
            btnExportExcel.BackColor = Color.SeaGreen;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(10, 60);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(130, 30);
            btnExportExcel.TabIndex = 5;
            btnExportExcel.Text = "Expor To Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += BtnExportExcel_Click;
            // 
            // btnWordReport
            // 
            btnWordReport.AutoSize = true;
            btnWordReport.BackColor = Color.FromArgb(41, 85, 152);
            btnWordReport.FlatStyle = FlatStyle.Flat;
            btnWordReport.ForeColor = Color.White;
            btnWordReport.Location = new Point(10, 100);
            btnWordReport.Name = "btnWordReport";
            btnWordReport.Size = new Size(130, 30);
            btnWordReport.TabIndex = 6;
            btnWordReport.Text = "Word Report";
            btnWordReport.UseVisualStyleBackColor = false;
            btnWordReport.Click += BtnWordReport_Click;
            // 
            // searchPanelFlow
            // 
            searchPanelFlow.AutoScroll = true;
            searchPanelFlow.BackColor = Color.AliceBlue;
            searchPanelFlow.Controls.Add(panel_ProductName);
            searchPanelFlow.Controls.Add(panel_SupplierName);
            searchPanelFlow.Controls.Add(panel_Material);
            searchPanelFlow.Controls.Add(panel_Size);
            searchPanelFlow.Controls.Add(panel_Price);
            searchPanelFlow.Controls.Add(panel_Contact);
            searchPanelFlow.Controls.Add(panel_Quarter);
            searchPanelFlow.Controls.Add(btnClearSearch);
            searchPanelFlow.Dock = DockStyle.Top;
            searchPanelFlow.Location = new Point(50, 10);
            searchPanelFlow.Name = "searchPanelFlow";
            searchPanelFlow.Size = new Size(1414, 120);
            searchPanelFlow.TabIndex = 9;
            searchPanelFlow.WrapContents = false;
            // 
            // panel_ProductName
            // 
            panel_ProductName.Controls.Add(tb_ProductName);
            panel_ProductName.Controls.Add(lbl_ProductName);
            panel_ProductName.Location = new Point(5, 20);
            panel_ProductName.Margin = new Padding(5, 20, 5, 5);
            panel_ProductName.Name = "panel_ProductName";
            panel_ProductName.Size = new Size(130, 60);
            panel_ProductName.TabIndex = 0;
            // 
            // tb_ProductName
            // 
            tb_ProductName.Location = new Point(0, 25);
            tb_ProductName.Name = "tb_ProductName";
            tb_ProductName.Size = new Size(130, 23);
            tb_ProductName.TabIndex = 1;
            tb_ProductName.Tag = "ProductName";
            // 
            // lbl_ProductName
            // 
            lbl_ProductName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_ProductName.Location = new Point(0, 0);
            lbl_ProductName.Name = "lbl_ProductName";
            lbl_ProductName.Size = new Size(130, 20);
            lbl_ProductName.TabIndex = 0;
            lbl_ProductName.Text = "Product Name";
            lbl_ProductName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_SupplierName
            // 
            panel_SupplierName.Controls.Add(tb_SupplierName);
            panel_SupplierName.Controls.Add(lbl_SupplierName);
            panel_SupplierName.Location = new Point(145, 20);
            panel_SupplierName.Margin = new Padding(5, 20, 5, 5);
            panel_SupplierName.Name = "panel_SupplierName";
            panel_SupplierName.Size = new Size(130, 60);
            panel_SupplierName.TabIndex = 1;
            // 
            // tb_SupplierName
            // 
            tb_SupplierName.Location = new Point(0, 25);
            tb_SupplierName.Name = "tb_SupplierName";
            tb_SupplierName.Size = new Size(130, 23);
            tb_SupplierName.TabIndex = 3;
            tb_SupplierName.Tag = "SupplierName";
            // 
            // lbl_SupplierName
            // 
            lbl_SupplierName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_SupplierName.Location = new Point(0, 0);
            lbl_SupplierName.Name = "lbl_SupplierName";
            lbl_SupplierName.Size = new Size(130, 20);
            lbl_SupplierName.TabIndex = 2;
            lbl_SupplierName.Text = "Supplier Name";
            lbl_SupplierName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Material
            // 
            panel_Material.Controls.Add(tb_Material);
            panel_Material.Controls.Add(lbl_Material);
            panel_Material.Location = new Point(285, 20);
            panel_Material.Margin = new Padding(5, 20, 5, 5);
            panel_Material.Name = "panel_Material";
            panel_Material.Size = new Size(130, 60);
            panel_Material.TabIndex = 1;
            // 
            // tb_Material
            // 
            tb_Material.Location = new Point(0, 25);
            tb_Material.Name = "tb_Material";
            tb_Material.Size = new Size(130, 23);
            tb_Material.TabIndex = 5;
            tb_Material.Tag = "Material";
            // 
            // lbl_Material
            // 
            lbl_Material.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Material.Location = new Point(0, 0);
            lbl_Material.Name = "lbl_Material";
            lbl_Material.Size = new Size(130, 20);
            lbl_Material.TabIndex = 4;
            lbl_Material.Text = "Material";
            lbl_Material.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Size
            // 
            panel_Size.Controls.Add(tb_Size);
            panel_Size.Controls.Add(lbl_Size);
            panel_Size.Location = new Point(425, 20);
            panel_Size.Margin = new Padding(5, 20, 5, 5);
            panel_Size.Name = "panel_Size";
            panel_Size.Size = new Size(130, 60);
            panel_Size.TabIndex = 1;
            // 
            // tb_Size
            // 
            tb_Size.Location = new Point(0, 25);
            tb_Size.Name = "tb_Size";
            tb_Size.Size = new Size(130, 23);
            tb_Size.TabIndex = 7;
            tb_Size.Tag = "Size";
            // 
            // lbl_Size
            // 
            lbl_Size.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Size.Location = new Point(0, 0);
            lbl_Size.Name = "lbl_Size";
            lbl_Size.Size = new Size(130, 20);
            lbl_Size.TabIndex = 6;
            lbl_Size.Text = "Size";
            lbl_Size.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Price
            // 
            panel_Price.Controls.Add(tb_Price);
            panel_Price.Controls.Add(lbl_Price);
            panel_Price.Location = new Point(565, 20);
            panel_Price.Margin = new Padding(5, 20, 5, 5);
            panel_Price.Name = "panel_Price";
            panel_Price.Size = new Size(130, 60);
            panel_Price.TabIndex = 1;
            // 
            // tb_Price
            // 
            tb_Price.Location = new Point(0, 25);
            tb_Price.Name = "tb_Price";
            tb_Price.Size = new Size(130, 23);
            tb_Price.TabIndex = 9;
            tb_Price.Tag = "Price";
            // 
            // lbl_Price
            // 
            lbl_Price.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Price.Location = new Point(0, 0);
            lbl_Price.Name = "lbl_Price";
            lbl_Price.Size = new Size(130, 20);
            lbl_Price.TabIndex = 8;
            lbl_Price.Text = "Price";
            lbl_Price.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Contact
            // 
            panel_Contact.Controls.Add(tb_Contact);
            panel_Contact.Controls.Add(lbl_Contact);
            panel_Contact.Location = new Point(705, 20);
            panel_Contact.Margin = new Padding(5, 20, 5, 5);
            panel_Contact.Name = "panel_Contact";
            panel_Contact.Size = new Size(130, 60);
            panel_Contact.TabIndex = 1;
            // 
            // tb_Contact
            // 
            tb_Contact.Location = new Point(0, 25);
            tb_Contact.Name = "tb_Contact";
            tb_Contact.Size = new Size(130, 23);
            tb_Contact.TabIndex = 11;
            tb_Contact.Tag = "Contact";
            // 
            // lbl_Contact
            // 
            lbl_Contact.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Contact.Location = new Point(0, 0);
            lbl_Contact.Name = "lbl_Contact";
            lbl_Contact.Size = new Size(130, 20);
            lbl_Contact.TabIndex = 10;
            lbl_Contact.Text = "Contact";
            lbl_Contact.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_Quarter
            // 
            panel_Quarter.Controls.Add(tb_Quarter);
            panel_Quarter.Controls.Add(lbl_Quarter);
            panel_Quarter.Location = new Point(845, 20);
            panel_Quarter.Margin = new Padding(5, 20, 5, 5);
            panel_Quarter.Name = "panel_Quarter";
            panel_Quarter.Size = new Size(130, 60);
            panel_Quarter.TabIndex = 1;
            // 
            // tb_Quarter
            // 
            tb_Quarter.Location = new Point(0, 25);
            tb_Quarter.Name = "tb_Quarter";
            tb_Quarter.Size = new Size(130, 23);
            tb_Quarter.TabIndex = 13;
            tb_Quarter.Tag = "Quarter";
            // 
            // lbl_Quarter
            // 
            lbl_Quarter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl_Quarter.Location = new Point(0, 0);
            lbl_Quarter.Name = "lbl_Quarter";
            lbl_Quarter.Size = new Size(130, 20);
            lbl_Quarter.TabIndex = 12;
            lbl_Quarter.Text = "Quarter";
            lbl_Quarter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClearSearch
            // 
            btnClearSearch.AutoSize = true;
            btnClearSearch.BackColor = Color.FromArgb(231, 76, 60);
            btnClearSearch.FlatAppearance.BorderSize = 0;
            btnClearSearch.FlatStyle = FlatStyle.Flat;
            btnClearSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearSearch.ForeColor = Color.White;
            btnClearSearch.Location = new Point(1000, 30);
            btnClearSearch.Margin = new Padding(20, 30, 10, 10);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(132, 27);
            btnClearSearch.TabIndex = 2;
            btnClearSearch.Text = "\U0001f9f9 مسح البحث";
            btnClearSearch.UseVisualStyleBackColor = false;
            // 
            // offersGrid
            // 
            offersGrid.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            offersGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            offersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(52, 152, 219);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            offersGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            offersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            offersGrid.DefaultCellStyle = dataGridViewCellStyle3;
            offersGrid.Dock = DockStyle.Fill;
            offersGrid.EnableHeadersVisualStyles = false;
            offersGrid.Location = new Point(50, 130);
            offersGrid.MultiSelect = false;
            offersGrid.Name = "offersGrid";
            offersGrid.ReadOnly = true;
            offersGrid.RowHeadersVisible = false;
            offersGrid.ScrollBars = ScrollBars.Vertical;
            offersGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            offersGrid.Size = new Size(1414, 596);
            offersGrid.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 756);
            Controls.Add(offersGrid);
            Controls.Add(searchPanelFlow);
            Controls.Add(panel1);
            Controls.Add(Panel_recordsCount);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Offers Search App";
            Panel_recordsCount.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            searchPanelFlow.ResumeLayout(false);
            searchPanelFlow.PerformLayout();
            panel_ProductName.ResumeLayout(false);
            panel_ProductName.PerformLayout();
            panel_SupplierName.ResumeLayout(false);
            panel_SupplierName.PerformLayout();
            panel_Material.ResumeLayout(false);
            panel_Material.PerformLayout();
            panel_Size.ResumeLayout(false);
            panel_Size.PerformLayout();
            panel_Price.ResumeLayout(false);
            panel_Price.PerformLayout();
            panel_Contact.ResumeLayout(false);
            panel_Contact.PerformLayout();
            panel_Quarter.ResumeLayout(false);
            panel_Quarter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)offersGrid).EndInit();
            ResumeLayout(false);
        }

        protected Label recordsCountLabel;
        private Panel Panel_recordsCount;
        private Panel panel1;
        private Button btnEditOffer;
        private Button btnDeleteAll;
        private Button btnAddOffer;
        private Button btnImportExcel;
        private FlowLayoutPanel searchPanelFlow;
        private Panel panel_ProductName;
        private TextBox tb_ProductName;
        private Label lbl_ProductName;
        private Panel panel_SupplierName;
        private TextBox tb_SupplierName;
        private Label lbl_SupplierName;
        private Panel panel_Material;
        private TextBox tb_Material;
        private Label lbl_Material;
        private Panel panel_Size;
        private TextBox tb_Size;
        private Label lbl_Size;
        private Panel panel_Price;
        private TextBox tb_Price;
        private Label lbl_Price;
        private Panel panel_Contact;
        private TextBox tb_Contact;
        private Label lbl_Contact;
        private Panel panel_Quarter;
        private TextBox tb_Quarter;
        private Label lbl_Quarter;
        private Button btnClearSearch;
        private Button btnExportExcel;
        private ComboBox cbQuarter;
        private Button btnWordReport;
        private DataGridView offersGrid;
        private Button BtnDeleteOffer;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}
