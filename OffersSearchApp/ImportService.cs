using System.Data;
using System.Data.OleDb;
using System.Text;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace OffersSearchApp
{
    internal class ImportService
    {
        public static void ImportToDatabase(string path, string connStr)
        {
            DataTable table;

            if (string.Equals(Path.GetExtension(path), ".csv", StringComparison.OrdinalIgnoreCase))
                table = ReadCsv(path);
            else
                table = ReadExcel(path);

            if (table.Rows.Count == 0)
                throw new Exception("لا توجد بيانات في الملف.");

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                int currentId = GetLastOfferId(conn);

                foreach (DataRow row in table.Rows)
                {
                    currentId++;

                    string query = @"
            INSERT INTO offers
            (OfferID, ProductName, SupplierName, Contact, Country, Quantity, Price, Material, Size, Type, Quarter)
            VALUES
            (@OfferID, @ProductName, @SupplierName, @Contact, @Country, @Quantity, @Price, @Material, @Size, @Type, @Quarter)";

                    using var cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@OfferID", currentId);

                    cmd.Parameters.AddWithValue("@ProductName", row["ProductName"]);
                    cmd.Parameters.AddWithValue("@SupplierName", row["SupplierName"]);
                    cmd.Parameters.AddWithValue("@Contact", row["Contact"]);
                    cmd.Parameters.AddWithValue("@Country", row["Country"]);

                    var qtyObj = row["Quantity"];
                    if (qtyObj == null || string.IsNullOrWhiteSpace(qtyObj.ToString()))
                        cmd.Parameters.AddWithValue("@Quantity", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Quantity", int.Parse(qtyObj.ToString()));

                    var priceObj = row["Price"];
                    if (priceObj == null || string.IsNullOrWhiteSpace(priceObj.ToString()))
                        cmd.Parameters.AddWithValue("@Price", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(priceObj.ToString().Replace(',', '.'), CultureInfo.InvariantCulture));

                    cmd.Parameters.AddWithValue("@Material", row["Material"]);
                    cmd.Parameters.AddWithValue("@Size", row["Size"]);
                    cmd.Parameters.AddWithValue("@Type", row["Type"]);
                    cmd.Parameters.AddWithValue("@Quarter", row["Quarter"]);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطأ أثناء الاستيراد: " + ex.Message);
            }
        }

        private static int GetLastOfferId(MySqlConnection conn)
        {
            string query = "SELECT IFNULL(MAX(OfferID), 0) FROM offers";

            using var cmd = new MySqlCommand(query, conn);
            var result = cmd.ExecuteScalar();

            return Convert.ToInt32(result);
        }

        private static DataTable ReadExcel(string path)
        {
            string connStr = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'";

            using var conn = new OleDbConnection(connStr);
            var table = new DataTable();

            conn.Open();
            using var adapter = new OleDbDataAdapter("SELECT * FROM [Offers$]", conn);
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
            return [..values];
        }
    }
}