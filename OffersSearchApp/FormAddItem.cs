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
                    string query = @"SELECT OfferID, ProductName, SupplierName, Contact, Quantity, Material, Size, Type, Price, Country, Quarter, IsSelected FROM offers 
                             WHERE ProductName LIKE @ProductName
                             ORDER BY OfferID";

                    using var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductName", "%"+productNameForEdit+"%");
                    using var adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(offersTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load data: " + ex.Message, "Error",
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
                offersTable.Columns.Add("IsSelected", typeof(bool));
            }

            dgvOffers.DataSource = offersTable;

            if (dgvOffers.Columns["IsSelected"] != null)
            {
                dgvOffers.Columns["IsSelected"].Visible = false;
            }

            ConfigureDgvOffersColumns();
            if (dgvOffers.Columns["Price"] != null)
            {
                dgvOffers.Columns["Price"].DefaultCellStyle.Format = "C";
            }

            if (string.IsNullOrEmpty(productNameForEdit))
            {
                AddNewEmptyRow();
            }
        }

        private void DgvOffers_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyColorsBasedOnSelection();
        }

        private void DgvOffers_DragEnter(object? sender, DragEventArgs e)
        {
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
            string? draggedText = e.Data?.GetData(DataFormats.UnicodeText)?.ToString()
                                  ?? e.Data?.GetData(DataFormats.StringFormat)?.ToString()
                                  ?? e.Data?.GetData(DataFormats.Text)?.ToString();

            if (string.IsNullOrEmpty(draggedText))
                return;

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
            newRow["OfferID"] = DBNull.Value;
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
            newRow["IsSelected"] = false;
            offersTable.Rows.Add(newRow);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData(true);
        }
        private void SaveData(bool closeAfterSave)
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
                MessageBox.Show("Please ensure that at least one row contains both the Product Name and Supplier Name.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        (OfferID, ProductName, SupplierName, Contact, Country, Quantity, Price, Material, Size, Type, Quarter, IsSelected)
                        VALUES
                        (@OfferID, @ProductName, @SupplierName, @Contact, @Country, @Quantity, @Price, @Material, @Size, @Type, @Quarter, @IsSelected)";

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
                        cmd.Parameters.AddWithValue("@IsSelected", false);

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

                LoadData();

                string message = $"📝 Successfully added {insertedCount} new offer(s).\n✏️ Successfully updated {updatedCount} offer(s).";
                MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (closeAfterSave)
                    Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error occurred:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnToggleSelect_Click(object? sender, EventArgs e)
        {

            if (dgvOffers.CurrentRow.Cells["OfferID"].Value == null ||
                dgvOffers.CurrentRow.Cells["OfferID"].Value == DBNull.Value)
            {
                MessageBox.Show("This offer hasn’t been saved to the database yet. Please save it before proceeding.", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int offerId = Convert.ToInt32(dgvOffers.CurrentRow.Cells["OfferID"].Value);

            DataRowView? rowView = dgvOffers.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null)
            {
                MessageBox.Show("Unable to access the row data.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!offersTable.Columns.Contains("IsSelected"))
            {
                MessageBox.Show("The 'IsSelected' column does not exist in the data table.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool currentSelected = false;
            if (rowView["IsSelected"] != null && rowView["IsSelected"] != DBNull.Value)
            {
                currentSelected = Convert.ToBoolean(rowView["IsSelected"]);
            }

            bool newSelected = !currentSelected;

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                string updateQuery = "UPDATE Offers SET IsSelected = @IsSelected WHERE OfferID = @OfferID";
                using var cmd = new MySqlCommand(updateQuery, conn);
                cmd.Parameters.AddWithValue("@IsSelected", newSelected ? 1 : 0);
                cmd.Parameters.AddWithValue("@OfferID", offerId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    rowView["IsSelected"] = newSelected;

                    DataRow[] rows = offersTable.Select($"OfferID = {offerId}");
                    if (rows.Length > 0)
                    {
                        rows[0]["IsSelected"] = newSelected;
                    }
                    ApplyColorsBasedOnSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update the offer status:\n" + ex.Message, "Error",
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

        private object ParseNullableDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
                return DBNull.Value;
            if (decimal.TryParse(value.ToString(), out decimal result))
                return result;
            return DBNull.Value;
        }

        private void DgvOffers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true;
                SaveData(false);
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                e.SuppressKeyPress = true;
                AddNewEmptyRow();
                if (dgvOffers.Rows.Count > 0)
                {
                    dgvOffers.CurrentCell = dgvOffers.Rows[dgvOffers.Rows.Count - 1].Cells[0];
                }
            }
            else if (e.Control && e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;

                if (dgvOffers.CurrentRow != null)
                {
                    if (MessageBox.Show("Do you want to delete this row?", "Confirmation",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        dgvOffers.Rows.Remove(dgvOffers.CurrentRow);
                    }
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;

                if (dgvOffers.CurrentCell != null)
                    dgvOffers.CurrentCell.Value = DBNull.Value;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string? clipboardText = Clipboard.GetText();
                if (string.IsNullOrEmpty(clipboardText))
                    return;

                if (dgvOffers.CurrentCell != null)
                {
                    dgvOffers.CurrentCell.Value = clipboardText;
                }
            }
        }

        private void ConfigureDgvOffersColumns()
        {
            dgvOffers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // تحديد عرض الأعمدة
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

            // ضبط محاذاة النصوص لجميع الأعمدة
            foreach (DataGridViewColumn col in dgvOffers.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // محاذاة خاصة لعمود SupplierName
            if (dgvOffers.Columns["SupplierName"] != null)
            {
                dgvOffers.Columns["SupplierName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }
        private void ApplyColorsBasedOnSelection()
        {
            if (dgvOffers.Rows.Count == 0) return;

            if (!offersTable.Columns.Contains("IsSelected"))
                return;

            foreach (DataGridViewRow row in dgvOffers.Rows)
            {
                if (row.DataBoundItem != null)
                {
                    DataRowView rowView = (DataRowView)row.DataBoundItem;
                    bool isSelected = false;

                    if (rowView["IsSelected"] != null && rowView["IsSelected"] != DBNull.Value)
                    {
                        isSelected = Convert.ToBoolean(rowView["IsSelected"]);
                    }

                    if (isSelected)
                    {
                        row.DefaultCellStyle.BackColor = ThemeManager.SelectionBackColor;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = ThemeManager.GridBackgroundColor;
                        row.DefaultCellStyle.ForeColor = ThemeManager.TextColor;
                    }
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnToggleTheme_Click(object? sender, EventArgs e)
        {
            ThemeManager.ToggleTheme();
            ApplyColorsBasedOnSelection();
        }
    }
}