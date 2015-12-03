using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCASSys
{
    public class ApplicationEvents
    {

        public delegate void studentSavedEvent();
        public event studentSavedEvent studentSavedHandler;


        public void studentSaved()
        {
            if (studentSavedHandler != null)
            {
                studentSavedHandler();
            }
        }
    }
}
