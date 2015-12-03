using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace UCASSys
{
    public static class Program
    {

        public const int MODE_New = 0;
        public const int MODE_Edit = 1;
        public const int MODE_View = 2;

        static Mutex mutex = new Mutex(true, "UCASSystem.Mutex." + Assembly.GetCallingAssembly().ToString());
        public static ApplicationEvents events = new ApplicationEvents();
        public static Classes.Controllers.Log log = new Classes.Controllers.Log();
        public static Classes.Controllers.Registry regCtrl = new Classes.Controllers.Registry();
        public static Classes.Database.Interface dbInt = new Classes.Database.Interface();
        public static Classes.Controllers.User userCtrl = new Classes.Controllers.User();
        public static Classes.Controllers.Config configCtrl = new Classes.Controllers.Config();
        public static Classes.Controllers.Notification notifyCtrl = new Classes.Controllers.Notification();
        public static Classes.Controllers.Taskbar taskbarCtrl;
        public static StartupArgs startup = new StartupArgs();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Program.log.console("UCASSys", "Initialising...");

            // Check whether application is already open
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                // Application isn't open, so let's open it
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (!Classes.SetupDatabase.checkResolution())
                {
                    return;
                }

                startupArguments();
                Program.log.console("UCASSys", "Initialised");
                Application.Run(new UCASSys.Forms.Main.main());
                mutex.ReleaseMutex();
            }
            else
            {
                Program.log.console("UCASSys", "Application already open, deferring to open instance.");
                startupArguments(true);
            }
        }

        static void startupArguments(bool is_alreadyOpen = false)
        {
            String[] args = Environment.GetCommandLineArgs();

            args = args.Where(arg => arg.Contains(".exe") == false).ToArray();

            if (is_alreadyOpen)
            {
                Classes.NativeMethods.PostMessage(
                    (IntPtr)Classes.NativeMethods.HWND_BROADCAST,
                    Classes.NativeMethods.WM_ShowMe,
                    IntPtr.Zero,
                    IntPtr.Zero
                );
            }
            foreach (String arg in args)
            {
                if (File.Exists(arg))
                {
                    regCtrl.writeKey("database", arg, Microsoft.Win32.RegistryValueKind.String);
                }
                else if (arg.Contains("add"))
                {
                    arg_add(arg, is_alreadyOpen);
                }
            }
        }

        static void arg_add(string arg, bool appOpen = false)
        {
            string[] parts = arg.Split('=');
            int msg = Classes.NativeMethods.WM_ShowMe;
            int startupArg = 0;
            if (parts.Count() == 2)
            {
                switch (parts[1])
                {
                    case "student":
                        startupArg = StartupArgs.ADD_STUDENT;
                        msg = Classes.NativeMethods.WM_Add_Student;
                        break;
                    case "application":
                        startupArg = StartupArgs.ADD_APPLICATION;
                        msg = Classes.NativeMethods.WM_Add_Application;
                        break;
                    case "reference":
                        startupArg = StartupArgs.ADD_REFERENCE;
                        msg = Classes.NativeMethods.WM_Add_Reference;
                        break;
                    default:
                        startupArg = Classes.NativeMethods.WM_ShowMe;
                        break;
                }
            }
            if (appOpen
                || userCtrl.is_loggedIn)
            {
                Classes.NativeMethods.PostMessage(
                    (IntPtr)Classes.NativeMethods.HWND_BROADCAST,
                    msg,
                    IntPtr.Zero,
                    IntPtr.Zero
                );
            }
            else
            {
                Program.startup.Add(startupArg);
            }
        }

       public static TaskDialogResult error(string subtitle, string text, string DetailsText = null)
        {
            using (Classes.TaskDialog dialog = new Classes.TaskDialog())
            {
                dialog.errorBox();
                dialog.Title = "UCAS System Error";
                dialog.Subtitle = subtitle;
                dialog.Text = text;
                dialog.DetailsText = DetailsText;

                return dialog.Show();
            }
        }

       public static TaskDialogResult authError(string subtitle, string text, string DetailsText = null)
       {
           using (Classes.TaskDialog dialog = new Classes.TaskDialog())
           {
               dialog.authBox();
               dialog.Title = "UCAS System Privilege Error";
               dialog.Subtitle = subtitle;
               dialog.Text = text;
               dialog.DetailsText = DetailsText;
               return dialog.Show();
           }
       }
    }
}
