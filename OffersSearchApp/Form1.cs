using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace OffersSearchApp
{
    public partial class Form1 : Form
    {
        private DataView? offersView;
        private DataTable? offersTable;

        private readonly string[] searchColumns = ["ProductName", "SupplierName", "Material", "Size", "Price", "Contact", "Quarter"];
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

        private void BtnAddSupplier_Click(object? sender, EventArgs e)
        {
            using var form = new FormAddOffer(connStr);
            if (form.ShowDialog() == DialogResult.OK)
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
            if (offersGrid.CurrentCell == null)
            {
                MessageBox.Show("الرجاء اختيار العرض الذي تريد تعديله من الجدول.");
                return;
            }

            if (!int.TryParse(offersGrid.CurrentCell.Value?.ToString(), out int offerId))
            {
                MessageBox.Show("الخلية المحددة لا تحتوي على رقم صالح للعرض.");
                return;
            }

            using var editForm = new FormEditOffer(connStr, offerId);
            editForm.ShowDialog();

            if (editForm.IsSaved)
            {
                LoadData();
                MessageBox.Show("تم تعديل العرض بنجاح!");
            }
        }

        private void BtnDeleteOffer_Click(object sender, EventArgs e)
        {
            if (offersGrid.CurrentCell == null)
            {
                MessageBox.Show("الرجاء اختيار العرض الذي تريد حذفه من الجدول.");
                return;
            }

            if (!int.TryParse(offersGrid.CurrentCell.Value?.ToString(), out int offerId))
            {
                MessageBox.Show("الخلية المحددة لا تحتوي على رقم صالح للعرض.");
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
                if (c is GroupBox groupBox)
                {
                    groupBox.Visible = isExpanded;  
                }

                if (c is Button button && button != btnMenu)
                {
                    button.Visible = isExpanded;  
                }

            }
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

        #endregion

    }
}