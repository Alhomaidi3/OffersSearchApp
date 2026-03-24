using MySql.Data.MySqlClient;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace OffersSearchApp
{
    public partial class Form1 : Form
    {
        private MySqlConnection? dbConnection;
        private DataView? offersView;
        private DataTable? offersTable;

        private readonly string[] searchColumns = { "ProductName", "SupplierName", "Material", "Size", "Price", "Contact", "Quarter" };
        private bool sortAscending = true;
        private string lastSortedColumn = "";

        public Form1()
        {
            InitializeComponent();

            // تفعيل البحث لكل TextBox
            foreach (var col in searchColumns)
            {
                var tb = Controls.Find("tb_" + col, true);
                if (tb.Length > 0 && tb[0] is TextBox textBox)
                    textBox.TextChanged += SearchFields_TextChanged;
            }

            btnClearSearch.Click += (s, e) => ClearSearchFields();
            btnImportExcel.Click += BtnImportExcel_Click;
            btnAddSupplier.Click += BtnAddSupplier_Click;
            offersGrid.ColumnHeaderMouseClick += OffersGrid_ColumnHeaderMouseClick;
            btnRefresh.Click += BtnRefresh_Click;
            btnDeleteAll.Click += BtnDeleteAll_Click;
            btnMenu.Click += BtnMenu_Click; // ربط زر القائمة
            btnExportExcel.Click += btnExportExcel_Click;

            ConnectDatabase();
            LoadData();
        }

        #region Database Methods

        private void ConnectDatabase()
        {
            string connStr = "Server=localhost;Database=OffersDB;Uid=root;Pwd=mall123;";
            dbConnection = new MySqlConnection(connStr);
        }

        private void LoadData()
        {
            if (dbConnection == null) return;

            try
            {
                dbConnection.Open();
                string query = "SELECT OfferID, ProductName, SupplierName, Contact, Quantity, Material, Size, Type, Price, Country, Quarter FROM offers";
                using var adapter = new MySqlDataAdapter(query, dbConnection);
                offersTable = new DataTable();
                adapter.Fill(offersTable);

                offersView = new DataView(offersTable);
                offersGrid.DataSource = offersView;

                UpdateRecordsCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message);
            }
            finally
            {
                dbConnection.Close();
            }
        }

        #endregion

        #region Buttons Events

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadData();
            MessageBox.Show("تم تحديث البيانات بنجاح!");
        }

        private void BtnDeleteAll_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "هل أنت متأكد من أنك تريد حذف كل السجلات؟\nهذه العملية غير قابلة للتراجع!",
                "تأكيد الحذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            if (dbConnection == null) return;

            try
            {
                dbConnection.Open();
                using var cmd = new MySqlCommand("DELETE FROM offers", dbConnection);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حذف كل السجلات بنجاح!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء الحذف: " + ex.Message);
            }
            finally
            {
                dbConnection.Close();
            }
        }

        private void BtnImportExcel_Click(object? sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            string path = ofd.FileName;
            string connStrExcel = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";

            using var excelConn = new OleDbConnection(connStrExcel);
            try
            {
                excelConn.Open();
                using var adapter = new OleDbDataAdapter("SELECT * FROM [Offers$]", excelConn);
                var excelTable = new DataTable();
                adapter.Fill(excelTable);

                if (excelTable.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد بيانات في ملف الإكسل.");
                    return;
                }

                if (dbConnection == null) return;
                dbConnection.Open();

                foreach (DataRow row in excelTable.Rows)
                {
                    string insertQuery = @"
                    INSERT INTO offers
                    (OfferID, ProductName, SupplierName, Contact, Country, Quantity, Price, Material, Size, Type, Quarter)
                    VALUES
                    (@OfferID, @ProductName, @SupplierName, @Contact, @Country, @Quantity, @Price, @Material, @Size, @Type, @Quarter)";

                    using var cmd = new MySqlCommand(insertQuery, dbConnection);
                    cmd.Parameters.AddWithValue("@OfferID", row["OfferID"]);
                    cmd.Parameters.AddWithValue("@ProductName", row["ProductName"]);
                    cmd.Parameters.AddWithValue("@SupplierName", row["SupplierName"]);
                    cmd.Parameters.AddWithValue("@Contact", row["Contact"]);
                    cmd.Parameters.AddWithValue("@Country", row["Country"]);
                    cmd.Parameters.AddWithValue("@Quantity", row["Quantity"]);
                    cmd.Parameters.AddWithValue("@Price", row["Price"]);
                    cmd.Parameters.AddWithValue("@Material", row["Material"]);
                    cmd.Parameters.AddWithValue("@Size", row["Size"]);
                    cmd.Parameters.AddWithValue("@Type", row["Type"]);
                    cmd.Parameters.AddWithValue("@Quarter", row["Quarter"]);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("تم استيراد البيانات بنجاح!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء الاستيراد: " + ex.Message);
            }
            finally
            {
                dbConnection?.Close();
            }
        }

        private void BtnAddSupplier_Click(object? sender, EventArgs e)
        {
            if (dbConnection == null) return;

            using var form = new FormAddOffer(dbConnection);
            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
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

        private void UpdateRecordsCount()
        {
            if (recordsCountLabel != null && offersView != null && offersTable != null)
                recordsCountLabel.Text = $"عدد النتائج: {offersView.Count} / إجمالي السجلات: {offersTable.Rows.Count}";
        }

        private bool isExpanded = false;

        private void BtnMenu_Click(object? sender, EventArgs e)
        {
            if (isExpanded)
            {
                panel1.Width = panel1.MinimumSize.Width;
                isExpanded = false;
            }
            else
            {
                panel1.Width = panel1.MaximumSize.Width;
                isExpanded = true;
            }

            foreach (Control c in panel1.Controls)
            {
                if ((c is Button btn && btn != btnMenu) || c == cbQuarter)
                {
                    c.Visible = isExpanded;
                }
            }
        }

        #endregion

        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            try
            {
                ExcelExportService.ExportToCsv(offersView, "OffersReport");
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التصدير: " + ex.Message);
            }

        }
        private void btnWordReport_Click(object? sender, EventArgs e)
        {
            try
            {
                WordReportService.GenerateWordReport(offersTable, cbQuarter.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء إنشاء التقرير: " + ex.Message);
            }
        }
    }
}