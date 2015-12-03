using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using UCASSys.Classes.Items;

namespace UCASSys.Forms.Students
{
    public partial class main : Form
    {
        private string studentHash = "";
        private string qualHash = "";
        public Classes.Items.StudentItem student = new Classes.Items.StudentItem();

        private Dictionary<string, bool> needs_saving = new Dictionary<string, bool>();
        private bool is_closing = false;

        private ListViewColumnSorter columnSorter = new ListViewColumnSorter();

        private int _mode = Program.MODE_New;
        public int Mode
        {
            get { return _mode; }
        }

        public main(int mode = Program.MODE_New, Classes.Items.StudentItem editStudent = null)
        {
            this._mode = mode;
            if (editStudent != null)
            {
                this.student = editStudent;
            }
            InitializeComponent();

            this.datetime_DoB.Format = DateTimePickerFormat.Short;
            datetime_DoB.Name = "Date of Birth";

            _loadForm();
            this.Shown += main_Shown;
            this.FormClosing += main_FormClosing;
            btn_close.Click += confirm_formClose;
            btn_save.Click += save;
            btn_completed.Click += btn_completed_Click;

            btn_doPersonal.Click += btn_doPersonal_Click;
            text_notes.TextChanged += text_notes_TextChanged;

            btn_addQuals.Click += btn_addQuals_Click;
            btn_editQual.Click += btn_editQual_Click;
            btn_deleteQuals.Click += btn_deleteQuals_Click;
            btn_quickAdd.Click += btn_quickAdd_Click;

            lv_quals.ListViewItemSorter = this.columnSorter;
            lv_quals.ColumnClick += lv_sortColumn;
            lv_quals.ItemSelectionChanged += lv_quals_ItemSelectionChanged;
            lv_quals.DoubleClick += lv_quals_DoubleClick;
            lv_quals.SizeChanged += _resizeLV;
        }

        private void main_Shown(object sender, EventArgs e)
        {
            if (this._mode == Program.MODE_New)
            {
                btn_doPersonal_Click(sender, e);
            }
        }

        private void _loadForm()
        {
            needs_saving.Add("details", false);
            needs_saving.Add("notes", false);
            needs_saving.Add("quals", false);

            if (this._mode == Program.MODE_New)
            {
                this.Text = "New Student";
            }
            else if (this._mode == Program.MODE_Edit)
            {
                this.Text = "Student: " + student.LastName + ", " + student.FirstName + " " + student.MiddleNames;
                this.btn_doPersonal.Text = "Edit &Personal Info";
                this.text_firstName.Text = student.FirstName;
                this.text_middleNames.Text = student.MiddleNames;
                this.text_lastName.Text = student.LastName;
                this.text_email.Text = student.Email;
                this.text_phone.Text = student.Phone;

                this.combo_gender.Items.Clear();
                this.combo_gender.Items.Add(student.Gender);
                this.combo_gender.SelectedItem = student.Gender;

                this.datetime_DoB.Value = student.DateOfBirth;

                this.text_notes.Text = student.Notes;

                this.group_notes.Enabled = true;
                this.group_qual.Enabled = true;

                if (student.Status == Classes.Status.Complete)
                {
                    _set_completeBtn_inProgress();
                }
                else
                {
                    _set_completeBtn_complete();
                }

                this.studentHash = student.Hash();
                this.qualHash = student.QualHash();

                _updateQualLV();
            }
            else
            {
                Program.error("Student form error.", "Failed to load student form.", "Invalid mode was passed.");
                this.Close();
            }

            combo_gender.DisplayMember = "Text";
            combo_gender.ValueMember = "ID";
        }

