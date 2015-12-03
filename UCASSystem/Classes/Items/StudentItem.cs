using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.OleDb;
using System.Security.Cryptography;
using Text = System.Text.Encoding;

namespace UCASSys.Classes.Items
{
    public class StudentItem
    {

        #region Properties
        private TextInfo _textInfo = CultureInfo.CurrentCulture.TextInfo;

        private bool is_new = true;

        private long _uln;
        public long ULN
        {
            get { return _uln; }
            set { _uln = value; }
        }

        private int _tutor;
        public int TutorGroup
        {
            get { return _tutor; }
            set { _tutor = value; }
        }
        private int _yoe;
        public int YearOfEntry
        {
            get { return _yoe; }
            set { _yoe = value; }
        }

        // NAMES
        private string _firstName = "";
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = _textInfo.ToTitleCase(value); }
        }

        private string _lastName = "";
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = _textInfo.ToTitleCase(value); }
        }

        private string _middleNames = "";
        public string MiddleNames
        {
            get { return _middleNames; }
            set { _middleNames = _textInfo.ToTitleCase(value); }
        }

        public string FullName
        {
            get
            {
                return _firstName + " " + _middleNames + " " + _lastName;
            }
        }


        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        private string _email = "";
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _phone = "";
        public string Phone
        {
            get { return _phone; }
            set { _phone = Validation.formatPhone(value); }
        }


        private GenderItem _gender = new GenderItem(-1, "null");
        public GenderItem Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private ReligionItem _religion = new ReligionItem(-1, "null");
        public ReligionItem Religion
        {
            get { return _religion; }
            set { _religion = value; }
        }

        private string _notes = "";
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        private AddressItem _address = new AddressItem();
        public AddressItem Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private ReferenceItem _reference = new ReferenceItem();
        public ReferenceItem Reference
        {
            get { return _reference; }
            set { _reference = value; }
        }

        private bool _isYoEDeadline = true;
        public bool isYoEDeadline
        {
            get { return _isYoEDeadline; }
            set { _isYoEDeadline = value; }
        }
        private DateTime _deadline;
        public DateTime Deadline
        {
            get { return _deadline; }
            set {
                _isYoEDeadline = false;
                _deadline = value;
            }
        }

        public Dictionary<string, QualificationItem> Qualifications = new Dictionary<string, QualificationItem>();

        public Dictionary<int, ApplicationItem> Applications = new Dictionary<int, ApplicationItem>();

        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }

        }
        #endregion

        public StudentItem(long ULN = -1)
        {
            if (ULN != -1)
            {
                load_ULN(ULN);
            }
        }

        public StatusMessage load_ULN(long ULN)
        {
            StatusMessage result = new StatusMessage(false, "Failed to load student.");

            using (OleDbCommand selectQuery = Program.dbInt.preparedStmt())
            {

                selectQuery.CommandText = "SELECT *, t.`YoE`, y.`deadline_details` AS alt_deadline FROM `students` s, `tutorGroups` t, `yearOfEntry` y WHERE `uln`=@uln AND t.`ID` = s.`tutorGroup` AND t.`YoE` = y.`ID`";
                try
                {
                    selectQuery.Parameters.AddWithValue("@uln", ULN);

                    using (OleDbDataReader data = selectQuery.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            result.Data = "Student ULN was not found.";
                            return result;
                        }
                        result.is_Success = true;
                        while (data.Read())
                        {
                            this.is_new = false;
                            this._uln = ULN;
                            this._yoe = (int)data["YoE"];
                            this._tutor = (int)data["tutorGroup"];
                            this._firstName = (string)data["firstName"];
                            this._middleNames = (string)data["middleNames"];
                            this._lastName = (string)data["lastName"];
                            this._email = (string)data["email"];
                            this._phone = Validation.formatPhone((string)data["phone"]);
                            this._dateOfBirth = (DateTime)data["dob"];
                            this._notes = (data["notes"] != DBNull.Value) ? (string)data["notes"] : String.Empty;
                            this._gender = new GenderItem((int)data["gender"]);
                            this._religion = new ReligionItem((int)data["religion"]);
                            if (data["deadline"] == DBNull.Value)
                            {
                                this._isYoEDeadline = true;
                                this._deadline = (DateTime)data["alt_deadline"];
                            }
                            else
                            {
                                this._isYoEDeadline = false;
                                this._deadline = (DateTime)data["deadline"];
                            }
                            if ((bool)data["complete"])
                            {
                                this._status = Classes.Status.Complete;
                            }
                            else
                            {
                                this._status = Classes.Status.InProgress;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                    result.Data = ex.ToString();
                    Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                }
            }
            if (result.is_Success)
            {
                return _load_Quals();
            }
            return result;
        }
        private StatusMessage _load_Quals()
        {
            StatusMessage result = new StatusMessage(false, "Failed to load qualifications.");
            using (OleDbCommand query = Program.dbInt.preparedStmt())
            {
                try
                {
                    query.CommandText = "SELECT `qualID`, `achieved`, `grade` FROM `student_qual` WHERE `uln`=@ULN";
                    query.Parameters.AddWithValue("@ULN", this._uln);

                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        result.is_Success = true;
                        if (!data.HasRows)
                        {
                            return result;
                        }
                        QualificationItem newQual;
                        while (data.Read())
                        {
                            newQual = new QualificationItem((string)data["qualID"]);
                            newQual.DateAchieved = (DateTime)data["achieved"];
                            newQual.GradeAchieved = (string)data["grade"];
                            if (Qualifications.ContainsKey(newQual.Reference))
                            {
                                continue;
                            }
                            Qualifications.Add(newQual.Reference, newQual);
                        }
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                    result.Data = ex.ToString();
                    Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                }
            }

            return result;
        }
        public StatusMessage save()
        {
            StatusMessage result = new StatusMessage(false);

            // Check for access controls
            if (!Program.userCtrl.can_write
                || !Program.userCtrl.access_students)
            {
                result.Message = "Failed to save student.";
                result.Data = "User lacks the required privilege.";
                return result;
            }

            using (OleDbTransaction transaction = Program.dbInt.connection.BeginTransaction())
            {
                using (OleDbCommand query = Program.dbInt.preparedStmt())
                {
                    query.Transaction = transaction;

                    if (is_new)
                    {
                        query.CommandText = "INSERT INTO `students` " +
                            "(`tutorGroup`,`firstName`,`middleNames`,`lastName`,`email`,`phone`,`dob`,`gender`,`religion`, `deadline`, `complete`, `uln`) " +
                            "VALUES (@tutorGroup, @firstName, @middleNames, @lastName, @email, @phone, @dob, @gender, @religion, @deadline, @complete, @uln)";

                    }
                    else
                    {
                        query.CommandText = "UPDATE `students` SET `tutorGroup`=@tutorGroup, `firstName`=@firstName, `middleNames`=@middleNames, `lastName`=@lastName, " +
                               "`email`=@email, `phone`=@phone, `dob`=@dob, `gender`=@gender, `religion`=@religion, `deadline`=@deadline, `complete` = @complete " +
                               "WHERE `uln`=@uln";
                    }
                    try
                    {
                        query.Parameters.AddWithValue("@tutorGroup", this._tutor);
                        query.Parameters.AddWithValue("@firstName", this._firstName);
                        query.Parameters.AddWithValue("@middleNames", this._middleNames);
                        query.Parameters.AddWithValue("@lastName", this._lastName);
                        query.Parameters.AddWithValue("@email", this._email);
                        query.Parameters.AddWithValue("@phone", this._phone);
                        query.Parameters.AddWithValue("@dob", DateTimeHelper.GetWithoutMilliseconds(this._dateOfBirth));
                        query.Parameters.AddWithValue("@gender", this._gender.ID);
                        query.Parameters.AddWithValue("@religion", this._religion.ID);
                        if (this._isYoEDeadline)
                        {
                            query.Parameters.Add("@deadline", OleDbType.Date).Value = DBNull.Value;
                        }
                        else
                        {
                            query.Parameters.AddWithValue("@deadline", this._deadline);
                        }
                        query.Parameters.AddWithValue("@complete", (this._status == Classes.Status.Complete));
                        query.Parameters.AddWithValue("@uln", this._uln);

                        if (query.ExecuteNonQuery() == 1)
                        {
                            transaction.Commit();
                            result.is_Success = true;
                            is_new = false;
                        }
                        else
                        {
                            transaction.Rollback();
                            result.Message = "Failed to save student.";
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        result.Message = ex.Message;
                        result.Data = ex.ToString();
                        Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                    }
                }
            }
            return result;
        }
        public StatusMessage save_notes()
        {
            StatusMessage result = new StatusMessage(false);

            // Check for access controls
            if (!Program.userCtrl.can_write
                || !Program.userCtrl.access_students)
            {
                result.Message = "Failed to save student notes.";
                result.Data = "User lacks the required privilege.";
                return result;
            }

            if (is_new)
            {
                result.Message = "Save student before saving notes.";
                return result;
            }
            using (OleDbTransaction transaction = Program.dbInt.connection.BeginTransaction())
            {
                using (OleDbCommand updateQuery = Program.dbInt.preparedStmt())
                {
                    updateQuery.Transaction = transaction;

                    updateQuery.CommandText = "UPDATE `students` SET `notes`=@notes WHERE `uln`=@ULN";

                    updateQuery.Parameters.AddWithValue("@notes", this._notes);
                    updateQuery.Parameters.AddWithValue("@ULN", this._uln);

                    try
                    {
                        if (updateQuery.ExecuteNonQuery() == 1)
                        {
                            transaction.Commit();
                            result.is_Success = true;
                        }
                        else
                        {
                            transaction.Rollback();
                            result.Message = "Did not update row.";
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        result.Message = ex.Message;
                        result.Data = ex.ToString();
                        Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                    }
                }
            }
            return result;
        }
        public StatusMessage save_quals()
        {
            StatusMessage result = new StatusMessage(false);

            // Check for access controls
            if (!Program.userCtrl.can_write
                || !Program.userCtrl.access_students)
            {
                result.Message = "Failed to save student qualifications.";
                result.Data = "User lacks the required privilege.";
                return result;
            }

            if (is_new)
            {
                result.Message = "Save student before saving qualifications.";
                return result;
            }

            using (OleDbTransaction transaction = Program.dbInt.connection.BeginTransaction())
            {
                // Remove all old rows
                using (OleDbCommand delete = Program.dbInt.preparedStmt())
                {
                    delete.Transaction = transaction;
                    try
                    {
                        delete.CommandText = "DELETE FROM `student_qual` WHERE `ULN`=@ULN";
                        delete.Parameters.AddWithValue("@ULN", this._uln);
                        delete.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        result.Message = ex.Message;
                        result.Data = ex.ToString();
                        Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                        return result;
                    }
                }

                // Insert new rows
                using (OleDbCommand insert = Program.dbInt.preparedStmt())
                {
                    insert.Transaction = transaction;

                    try
                    {
                        insert.CommandText = "INSERT INTO `student_qual` (`ULN`, `qualID`, `achieved`, `grade`) VALUES (@ULN, @qualID, @achieved, @grade)";
                        insert.Parameters.Add("@ULN", OleDbType.BigInt);
                        insert.Parameters.Add("@qualID", OleDbType.VarChar, 255);
                        insert.Parameters.Add("@achieved", OleDbType.Date);
                        insert.Parameters.Add("@grade", OleDbType.VarChar, 255);
                        insert.Prepare();
                        int rowsInserted = 0;
                        foreach (KeyValuePair<string, QualificationItem> qualItem in Qualifications)
                        {
                            insert.Parameters[0].Value = this._uln;
                            insert.Parameters[1].Value = qualItem.Key;
                            insert.Parameters[2].Value =  DateTimeHelper.GetWithoutMilliseconds(qualItem.Value.DateAchieved);
                            insert.Parameters[3].Value = qualItem.Value.GradeAchieved; 
                            rowsInserted += insert.ExecuteNonQuery();
                        }

                        if (rowsInserted != Qualifications.Count)
                        {
                            transaction.Rollback();
                            result.Message = "Failed to save all qualifications.";
                        }
                        else
                        {
                            transaction.Commit();
                            result.is_Success = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        result.Message = ex.Message;
                        result.Data = ex.ToString();
                        Program.log.log(GetType().Namespace, ex.Message + ex.TargetSite);
                        return result;
                    }
                }
            }
            return result;
        }

        public string Hash()
        {
            using (SHA256Managed sha = new SHA256Managed())
            {
                string toHash = _uln + _tutor.ToString() + _yoe.ToString() + _firstName + _middleNames + _lastName + _email + _phone + _gender.Text + _religion.Text + _dateOfBirth.ToString() + _status.ToString() + _deadline.ToUniversalTime() + _isYoEDeadline.ToString();
                Byte[] bytesToHash;
                Byte[] hash;
                bytesToHash = Text.UTF8.GetBytes(toHash);
                hash = sha.ComputeHash(bytesToHash);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        public string QualHash()
        {
            using (SHA256Managed sha = new SHA256Managed())
            {
                string toHash = "";
                foreach (KeyValuePair<string, QualificationItem> qual in Qualifications)
                {
                    toHash += qual.Key + qual.Value.DateAchieved.ToUniversalTime() + qual.Value.GradeAchieved;
                }
                Byte[] bytesToHash;
                Byte[] hash;
                bytesToHash = Text.UTF8.GetBytes(toHash);
                hash = sha.ComputeHash(bytesToHash);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}
