using System;
using System.Runtime.InteropServices;

namespace UCASSys.Classes
{
    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;
        public static readonly int WM_ShowMe = RegisterWindowMessage("WW_ShowMe");
        public static readonly int WM_Add_Student = RegisterWindowMessage("WM_ADD_Student");
        public static readonly int WM_Add_Application = RegisterWindowMessage("WM_ADD_Application");
        public static readonly int WM_Add_Reference = RegisterWindowMessage("WM_ADD_Reference");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}
