using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OffersSearchApp
{
    public partial class FormAddOffer : Form
    {
        private readonly string connStr;

        public FormAddOffer(string connectionString)
        {
            InitializeComponent();
            connStr = connectionString;
        }

        private int GetNextOfferId(MySqlConnection conn)
        {
            string query = "SELECT MAX(OfferID) FROM Offers";

            using var cmd = new MySqlCommand(query, conn);
            var result = cmd.ExecuteScalar();

            return (result != DBNull.Value && result != null)
                ? Convert.ToInt32(result) + 1
                : 1;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                int nextId = GetNextOfferId(conn);

                string query = @"INSERT INTO Offers
                        (OfferID, ProductName, SupplierName, Contact, Country, Quantity, Price, Material, Size, Type, Quarter)
                        VALUES
                        (@OfferID, @ProductName, @SupplierName, @Contact, @Country, @Quantity, @Price, @Material, @Size, @Type, @Quarter)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OfferID", nextId);
                    cmd.Parameters.AddWithValue("@ProductName", tbProductName.Text.Trim());
                    cmd.Parameters.AddWithValue("@SupplierName", tbSupplierName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Contact", string.IsNullOrWhiteSpace(tbContact.Text) ? DBNull.Value : tbContact.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", string.IsNullOrWhiteSpace(tbCountry.Text) ? DBNull.Value : tbCountry.Text.Trim());
                    cmd.Parameters.AddWithValue("@Quantity", ParseNullableInt(tbQuantity.Text));
                    cmd.Parameters.AddWithValue("@Price", ParseNullableDecimal(tbPrice.Text));
                    cmd.Parameters.AddWithValue("@Material", string.IsNullOrWhiteSpace(tbMaterial.Text) ? DBNull.Value : tbMaterial.Text.Trim());
                    cmd.Parameters.AddWithValue("@Size", string.IsNullOrWhiteSpace(tbSize.Text) ? DBNull.Value : tbSize.Text.Trim());
                    cmd.Parameters.AddWithValue("@Type", string.IsNullOrWhiteSpace(tbType.Text) ? DBNull.Value : tbType.Text.Trim());
                    cmd.Parameters.AddWithValue("@Quarter", string.IsNullOrWhiteSpace(tbQuarter.Text) ? DBNull.Value : tbQuarter.Text.Trim());

                    cmd.ExecuteNonQuery(); 
                }

                MessageBox.Show("تم حفظ العرض بنجاح!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في قاعدة البيانات:\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(tbProductName.Text))
            {
                MessageBox.Show("الرجاء إدخال اسم المنتج.");
                tbProductName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbSupplierName.Text))
            {
                MessageBox.Show("الرجاء إدخال اسم المورد.");
                tbSupplierName.Focus();
                return false;
            }

            return true;
        }

        private object ParseNullableInt(string value)
        {
            return int.TryParse(value, out int result) ? result : (object)DBNull.Value;
        }

        private object ParseNullableDecimal(string value)
        {
            return decimal.TryParse(value, out decimal result) ? result : (object)DBNull.Value;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
