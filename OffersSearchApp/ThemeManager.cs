using System;
using System.Drawing;

namespace OffersSearchApp
{
    public static class ThemeManager
    {
        private static bool _isDarkMode;

        static ThemeManager()
        {
            // قراءة القيمة المحفوظة
            _isDarkMode = Properties.Settings.Default.IsDarkMode;
        }

        public static bool IsDarkMode
        {
            get => _isDarkMode;
            set
            {
                if (_isDarkMode != value)
                {
                    _isDarkMode = value;
                    Properties.Settings.Default.IsDarkMode = value;
                    Properties.Settings.Default.Save();
                    OnThemeChanged?.Invoke();
                }
            }
        }

        public static event Action? OnThemeChanged;

        public static void ToggleTheme()
        {
            IsDarkMode = !IsDarkMode;
        }

        #region Colors Classes

        public static class LightColors
        {
            public static readonly Color Back = Color.AliceBlue;
            public static readonly Color Sidebar = Color.AliceBlue;
            public static readonly Color Header = Color.FromArgb(52, 152, 219);
            public static readonly Color Alternating = Color.WhiteSmoke;
            public static readonly Color GridBackground = Color.WhiteSmoke;
            public static readonly Color GridLine = Color.LightGray;
            public static readonly Color GridAlternating = Color.Gainsboro;
            public static readonly Color Input = Color.White;
            public static readonly Color Text = Color.Black;
            public static readonly Color Button = Color.AliceBlue;
            public static readonly Color SelectionBackColor = Color.FromArgb(0, 120, 215);

            public static readonly Color DeleteAllButton = Color.Crimson;
            public static readonly Color ClearSearchButton = Color.FromArgb(231, 76, 60);
            public static readonly Color SaveButton = Color.SeaGreen;
            public static readonly Color CancelButton = Color.FromArgb(231, 76, 60);
            public static readonly Color AddOfferButton = Color.FromArgb(52, 152, 219);
            public static readonly Color EditOfferButton = Color.FromArgb(52, 152, 219);
            public static readonly Color DeleteOfferButton = Color.Crimson;

            public static readonly Color ImportExcelButton = Color.SeaGreen;
            public static readonly Color ExportExcelButton = Color.SeaGreen;
            public static readonly Color WordReportButton = Color.FromArgb(41, 85, 152);
            public static readonly Color ToggleThemeButton = Color.FromArgb(128, 128, 255);
            public static readonly Color ToggleSelectButton = Color.FromArgb(255, 193, 7);
        }

        public static class DarkColors
        {
            public static readonly Color Back = Color.FromArgb(32, 32, 38);
            public static readonly Color Sidebar = Color.FromArgb(40, 40, 45);
            public static readonly Color Header = Color.FromArgb(80, 80, 90);
            public static readonly Color Alternating = Color.FromArgb(45, 45, 52);
            public static readonly Color GridBackground = Color.FromArgb(38, 38, 45);
            public static readonly Color GridLine = Color.FromArgb(80, 80, 90);
            public static readonly Color GridAlternating = Color.FromArgb(42, 42, 50);
            public static readonly Color Input = Color.FromArgb(80, 80, 90);
            public static readonly Color Text = Color.FromArgb(230, 230, 240);
            public static readonly Color Button = Color.FromArgb(32, 32, 38);
            public static readonly Color SelectionBackColor = Color.FromArgb(80, 80, 90);

