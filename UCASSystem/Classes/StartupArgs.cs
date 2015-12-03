using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCASSys
{
    public class StartupArgs
    {
        public const int ADD_STUDENT = 1;
        public const int ADD_APPLICATION = 2;
        public const int ADD_REFERENCE = 3;

        public List<int> startupArgs = new List<int>();

        public delegate void startupArgAdded();
        public event startupArgAdded startupArgAddedHandler;

        public void Add(int arg)
        {
            if (startupArgs.Contains(arg))
            {
                return;
            }
            startupArgs.Add(arg);
            if (startupArgAddedHandler != null)
            {
                startupArgAddedHandler();
            }
        }
    }
}
