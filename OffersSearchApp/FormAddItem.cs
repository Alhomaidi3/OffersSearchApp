using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OffersSearchApp
{
    public partial class FormAddItem : BaseThemeForm
    {
        private readonly string connStr;
        private readonly string productNameForEdit;
        private DataTable offersTable;
        private bool isSaved = false;
        public FormWindowState ParentWindowState { get; set; } = FormWindowState.Normal;

        public bool IsSaved => isSaved;

        public FormAddItem(string connectionString) : this(connectionString, null) { }

        public FormAddItem(string connectionString, string productName)
        {
            InitializeComponent();
            connStr = connectionString;
            productNameForEdit = productName;

            LoadData();

            if (!string.IsNullOrEmpty(productNameForEdit))
            {
                lblTitle.Text = $"✏️ Edit Offers for: {productNameForEdit}";
                lblTitle.ForeColor = Color.FromArgb(52, 152, 219);
            }
            else
            {
                lblTitle.Text = "➕ Add New Offers";
                lblTitle.ForeColor = Color.SeaGreen;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = ParentWindowState;
        }

        private void LoadData()
        {
            offersTable = new DataTable();

            if (!string.IsNullOrEmpty(productNameForEdit))
            {
                try
                {
                    using var conn = new MySqlConnection(connStr);
                    conn.Open();
                    string query = @"SELECT OfferID, ProductName, SupplierName, Contact, Quantity, Material, Size, Type, Price, Country, Quarter FROM offers 
                                     WHERE ProductName = @ProductName
                                     ORDER BY OfferID";

                    using var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductName", productNameForEdit);
                    using var adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(offersTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("خطأ في تحميل البيانات: " + ex.Message, "خطأ",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                offersTable.Columns.Add("OfferID", typeof(int));
                offersTable.Columns.Add("ProductName", typeof(string));
                offersTable.Columns.Add("SupplierName", typeof(string));
                offersTable.Columns.Add("Contact", typeof(string));
                offersTable.Columns.Add("Country", typeof(string));
                offersTable.Columns.Add("Quantity", typeof(int));
                offersTable.Columns.Add("Price", typeof(decimal));
                offersTable.Columns.Add("Material", typeof(string));
                offersTable.Columns.Add("Size", typeof(string));
                offersTable.Columns.Add("Type", typeof(string));
                offersTable.Columns.Add("Quarter", typeof(string));
            }

            dgvOffers.DataSource = offersTable;
            SetColumnWidths();
            SetColumnAlignment();
            if (string.IsNullOrEmpty(productNameForEdit))
            {
                AddNewEmptyRow();
            }
        }

        private void DgvOffers_DragEnter(object? sender, DragEventArgs e)
        {
            // السماح بنسخ النص
            if (e.Data!.GetDataPresent(DataFormats.Text) ||
                e.Data.GetDataPresent(DataFormats.UnicodeText) ||
                e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void DgvOffers_DragDrop(object? sender, DragEventArgs e)
        {
            // الحصول على النص المسحوب
            string? draggedText = e.Data?.GetData(DataFormats.UnicodeText)?.ToString()
                                  ?? e.Data?.GetData(DataFormats.StringFormat)?.ToString()
                                  ?? e.Data?.GetData(DataFormats.Text)?.ToString();

            if (string.IsNullOrEmpty(draggedText))
                return;

            // تحديد موقع الإفلات
            Point clientPoint = dgvOffers.PointToClient(new Point(e.X, e.Y));
            var hitTest = dgvOffers.HitTest(clientPoint.X, clientPoint.Y);

            if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
            {
                // إفلات النص في الخلية المحددة
                dgvOffers.Rows[hitTest.RowIndex].Cells[hitTest.ColumnIndex].Value = draggedText;
            }
            else if (hitTest.RowIndex >= 0)
            {
                // إفلات في صف ولكن خارج الأعمدة (يضعه في العمود الأول)
                dgvOffers.Rows[hitTest.RowIndex].Cells[0].Value = draggedText;
            }
            else
            {
                // إفلات خارج الجدول - إضافة صف جديد
                AddNewEmptyRow();
                int lastRow = dgvOffers.Rows.Count - 1;
                dgvOffers.Rows[lastRow].Cells[0].Value = draggedText;
            }
        }

        private void AddNewEmptyRow()
        {
            DataRow newRow = offersTable.NewRow();
            newRow["ProductName"] = "";
            newRow["SupplierName"] = "";
            newRow["Contact"] = "";
            newRow["Country"] = "";
            newRow["Quantity"] = DBNull.Value;
            newRow["Price"] = DBNull.Value;
            newRow["Material"] = "";
            newRow["Size"] = "";
            newRow["Type"] = "";
            newRow["Quarter"] = "";
            offersTable.Rows.Add(newRow);
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool hasValidRow = false;
            foreach (DataRow row in offersTable.Rows)
            {
                string productName = row["ProductName"]?.ToString()?.Trim();
                string supplierName = row["SupplierName"]?.ToString()?.Trim();

                if (!string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(supplierName))
                {
                    hasValidRow = true;
                    break;
                }
            }

            if (!hasValidRow)
            {
                MessageBox.Show("الرجاء إدخال اسم المنتج واسم المورد في صف واحد على الأقل.",
                    "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                int insertedCount = 0;
                int updatedCount = 0;

                foreach (DataRow row in offersTable.Rows)
                {
                    string productName = row["ProductName"]?.ToString()?.Trim();
                    string supplierName = row["SupplierName"]?.ToString()?.Trim();

                    if (string.IsNullOrEmpty(productName) && string.IsNullOrEmpty(supplierName))
                        continue;

                    bool isNewRow = row.RowState == DataRowState.Added;
                    bool isModified = row.RowState == DataRowState.Modified;

                    if (!isNewRow && !isModified)
                        continue;

                    int offerId = 0;
                    if (!isNewRow && row["OfferID"] != DBNull.Value)
                        offerId = Convert.ToInt32(row["OfferID"]);

                    if (isNewRow || offerId == 0)
                    {
                        int nextId = GetNextOfferId(conn);
                        string insertQuery = @"INSERT INTO Offers
                                (OfferID, ProductName, SupplierName, Contact, Country, Quantity, Price, Material, Size, Type, Quarter)
                                VALUES
                                (@OfferID, @ProductName, @SupplierName, @Contact, @Country, @Quantity, @Price, @Material, @Size, @Type, @Quarter)";

                        using var cmd = new MySqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@OfferID", nextId);
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                        cmd.Parameters.AddWithValue("@Contact", GetValueOrNull(row["Contact"]));
                        cmd.Parameters.AddWithValue("@Country", GetValueOrNull(row["Country"]));
                        cmd.Parameters.AddWithValue("@Quantity", ParseNullableInt(row["Quantity"]));
                        cmd.Parameters.AddWithValue("@Price", ParseNullableDecimal(row["Price"]));
                        cmd.Parameters.AddWithValue("@Material", GetValueOrNull(row["Material"]));
                        cmd.Parameters.AddWithValue("@Size", GetValueOrNull(row["Size"]));
                        cmd.Parameters.AddWithValue("@Type", GetValueOrNull(row["Type"]));
                        cmd.Parameters.AddWithValue("@Quarter", GetValueOrNull(row["Quarter"]));

                        cmd.ExecuteNonQuery();
                        insertedCount++;
                    }
                    else
                    {
                        string updateQuery = @"UPDATE Offers SET
                                ProductName = @ProductName,
                                SupplierName = @SupplierName,
                                Contact = @Contact,
                                Country = @Country,
                                Quantity = @Quantity,
                                Price = @Price,
                                Material = @Material,
                                Size = @Size,
                                Type = @Type,
                                Quarter = @Quarter
                                WHERE OfferID = @OfferID";

                        using var cmd = new MySqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@OfferID", offerId);
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                        cmd.Parameters.AddWithValue("@Contact", GetValueOrNull(row["Contact"]));
                        cmd.Parameters.AddWithValue("@Country", GetValueOrNull(row["Country"]));
                        cmd.Parameters.AddWithValue("@Quantity", ParseNullableInt(row["Quantity"]));
                        cmd.Parameters.AddWithValue("@Price", ParseNullableDecimal(row["Price"]));
                        cmd.Parameters.AddWithValue("@Material", GetValueOrNull(row["Material"]));
                        cmd.Parameters.AddWithValue("@Size", GetValueOrNull(row["Size"]));
                        cmd.Parameters.AddWithValue("@Type", GetValueOrNull(row["Type"]));
                        cmd.Parameters.AddWithValue("@Quarter", GetValueOrNull(row["Quarter"]));

                        cmd.ExecuteNonQuery();
                        updatedCount++;
                    }
                }

                isSaved = true;
                string message = $"📝 تم إضافة {insertedCount} عرض جديد.\n✏️ تم تحديث {updatedCount} عرض.";
                MessageBox.Show(message, "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في قاعدة البيانات:\n" + ex.Message, "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetNextOfferId(MySqlConnection conn)
        {
            string query = "SELECT MAX(OfferID) FROM Offers";
            using var cmd = new MySqlCommand(query, conn);
            var result = cmd.ExecuteScalar();
            return (result != DBNull.Value && result != null) ? Convert.ToInt32(result) + 1 : 1;
        }
        private object GetValueOrNull(object value)
        {
            if (value == null || value == DBNull.Value)
                return DBNull.Value;
            string str = value.ToString().Trim();
            return string.IsNullOrEmpty(str) ? DBNull.Value : str;
        }
        private object ParseNullableInt(object value)
        {
            if (value == null || value == DBNull.Value)
                return DBNull.Value;
            if (int.TryParse(value.ToString(), out int result))
                return result;
            return DBNull.Value;
        }
        private void DgvOffers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                var currentCell = dgvOffers.CurrentCell;
                if (currentCell == null) return;

                int currentColumn = currentCell.ColumnIndex;
                int currentRow = currentCell.RowIndex;
                int totalColumns = dgvOffers.Columns.Count;

                if (currentColumn < totalColumns - 1)
                {
                    dgvOffers.CurrentCell = dgvOffers[currentColumn + 1, currentRow];
                }
                else
                {
                    if (currentRow < dgvOffers.Rows.Count - 1)
                    {
                        dgvOffers.CurrentCell = dgvOffers[0, currentRow + 1];
                    }
                    else
                    {
                        AddNewEmptyRow();
                        dgvOffers.CurrentCell = dgvOffers[0, dgvOffers.Rows.Count - 1];
                    }
                }
            }
        }
        private void SetColumnWidths()
        {
            dgvOffers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvOffers.Columns["OfferID"].FillWeight = 4;
            dgvOffers.Columns["ProductName"].FillWeight = 10;
            dgvOffers.Columns["SupplierName"].FillWeight = 20;
            dgvOffers.Columns["Contact"].FillWeight = 10;
            dgvOffers.Columns["Country"].FillWeight = 8;
            dgvOffers.Columns["Quantity"].FillWeight = 8;
            dgvOffers.Columns["Price"].FillWeight = 8;
            dgvOffers.Columns["Material"].FillWeight = 10;
            dgvOffers.Columns["Size"].FillWeight = 10;
            dgvOffers.Columns["Type"].FillWeight = 8;
            dgvOffers.Columns["Quarter"].FillWeight = 4;
        }
        private void SetColumnAlignment()
        {
            foreach (DataGridViewColumn col in dgvOffers.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvOffers.Columns["SupplierName"] != null)
            {
                dgvOffers.Columns["SupplierName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        private object ParseNullableDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
                return DBNull.Value;
            if (decimal.TryParse(value.ToString(), out decimal result))
                return result;
            return DBNull.Value;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnToggleTheme_Click(object? sender, EventArgs e)
        {
            ThemeManager.ToggleTheme();
        }
    }
}