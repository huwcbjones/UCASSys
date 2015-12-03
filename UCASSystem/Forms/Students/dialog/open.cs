using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.OleDb;
using StatusMsg = UCASSys.Classes.StatusMessage;
using Delay = System.Timers.Timer;
using UCASSys.Classes.Items;

namespace UCASSys.Forms.Students.dialog
{
    public partial class open : Form
    {
        public Classes.Items.StudentItem student;
        private Thread searchThread;
        private AutoResetEvent startSearch = new AutoResetEvent(false);
        private ListViewColumnSorter columnSorter = new ListViewColumnSorter();
        public open()
        {
            InitializeComponent();
            _loadForm();

            btn_reset.Click += reset;
            btn_search.Click += triggerSearch;
            btn_open.Click += openStudent;

            lv_results.ListViewItemSorter = this.columnSorter;
            lv_results.ColumnClick += lv_sortColumn;
            lv_results.SelectedIndexChanged += lv_results_selection;
            lv_results.DoubleClick += lv_results_DoubleClick;

            combo_status.SelectedIndexChanged += triggerSearch;
            combo_YoE.SelectedIndexChanged += combo_YoE_setTutorSource;
            combo_YoE.SelectedIndexChanged += triggerSearch;
            combo_tutorGroup.SelectedIndexChanged += triggerSearch;
            combo_gender.SelectedIndexChanged += triggerSearch;

            text_firstName.KeyDown += text_keyDown_searchTrigger;
            text_firstName.LostFocus += triggerSearch;
            text_middleNames.KeyDown += text_keyDown_searchTrigger;
            text_middleNames.LostFocus += triggerSearch;
            text_lastName.KeyDown += text_keyDown_searchTrigger;
            text_lastName.LostFocus += triggerSearch;
        }

        private void _loadForm()
        {
            searchThread = new Thread(search);
            searchThread.Priority = ThreadPriority.AboveNormal;
            searchThread.IsBackground = true;
            searchThread.Start();

            combo_status.DataSource = new Classes.Lists.Status(false, false).List;
            combo_status.DisplayMember = "Text";
            combo_status.ValueMember = "ID";

            combo_gender.DataSource = new Classes.Lists.Gender(true, false).List;
            combo_gender.DisplayMember = "Text";
            combo_gender.ValueMember = "ID";

            combo_YoE.DataSource = new Classes.Lists.YearOfEntry(true, false).List;
            combo_YoE.DisplayMember = "Text";
            combo_YoE.ValueMember = "ID";

            combo_tutorGroup.DataSource = new Classes.Lists.TutorGroup(-1, true, false).List;
            combo_tutorGroup.DisplayMember = "Text";
            combo_tutorGroup.ValueMember = "ID";
        }

        private void btn_open_enabled(bool is_enabled)
        {
            if (btn_open.InvokeRequired)
            {
                btn_open.Invoke(new Action<bool>(btn_open_enabled), is_enabled);
            }
            else
            {
                btn_open.Enabled = is_enabled;
            }
        }

        private void combo_YoE_setTutorSource(object sender, EventArgs e)
        {
            List<Classes.Items.TutorItem> list;
            if ((int)combo_YoE.SelectedValue < 0)
            {
                list = new Classes.Lists.TutorGroup(-1, true, false).List;
            }
            else
            {
                list = new Classes.Lists.TutorGroup((int)combo_YoE.SelectedValue, true, false).List;
            }
            combo_tutorGroup.DataSource = list;
        }

        private void text_keyDown_searchTrigger(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                startSearch.Set();
            }
        }

        private void triggerSearch(object sender, EventArgs e)
        {
            startSearch.Set();
        }

        private void reset(object sender, EventArgs e)
        {
            combo_status.SelectedIndexChanged -= triggerSearch;
            combo_YoE.SelectedIndexChanged -= combo_YoE_setTutorSource;
            combo_YoE.SelectedIndexChanged -= triggerSearch;
            combo_tutorGroup.SelectedIndexChanged -= triggerSearch;
            combo_gender.SelectedIndexChanged -= triggerSearch;

            combo_status.SelectedIndex = 0;
            combo_YoE.SelectedIndex = 0;
            combo_tutorGroup.SelectedIndex = 0;
            combo_gender.SelectedIndex = 0;
            text_firstName.Text = "";
            text_middleNames.Text = "";
            text_lastName.Text = "";

            lv_update(true);
            lv_clear();
            lv_update(false);

            combo_status.SelectedIndexChanged += triggerSearch;
            combo_YoE.SelectedIndexChanged += combo_YoE_setTutorSource;
            combo_YoE.SelectedIndexChanged += triggerSearch;
            combo_tutorGroup.SelectedIndexChanged += triggerSearch;
            combo_gender.SelectedIndexChanged += triggerSearch;
        }

