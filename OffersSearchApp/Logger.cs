using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffersSearchApp
{
    public static class Logger
    {
        private static readonly string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static readonly string logFile = Path.Combine(logDir, "app_logs.txt");
        public static void Log(string message, string type = "INFO")
        {
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);

            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{type}] {message}";
            File.AppendAllText(logFile, line + Environment.NewLine);
        }
    }
}
