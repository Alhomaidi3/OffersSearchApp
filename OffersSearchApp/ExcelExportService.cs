using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OffersSearchApp
{
    public static class ExcelExportService
    {
        public static void ExportToCsv(DataView dataView, string fileTitle = "ExportedData")
        {
            if (dataView == null || dataView.Count == 0 || dataView.Table == null || dataView.Table.Columns.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات للتصدير!");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "CSV File|*.csv",
                Title = "حفظ الملف",
                FileName = fileTitle + ".csv"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();

                // دالة مساعدة للتعامل مع علامات الاقتباس والفواصل
                static string Escape(string? s)
                {
                    if (string.IsNullOrEmpty(s)) return "\"\"";
                    return $"\"{s.Replace("\"", "\"\"")}\"";
                }

                var table = dataView.Table;

                // إضافة رؤوس الأعمدة
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    sb.Append(Escape(table.Columns[i].ColumnName));
                    if (i < table.Columns.Count - 1)
                        sb.Append(',');
                }
                sb.AppendLine();

                // إضافة بيانات الصفوف
                foreach (DataRowView row in dataView)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        sb.Append(Escape(row[i]?.ToString()));
                        if (i < table.Columns.Count - 1)
                            sb.Append(',');
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                MessageBox.Show("تم تصدير البيانات بنجاح!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ أثناء التصدير: " + ex.Message);
            }
        }
    }
}