        private void search()
        {
            do
            {
                startSearch.WaitOne();

                Program.log.console(GetType().Namespace, "Starting search...");
                using (OleDbCommand query = Program.dbInt.preparedStmt())
                {

                    try
                    {
                        string queryString = "SELECT s.`uln`, y.`YearOfEntry`, t.`yearGroup`, t.`initials`, s.`firstName`, s.`middleNames`, s.`lastName`, s.`complete` ";
                        queryString += " FROM `students` s, `tutorGroups` t, `yearOfEntry` y";
                        queryString += " WHERE s.`tutorGroup` = t.`ID` AND t.`YoE` = y.`ID`";

                        #region Query String Builder
                        if (search_status())
                        {
                            queryString += search_status().Message;
                            query.Parameters.AddWithValue("@status", (bool)search_status().Data);
                        }
                        if (search_YoE())
                        {
                            queryString += search_YoE().Message;
                            query.Parameters.AddWithValue("@YoE", (int)search_YoE().Data);
                        }
                        if (search_TutorGroup())
                        {
                            queryString += search_TutorGroup().Message;
                            query.Parameters.AddWithValue("@tutorGroup", (int)search_TutorGroup().Data);
                        }
                        if (search_gender())
                        {
                            queryString += search_gender().Message;
                            query.Parameters.AddWithValue("@gender", (int)search_gender().Data);
                        }
                        if (search_firstName())
                        {
                            queryString += search_firstName().Message;
                            query.Parameters.AddWithValue("@firstName", (string)search_firstName().Data);
                        }
                        if (search_middleNames())
                        {
                            queryString += search_middleNames().Message;
                            query.Parameters.AddWithValue("@middleNames", (string)search_middleNames().Data);
                        }
                        if (search_lastName())
                        {
                            queryString += search_lastName().Message;
                            query.Parameters.AddWithValue("@lastName", (string)search_lastName().Data);
                        }
                        #endregion

                        query.CommandText = queryString;

                        using (OleDbDataReader data = query.ExecuteReader())
                        {
                            lv_update(true);
                            lv_clear();
                            if (!data.HasRows)
                            {
                                lv_update(false);
                                continue;
                            }
                            ListViewItem item;
                            while (data.Read())
                            {
                                item = new ListViewItem(((int)data["uln"]).ToString());
                                item.Tag = (int)data["uln"];
                                item.SubItems.Add((string)data["YearOfEntry"]);
                                item.SubItems.Add(((int)data["yearGroup"]).ToString() + (string)data["initials"]);
                                item.SubItems.Add((string)data["firstName"]);
                                item.SubItems.Add((string)data["middleNames"]);
                                item.SubItems.Add((string)data["lastName"]);
                                item.SubItems.Add(((bool)data["complete"] ? "Complete" : "In Progress")).ForeColor = (bool)data["complete"] ? Color.Green : Color.DarkOrange;

                                lv_addItem(item);
                            }
                            lv_update(false);
                        }
                    }
                    catch (Exception ex)
                    {
                        Classes.Database.Interface.databaseError("Failed to search for students.", GetType().Namespace, ex.Message);
                    }

                }
            } while (true);
        }

        void lv_results_selection(object sender, EventArgs e)
        {
            if (lv_results.SelectedItems.Count != 1)
            {
                btn_open_enabled(false);
                return;
            }
            btn_open_enabled(true);
            this.student = new Classes.Items.StudentItem((int)lv_results.SelectedItems[0].Tag);
        }

