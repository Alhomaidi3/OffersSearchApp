using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OffersSearchApp
{
    public partial class FormEditOffer : Form
    {
        public bool IsSaved { get; private set; }

        private readonly string connStr;
        private readonly int offerId;

        public FormEditOffer(string connectionString, int offerID)
        {
            InitializeComponent();
            connStr = connectionString;
            offerId = offerID;

            LoadOfferData();
        }

        private void LoadOfferData()
        {
            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                string query = "SELECT * FROM Offers WHERE OfferID=@OfferID";
                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OfferID", offerId);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tbProductName.Text = reader["ProductName"].ToString();
                    tbSupplierName.Text = reader["SupplierName"].ToString();
                    tbContact.Text = reader["Contact"].ToString();
                    tbCountry.Text = reader["Country"].ToString();
                    tbQuantity.Text = reader["Quantity"]?.ToString() ?? "";
                    tbPrice.Text = reader["Price"]?.ToString() ?? "";
                    tbMaterial.Text = reader["Material"].ToString();
                    tbSize.Text = reader["Size"].ToString();
                    tbType.Text = reader["Type"].ToString();
                    tbQuarter.Text = reader["Quarter"].ToString();
                }
                else
                {
                    MessageBox.Show("رقم العرض غير موجود.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في قاعدة البيانات:\n" + ex.Message);
                Close();
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                using var conn = new MySqlConnection(connStr);
                conn.Open();

                string query = @"UPDATE Offers SET
                    ProductName=@ProductName,
                    SupplierName=@SupplierName,
                    Contact=@Contact,
                    Country=@Country,
                    Quantity=@Quantity,
                    Price=@Price,
                    Material=@Material,
                    Size=@Size,
                    Type=@Type,
                    Quarter=@Quarter
                    WHERE OfferID=@OfferID";

                using var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OfferID", offerId);
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
                IsSaved = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ أثناء تعديل العرض:\n" + ex.Message);
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