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
using UCASSys.Classes;
using QualificationItem = UCASSys.Classes.Items.QualificationItem;

namespace UCASSys.Forms.Students.dialog
{
    public partial class qualification : Form
    {
        private int _mode = Program.MODE_New;
        private Thread _lazyLoadExamBoards;

        private ListViewColumnSorter columnSorter = new ListViewColumnSorter();

        private Classes.Timeout searchDelay = new Classes.Timeout(400);

        public int Mode
        {
            get { return _mode; }
        }

        public Classes.Items.QualificationItem qual;

        public qualification(int mode = Program.MODE_New, QualificationItem editQual = null)
        {
            _mode = mode;
            _lazyLoadExamBoards = new Thread(_loadExamBoards);
            _lazyLoadExamBoards.Priority = ThreadPriority.BelowNormal;
            _lazyLoadExamBoards.IsBackground = true;

            InitializeComponent();

            this.Shown += qualification_Shown;

            _loadForm(editQual);


            searchDelay.timeoutReachedHandler += _runSearch;

            combo_board.SelectedIndexChanged += combo_board_SelectedIndexChanged;
            combo_level.SelectedIndexChanged += combo_level_SelectedIndexChanged;
            text_search.KeyDown += trigger_KeyPress;

            lv_results.SelectedIndexChanged += lv_results_SelectedIndexChanged;
            lv_results.ListViewItemSorter = this.columnSorter;
            lv_results.ColumnClick += lv_sortColumn;
            btn_do.Click += btn_do_Click;

            this.Shown += new EventHandler(delegate (Object o, EventArgs e){
                if (mode == Program.MODE_Edit
             || mode == Program.MODE_View
            )
            {
                _loadQualification();
            }
            });
        }