        #region Helper Functions
        private void _set_completeBtn_complete()
        {
            if (btn_completed.InvokeRequired)
            {
                btn_completed.Invoke(new Action(_set_completeBtn_complete));
                return;
            }

            btn_completed.Enabled = true;
            btn_completed.Text = "Set &Complete";

            btn_doPersonal.Text = "Edit &Personal Info";

            text_notes.ReadOnly = false;

            btn_addQuals.Enabled = true;
            btn_editQual.Text = "&Edit";

            _mode = Program.MODE_Edit;
        }
        private void _set_completeBtn_inProgress()
        {
            if (btn_completed.InvokeRequired)
            {
                btn_completed.Invoke(new Action(_set_completeBtn_inProgress));
                return;
            }
            btn_completed.Enabled = true;
            btn_completed.Text = "Set &In Progress";

            btn_doPersonal.Text = "View &Personal Info";

            btn_addQuals.Enabled = false;
            btn_editQual.Text = "&View";
            btn_deleteQuals.Enabled = false;

            text_notes.ReadOnly = true;
            _mode = Program.MODE_View;

        }
        private void _set_saveBtn()
        {
            if (needs_saving.ContainsValue(true))
            {
                this.btn_save.Enabled = true;
            }
            else if (this._mode == Program.MODE_View)
            {
                this.btn_save.Enabled = false;
            }
            else
            {
                this.btn_save.Enabled = false;
            }
        }
        private void _set_qualBtns()
        {
            if (lv_quals.InvokeRequired)
            {
                lv_quals.Invoke(new Action(_set_qualBtns));
            }
            else if (btn_editQual.InvokeRequired)
            {
                btn_editQual.Invoke(new Action(_set_qualBtns));
            }
            else if (btn_deleteQuals.InvokeRequired)
            {
                btn_deleteQuals.Invoke(new Action(_set_qualBtns));
            }
            else if (lv_quals.SelectedItems.Count == 0)
            {
                btn_editQual.Enabled = false;
                btn_deleteQuals.Enabled = false;
            }
            else if (lv_quals.SelectedItems.Count == 1)
            {
                btn_editQual.Enabled = true;
                btn_deleteQuals.Enabled = true;
            }
            else
            {
                btn_editQual.Enabled = false;
                btn_deleteQuals.Enabled = true;
            }
        }
        #endregion

