using System;
using System.Collections.Generic;
using Colour = System.Drawing.Color;
using System.Linq;
using System.Text;
using System.Threading;
using LV = System.Windows.Forms.ListView;
using LVItem = System.Windows.Forms.ListViewItem;
using Timer = System.Windows.Forms.Timer;
using System.Windows.Media;
using System.Data.OleDb;

namespace UCASSys.Forms.Main
{

    class TaskList
    {
        public const int LV_STUDENT = 1;
        public const int LV_APPLICATION = 2;
        public const int LV_REFERENCE = 3;

        private bool canPoll_students = true;
        private bool canPoll_applications = true;
        private bool canPoll_references = false;

        private int interval_Warn = 7;
        private int interval_Alert = 3;

        private Colour colour_Warn = Colour.Orange;
        private Colour colour_Alert = Colour.OrangeRed;
        private Colour colour_MissedDeadline = Colour.Red;

        private Timer pollTimer = new Timer();

        public delegate void taskListHandler(List<Classes.Items.TaskListItem> tasklistItems, int target);
        public event taskListHandler updateTaskList;

        public delegate void openEditFormHandler(int mode, int ULN);
        public event openEditFormHandler openForm;

        public TaskList()
        {
            Program.log.console(GetType().ToString(), "Initialising...");
            Program.log.console(GetType().ToString(), "Student tasklist: " + (canPoll_students ? "EN" : "DIS") + "abled");
            Program.log.console(GetType().ToString(), "Appliactions tasklist: " + (canPoll_applications ? "EN" : "DIS") + "abled");
            Program.log.console(GetType().ToString(), "References tasklist: " + (canPoll_applications ? "EN" : "DIS") + "abled");

            pollTimer.Interval = (int)(2.5 * 1000);

            _initIntervals();
            _initColours();

            pollTimer.Tick += _pollTaskList;
            Program.events.studentSavedHandler += _triggerPoll;
            Program.userCtrl.userLoggedOut += _clearTaskList;
            Program.log.console(GetType().ToString(), "Initialised!");
        }

        private void _initIntervals()
        {
            // Load intervals
            Program.log.console(GetType().ToString(), "Loading time intervals...");
            if (Program.regCtrl.getKey("tasklist/interval"))
            {
                pollTimer.Interval = 1000 * (int)Program.regCtrl.getKey("tasklist/interval").Data;
            }
            if (Program.regCtrl.getKey("tasklist/interval_warn"))
            {
                interval_Warn = (int)Program.regCtrl.getKey("tasklist/interval_warn").Data;
            }
            if (Program.regCtrl.getKey("tasklist/interval_alert"))
            {
                interval_Alert = (int)Program.regCtrl.getKey("tasklist/interval_alert").Data;
            }

            Program.log.console(GetType().ToString(), "Poll Timer = " + (pollTimer.Interval / 1000).ToString() + "s");
            Program.log.console(GetType().ToString(), "Warn Interval = " + interval_Warn.ToString() + "d");
            Program.log.console(GetType().ToString(), "Alert Interval = " + interval_Alert.ToString() + "d");
        }
        private void _initColours()
        {
            // Load colours
            Program.log.console(GetType().ToString(), "Loading colours...");
            if (Program.regCtrl.getKey("tasklist/colour_warn"))
            {
                colour_Warn = (Colour)ColorConverter.ConvertFromString((String)Program.regCtrl.getKey("tasklist/colour_warn").Data);
            }
            if (Program.regCtrl.getKey("tasklist/colour_alert"))
            {
                colour_Alert = (Colour)ColorConverter.ConvertFromString((String)Program.regCtrl.getKey("tasklist/colour_alert").Data);
            }
            if (Program.regCtrl.getKey("tasklist/colour_missedDeadline"))
            {
                colour_MissedDeadline = (Colour)ColorConverter.ConvertFromString((String)Program.regCtrl.getKey("tasklist/colour_missedDeadline").Data);
            }

            Program.log.console(GetType().ToString(), "Warning Colour = " + colour_Warn.ToString());
            Program.log.console(GetType().ToString(), "Alert Colour = " + colour_Alert.ToString());
            Program.log.console(GetType().ToString(), "Missed Deadline Colour = " + colour_MissedDeadline.ToString());
        }