            public static readonly Color DeleteAllButton = Color.FromArgb(220, 53, 69);
            public static readonly Color ClearSearchButton = Color.FromArgb(255, 69, 0);
            public static readonly Color SaveButton = Color.FromArgb(40, 167, 69);
            public static readonly Color CancelButton = Color.FromArgb(255, 69, 0);
            public static readonly Color AddOfferButton = Color.FromArgb(0, 123, 255);
            public static readonly Color EditOfferButton = Color.FromArgb(0, 102, 204);
            public static readonly Color DeleteOfferButton = Color.FromArgb(220, 53, 69);
            public static readonly Color ImportExcelButton = Color.FromArgb(40, 167, 69);
            public static readonly Color ExportExcelButton = Color.FromArgb(40, 167, 69);
            public static readonly Color WordReportButton = Color.FromArgb(0, 85, 150);
            public static readonly Color ToggleThemeButton = Color.FromArgb(123, 104, 238);
            public static readonly Color ToggleSelectButton = Color.FromArgb(255, 140, 0);
        }

        #endregion

        #region Current Color Properties

        public static Color CurrentBackColor => IsDarkMode ? DarkColors.Back : LightColors.Back;
        public static Color CurrentSidebarColor => IsDarkMode ? DarkColors.Sidebar : LightColors.Sidebar;
        public static Color CurrentHeaderColor => IsDarkMode ? DarkColors.Header : LightColors.Header;
        public static Color CurrentAlternatingColor => IsDarkMode ? DarkColors.Alternating : LightColors.Alternating;
        public static Color InputBackColor => IsDarkMode ? DarkColors.Input : LightColors.Input;
        public static Color TextColor => IsDarkMode ? DarkColors.Text : LightColors.Text;
        public static Color GridBackgroundColor => IsDarkMode ? DarkColors.GridBackground : LightColors.GridBackground;
        public static Color GridLineColor => IsDarkMode ? DarkColors.GridLine : LightColors.GridLine;
        public static Color GridAlternatingColor => IsDarkMode ? DarkColors.GridAlternating : LightColors.GridAlternating;
        public static Color CurrentButtonBackColor => IsDarkMode ? DarkColors.Button : LightColors.Button;
        public static Color DeleteAllButtonColor => IsDarkMode ? DarkColors.DeleteAllButton : LightColors.DeleteAllButton;
        public static Color ClearSearchButtonColor => IsDarkMode ? DarkColors.ClearSearchButton : LightColors.ClearSearchButton;
        public static Color SaveButtonColor => IsDarkMode ? DarkColors.SaveButton : LightColors.SaveButton;
        public static Color CancelButtonColor => IsDarkMode ? DarkColors.CancelButton : LightColors.CancelButton;
        public static Color AddOfferButtonColor => IsDarkMode ? DarkColors.AddOfferButton : LightColors.AddOfferButton;
        public static Color EditOfferButtonColor => IsDarkMode ? DarkColors.EditOfferButton : LightColors.EditOfferButton;
        public static Color DeleteOfferButtonColor => IsDarkMode ? DarkColors.DeleteOfferButton : LightColors.DeleteOfferButton;
        public static Color ImportExcelButtonColor => IsDarkMode ? DarkColors.ImportExcelButton : LightColors.ImportExcelButton;
        public static Color ExportExcelButtonColor => IsDarkMode ? DarkColors.ExportExcelButton : LightColors.ExportExcelButton;
        public static Color WordReportButtonColor => IsDarkMode ? DarkColors.WordReportButton : LightColors.WordReportButton;
        public static Color ToggleThemeButtonColor => IsDarkMode ? DarkColors.ToggleThemeButton : LightColors.ToggleThemeButton;
        public static Color SelectionBackColor => IsDarkMode ? DarkColors.SelectionBackColor : LightColors.SelectionBackColor;
        public static Color ToggleSelectButtonColor => IsDarkMode ? DarkColors.ToggleSelectButton : LightColors.ToggleSelectButton;



        #endregion

        public static void ApplyThemeToDataGridView(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = GridBackgroundColor;
            dgv.GridColor = GridLineColor;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = CurrentHeaderColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAlternatingColor;
            dgv.DefaultCellStyle.BackColor = GridBackgroundColor;
            dgv.DefaultCellStyle.ForeColor = TextColor;
            dgv.DefaultCellStyle.SelectionBackColor = SelectionBackColor;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
}