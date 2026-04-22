using System.Data;
using System.Data.OleDb;
using System.Text;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace OffersSearchApp
{
    internal class ImportService
    {
        public enum ImportType
        {
            Offers,
            Suppliers
        }

        public static void ImportToDatabase(string path, string connStr, ImportType type)
        {
            DataTable table;

            if (string.Equals(Path.GetExtension(path), ".csv", StringComparison.OrdinalIgnoreCase))
                table = ReadCsv(path);
            else
                table = ReadExcel(path, type);

            if (table.Rows.Count == 0)
                throw new Exception("No data found in the file.");

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                if (type == ImportType.Offers)
                    ImportOffers(table, conn);
                else
                    ImportSuppliers(table, conn);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred during import: " + ex.Message);
            }
        }

        private static void ImportOffers(DataTable table, MySqlConnection conn)
        {
            int currentId = GetLastOfferId(conn);

            foreach (DataRow row in table.Rows)
            {
                currentId++;
                string query = @"
                    INSERT INTO offers
                    (OfferID, ProductName, SupplierName, Contact, Country, Quantity, Price, Material, Size, Type, Quarter, IsSelected)
                    VALUES
                    (@OfferID, @ProductName, @SupplierName, @Contact, @Country, @Quantity, @Price, @Material, @Size, @Type, @Quarter, @IsSelected)";

                using var cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@OfferID", currentId);
                cmd.Parameters.AddWithValue("@ProductName", row["ProductName"]);
                cmd.Parameters.AddWithValue("@SupplierName", row["SupplierName"]);
                cmd.Parameters.AddWithValue("@Contact", row["Contact"]);
                cmd.Parameters.AddWithValue("@Country", row["Country"]);

                cmd.Parameters.AddWithValue("@Quantity", ParseNullableInt(row["Quantity"]));
                cmd.Parameters.AddWithValue("@Price", ParseNullableDecimal(row["Price"]));
                cmd.Parameters.AddWithValue("@Material", row["Material"]);
                cmd.Parameters.AddWithValue("@Size", row["Size"]);
                cmd.Parameters.AddWithValue("@Type", row["Type"]);
                cmd.Parameters.AddWithValue("@Quarter", row["Quarter"]);

                bool isSelected = false;
                if (table.Columns.Contains("IsSelected") && row["IsSelected"] != null && row["IsSelected"] != DBNull.Value)
                {
                    string val = row["IsSelected"].ToString().Trim().ToUpper();
                    isSelected = (val == "TRUE" || val == "1");
                }
                cmd.Parameters.AddWithValue("@IsSelected", isSelected ? 1 : 0);

                cmd.ExecuteNonQuery();
            }
        }

        private static void ImportSuppliers(DataTable table, MySqlConnection conn)
        {
            int currentId = GetLastSupplierId(conn);

            foreach (DataRow row in table.Rows)
            {
                currentId++;
                string query = @"
                    INSERT INTO Suppliers
                    (SupplierID, SupplierName, SupplierAddress, Country,
                     CompanyOwnerName, CompanyOwnerPhone, CompanyOwnerEmail,
                     ContactPersonName, ContactPersonPhone, ContactPersonEmail,
                     RegistrationNumber, GoodsOrService, AccountOpeningDate,
                     Notes1, Notes2,Amount)
                    VALUES
                    (@SupplierID, @SupplierName, @SupplierAddress, @Country,
                     @CompanyOwnerName, @CompanyOwnerPhone, @CompanyOwnerEmail,
                     @ContactPersonName, @ContactPersonPhone, @ContactPersonEmail,
                     @RegistrationNumber, @GoodsOrService, @AccountOpeningDate,
                     @Notes1, @Notes2,@Amount)";

                using var cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@SupplierID", currentId);
                cmd.Parameters.AddWithValue("@SupplierName", GetValue(row, "SupplierName"));
                cmd.Parameters.AddWithValue("@SupplierAddress", GetValue(row, "SupplierAddress"));
                cmd.Parameters.AddWithValue("@Country", GetValue(row, "Country"));
                cmd.Parameters.AddWithValue("@CompanyOwnerName", GetValue(row, "CompanyOwnerName"));
                cmd.Parameters.AddWithValue("@CompanyOwnerPhone", GetValue(row, "CompanyOwnerPhone"));
                cmd.Parameters.AddWithValue("@CompanyOwnerEmail", GetValue(row, "CompanyOwnerEmail"));
                cmd.Parameters.AddWithValue("@ContactPersonName", GetValue(row, "ContactPersonName"));
                cmd.Parameters.AddWithValue("@ContactPersonPhone", GetValue(row, "ContactPersonPhone"));
                cmd.Parameters.AddWithValue("@ContactPersonEmail", GetValue(row, "ContactPersonEmail"));
                cmd.Parameters.AddWithValue("@RegistrationNumber", GetValue(row, "RegistrationNumber"));
                cmd.Parameters.AddWithValue("@GoodsOrService", GetValue(row, "GoodsOrService"));
                cmd.Parameters.AddWithValue("@AccountOpeningDate", GetValue(row, "AccountOpeningDate"));
                cmd.Parameters.AddWithValue("@Notes1", GetValue(row, "Notes1"));
                cmd.Parameters.AddWithValue("@Notes2", GetValue(row, "Notes2"));
                cmd.Parameters.AddWithValue("@Amount", ParseNullableDecimal(row["Amount"]));


                cmd.ExecuteNonQuery();
            }
        }

        private static int GetLastOfferId(MySqlConnection conn)
        {
            using var cmd = new MySqlCommand("SELECT IFNULL(MAX(OfferID), 0) FROM offers", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private static int GetLastSupplierId(MySqlConnection conn)
        {
            using var cmd = new MySqlCommand("SELECT IFNULL(MAX(SupplierID), 0) FROM Suppliers", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private static object ParseNullableInt(object val)
        {
            if (val == null || string.IsNullOrWhiteSpace(val.ToString())) return DBNull.Value;
            return int.Parse(val.ToString());
        }

        private static object ParseNullableDecimal(object val)
        {
            if (val == null || string.IsNullOrWhiteSpace(val.ToString())) return DBNull.Value;
            return decimal.Parse(val.ToString().Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        private static string GetValue(DataRow row, string column)
        {
            if (!row.Table.Columns.Contains(column)) return DBNull.Value.ToString();
            var val = row[column];
            return (val == null || val == DBNull.Value) ? DBNull.Value.ToString() : val.ToString().Trim();
        }

        private static DataTable ReadExcel(string path, ImportType type)
        {
            string sheetName = type == ImportType.Offers ? "Offers" : "Suppliers";
            string connStr = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";
            using var conn = new OleDbConnection(connStr);
            var table = new DataTable();
            conn.Open();
            using var adapter = new OleDbDataAdapter($"SELECT * FROM [{sheetName}$]", conn);
            adapter.Fill(table);
            return table;
        }

        private static DataTable ReadCsv(string path)
        {
            var table = new DataTable();
            var lines = File.ReadAllLines(path, Encoding.UTF8);
            if (lines.Length == 0) return table;

            var headers = ParseCsvLine(lines[0]);
            foreach (var h in headers) table.Columns.Add(h);

            for (int i = 1; i < lines.Length; i++)
            {
                var values = ParseCsvLine(lines[i]);
                table.Rows.Add(values);
            }

            return table;
        }

        private static string[] ParseCsvLine(string line)
        {
            var values = new List<string>();
            bool inQuotes = false;
            var sb = new StringBuilder();

            foreach (char c in line)
            {
                if (c == '\"')
                    inQuotes = !inQuotes;
                else if (c == ',' && !inQuotes)
                {
                    values.Add(sb.ToString());
                    sb.Clear();
                }
                else
                    sb.Append(c);
            }

            values.Add(sb.ToString());
            return values.ToArray();
        }
    }
}