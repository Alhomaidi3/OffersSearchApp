using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace OffersSearchApp
{
    public partial class Form1 : BaseThemeForm
    {
        private DataView? offersView;
        private DataTable? offersTable;

        private readonly string[] searchColumns = ["ProductName", "SupplierName", "Material", "Size", "Price", "Contact", "Quarter"];
        private bool sortAscending = true;
        private string lastSortedColumn = "";

        public Form1()
        {
            InitializeComponent();

            foreach (var col in searchColumns)
            {
                var tb = Controls.Find("tb_" + col, true);
                if (tb.Length > 0 && tb[0] is TextBox textBox)
                    textBox.TextChanged += SearchFields_TextChanged;
            }

            btnClearSearch.Click += (s, e) => ClearSearchFields();
            offersGrid.ColumnHeaderMouseClick += OffersGrid_ColumnHeaderMouseClick;

            ConnectDatabase();
            LoadData();
        }

        #region Database Methods

        private string connStr = "";
        private void ConnectDatabase()
        {
            connStr = ConfigurationManager.ConnectionStrings["MyDb"].ConnectionString;
        }
        private void LoadData()
        {
            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                string query = "SELECT OfferID, ProductName, SupplierName, Contact, Quantity, Material, Size, Type, Price, Country, Quarter, IsSelected FROM offers";
                using var adapter = new MySqlDataAdapter(query, conn);
                offersTable = new DataTable();
                adapter.Fill(offersTable);

                offersView = new DataView(offersTable);
                offersGrid.DataSource = offersView;

                if (offersGrid.Columns["IsSelected"] != null)
                {
                    offersGrid.Columns["IsSelected"].Visible = false;
                }

                ConfigureGridColumns();
                UpdateRecordsCount();
                if (offersGrid.Columns["Price"] != null)
                {
                    offersGrid.Columns["Price"].DefaultCellStyle.Format = "C";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data: " + ex.Message);
            }
        }

        #endregion

        #region Buttons Events

        private void BtnDeleteAll_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete all records?\nThis action cannot be undone!",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                using var cmd = new MySqlCommand("DELETE FROM offers", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("All records have been successfully deleted!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting: " + ex.Message);
            }
        }

        private void BtnImportExcel_Click(object? sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Excel or CSV Files|*.xlsx;*.xls;*.csv"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                ImportService.ImportToDatabase(ofd.FileName, connStr, ImportService.ImportType.Offers);
                MessageBox.Show("Import completed successfully!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred during import: " + ex.Message);
            }
        }
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            using var form = new FormAddItem(connStr);
            form.ParentWindowState = this.WindowState;
            form.ShowDialog();

            this.Show();

            this.WindowState = form.ParentWindowState;

            if (form.IsSaved)
                LoadData();

        }

        private void BtnExportExcel_Click(object? sender, EventArgs e)
        {
            try
            {
                ExcelExportService.ExportToCsv(offersView!, "OffersReport");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred during export: " + ex.Message);
            }

        }

        private void BtnWordReport_Click(object? sender, EventArgs e)
        {
            try
            {
                WordReportService.GenerateWordReport(offersTable!, cbQuarter.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while generating the report: " + ex.Message);
            }
        }

        private void BtnEditOffer_Click(object sender, EventArgs e)
        {
            // Get the ProductName from the selected row
            string productName = offersGrid.CurrentRow.Cells["ProductName"].Value?.ToString();
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Please select an offer with a valid product name.");
                return;
            }
            this.Hide();

            using var editForm = new FormAddItem(connStr, productName);
            editForm.ParentWindowState = this.WindowState;
            editForm.ShowDialog();
            this.Show();

            this.WindowState = editForm.ParentWindowState;
            if (editForm.IsSaved)
            {
                LoadData();
            }
        }
        private void BtnDeleteOffer_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(offersGrid.CurrentRow.Cells["OfferID"].Value.ToString(), out int offerId))
            {
                MessageBox.Show("Invalid offer ID.");
                return;
            }


            var result = MessageBox.Show("Are you sure you want to delete this offer?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using var conn = new MySqlConnection(connStr);
                    conn.Open();

                    string query = "DELETE FROM Offers WHERE OfferID=@OfferID";
                    using var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@OfferID", offerId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("The offer has been successfully deleted!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting:\n" + ex.Message);
                }
            }
        }
        private void BtnToggleTheme_Click(object? sender, EventArgs e)
        {
            ThemeManager.ToggleTheme();
        }

        private bool isExpanded = false;

        private void BtnMenu_Click(object? sender, EventArgs e)
        {
            if (isExpanded)
            {
                // تصغير حجم الـ Sidebar
                mainLayout.ColumnStyles[0].Width = 40; // الحجم المصغر
                panelSidebar.MinimumSize = new Size(40, 0);
                isExpanded = false;
            }
            else
            {
                // تكبير حجم الـ Sidebar
                mainLayout.ColumnStyles[0].Width = 160; // الحجم الأصلي
                panelSidebar.MinimumSize = new Size(160, 0);
                isExpanded = true;
            }

            // إخفاء/إظهار المحتويات داخل الـ Sidebar
            foreach (Control c in panelSidebar.Controls)
            {
                if (c is GroupBox groupBox)
                {
                    groupBox.Visible = isExpanded;
                }

                if (c is Button button && button != btnMenu)
                {
                    button.Visible = isExpanded;
                }
            }

            // فرض إعادة التخطيط
            mainLayout.PerformLayout();
        }
        private void btnOpenSuppliers_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            using var frm = new FormSuppliers(connStr);
            frm.ShowDialog();

            this.Show();

        }

        #endregion

        #region Search & Sorting

        private void SearchFields_TextChanged(object? sender, EventArgs e)
        {
            if (offersView == null || offersTable == null) return;

            StringBuilder filter = new();

            foreach (var col in searchColumns)
            {
                var tb = Controls.Find("tb_" + col, true);
                if (tb.Length > 0 && tb[0] is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    string val = textBox.Text.Replace("'", "''");
                    if (offersTable.Columns[col].DataType == typeof(string))
                        filter.AppendFormat("{0} LIKE '%{1}%' AND ", col, val);
                    else
                        filter.AppendFormat("Convert([{0}], 'System.String') LIKE '{1}%' AND ", col, val);
                }
            }

            if (filter.Length > 0)
                filter.Remove(filter.Length - 5, 5);

            offersView.RowFilter = filter.ToString();
            UpdateRecordsCount();
        }

        private void OffersGrid_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (offersView == null) return;

            string colName = offersGrid.Columns[e.ColumnIndex].DataPropertyName;

            if (lastSortedColumn == colName)
                sortAscending = !sortAscending;
            else
            {
                lastSortedColumn = colName;
                sortAscending = true;
            }

            offersView.Sort = $"{colName} {(sortAscending ? "ASC" : "DESC")}";
        }

        private void ClearSearchFields()
        {
            foreach (var col in searchColumns)
            {
                var tb = Controls.Find("tb_" + col, true);
                if (tb.Length > 0 && tb[0] is TextBox textBox)
                    textBox.Text = "";
            }
        }
        private void ConfigureGridColumns()
        {
            offersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // تحديد عرض الأعمدة
            offersGrid.Columns["OfferID"].FillWeight = 6;
            offersGrid.Columns["ProductName"].FillWeight = 10;
            offersGrid.Columns["SupplierName"].FillWeight = 20;
            offersGrid.Columns["Contact"].FillWeight = 10;
            offersGrid.Columns["Country"].FillWeight = 7;
            offersGrid.Columns["Quantity"].FillWeight = 7;
            offersGrid.Columns["Price"].FillWeight = 7;
            offersGrid.Columns["Material"].FillWeight = 10;
            offersGrid.Columns["Size"].FillWeight = 10;
            offersGrid.Columns["Type"].FillWeight = 7;
            offersGrid.Columns["Quarter"].FillWeight = 6;

            // ضبط محاذاة النصوص لجميع الأعمدة
            foreach (DataGridViewColumn col in offersGrid.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // محاذاة خاصة لعمود SupplierName
            if (offersGrid.Columns["SupplierName"] != null)
            {
                offersGrid.Columns["SupplierName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        private void UpdateRecordsCount()
        {
            if (recordsCountLabel != null && offersView != null && offersTable != null)
                recordsCountLabel.Text = $"Records found: {offersView.Count} / Total records: {offersTable.Rows.Count}";
        }

        #endregion

        private void offersGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string productName = offersGrid.Rows[e.RowIndex].Cells["ProductName"].Value?.ToString();

            this.Hide();

            using var editForm = new FormAddItem(connStr, productName);
            editForm.ParentWindowState = this.WindowState;
            editForm.ShowDialog();
            this.Show();

            this.WindowState = editForm.ParentWindowState;
            if (editForm.IsSaved)
            {
                LoadData();
            }
        }

    }
}