        private void _loadForm(QualificationItem editQual = null)
        {
            combo_board.ValueMember = "ID";
            combo_board.DisplayMember = "Text";
            combo_board.DataSource = new List<Classes.Items.dropDownItem> { new Classes.Items.dropDownItem(-1, "Loading Exam Boards...") };

            combo_level.ValueMember = "ID";
            combo_level.DisplayMember = "Text";
            combo_level.DataSource = new Classes.Lists.Level(-1, false).List;

            combo_month.ValueMember = "ID";
            combo_month.DisplayMember = "Text";
            combo_month.DataSource = new List<Classes.Items.dropDownItem> { new Classes.Items.dropDownItem(-1, "Select Qualification") };

            combo_year.ValueMember = "ID";
            combo_year.DisplayMember = "Text";
            combo_year.DataSource = new List<Classes.Items.dropDownItem> { new Classes.Items.dropDownItem(-1, "Select Qualification") };

            combo_grade.ValueMember = "ID";
            combo_grade.DisplayMember = "Text";
            combo_grade.DataSource = new List<Classes.Items.dropDownItem> { new Classes.Items.dropDownItem(-1, "Select Qualification") };

            if (this._mode == Program.MODE_New)
            {
                this.Text = "Add Qualification";
                btn_do.Enabled = false;
                btn_do.Text = "&Add";
            }
            else if (
                (
                  this._mode == Program.MODE_Edit
               || this._mode == Program.MODE_View
                )
                && editQual == null
            )
            {
                using (Classes.TaskDialog dialog = new Classes.TaskDialog(this.Handle))
                {
                    dialog.errorBox();
                    dialog.Title = "Data Error";
                    dialog.Subtitle = "Failed to load qualification.";
                    dialog.Text = "UCAS Sys tried to load qualification, but failed.";
                    dialog.DetailsText = "QualificationItem was null.";

                    dialog.Show();
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            else if (
                this._mode == Program.MODE_Edit
             || this._mode == Program.MODE_View
            )
            {
                this.Shown -= qualification_Shown;
                this.qual = editQual;
            }
        }
        private void _loadQualification()
        {
            if (this._mode == Program.MODE_Edit)
            {
                this.Text = "Edit Qualification";
                btn_do.Text = "&Edit";
                btn_do.Visible = true;

                combo_month.Enabled = true;
                combo_year.Enabled = true;
                combo_grade.Enabled = true;
            }
            else if (this._mode == Program.MODE_View)
            {
                this.Text = "View Qualification";
                btn_do.Visible = false;

                combo_month.Enabled = false;
                combo_year.Enabled = false;
                combo_grade.Enabled = false;
            }
            else
            {
                return;
            }
            lv_results.Enabled = false;
            combo_board.Enabled = false;
            combo_level.Enabled = false;
            text_search.Enabled = false;
            
            combo_board.DataSource = new List<Classes.Items.ExamBoardItem>{this.qual.ExamBoard};
            combo_level.DataSource = new List<Classes.Items.dropDownItem>{new Classes.Items.dropDownItem(1, this.qual.Level)};

            
            ListViewItem editQualLV = new ListViewItem(this.qual.Level);
            editQualLV.Tag = this.qual;
            editQualLV.SubItems.Add(this.qual.Name);
            editQualLV.SubItems.Add(this.qual.CourseStart.ToShortDateString());
            editQualLV.SubItems.Add(this.qual.CourseEnd.ToShortDateString());

            lv_results.SelectedIndexChanged -= lv_results_SelectedIndexChanged;
            _lv_Update(true);
            _lv_Items_Clear();
            _lv_Items_Add(editQualLV);
            lv_results.Items[0].Selected = true;
            _lv_Update(false);

            text_qualification.Text = this.qual.Name;

            combo_month.DataSource = new Classes.Lists.Month().List;
            combo_year.DataSource = new Classes.Lists.Year(this.qual.CourseEnd.Year - this.qual.CourseStart.Year, this.qual.CourseEnd.Year, Classes.Lists.Year.SORT_DESC).List;
            combo_grade.DataSource = new Classes.Lists.Grades(this.qual.Grades).List;

            // TODO: Fix setting of qualification properties
            combo_month.SelectedValue = this.qual.DateAchieved.Month;
            combo_year.SelectedValue = this.qual.DateAchieved.Year;
            combo_grade.SelectedValue = this.qual.Grades.IndexOf(this.qual.GradeAchieved) + 1;
        }
        void qualification_Shown(object sender, EventArgs e)
        {
            _lazyLoadExamBoards.Start();
        }

        void combo_board_SelectedIndexChanged(object sender, EventArgs e)
        {
            int examBoardID = ((Classes.Items.ExamBoardItem)combo_board.SelectedItem).ID;
            combo_level.DataSource = new Classes.Lists.Level(examBoardID, false).List;
            _runSearch();
        }
        void combo_level_SelectedIndexChanged(object sender, EventArgs e)
        {
            _runSearch();
        }
        private void trigger_KeyPress(object sender, EventArgs e)
        {
            searchDelay.KeyPress();
        }
        void lv_results_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_results.SelectedItems.Count != 1)
            {
                combo_month.SelectedIndexChanged -= combo_month_SelectedIndexChanged;
                combo_year.SelectedIndexChanged -= combo_year_SelectedIndexChanged;
                combo_grade.SelectedIndexChanged -= combo_grade_SelectedIndexChanged;

                text_qualification.Text = "";
                btn_do.Enabled = false;
                combo_month.Enabled = false;
                combo_year.Enabled = false;
                combo_grade.Enabled = false;

                combo_month.DataSource = new List<Classes.Items.dropDownItem> { new Classes.Items.dropDownItem(-1, "Select Qualification") };
                combo_year.DataSource = new List<Classes.Items.dropDownItem> { new Classes.Items.dropDownItem(-1, "Select Qualification") };
                combo_grade.DataSource = new List<Classes.Items.dropDownItem> { new Classes.Items.dropDownItem(-1, "Select Qualification") };
            }
            else
            {
                this.qual = (Classes.Items.QualificationItem)lv_results.SelectedItems[0].Tag;
                text_qualification.Text = this.qual.Name;
                btn_do.Enabled = true;
                combo_month.Enabled = true;
                combo_month.DataSource = new Classes.Lists.Month().List;
                combo_year.Enabled = true;
                combo_year.DataSource = new Classes.Lists.Year(qual.CourseEnd.Year - qual.CourseStart.Year, qual.CourseEnd.Year, Classes.Lists.Year.SORT_DESC).List;
                combo_grade.Enabled = true;
                combo_grade.DataSource = new Classes.Lists.Grades(qual.Grades).List;

                combo_month.SelectedIndexChanged += combo_month_SelectedIndexChanged;
                combo_year.SelectedIndexChanged += combo_year_SelectedIndexChanged;
                combo_grade.SelectedIndexChanged += combo_grade_SelectedIndexChanged;
            }
        }