        #region Details Stuff
        void btn_completed_Click(object sender, EventArgs e)
        {
            if (student.Status == Classes.Status.Complete)
            {
                student.Status = Classes.Status.InProgress;
            }
            else
            {
                student.Status = Classes.Status.Complete;
            }
            if (student.Hash() != studentHash)
            {
                needs_saving["details"] = true;
            }
            else
            {
                needs_saving["details"] = false;
            }

            save(sender, e);

        }
        void text_notes_TextChanged(object sender, EventArgs e)
        {
            if (text_notes.Text != student.Notes)
            {
                needs_saving["notes"] = true;
                _set_saveBtn();
            }
            else
            {
                needs_saving["notes"] = false;
                _set_saveBtn();
            }
        }
        void btn_doPersonal_Click(object sender, EventArgs e)
        {
            dialog.information studentInfo;

            // Check to see if we are editing an existing student
            if (_mode == Program.MODE_New)
            {
                studentInfo = new dialog.information();
            }
            else
            {
                studentInfo = new dialog.information(_mode, student);
                studentHash = student.Hash();
            }

            // Did user want to keep changes?
            if (studentInfo.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (_mode == Program.MODE_New)
            {
                // New student, so now editing
                _mode = Program.MODE_Edit;
                // And needs saving
                needs_saving["details"] = true;
                _set_saveBtn();

                // Can edit rest of form now
                this.group_qual.Enabled = true;
                this.group_notes.Enabled = true;

                this.btn_doPersonal.Text = "Edit &Personal Info";
            }
            // Editing existing, compare hash to check for changes
            else if (studentInfo.student.Hash() != studentHash)
            {
                needs_saving["details"] = true;
            }
            else
            {
                needs_saving["details"] = false;
                _set_saveBtn();
                return;
            }

            _set_saveBtn();

            student = studentInfo.student;

            this.Text = "Student: " + student.LastName + ", " + student.FirstName + " " + student.MiddleNames;

            this.text_firstName.Text = student.FirstName;
            this.text_middleNames.Text = student.MiddleNames;
            this.text_lastName.Text = student.LastName;
            this.text_email.Text = student.Email;
            this.text_phone.Text = student.Phone;

            this.combo_gender.Items.Clear();
            this.combo_gender.Items.Add(student.Gender);
            this.combo_gender.SelectedItem = student.Gender;

            this.datetime_DoB.Value = student.DateOfBirth;
        }
        #endregion

        #region Quals Stuff
        void btn_addQuals_Click(object sender, EventArgs e)
        {
            using (dialog.qualification newQual = new dialog.qualification())
            {
                if (newQual.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                if (student.Qualifications.ContainsKey(newQual.qual.Reference))
                {
                    student.Qualifications[newQual.qual.Reference] = newQual.qual;
                }
                else
                {
                    student.Qualifications.Add(newQual.qual.Reference, newQual.qual);
                }
            }
            if (qualHash != student.QualHash())
            {
                needs_saving["quals"] = true;
            }
            else
            {
                needs_saving["quals"] = false;
            }
            _set_saveBtn();
            _updateQualLV();
        }
        void btn_editQual_Click(object sender, EventArgs e)
        {
            if (lv_quals.InvokeRequired)
            {
                lv_quals.Invoke(new Action<object, EventArgs>(btn_editQual_Click), sender, e);
                return;
            }
            QualificationItem editQual = student.Qualifications[(string)lv_quals.SelectedItems[0].Tag];
            using (dialog.qualification editQualForm = new dialog.qualification(this.Mode, editQual))
            {
                if (editQualForm.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                student.Qualifications[(string)lv_quals.SelectedItems[0].Tag] = editQualForm.qual;
                if (qualHash != student.QualHash())
                {
                    needs_saving["quals"] = true;
                }
                _updateQualLV();
                _set_saveBtn();
            }
        }
        void btn_deleteQuals_Click(object sender, EventArgs e)
        {
            if (lv_quals.InvokeRequired)
            {
                lv_quals.Invoke(new Action<object, EventArgs>(btn_deleteQuals_Click), sender, e);
                return;
            }

            foreach (ListViewItem item in lv_quals.SelectedItems)
            {
                student.Qualifications.Remove((string)item.Tag);
            }

            needs_saving["quals"] = true;
            _updateQualLV();
            _set_saveBtn();
        }
        void btn_quickAdd_Click(object sender, EventArgs e)
        {
            using (dialog.quickAddQual quickAdd = new dialog.quickAddQual(student.YearOfEntry))
            {

                if (quickAdd.IsDisposed
                    || quickAdd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                foreach (QualificationItem qual in quickAdd.Qualifications)
                {
                    if (student.Qualifications.ContainsKey(qual.Reference))
                    {
                        student.Qualifications[qual.Reference] = qual;
                    }
                    else
                    {
                        student.Qualifications.Add(qual.Reference, qual);
                    }
                }
            }
            if (qualHash != student.QualHash())
            {
                needs_saving["quals"] = true;
            }
            else
            {
                needs_saving["quals"] = false;
            }
            _set_saveBtn();
            _updateQualLV();
        }
        void lv_quals_ItemSelectionChanged(object sender, EventArgs e)
        {
            _set_qualBtns();
        }
        void lv_quals_DoubleClick(object sender, EventArgs e)
        {
            if(lv_quals.SelectedItems.Count == 1){
                btn_editQual_Click(sender, e);
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
            this.lv_quals.Sort();
        }
        private void _resizeLV(object sender, EventArgs e)
        {
            if (lv_quals.InvokeRequired)
            {
                lv_quals.Invoke(new Action<object, EventArgs>(_resizeLV), sender, e);
                return;
            }
            double unitFactor = (double)(lv_quals.Width - 6) / 760;

            lv_qual_board.Width = (int)Math.Floor(unitFactor * 175);
            lv_qual_subject.Width = (int)Math.Floor(unitFactor * 380);
        }

        private void _editQual()
        {

        }
        private void _updateQualLV()
        {
            if (lv_quals.InvokeRequired)
            {
                lv_quals.Invoke(new Action(_updateQualLV));
                return;
            }

            lv_quals.BeginUpdate();
            lv_quals.Items.Clear();

            ListViewItem lv_item;
            foreach (KeyValuePair<string, QualificationItem> qualPair in student.Qualifications)
            {
                lv_item = new ListViewItem(qualPair.Value.Level);
                lv_item.Tag = qualPair.Key;
                lv_item.SubItems.Add(qualPair.Value.ExamBoard.Text);
                lv_item.SubItems.Add(qualPair.Value.Name);
                lv_item.SubItems.Add(qualPair.Value.GradeAchieved);
                lv_item.SubItems.Add(qualPair.Value.DateAchieved.ToString("MMMM yyyy"));

                lv_quals.Items.Add(lv_item);
            }
            lv_quals.EndUpdate();
        }
        #endregion

        #region Saving
        void save(object sender, EventArgs e)
        {
            if (!_save_details())
            {
                return;
            }

            if (!_save_notes())
            {
                return;
            }

            if (!_save_quals())
            {
                return;
            }

            _set_saveBtn();

            if (student.Status == Classes.Status.Complete)
            {
                _set_completeBtn_inProgress();
            }
            else
            {
                _set_completeBtn_complete();
            }

            Program.events.studentSaved();
        }

        private Classes.StatusMessage _save_details()
        {
            if (!needs_saving["details"])
            {
                return new Classes.StatusMessage();
            }

            if (this.studentHash == student.Hash())
            {
                needs_saving["details"] = false;
                return new Classes.StatusMessage();
            }

            Classes.StatusMessage result = student.save();
            if (result)
            {
                needs_saving["details"] = false;
                studentHash = student.Hash();
                return new Classes.StatusMessage();
            }

            needs_saving["details"] = true;
            using (Classes.TaskDialog dialog = new Classes.TaskDialog(this.Handle))
            {
                dialog.errorBox();
                dialog.Title = "Save Failed!";
                dialog.Subtitle = "Failed to save student!";
                dialog.Text = "There was an error whilst saving details.";
                dialog.DetailsText = result.Message;
                dialog.StandardButtons = TaskDialogStandardButtons.Cancel | TaskDialogStandardButtons.Retry;
                if (dialog.Show() == TaskDialogResult.Retry)
                {
                    return _save_details();
                }
            }
            return new Classes.StatusMessage(false, result.Message, result.Data);

        }
        private Classes.StatusMessage _save_notes()
        {
            if (!needs_saving["notes"])
            {
                return new Classes.StatusMessage();
            }
            if (student.Notes == text_notes.Text)
            {
                needs_saving["notes"] = false;
                return new Classes.StatusMessage();
            }

            student.Notes = text_notes.Text;
            Classes.StatusMessage result = student.save_notes();
            if (result)
            {
                needs_saving["notes"] = false;
                return new Classes.StatusMessage();
            }

            using (Classes.TaskDialog dialog = new Classes.TaskDialog(this.Handle))
            {
                dialog.errorBox();
                dialog.Title = "Save Failed!";
                dialog.Subtitle = "Failed to save student!";
                dialog.Text = "There was an error whilst saving notes.";
                dialog.DetailsText = result.Message;
                dialog.StandardButtons = TaskDialogStandardButtons.Cancel | TaskDialogStandardButtons.Retry;
                if (dialog.Show() == TaskDialogResult.Retry)
                {
                    return _save_notes();
                }
            }
            return new Classes.StatusMessage(false, result.Message, result.Data);
        }
        private Classes.StatusMessage _save_quals()
        {
            if (!needs_saving["quals"])
            {
                return new Classes.StatusMessage();
            }
            if (qualHash == student.QualHash())
            {
                needs_saving["quals"] = false;
                return new Classes.StatusMessage();
            }

            Classes.StatusMessage result = student.save_quals();
            if (result)
            {
                qualHash = student.QualHash();
                needs_saving["quals"] = false;
                return new Classes.StatusMessage();
            }

            using (Classes.TaskDialog dialog = new Classes.TaskDialog(this.Handle))
            {
                dialog.errorBox();
                dialog.Title = "Save Failed!";
                dialog.Subtitle = "Failed to save student!";
                dialog.Text = "There was an error whilst saving qualifications.";
                dialog.DetailsText = result.Message;
                dialog.StandardButtons = TaskDialogStandardButtons.Cancel | TaskDialogStandardButtons.Retry;
                if (dialog.Show() == TaskDialogResult.Retry)
                {
                    return _save_quals();
                }
            }
            return new Classes.StatusMessage();
        }

        #endregion

        #region Close Checking
        private bool can_Close()
        {
            using (Classes.TaskDialog dialog = new Classes.TaskDialog(this.Handle))
            {
                dialog.confirmBox();
                dialog.Title = "Save student?";
                dialog.Subtitle = "Close without saving?";
                dialog.Text = "Are you sure you want to close this student without saving their data?";

                return (dialog.Show() == Microsoft.WindowsAPICodePack.Dialogs.TaskDialogResult.Ok);
            }
        }
        private void confirm_formClose(object sender, EventArgs e)
        {
            if (!needs_saving.ContainsValue(true))
            {
                is_closing = true;
                this.Close();
                return;
            }
            if (can_Close())
            {
                is_closing = true;
                this.Close();
            }
        }
        void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (is_closing
                || !needs_saving.ContainsValue(true))
            {
                return;
            }
            if (!can_Close())
            {
                e.Cancel = true;
            }
        }
        #endregion

    }
}
