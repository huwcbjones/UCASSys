using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.WindowsAPICodePack.Shell;
using System.Reflection;

namespace UCASSys.Classes.Controllers
{
    public class Taskbar
    {
        JumpList jumpList;

        public Taskbar()
        {
            Program.log.console(GetType().ToString(), "Initialising...");
            jumpList = JumpList.CreateJumpList();
            jumpList.ClearAllUserTasks();
            jumpList.KnownCategoryToDisplay = JumpListKnownCategoryType.Recent;

            addTasks();

            jumpList.Refresh();
            Program.log.console(GetType().ToString(), "Initialised");
        }

        public void AddToRecent(string file)
        {
         
        }

        private void addTasks()
        {
            Program.log.console(GetType().ToString(), "Adding tasks to taskbar...");
            List<JumpListLink> links = new List<JumpListLink>();

            links.Add(new JumpListLink(Assembly.GetEntryAssembly().Location, "Add Student") {
                Arguments = " -add=student"
            });
            links.Add(new JumpListLink(Assembly.GetEntryAssembly().Location, "Add Application")
            {
                Arguments = " -add=application"
            });
            links.Add(new JumpListLink(Assembly.GetEntryAssembly().Location, "Add Reference")
            {
                Arguments = " -add=reference"
            });

            foreach (JumpListLink link in links)
            {
                Program.log.console(GetType().Namespace, "Adding " + link.Title);
                jumpList.AddUserTasks(link);
            }
            Program.log.console(GetType().Namespace, "Tasks added!");
        }
    }
}