        void lv_results_DoubleClick(object sender, EventArgs e)
        {
            if (lv_results.SelectedItems.Count == 1)
            {
                this.student = new StudentItem((int)lv_results.SelectedItems[0].Tag);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void openStudent(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        #region Search Term Generator
        private StatusMsg search_gender()
        {
            if (combo_gender.InvokeRequired)
            {
                return (StatusMsg)combo_gender.Invoke(new Func<StatusMsg>(search_gender));
            }
            StatusMsg result = new StatusMsg(false);
            Classes.Items.GenderItem gender = (Classes.Items.GenderItem)combo_gender.SelectedItem;
            if (gender.ID < 0)
            {
                return result;
            }
            result.Data = gender.ID;
            result.is_Success = true;
            result.Message = " AND s.`gender`=@gender";
            return result;
        }

        private StatusMsg search_status()
        {
            if (combo_status.InvokeRequired)
            {
                return (StatusMsg)combo_status.Invoke(new Func<StatusMsg>(search_status));
            }
            StatusMsg result = new StatusMsg(false);
            Classes.Items.dropDownItem status = (Classes.Items.dropDownItem)combo_status.SelectedItem;
            if (status.ID < 0)
            {
                return result;
            }
            result.Data = (status.ID == Classes.Status.Complete);
            result.is_Success = true;
            result.Message = " AND s.`complete`=@status";
            return result;
        }

        private StatusMsg search_YoE()
        {
            if (combo_YoE.InvokeRequired)
            {
                return (StatusMsg)combo_status.Invoke(new Func<StatusMsg>(search_YoE));
            }
            StatusMsg result = new StatusMsg(false);
            Classes.Items.YearOfEntryItem YoE = (Classes.Items.YearOfEntryItem)combo_YoE.SelectedItem;
            if (YoE.ID < 0)
            {
                return result;
            }
            result.Data = YoE.ID;
            result.is_Success = true;
            result.Message = " AND y.`ID`=@YoE";
            return result;
        }

        private StatusMsg search_TutorGroup()
        {
            if (combo_tutorGroup.InvokeRequired)
            {
                return (StatusMsg)combo_tutorGroup.Invoke(new Func<StatusMsg>(search_TutorGroup));
            }
            StatusMsg result = new StatusMsg(false);
            Classes.Items.TutorItem tutor = (Classes.Items.TutorItem)combo_tutorGroup.SelectedItem;
            if (tutor.ID < 0)
            {
                return result;
            }
            result.Data = tutor.ID;
            result.is_Success = true;
            result.Message = " AND t.`ID`=@tutorGroup";
            return result;
        }

        private StatusMsg search_firstName()
        {
            if (text_firstName.InvokeRequired)
            {
                return (StatusMsg)text_firstName.Invoke(new Func<StatusMsg>(search_firstName));
            }
            StatusMsg result = new StatusMsg(false);
            if (text_firstName.TextLength == 0)
            {
                return result;
            }
            result.Data = "%" + text_firstName.Text.Trim() + "%";
            result.is_Success = true;
            result.Message = " AND s.`firstName` LIKE @firstName";
            return result;
        }

        private StatusMsg search_middleNames()
        {
            if (text_middleNames.InvokeRequired)
            {
                return (StatusMsg)text_middleNames.Invoke(new Func<StatusMsg>(search_middleNames));
            }
            StatusMsg result = new StatusMsg(false);
            if (text_middleNames.TextLength == 0)
            {
                return result;
            }
            result.Data = "%" + text_middleNames.Text.Trim() + "%";
            result.is_Success = true;
            result.Message = " AND s.`middleNames` LIKE @middleNames";
            return result;
        }

        private StatusMsg search_lastName()
        {
            if (text_lastName.InvokeRequired)
            {
                return (StatusMsg)text_lastName.Invoke(new Func<StatusMsg>(search_lastName));
            }
            StatusMsg result = new StatusMsg(false);
            if (text_lastName.TextLength == 0)
            {
                return result;
            }
            result.Data = "%" + text_lastName.Text.Trim() + "%";
            result.is_Success = true;
            result.Message = " AND s.`lastName` LIKE @lastName";
            return result;
        }

        #endregion

        #region ListView Delegates
        private void lv_sortColumn(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == columnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (columnSorter.Order == SortOrder.Ascending)
                {
                    columnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    columnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                columnSorter.SortColumn = e.Column;
                columnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lv_results.Sort();
        }
        private void lv_clear()
        {
            if (lv_results.InvokeRequired)
            {
                lv_results.Invoke(new Action(lv_clear));
            }
            else
            {
                lv_results.Items.Clear();
            }
        }
        private void lv_update(bool begin)
        {
            if (lv_results.InvokeRequired)
            {
                lv_results.Invoke(new Action<bool>(lv_update), begin);
            }
            else
            {
                if (begin)
                {
                    lv_results.BeginUpdate();
                }
                else
                {
                    lv_results.EndUpdate();
                }
            }
        }
        private void lv_addItem(ListViewItem item)
        {
            if (lv_results.InvokeRequired)
            {
                lv_results.Invoke(new Action<ListViewItem>(lv_addItem), item);
            }
            else
            {
                lv_results.Items.Add(item);
            }
        }
        #endregion

    }
}
