using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Validation = UCASSys.Classes.Validation;
using StatusMessage = UCASSys.Classes.StatusMessage;
using System.Globalization;
namespace UCASSys.Forms.Students.dialog
{

    public partial class information : Form
    {
        protected bool ulnValid = false;

        TextInfo textinf = CultureInfo.CurrentCulture.TextInfo;

        public Classes.Items.StudentItem student = new Classes.Items.StudentItem();

        public information(int mode = Program.MODE_New, Classes.Items.StudentItem editStudent = null)
        {
            InitializeComponent();

            _loadForm(mode, editStudent);

            if (mode == Program.MODE_Edit
             || mode == Program.MODE_View
            )
            {
                _loadStudent(mode);
            }

            btn_do.Click += btn_do_Click;
            // Format Handlers
            text_firstName.LostFocus += formatNames;
            text_middleNames.LostFocus += formatNames;
            text_lastName.LostFocus += formatNames;
            text_email.LostFocus += formatEmail;

            // Validation Handlers
            text_uln.TextChanged += text_uln_TextChanged;
            text_firstName.TextChanged += text_firstName_TextChanged;
            text_middleNames.TextChanged += text_middleNames_TextChanged;
            text_lastName.TextChanged += text_lastName_TextChanged;
            text_email.TextChanged += text_email_TextChanged;
            text_phone.TextChanged += text_phone_TextChanged;
            combo_gender.SelectedValueChanged += combo_gender_SelectedValueChanged;
            combo_religion.SelectedValueChanged += combo_religion_SelectedValueChanged;

            combo_YoE.SelectedValueChanged += combo_YoE_SelectedValueChanged;
            combo_tutor.SelectedValueChanged += combo_tutor_SelectedValueChanged;
        }

