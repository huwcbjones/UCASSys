using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Globalization;

namespace UCASSys.Classes
{
    static class Validation
    {
        static TextInfo textinf = CultureInfo.CurrentCulture.TextInfo;
        public static void set_validation(Label label, bool state)
        {
            if (state)
            {
                label.ForeColor = Color.Green; label.Text = "✓";
            }
            else
            {
                label.ForeColor = Color.Red; label.Text = "X";
            }
        }
        public static StatusMessage validate_string(string text, string fieldName, string conditions, string message, int minLength = -1, int maxLength = -1, bool ignoreCase = true)
        {
            fieldName = textinf.ToTitleCase(fieldName);
            StatusMessage result = new StatusMessage();
            RegexOptions options = RegexOptions.None;
            if (ignoreCase)
            {
                options = RegexOptions.IgnoreCase;
            }

            if (minLength != -1 && text.Length < minLength)
            {
                result.is_Success = false;
                result.Message = fieldName + " must be at least " + minLength.ToString() + " characters.";
            }
            else if (maxLength != -1 && text.Length > maxLength)
            {
                result.is_Success = false;
                result.Message = fieldName + " must not be more than " + maxLength.ToString() + " characters.";
            }
            else if (!Regex.Match(text, conditions, options).Success)
            {
                result.is_Success = false;
                result.Message = fieldName + " " + message;
            }
            return result;
        }
        public static StatusMessage password(string text, bool is_required = false)
        {
            if (text.Length == 0 && !is_required)
            {
                return new StatusMessage();
            }
            return validate_string(text, "Password", "^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])[\\s\\S]+$", "must contain at least 1 lower case letter, upper case letter and number and must be more than 3 charaters long", 3, -1, false);
        }
        public static StatusMessage name(string text, string name, bool is_required = false)
        {
            if (text.Length == 0 && !is_required)
            {
                return new StatusMessage();
            }
            return validate_string(text, name, "^[a-z\\-]+$", "can only contain letters and -", 3, 255);
        }
        public static StatusMessage middleNames(string text, bool is_required = false)
        {
            if (text.Length == 0 && !is_required)
            {
                return new StatusMessage();
            }
            return validate_string(text, "Middle name", "^([a-z\\-]+)(\\s[a-z\\-]+)*$", "can only contain letters and -", 3, 255);
        }
        public static StatusMessage phone(string text, bool is_required = false)
        {
            if (text.Length == 0 && !is_required)
            {
                return new StatusMessage();
            }
            return validate_string(text, "Phone", "^((\\+[\\d]{2})|0)[\\s\\d]+$", "must start with country code, or 0 and containg only numbers and spaces", 6, 255);
        }
        public static StatusMessage username(string text, bool is_required = false)
        {
            if (text.Length == 0 && !is_required)
            {
                return new StatusMessage();
            }
            return validate_string(text, "Username", "[a-z0-9_]$", "can only contain letters, numbers and underscore (_)", 3, 255);
        }
        public static StatusMessage email(string text, bool is_required = false)
        {
            if (text.Length == 0 && !is_required)
            {
                return new StatusMessage();
            }
            return validate_string(text, "Email Address", "\\b[A-z0-9._%+-]+@[A-z0-9.-]+\\.[A-z]{2,4}\\b", "can only contain letters, numbers and underscore (_)", 3, 255);
        }
        public static StatusMessage confirm(string field1, string field2, string message, bool reverse = false)
        {
            StatusMessage result = new StatusMessage();
            if (!reverse)
            {
                if (field1 != field2)
                {
                    result.is_Success = false;
                    result.Message = message;
                }
            }
            else
            {
                if (field1 == field2)
                {
                    result.is_Success = false;
                    result.Message = message;
                }
            }


            return result;
        }

        public static string formatPhone(string phone)
        {
            if (phone.Length == 0)
            {
                return "";
            }
            string formattedPhone = "";
            phone = phone.Replace(" ", "");
            if (phone.Contains("+"))
            {
                formattedPhone = phone.Substring(0, 3) + " " + phone.Substring(3, 4) + " " + phone.Substring(7, phone.Length - 7);
            }
            else
            {
                formattedPhone = phone.Substring(0, 5) + " " + phone.Substring(5, phone.Length - 5);
            }
            return formattedPhone;
        }
        public static void show_message(List<string> message)
        {
            string content = "";
            int i = 1;
            foreach (string str in message)
            {
                content += "- " + str;
                if (i != message.Count())
                {
                    content += Environment.NewLine;
                }
                i++;
            }
            TaskDialog dialog = new TaskDialog();
            dialog.errorBox();
            dialog.Title = "Validation Error";
            dialog.Subtitle = "Form was filled in incorrectly.";
            dialog.Text = "Please correct the following errors.";
            dialog.DetailsText = content;
            dialog.ExpansionMode = Microsoft.WindowsAPICodePack.Dialogs.TaskDialogExpandedDetailsLocation.ExpandContent;
            dialog.Show();
        }
    }
}