        void combo_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            _validate_achievedMonth();
        }
        void combo_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            _validate_achievedYear();
        }
        void combo_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            _validate_grade();
        }

        void btn_do_Click(object sender, EventArgs e)
        {
            if (!_checkValidation())
            {
                return;
            }
            if (lv_results.InvokeRequired)
            {
                lv_results.Invoke(new Action<object, EventArgs>(btn_do_Click), sender, e);
                return;
            }
            this.qual = (QualificationItem)lv_results.SelectedItems[0].Tag;
            this.qual.GradeAchieved = ((Classes.Items.dropDownItem)combo_grade.SelectedItem).Text;
            this.qual.DateAchieved = new DateTime((int)combo_year.SelectedValue, (int)combo_month.SelectedValue, 1);
            this.DialogResult = DialogResult.OK;
        }
        private void _runSearch()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(_search));
        }

        private void _search(object stateInfo)
        {
            if (combo_board.InvokeRequired)
            {
                combo_board.Invoke(new Action<object>(_search), stateInfo);
                return;
            }
            if ((int)combo_board.SelectedValue < 0
                || text_search.Text.Length <= 1
                )
            {
                return;
            }
            try
            {
                using (OleDbCommand query = Program.dbInt.preparedStmt())
                {
                    query.CommandText = "SELECT `qualRef` FROM `qualifications` WHERE `examBoard`=@board";
                    query.Parameters.AddWithValue("@board", (int)((Classes.Items.ExamBoardItem)combo_board.SelectedItem).ID);
                    if ((int)combo_level.SelectedValue > 0)
                    {
                        query.CommandText += " AND `level`=@level";
                        query.Parameters.AddWithValue("@level", (string)((Classes.Items.dropDownItem)combo_level.SelectedItem).Text);
                    }
                    if (text_search.Text.Length != 0)
                    {
                        query.CommandText += " AND `title` LIKE @title";
                        query.Parameters.AddWithValue("@title", "%" + text_search.Text + "%");
                    }

                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        _lv_Update(true);
                        _lv_Items_Clear();
                        if (!data.HasRows)
                        {
                            _lv_Update(false);
                            return;
                        }
                        ListViewItem item;
                        Classes.Items.QualificationItem qual;
                        while (data.Read())
                        {
                            qual = new Classes.Items.QualificationItem((string)data["qualRef"]);
                            item = new ListViewItem(qual.Level);
                            item.SubItems.Add(qual.Name);
                            item.SubItems.Add(qual.CourseStart.ToShortDateString());
                            item.SubItems.Add(qual.CourseEnd.ToShortDateString());
                            item.Tag = qual;

                            _lv_Items_Add(item);
                        }
                        _lv_Update(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Classes.Database.Interface.databaseError("Failed to search database.", GetType().Namespace, ex.Message);
            }
            _lv_Update(false);
        }

        #region LV Delegates
        private void _lv_Update(bool begin)
        {
            if (lv_results.InvokeRequired)
            {
                lv_results.Invoke(new Action<bool>(_lv_Update), begin);
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
        private void _lv_Items_Clear()
        {
            if (lv_results.InvokeRequired)
            {
                lv_results.Invoke(new Action(_lv_Items_Clear));
            }
            else
            {
                lv_results.Items.Clear();
            }
        }
        private void _lv_Items_Add(ListViewItem item)
        {
            if (lv_results.InvokeRequired)
            {
                lv_results.Invoke(new Action<ListViewItem>(_lv_Items_Add), item);
            }
            else
            {
                lv_results.Items.Add(item);
            }
        }
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
        #endregion
        private void _loadExamBoards()
        {
            Thread.Sleep(50);
            if (combo_board.InvokeRequired)
            {
                combo_board.Invoke(new Action(_loadExamBoards));
            }
            else
            {
                combo_board.SelectedIndexChanged -= combo_board_SelectedIndexChanged;
                combo_board.DataSource = new Classes.Lists.ExamBoard(true).List;
                combo_board.SelectedIndexChanged += combo_board_SelectedIndexChanged;
            }
        }

        #region Validation
        private bool _checkValidation()
        {
            List<string> messages = new List<string>();
            bool is_success = true;
            if (!_validate_achievedMonth())
            {
                messages.Add(_validate_achievedMonth().Message);
                is_success = false;
            }
            if (!_validate_achievedYear())
            {
                messages.Add(_validate_achievedYear().Message);
                is_success = false;
            }
            if (!_validate_grade())
            {
                messages.Add(_validate_grade().Message);
                is_success = false;
            }

            if (!is_success)
            {
                Validation.show_message(messages);
            }
            return is_success;
        }

        private StatusMessage _validate_achievedMonth(bool call_Validate = true)
        {
            if (combo_month.InvokeRequired)
            {
                return (StatusMessage)combo_month.Invoke(new Func<bool, StatusMessage>(_validate_achievedMonth));
            }
            StatusMessage result = new StatusMessage(false);
            if ((int)combo_month.SelectedValue < 0)
            {
                result.Message = "Select month of achievment.";
            }
            else
            {
                result.is_Success = true;
            }

            if (!result || !_validate_achievedYear(false))
            {
                Validation.set_validation(label_val_achieved, false);
            }
            else
            {
                Validation.set_validation(label_val_achieved, true);
            }
            return result;
        }
        private StatusMessage _validate_achievedYear(bool call_Validate = true)
        {
            if (combo_year.InvokeRequired)
            {
                return (StatusMessage)combo_year.Invoke(new Func<bool, StatusMessage>(_validate_achievedYear), call_Validate);
            }
            StatusMessage result = new StatusMessage(false);
            if ((int)combo_year.SelectedValue < 0)
            {
                result.Message = "Select year of achievment.";
            }
            else
            {
                result.is_Success = true;
            }
            if (!call_Validate)
            {
                return result;
            }

            if (!result || !_validate_achievedMonth(false))
            {
                Validation.set_validation(label_val_achieved, false);
            }
            else
            {
                Validation.set_validation(label_val_achieved, true);
            }
            return result;
        }

        private StatusMessage _validate_grade()
        {
            if (combo_grade.InvokeRequired)
            {
                return (StatusMessage)combo_grade.Invoke(new Func<StatusMessage>(_validate_grade));
            }
            StatusMessage result = new StatusMessage(false);
            if ((int)combo_grade.SelectedValue < 0)
            {
                result.Message = "Select grade achieved.";
            }
            else
            {
                result.is_Success = true;
            }
            Validation.set_validation(label_val_grade, result);
            return result;
        }
        #endregion
    }
}