        private void _loadForm(int mode, Classes.Items.StudentItem editStudent)
        {
            // Set datetime options
            this.datetime_DoB.Format = DateTimePickerFormat.Short;
            datetime_DoB.MaxDate = DateTime.Now.AddYears(-16);
            datetime_DoB.MinDate = DateTime.Parse("1980-01-01");
            datetime_DoB.Name = "Date of Birth";

            // Set religion options
            combo_religion.DataSource = new Classes.Lists.Religion().List;
            combo_religion.DisplayMember = "Text";
            combo_religion.ValueMember = "ID";

            combo_gender.DataSource = new Classes.Lists.Gender().List;
            combo_gender.DisplayMember = "Text";
            combo_gender.ValueMember = "ID";

            combo_YoE.DataSource = new Classes.Lists.YearOfEntry().List;
            combo_YoE.DisplayMember = "Text";
            combo_YoE.ValueMember = "ID";

            combo_tutor.DataSource = new Classes.Lists.TutorGroup().List;
            combo_tutor.DisplayMember = "Text";
            combo_tutor.ValueMember = "ID";


            if (mode == Program.MODE_New)
            {
                this.Text = "Add Personal Information";
                btn_do.Text = "&Add";
            }
            else if (
                (
                  mode == Program.MODE_Edit
               || mode == Program.MODE_View
                )
                && editStudent == null
            )
            {
                using (Classes.TaskDialog dialog = new Classes.TaskDialog(this.Handle))
                {
                    dialog.errorBox();
                    dialog.Title = "Data Error";
                    dialog.Subtitle = "Failed to load student information.";
                    dialog.Text = "UCAS Sys tried to load student information, but failed.";
                    dialog.DetailsText = "StudentItem was null.";

                    dialog.Show();
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            else if (
                mode == Program.MODE_Edit
             || mode == Program.MODE_View
            )
            {
                this.student = editStudent;
            }
        }


        private void _loadStudent(int mode)
        {
            if (mode == Program.MODE_Edit)
            {
                this.Text = "Edit Personal Information";
                btn_do.Text = "&Edit";
                btn_do.Visible = true;
            }else if (mode == Program.MODE_View){
                this.Text = "View Personal Information";
                btn_do.Visible = false;

                text_uln.ReadOnly = true;

                text_firstName.ReadOnly = true;
                text_middleNames.ReadOnly = true;
                text_lastName.ReadOnly = true;
                text_email.ReadOnly = true;
                text_phone.ReadOnly = true;
                datetime_DoB.Enabled = false;
                combo_gender.Enabled = false;
                combo_religion.Enabled = false;

                combo_YoE.Enabled = false;
                combo_tutor.Enabled = false;
            }else{
                return;
            }

            text_uln.Text = this.student.ULN.ToString();
            text_uln.ReadOnly = true;
            text_uln.TabStop = false;

            text_firstName.Text = this.student.FirstName;
            text_middleNames.Text = this.student.MiddleNames;
            text_lastName.Text = this.student.LastName;
            text_email.Text = this.student.Email;
            text_phone.Text = this.student.Phone;

            datetime_DoB.Value = this.student.DateOfBirth;

            combo_gender.SelectedValue = this.student.Gender.ID;
            combo_religion.SelectedValue = this.student.Religion.ID;

            combo_YoE.SelectedValue = this.student.YearOfEntry;
            set_tutor_source();
            combo_tutor.SelectedValue = this.student.TutorGroup;

            if (student.isYoEDeadline)
            {
                datetime_deadline.Checked = false;
                datetime_deadline.Value = DateTime.Now;
            }
            else
            {
                datetime_deadline.Checked = true;
                datetime_deadline.Value = student.Deadline;
            }
        }

        void btn_do_Click(object sender, EventArgs e)
        {
            if (this.checkValidation())
            {
                student.ULN = Int64.Parse(text_uln.Text);
                student.FirstName = text_firstName.Text;
                student.MiddleNames = text_middleNames.Text;
                student.LastName = text_lastName.Text;
                student.Email = text_email.Text;
                student.DateOfBirth = datetime_DoB.Value;
                student.Phone = text_phone.Text;
                student.Gender = (Classes.Items.GenderItem)combo_gender.SelectedItem;
                student.Religion = (Classes.Items.ReligionItem)combo_religion.SelectedItem;
                student.YearOfEntry = (int)combo_YoE.SelectedValue;
                student.TutorGroup = (int)combo_tutor.SelectedValue;
                if (datetime_deadline.Checked)
                {
                    student.isYoEDeadline = false;
                    student.Deadline = datetime_deadline.Value;
                }
                else
                {
                    student.isYoEDeadline = true;
                }
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }

        #region Formatters
        private void formatNames(object sender, EventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            tbox.Text = this.textinf.ToTitleCase(tbox.Text);
        }
        private void formatEmail(object sender, EventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            tbox.Text = tbox.Text.ToLower();
        }
        #endregion

        #region Validation Handlers
        private void text_uln_TextChanged(object sender, EventArgs e)
        {
            validate_ULN();
        }
        void text_firstName_TextChanged(object sender, EventArgs e)
        {

            validate_FirstName();
        }
        void text_middleNames_TextChanged(object sender, EventArgs e)
        {
            validate_MiddleNames();
        }
        void text_lastName_TextChanged(object sender, EventArgs e)
        {
            validate_LastName();
        }
        void text_email_TextChanged(object sender, EventArgs e)
        {
            validate_Email();
        }
        void text_phone_TextChanged(object sender, EventArgs e)
        {
            validate_Phone();
        }
        void combo_gender_SelectedValueChanged(object sender, EventArgs e)
        {
            if (
                (int)combo_gender.SelectedValue == -2
                && Program.userCtrl.is_admin
                )
            {
                Forms.Admin.Gender.Gender newGender = new Admin.Gender.Gender();
                if (newGender.ShowDialog() == DialogResult.OK)
                {
                    combo_gender.DataSource = new Classes.Lists.Gender().List;
                }
                else
                {
                    validate_Gender();
                }
            }
            else
            {
                validate_Gender();
            }
        }
        void combo_religion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (
                (int)combo_religion.SelectedValue == -2
                && Program.userCtrl.is_admin
               )
            {
                Forms.Admin.Religion.Religion newReligion = new Admin.Religion.Religion();
                if (newReligion.ShowDialog() == DialogResult.OK)
                {
                    combo_religion.DataSource = new Classes.Lists.Religion().List;
                }
                else
                {
                    validate_Religion();
                }
            }
            else
            {
                validate_Religion();
            }
        }
        void combo_YoE_SelectedValueChanged(object sender, EventArgs e)
        {
            if (
                 (int)combo_YoE.SelectedValue == -2
                 && Program.userCtrl.is_admin
                )
            {
                Forms.Admin.YoE.Dialog.YearOfEntry newYearOfEntry = new Forms.Admin.YoE.Dialog.YearOfEntry();
                if (newYearOfEntry.ShowDialog() == DialogResult.OK)
                {
                    combo_YoE.DataSource = new Classes.Lists.YearOfEntry().List;
                }
                else
                {
                    set_tutor_source();
                    validate_YoE();
                }
            }
            else
            {
                set_tutor_source();
                validate_YoE();
            }
        }
        void set_tutor_source()
        {
            if (combo_YoE.SelectedValue == null
               || (int)combo_YoE.SelectedValue < 0) {
                return;
            }
            combo_tutor.DataSource = new Classes.Lists.TutorGroup((int)combo_YoE.SelectedValue).List;
        }
        void combo_tutor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (
                 (int)combo_tutor.SelectedValue == -2
                 && Program.userCtrl.is_admin
                )
            {
                Forms.Admin.YoE.Dialog.TutorGroup newTutorGroup = new Forms.Admin.YoE.Dialog.TutorGroup();
                if (newTutorGroup.ShowDialog() == DialogResult.OK)
                {
                    combo_tutor.DataSource = new Classes.Lists.TutorGroup().List;
                    set_tutor_source();
                }
                else
                {
                    validate_Tutor();
                }
            }
            else
            {
                validate_Tutor();
            }
        }
        #endregion

        #region Validation
        StatusMessage validate_ULN()
        {
            if (text_uln.ReadOnly)
            {
                Validation.set_validation(label_val_uln, true);
                return new StatusMessage();
            }
            StatusMessage result = Validation.validate_string(text_uln.Text, "ULN", "^[0-9]+$", "must be an integer.");
            if (result)
            {
                using (OleDbCommand selectQuery = Program.dbInt.preparedStmt())
                {
                    selectQuery.CommandText = "SELECT COUNT(*) FROM `students` WHERE `uln`=@uln";
                    selectQuery.Parameters.AddWithValue("@uln", text_uln.Text);

                    if ((int)selectQuery.ExecuteScalar() != 0)
                    {
                        result.Message = "ULN already exists.";
                        result.is_Success = false;
                    }
                    else
                    {
                        result.is_Success = true;
                    }
                }
            }
            Validation.set_validation(label_val_uln, result);
            return result;
        }

        StatusMessage validate_FirstName()
        {
            StatusMessage result = Validation.name(text_firstName.Text, "First Name", true);
            Validation.set_validation(label_val_firstName, result);
            return result;
        }

        StatusMessage validate_MiddleNames()
        {
            StatusMessage result = Validation.middleNames(text_middleNames.Text);
            Validation.set_validation(label_val_middleNames, result);
            return result;
        }

        StatusMessage validate_LastName()
        {
            StatusMessage result = Validation.name(text_lastName.Text, "Last Name", true);
            Validation.set_validation(label_val_lastName, result);
            return result;
        }

        StatusMessage validate_Email()
        {
            StatusMessage result = Validation.email(text_email.Text, true);
            Validation.set_validation(label_val_email, result);
            return result;
        }

        StatusMessage validate_Phone()
        {
            StatusMessage result = Validation.phone(text_phone.Text);
            Validation.set_validation(label_val_phone, result);
            return result;
        }

        StatusMessage validate_Gender()
        {
            StatusMessage result = new StatusMessage();
            if ((int)combo_gender.SelectedValue < 0)
            {
                result.Message = "Gender selection is invalid.";
                result.is_Success = false;
            }
            Validation.set_validation(label_val_gender, result);
            return result;
        }

        StatusMessage validate_Religion()
        {
            StatusMessage result = new StatusMessage();
            if ((int)combo_religion.SelectedValue < 0)
            {
                result.Message = "Religion selection is invalid.";
                result.is_Success = false;
            }
            Validation.set_validation(label_val_religion, result);
            return result;
        }

        StatusMessage validate_YoE()
        {
            StatusMessage result = new StatusMessage();
            if (combo_YoE.SelectedValue == null
                || (int)combo_YoE.SelectedValue < 0)
            {
                result.Message = "Year of Entry selection is invalid.";
                result.is_Success = false;
            }
            Validation.set_validation(label_val_YoE, result);
            return result;
        }

        StatusMessage validate_Tutor()
        {
            StatusMessage result = new StatusMessage();
            if (combo_tutor.SelectedValue == null
              || (int)combo_tutor.SelectedValue < 0)
            {
                result.Message = "Tutor group selection is invalid.";
                result.is_Success = false;
            }
            Validation.set_validation(label_val_tutor, result);
            return result;
        }
        #endregion

        private bool checkValidation()
        {
            List<string> messages = new List<string>();
            bool is_success = true;
            if (!validate_ULN())
            {
                messages.Add(validate_ULN().Message);
                is_success = false;
            }
            if (!validate_FirstName())
            {
                messages.Add(validate_FirstName().Message);
                is_success = false;
            }
            if (!validate_MiddleNames())
            {
                messages.Add(validate_MiddleNames().Message);
                is_success = false;
            }
            if (!validate_LastName())
            {
                messages.Add(validate_LastName().Message);
                is_success = false;
            }
            if (!validate_Email())
            {
                messages.Add(validate_Email().Message);
                is_success = false;
            }
            if (!validate_Phone())
            {
                messages.Add(validate_Phone().Message);
                is_success = false;
            }
            if (!validate_Gender())
            {
                messages.Add(validate_Gender().Message);
                is_success = false;
            }
            if (!validate_Religion())
            {
                messages.Add(validate_Religion().Message);
                is_success = false;
            }
            if (!validate_YoE())
            {
                messages.Add(validate_YoE().Message);
                is_success = false;
            }
            if (!validate_Tutor())
            {
                messages.Add(validate_Tutor().Message);
                is_success = false;
            }

            if (!is_success)
            {
                Validation.show_message(messages);
            }
            return is_success;
        }
    }
}
