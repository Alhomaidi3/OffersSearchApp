using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OffersSearchApp
{
    public partial class FormSuppliers : BaseThemeForm
    {
        private readonly string connStr;
        private DataTable suppliersTable;
        private DataView suppliersView;
        public FormWindowState ParentWindowState { get; set; } = FormWindowState.Normal;


        private readonly string[] searchColumns = { "SupplierName", "GoodsOrService" };

        public FormSuppliers(string connectionString)
        {
            InitializeComponent();
            connStr = connectionString;

            foreach (var col in searchColumns)
            {
                var tb = Controls.Find("tb_" + col, true);
                if (tb.Length > 0 && tb[0] is TextBox textBox)
                    textBox.TextChanged += SearchFields_TextChanged;
            }

            LoadData();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.WindowState = ParentWindowState;
        }

        private void LoadData()
        {
            try
            {
                suppliersTable = new DataTable();
                Logger.Log("Loading suppliers data");

                using var conn = new MySqlConnection(connStr);
                conn.Open();

                string query = @"
                       SELECT SupplierID, SupplierName, SupplierAddress, Country,
                       CompanyOwnerName, CompanyOwnerPhone, CompanyOwnerEmail,
                       ContactPersonName, ContactPersonPhone, ContactPersonEmail,
                       RegistrationNumber, GoodsOrService, AccountOpeningDate,
                       Notes1, Notes2, Amount 
                       FROM Suppliers
                       ORDER BY SupplierID";

                using var cmd = new MySqlCommand(query, conn);
                using var adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(suppliersTable);

                suppliersView = new DataView(suppliersTable);
                suppliersGrid.DataSource = suppliersView;

                if (suppliersGrid.Columns["Amount"] != null)
                {
                    suppliersGrid.Columns["Amount"].DefaultCellStyle.Format = "C";
                }

                ApplyGridStyle();
            }
            catch (Exception ex)
            {
                Logger.Log("LoadData error: " + ex.Message, "ERROR");
                MessageBox.Show("Failed to load suppliers data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchFields_TextChanged(object? sender, EventArgs e)
        {
            if (suppliersView == null || suppliersTable == null) return;

            StringBuilder filter = new();

            foreach (var col in searchColumns)
            {
                var tb = Controls.Find("tb_" + col, true);
                if (tb.Length > 0 && tb[0] is TextBox textBox && !string.IsNullOrWhiteSpace(textBox.Text))
                {
                    string val = textBox.Text.Replace("'", "''");
                    filter.AppendFormat("{0} LIKE '%{1}%' AND ", col, val);
                }
            }

            if (filter.Length > 0)
                filter.Remove(filter.Length - 5, 5); // إزالة آخر " AND "

            suppliersView.RowFilter = filter.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(suppliersGrid.CurrentRow.Cells["SupplierID"].Value?.ToString(), out int supplierId))
            {
                MessageBox.Show("Invalid supplier ID.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this supplier?", "Delete Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using var conn = new MySqlConnection(connStr);
                    conn.Open();

                    string query = "DELETE FROM Suppliers WHERE SupplierID=@SupplierID";
                    using var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SupplierID", supplierId);

                    cmd.ExecuteNonQuery();

                    Logger.Log($"Supplier {supplierId} deleted");
                    MessageBox.Show("The supplier has been successfully deleted!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    Logger.Log("Delete supplier error: " + ex.Message, "ERROR");
                    MessageBox.Show("An error occurred while deleting:\n" + ex.Message);
                }
            }
        }

        private void BtnDeleteAll_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to delete all suppliers?\nThis action cannot be undone!",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();
                using var cmd = new MySqlCommand("DELETE FROM Suppliers", conn);
                cmd.ExecuteNonQuery();

                Logger.Log("All suppliers deleted");
                MessageBox.Show("All suppliers have been successfully deleted!");
                LoadData();
            }
            catch (Exception ex)
            {
                Logger.Log("Error while deleting: " + ex.Message, "ERROR");
                MessageBox.Show("Error while deleting: " + ex.Message);
            }
        }

        private void BtnImportExcel_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Excel or CSV Files|*.xlsx;*.xls;*.csv"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                Logger.Log("Suppliers imported from Excel");
                ImportService.ImportToDatabase(ofd.FileName, connStr, ImportService.ImportType.Suppliers);
                Logger.Log("Import completed");
                MessageBox.Show("Import completed successfully!");
                LoadData();
            }
            catch (Exception ex)
            {
                Logger.Log("Import error: " + ex.Message, "ERROR");
                MessageBox.Show("Error occurred during import: " + ex.Message);
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelExportService.ExportToCsv(suppliersView, "SuppliersReport");
                Logger.Log("Suppliers exported to CSV");
            }
            catch (Exception ex)
            {
                Logger.Log("Export error: " + ex.Message, "ERROR");
                MessageBox.Show("Error occurred during export: " + ex.Message);
            }
        }

        private void ApplyGridStyle()
        {

            foreach (DataGridViewColumn col in suppliersGrid.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (suppliersGrid.Columns["SupplierName"] != null)
                suppliersGrid.Columns["SupplierName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        private void SuppliersGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) ||
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
        private void SuppliersGrid_DragDrop(object sender, DragEventArgs e)
        {
            string draggedText = e.Data.GetData(DataFormats.UnicodeText)?.ToString()
                               ?? e.Data.GetData(DataFormats.StringFormat)?.ToString()
                               ?? e.Data.GetData(DataFormats.Text)?.ToString();

            if (string.IsNullOrEmpty(draggedText))
                return;

            Point clientPoint = suppliersGrid.PointToClient(new Point(e.X, e.Y));
            var hitTest = suppliersGrid.HitTest(clientPoint.X, clientPoint.Y);

            if (hitTest.RowIndex >= 0 && hitTest.ColumnIndex >= 0)
            {
                suppliersGrid.Rows[hitTest.RowIndex].Cells[hitTest.ColumnIndex].Value = draggedText;
            }
            else if (hitTest.RowIndex >= 0)
            {
                suppliersGrid.Rows[hitTest.RowIndex].Cells[0].Value = draggedText;
            }
            else
            {
                DataRow newRow = suppliersTable.NewRow();
                suppliersTable.Rows.Add(newRow);
                suppliersGrid.Rows[suppliersGrid.Rows.Count - 1].Cells[0].Value = draggedText;
            }
        }
        private void SuppliersGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true;
                SaveData(false);
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                e.SuppressKeyPress = true;
                suppliersTable.Rows.Add(suppliersTable.NewRow());
                Logger.Log("New empty row added");
                suppliersGrid.CurrentCell = suppliersGrid.Rows[suppliersGrid.Rows.Count - 1].Cells[0];
            }
            else if (e.Control && e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                if (suppliersGrid.CurrentRow != null)
                    suppliersGrid.Rows.Remove(suppliersGrid.CurrentRow);
            }
            else if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                if (suppliersGrid.CurrentCell != null)
                    suppliersGrid.CurrentCell.Value = DBNull.Value;
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string clipboardText = Clipboard.GetText();
                if (!string.IsNullOrEmpty(clipboardText) && suppliersGrid.CurrentCell != null)
                    suppliersGrid.CurrentCell.Value = clipboardText;
            }
        }
        private void SaveData(bool closeAfterSave)
        {
            Logger.Log("Suppliers save started");
            bool hasValidRow = false;
            foreach (DataRow row in suppliersTable.Rows)
            {
                string supplierName = row["SupplierName"]?.ToString()?.Trim();

                if (!string.IsNullOrEmpty(supplierName))
                {
                    hasValidRow = true;
                    break;
                }
            }

            if (!hasValidRow)
            {
                Logger.Log("Save failed: no valid supplier rows", "WARNING");
                MessageBox.Show("Please ensure that at least one row contains the Supplier Name.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                int insertedCount = 0;
                int updatedCount = 0;

                foreach (DataRow row in suppliersTable.Rows)
                {
                    string supplierName = row["SupplierName"]?.ToString()?.Trim();

                    if (string.IsNullOrEmpty(supplierName))
                        continue;

                    bool isNewRow = row.RowState == DataRowState.Added;
                    bool isModified = row.RowState == DataRowState.Modified;

                    if (!isNewRow && !isModified)
                        continue;

                    int supplierId = 0;
                    if (!isNewRow && row["SupplierID"] != DBNull.Value)
                        supplierId = Convert.ToInt32(row["SupplierID"]);

                    if (isNewRow || supplierId == 0)
                    {
                        string insertQuery = @"INSERT INTO Suppliers
                (SupplierName, SupplierAddress, Country, CompanyOwnerName, CompanyOwnerPhone,
                 CompanyOwnerEmail, ContactPersonName, ContactPersonPhone, ContactPersonEmail,
                 RegistrationNumber, GoodsOrService, AccountOpeningDate, Notes1, Notes2,Amount )
                 VALUES
                (@SupplierName, @SupplierAddress, @Country, @CompanyOwnerName, @CompanyOwnerPhone,
                 @CompanyOwnerEmail, @ContactPersonName, @ContactPersonPhone, @ContactPersonEmail,
                 @RegistrationNumber, @GoodsOrService, @AccountOpeningDate, @Notes1, @Notes2,@Amount)";

                        using var cmd = new MySqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                        cmd.Parameters.AddWithValue("@SupplierAddress", GetValueOrNull(row["SupplierAddress"]));
                        cmd.Parameters.AddWithValue("@Country", GetValueOrNull(row["Country"]));
                        cmd.Parameters.AddWithValue("@CompanyOwnerName", GetValueOrNull(row["CompanyOwnerName"]));
                        cmd.Parameters.AddWithValue("@CompanyOwnerPhone", GetValueOrNull(row["CompanyOwnerPhone"]));
                        cmd.Parameters.AddWithValue("@CompanyOwnerEmail", GetValueOrNull(row["CompanyOwnerEmail"]));
                        cmd.Parameters.AddWithValue("@ContactPersonName", GetValueOrNull(row["ContactPersonName"]));
                        cmd.Parameters.AddWithValue("@ContactPersonPhone", GetValueOrNull(row["ContactPersonPhone"]));
                        cmd.Parameters.AddWithValue("@ContactPersonEmail", GetValueOrNull(row["ContactPersonEmail"]));
                        cmd.Parameters.AddWithValue("@RegistrationNumber", GetValueOrNull(row["RegistrationNumber"]));
                        cmd.Parameters.AddWithValue("@GoodsOrService", GetValueOrNull(row["GoodsOrService"]));
                        cmd.Parameters.AddWithValue("@AccountOpeningDate", GetValueOrNull(row["AccountOpeningDate"]));
                        cmd.Parameters.AddWithValue("@Notes1", GetValueOrNull(row["Notes1"]));
                        cmd.Parameters.AddWithValue("@Notes2", GetValueOrNull(row["Notes2"]));
                        cmd.Parameters.AddWithValue("@Amount", ParseNullableDecimal(row["Amount"]));


                        cmd.ExecuteNonQuery();
                        insertedCount++;
                    }
                    else
                    {
                        string updateQuery = @"UPDATE Suppliers SET
                    SupplierName=@SupplierName,
                    SupplierAddress=@SupplierAddress,
                    Country=@Country,
                    CompanyOwnerName=@CompanyOwnerName,
                    CompanyOwnerPhone=@CompanyOwnerPhone,
                    CompanyOwnerEmail=@CompanyOwnerEmail,
                    ContactPersonName=@ContactPersonName,
                    ContactPersonPhone=@ContactPersonPhone,
                    ContactPersonEmail=@ContactPersonEmail,
                    RegistrationNumber=@RegistrationNumber,
                    GoodsOrService=@GoodsOrService,
                    AccountOpeningDate=@AccountOpeningDate,
                    Notes1=@Notes1,
                    Notes2=@Notes2,
                    Amount=@Amount
                    WHERE SupplierID=@SupplierID";

                        using var cmd = new MySqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                        cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                        cmd.Parameters.AddWithValue("@SupplierAddress", GetValueOrNull(row["SupplierAddress"]));
                        cmd.Parameters.AddWithValue("@Country", GetValueOrNull(row["Country"]));
                        cmd.Parameters.AddWithValue("@CompanyOwnerName", GetValueOrNull(row["CompanyOwnerName"]));
                        cmd.Parameters.AddWithValue("@CompanyOwnerPhone", GetValueOrNull(row["CompanyOwnerPhone"]));
                        cmd.Parameters.AddWithValue("@CompanyOwnerEmail", GetValueOrNull(row["CompanyOwnerEmail"]));
                        cmd.Parameters.AddWithValue("@ContactPersonName", GetValueOrNull(row["ContactPersonName"]));
                        cmd.Parameters.AddWithValue("@ContactPersonPhone", GetValueOrNull(row["ContactPersonPhone"]));
                        cmd.Parameters.AddWithValue("@ContactPersonEmail", GetValueOrNull(row["ContactPersonEmail"]));
                        cmd.Parameters.AddWithValue("@RegistrationNumber", GetValueOrNull(row["RegistrationNumber"]));
                        cmd.Parameters.AddWithValue("@GoodsOrService", GetValueOrNull(row["GoodsOrService"]));
                        cmd.Parameters.AddWithValue("@AccountOpeningDate", GetValueOrNull(row["AccountOpeningDate"]));
                        cmd.Parameters.AddWithValue("@Notes1", GetValueOrNull(row["Notes1"]));
                        cmd.Parameters.AddWithValue("@Notes2", GetValueOrNull(row["Notes2"]));
                        cmd.Parameters.AddWithValue("@Amount", ParseNullableDecimal(row["Amount"]));

                        cmd.ExecuteNonQuery();
                        updatedCount++;
                    }
                }
                LoadData();

                Logger.Log($"Suppliers saved: {insertedCount} inserted, {updatedCount} updated");
                MessageBox.Show($"📝 Successfully added {insertedCount} supplier(s).\n✏️ Successfully updated {updatedCount} supplier(s).",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (closeAfterSave)
                    Close();
            }
            catch (Exception ex)
            {
                Logger.Log("Save error: " + ex.Message, "ERROR");
                MessageBox.Show("Database error occurred:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private object GetValueOrNull(object value)
        {
            if (value == null || value == DBNull.Value)
                return DBNull.Value;
            string str = value.ToString().Trim();
            return string.IsNullOrEmpty(str) ? DBNull.Value : str;
        }
        private void BtnToggleTheme_Click(object sender, EventArgs e)
        {
            Logger.Log("Appearance changed");
            ThemeManager.ToggleTheme();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData(true);

        }

        private void btnItemDetails_Click(object sender, EventArgs e)
        {
            string productName = suppliersGrid.CurrentRow.Cells["GoodsOrService"].Value?.ToString();
            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Please select an offer with a valid product name.");
                return;
            }
            Logger.Log($"Opened supplier item details: {productName}");
            this.Hide();

            using var editForm = new FormAddItem(connStr, productName);
            editForm.ParentWindowState = this.WindowState;
            editForm.ShowDialog();
            this.Show();
            this.WindowState = editForm.WindowState;
            Logger.Log($"Cloesd supplier item details: {productName}");

            if (editForm.IsSaved)
            {
                LoadData();
            }
        }

    }
}