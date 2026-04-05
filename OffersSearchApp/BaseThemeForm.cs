using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OffersSearchApp
{
    public class BaseThemeForm : Form
    {
        protected BaseThemeForm()
        {
            ThemeManager.OnThemeChanged += ApplyTheme;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyTheme();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ThemeManager.OnThemeChanged -= ApplyTheme;
            base.OnFormClosed(e);
        }

        private void ApplyTheme()
        {
            // تطبيق على النموذج نفسه
            this.BackColor = ThemeManager.CurrentBackColor;

            // تطبيق على جميع التحكمات
            ApplyThemeToControl(this);

            // تطبيق خاص على الـ DataGridView إذا وجد
            ApplyThemeToDataGridViews(this);

            // تحديث أزرار تبديل الثيم
            UpdateThemeToggleButtons();
        }

        private void ApplyThemeToControl(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                // تحديد اللون حسب نوع التحكم
                switch (ctrl)
                {
                    case FlowLayoutPanel flowPanel:
                        flowPanel.BackColor = ThemeManager.CurrentBackColor;
                        break;
                    case Panel panel:
                        panel.BackColor = ThemeManager.CurrentBackColor;
                        break;

                    case GroupBox groupBox:
                        groupBox.BackColor = ThemeManager.CurrentBackColor;
                        groupBox.ForeColor = ThemeManager.TextColor;
                        break;

                    case Button button:
                        ApplyButtonTheme(button);
                        break;

                    case Label label:
                        label.ForeColor = ThemeManager.TextColor;
                        break;

                    case TextBox textBox:
                        textBox.BackColor = ThemeManager.InputBackColor;
                        textBox.ForeColor = ThemeManager.TextColor;
                        break;

                    case ComboBox comboBox:
                        comboBox.BackColor = ThemeManager.InputBackColor;
                        comboBox.ForeColor = ThemeManager.TextColor;
                        break;
                }

                // معالجة التحكمات الفرعية
                if (ctrl.HasChildren)
                    ApplyThemeToControl(ctrl);
            }
        }

        private void ApplyButtonTheme(Button button)
        {

            switch (button.Name)
            {
                case "btnDeleteAll":
                    button.BackColor = ThemeManager.DeleteAllButtonColor;
                    break;
                case "btnClearSearch":
                    button.BackColor = ThemeManager.ClearSearchButtonColor;
                    break;
                case "btnSave":
                    button.BackColor = ThemeManager.SaveButtonColor;
                    break;
                case "btnCancel":
                    button.BackColor = ThemeManager.CancelButtonColor;
                    break;
                case "btnAddOffer":
                    button.BackColor = ThemeManager.AddOfferButtonColor;
                    break;
                case "btnEditOffer":
                    button.BackColor = ThemeManager.EditOfferButtonColor;
                    break;
                case "BtnDeleteOffer":
                    button.BackColor = ThemeManager.DeleteOfferButtonColor;
                    break;
                case "btnImportExcel":
                    button.BackColor = ThemeManager.ImportExcelButtonColor;
                    break;
                case "btnExportExcel":
                    button.BackColor = ThemeManager.ExportExcelButtonColor;
                    break;
                case "btnWordReport":
                    button.BackColor = ThemeManager.WordReportButtonColor;
                    break;
                case "btnToggleTheme":
                    button.BackColor = ThemeManager.ToggleThemeButtonColor;
                    break;
                default:
                    button.BackColor = ThemeManager.CurrentButtonBackColor;
                    break;
            }

            button.FlatStyle = FlatStyle.Flat;

            if (button.Name != "btnMenu")
            {
                button.FlatAppearance.BorderSize = 1;
                button.ForeColor = Color.White;

            }
            else {
                button.ForeColor = ThemeManager.TextColor;
            }

        }

        private void ApplyThemeToDataGridViews(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is DataGridView dgv)
                {
                    ThemeManager.ApplyThemeToDataGridView(dgv);
                }

                if (ctrl.HasChildren)
                    ApplyThemeToDataGridViews(ctrl);
            }
        }

        private void UpdateThemeToggleButtons()
        {
            foreach (Control ctrl in this.Controls)
            {
                var btn = FindButtonByName(ctrl, "btnToggleTheme");
                if (btn != null)
                {
                    btn.Text = ThemeManager.IsDarkMode ? "☀️ Light Mode" : "🌙 Dark Mode";
                }
            }
        }

        private Button? FindButtonByName(Control parent, string name)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is Button btn && btn.Name == name)
                    return btn;

                if (ctrl.HasChildren)
                {
                    var result = FindButtonByName(ctrl, name);
                    if (result != null) return result;
                }
            }
            return null;
        }
    }
}