        public void Enabled(bool enabled)
        {
            Program.log.console(GetType().ToString(), "TaskList polling " + (enabled ? "EN" : "DIS") + "abled");
            pollTimer.Enabled = enabled;
            if (enabled)
            {
                _pollTaskList(null, null);
            }
        }

        #region Polling
        private void _triggerPoll()
        {
            _pollTaskList(new Object(), new EventArgs());
        }
        private void _pollTaskList(object sender, EventArgs e)
        {
            Program.log.console(GetType().ToString(), "Polling tasklist...");
            if (canPoll_students)
            {
                updateTaskList(_poll_Students(), LV_STUDENT);
            }
            if (canPoll_applications)
            {
                updateTaskList(_poll_Applications(), LV_APPLICATION);
            }
            if (canPoll_references)
            {
                updateTaskList(_poll_References(), LV_REFERENCE);
            }
        }

        private void _clearTaskList(StringEventArgs reason)
        {
            updateTaskList(new List<Classes.Items.TaskListItem>(), LV_STUDENT);
            updateTaskList(new List<Classes.Items.TaskListItem>(), LV_APPLICATION);
            updateTaskList(new List<Classes.Items.TaskListItem>(), LV_REFERENCE);
        }

        private List<Classes.Items.TaskListItem> _poll_Students()
        {
            List<Classes.Items.TaskListItem> tasklist = new List<Classes.Items.TaskListItem>();

            string queryString = "SELECT s.`uln`, s.`firstName`, s.`lastName`, IIF(ISNULL(s.`deadline`), y.`deadline_details`, s.`deadline`) AS deadline" +
                "  FROM `students` s, `tutorGroups` t, `yearOfEntry` y" +
                "  WHERE s.`tutorGroup` = t.`ID` AND t.`YoE` = y.`ID` AND s.`complete` = false" +
                "  ORDER BY `deadline` ASC";
            try
            {
                using (OleDbCommand query = Program.dbInt.preparedStmt())
                {
                    query.CommandText = queryString;

                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            return tasklist;
                        }

                        Classes.Items.TaskListItem newItem;
                        while (data.Read())
                        {
                            newItem = new Classes.Items.TaskListItem();
                            newItem.ULN = (int)data["uln"];
                            newItem.FirstName = (string)data["firstName"];
                            newItem.LastName = (string)data["lastName"];
                            newItem.Deadline = (DateTime)data["deadline"];
                            tasklist.Add(newItem);
                        }
                        return tasklist;
                    }
                }
            }
            catch (Exception ex)
            {
                Classes.Database.Interface.databaseError("Failed to check tasklist.", GetType().Namespace, ex.Message);
            }
            return tasklist;
        }

        private List<Classes.Items.TaskListItem> _poll_Applications()
        {
            List<Classes.Items.TaskListItem> tasklist = new List<Classes.Items.TaskListItem>();

            string queryString = "SELECT s.`uln`, s.`firstName`, s.`lastName`, IIF(ISNULL(a.`deadline`), y.`deadline_applications`, a.`deadline`) AS dline " +
                "  FROM `students` s, `applications` a, `tutorGroups` t, `yearOfEntry` y" +
                "  WHERE s.`tutorGroup` = t.`ID` AND t.`YoE` = y.`ID` AND a.`uln` = s.`ULN` AND a.`complete` = false" +
                "  ORDER BY 'dline' ASC";
            try
            {
                using (OleDbCommand query = Program.dbInt.preparedStmt())
                {
                    query.CommandText = queryString;

                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            return tasklist;
                        }

                        Classes.Items.TaskListItem newItem;
                        while (data.Read())
                        {
                            newItem = new Classes.Items.TaskListItem();
                            newItem.ULN = (int)data["uln"];
                            newItem.FirstName = (string)data["firstName"];
                            newItem.LastName = (string)data["lastName"];
                            newItem.Deadline = (DateTime)data["dline"];
                            tasklist.Add(newItem);
                        }
                        return tasklist;
                    }
                }
            }
            catch (Exception ex)
            {
                Classes.Database.Interface.databaseError("Failed to check tasklist.", GetType().Namespace, ex.Message);
            }
            return tasklist;
        }

        private List<Classes.Items.TaskListItem> _poll_References()
        {
            List<Classes.Items.TaskListItem> tasklist = new List<Classes.Items.TaskListItem>();

            string queryString = "SELECT s.`uln`, s.`firstName`, s.`lastName`, IIF(ISNULL(a.`deadline`), y.`deadline_applications`, a.`deadline`) AS dline " +
                "  FROM `students` s, `applications` a, `tutorGroups` t, `yearOfEntry` y" +
                "  WHERE s.`tutorGroup` = t.`ID` AND t.`YoE` = y.`ID` AND a.`uln` = s.`ULN` AND a.`complete` = false" +
                "  ORDER BY 'dline' ASC";
            try
            {
                using (OleDbCommand query = Program.dbInt.preparedStmt())
                {
                    query.CommandText = queryString;

                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            return tasklist;
                        }

                        Classes.Items.TaskListItem newItem;
                        while (data.Read())
                        {
                            newItem = new Classes.Items.TaskListItem();
                            newItem.ULN = (int)data["uln"];
                            newItem.FirstName = (string)data["firstName"];
                            newItem.LastName = (string)data["lastName"];
                            newItem.Deadline = (DateTime)data["deadline"];
                            tasklist.Add(newItem);
                        }
                        return tasklist;
                    }
                }
            }
            catch (Exception ex)
            {
                Classes.Database.Interface.databaseError("Failed to check tasklist.", GetType().Namespace, ex.Message);
            }
            return tasklist;
        }
        #endregion

        #region Open Events
        public void openStudent(object sender, EventArgs e)
        {
            LV listview = (LV)sender;
            if (listview.SelectedItems.Count != 1)
            {
                return;
            }
            if (openForm != null) openForm(LV_STUDENT, (int)listview.SelectedItems[0].Tag);
        }
        public void openApplication(object sender, EventArgs e)
        {
            LV listview = (LV)sender;
            if (listview.SelectedItems.Count != 1)
            {
                return;
            }
            if (openForm != null) openForm(LV_APPLICATION, (int)listview.SelectedItems[0].Tag);
        }
        public void openReference(object sender, EventArgs e)
        {
            LV listview = (LV)sender;
            if (listview.SelectedItems.Count != 1)
            {
                return;
            }
            if (openForm != null) openForm(LV_REFERENCE, (int)listview.SelectedItems[0].Tag);
        }
        #endregion

        public void colourLVItem(ref LVItem item, DateTime deadline)
        {
            if (deadline < DateTime.Now)
            {
                item.BackColor = colour_MissedDeadline;
                item.ForeColor = Colour.White;
            }
            else if (deadline < DateTime.Now.AddDays(interval_Alert))
            {
                item.BackColor = colour_Alert;
            }
            else if (deadline < DateTime.Now.AddDays(interval_Warn))
            {
                item.BackColor = colour_Warn;
            }
        }

        #region Static Methods
        public static string getTimeInterval(DateTime timeInstance)
        {
            String left = "";
            TimeSpan timeDiff = (timeInstance - DateTime.Now);
            int timeLeft = timeDiff.Days;
            if (timeLeft < 0)
            {
                left = "Missed Deadline";
            }
            else if (timeLeft == 0)
            {
                left = "Today";
            }
            else if (timeLeft < 1)
            {
                left = "Tomorrow";
            }
            else if (timeLeft > 7)
            {
                left = Math.Ceiling((double)(timeDiff.Days / 7)).ToString() + " Week(s)";
            }
            else
            {
                left = timeLeft.ToString() + " Days";
            }

            return left;
        }
        public static void resizeTaskListLV(ref LV lv)
        {
            double columnSizeUnit = (double)(lv.Width - 6) / 150;
            if (lv.Columns.Count == 0)
            {
                return;
            }
            lv.Columns[0].Width = (int)Math.Floor(columnSizeUnit * 50);
            lv.Columns[1].Width = (int)Math.Floor(columnSizeUnit * 65);
            lv.Columns[2].Width = (int)Math.Floor(columnSizeUnit * 35);
        }
        #endregion
    }
}
