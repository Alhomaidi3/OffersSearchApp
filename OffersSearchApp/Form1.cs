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
                string query = "SELECT OfferID, ProductName, SupplierName, Contact, Quantity, Material, Size, Type, Price, Country, Quarter FROM offers";
                using var adapter = new MySqlDataAdapter(query, conn);
                offersTable = new DataTable();
                adapter.Fill(offersTable);

                offersView = new DataView(offersTable);
                offersGrid.DataSource = offersView;
                SetColumnWidths();
                SetColumnAlignment();
                UpdateRecordsCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message);
            }
        }

        #endregion

        #region Buttons Events

        private void BtnDeleteAll_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من أنك تريد حذف كل السجلات؟\nهذه العملية غير قابلة للتراجع!",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                using var cmd = new MySqlCommand("DELETE FROM offers", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حذف كل السجلات بنجاح!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء الحذف: " + ex.Message);
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
                ImportService.ImportToDatabase(ofd.FileName, connStr);
                MessageBox.Show("تم الاستيراد بنجاح!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء الاستيراد: " + ex.Message);
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
                MessageBox.Show("حدث خطأ أثناء التصدير: " + ex.Message);
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
                MessageBox.Show("حدث خطأ أثناء إنشاء التقرير: " + ex.Message);
            }
        }

        private void BtnEditOffer_Click(object sender, EventArgs e)
        {
            if (offersGrid.CurrentRow == null)
            {
                MessageBox.Show("الرجاء اختيار العرض الذي تريد تعديله من الجدول.");
                return;
            }

            // Get the ProductName from the selected row
            string productName = offersGrid.CurrentRow.Cells["ProductName"].Value?.ToString();
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("الرجاء اختيار عرض يحتوي على اسم منتج صالح.");
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
            if (offersGrid.CurrentRow == null)
            {
                MessageBox.Show("الرجاء اختيار العرض الذي تريد حذفه من الجدول.");
                return;
            }

            if (!int.TryParse(offersGrid.CurrentRow.Cells["OfferID"].Value.ToString(), out int offerId))
            {
                MessageBox.Show("رقم العرض غير صالح.");
                return;
            }


            var result = MessageBox.Show("هل أنت متأكد أنك تريد حذف هذا العرض؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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

                    MessageBox.Show("تم حذف العرض بنجاح!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("حدث خطأ أثناء الحذف:\n" + ex.Message);
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
        private void SetColumnWidths()
        {
            offersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
        }
        private void SetColumnAlignment()
        {
            foreach (DataGridViewColumn col in offersGrid.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (offersGrid.Columns["SupplierName"] != null)
            {
                offersGrid.Columns["SupplierName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        private void UpdateRecordsCount()
        {
            if (recordsCountLabel != null && offersView != null && offersTable != null)
                recordsCountLabel.Text = $"عدد النتائج: {offersView.Count} / إجمالي السجلات: {offersTable.Rows.Count}";
        }

        #endregion

        private void offersGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || offersGrid.Rows[e.RowIndex].IsNewRow)
            {
                MessageBox.Show("الرجاء اختيار عرض صالح من الجدول.");
                return;
            }

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