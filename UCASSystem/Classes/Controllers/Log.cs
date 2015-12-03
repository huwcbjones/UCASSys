using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UCASSys.Classes.Controllers
{
    public class Log
    {

        private string currentLog;

        public Log()
        {
            console(GetType().ToString(), "Initialising...");
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += _error;

            console(GetType().ToString(), "Initialised");
        }

        private StatusMessage _openLog()
        {
            StatusMessage result = new StatusMessage(false);
            try
            {
                currentLog = "logs/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

                if (!Directory.Exists("logs"))
                {
                    Directory.CreateDirectory("logs");
                }
                if (!File.Exists(currentLog))
                {
                    result.Data = File.CreateText(currentLog);
                }
                else
                {
                    result.Data = new StreamWriter(currentLog, true);
                }
                result.is_Success = true;
                return result;
            }
            catch (Exception ex)
            {
                using (TaskDialog dialog = new TaskDialog())
                {
                    dialog.errorBox();
                    dialog.Title = "Log Error";
                    dialog.Subtitle = "Failed to open log file.";
                    dialog.Text = ex.Message;
                    dialog.DetailsText = ex.ToString();

                    dialog.Show();
                }
                Application.Exit();
            }
            return result;
        }
        public void console(string nspace, string message)
        {
#if DEBUG
            Console.WriteLine(_logLine(nspace, message));
#endif
        }

        public void log(string nspace, string message, string location = "")
        {
            StatusMessage result = _openLog();
            StreamWriter logStream;
            if (!result)
            {
                return;
            }
            logStream = (StreamWriter)result.Data;
            if (location != "")
            {
                message += " @: " + location;
            }
            logStream.WriteLine(_logLine(nspace, message));
            logStream.Flush();
            logStream.Close();
        }
        private void _error(object e, UnhandledExceptionEventArgs ex)
        {
            log(e.GetType().Namespace + "." + e.GetType().Name, ex.ToString());
        }

        private string _logLine(string nspace, string message)
        {
            return DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ": [" + nspace + "] " + message;
        }
    }
}
