
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

namespace OffersSearchApp
{

    public partial class FormLogs : BaseThemeForm
    {
        public FormLogs()
        {
            InitializeComponent();
        }

        private void FormLogs_Load(object sender, EventArgs e)
        {
            string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
            string logFile = Path.Combine(logDir, "app_logs.txt");

            if (!File.Exists(logFile))
            {
                txtLogs.Text = "No logs found.";
                return;
            }

            try
            {
                txtLogs.Text = File.ReadAllText(logFile);
            }
            catch (Exception ex)
            {
                txtLogs.Text = "Error reading log file:\n" + ex.Message;
            }
            this.ActiveControl = lblTitle;
        }
    }
}
