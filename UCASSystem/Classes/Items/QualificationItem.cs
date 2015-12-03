using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Items
{
    public class QualificationItem
    {
        #region Properties
        private bool _readOnly = false;
        public bool ReadOnly
        {
            get { return _readOnly; }
        }

        private string _ref;
        public string Reference
        {
            get { return _ref; }
            set
            {
                if (_readOnly)
                {
                    throw new InvalidOperationException("Qualification is read only.");
                }
                else
                {
                    _ref = value;
                }
            }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_readOnly)
                {
                    throw new InvalidOperationException("Qualification is read only.");
                }
                else
                {
                    _name = value;
                }
            }
        }

        private ExamBoardItem _examBoard;
        public ExamBoardItem ExamBoard
        {
            get { return _examBoard; }
            set
            {
                if (_readOnly)
                {
                    throw new InvalidOperationException("Qualification is read only.");
                }
                else
                {
                    _examBoard = value;
                }
            }
        }

        private string _gradeAchieved;
        public string GradeAchieved
        {
            get { return _gradeAchieved; }
            set { _gradeAchieved = value; }
        }

        private DateTime _dateAchieved;
        public DateTime DateAchieved
        {
            get { return _dateAchieved; }
            set { _dateAchieved = value; }
        }

        private string _subjectArea;
        public string SubjectArea
        {
            get { return _subjectArea; }
            set
            {
                if (_readOnly)
                {
                    throw new InvalidOperationException("Qualification is read only.");
                }
                else
                {
                    _subjectArea = value;
                }
            }
        }

        private string _level;
        public string Level
        {
            get { return _level; }
            set
            {
                if (_readOnly)
                {
                    throw new InvalidOperationException("Qualification is read only.");
                }
                else
                {
                    _level = value;
                }
            }
        }

        private DateTime _courseStart;
        public DateTime CourseStart
        {
            get { return _courseStart; }
            set
            {
                if (_readOnly)
                {
                    throw new InvalidOperationException("Qualification is read only.");
                }
                else
                {
                    _courseStart = value;
                }
            }
        }

        private DateTime _courseEnd;
        public DateTime CourseEnd
        {
            get { return _courseEnd; }
            set
            {
                if (_readOnly)
                {
                    throw new InvalidOperationException("Qualification is read only.");
                }
                else
                {
                    _courseEnd = value;
                }
            }
        }

        private DateTime _lastCertDate;
        public DateTime LastCertification
        {
            get { return _lastCertDate; }
            set
            {
                if (_readOnly)
                {
                    throw new InvalidOperationException("Qualification is read only.");
                }
                else
                {
                    _lastCertDate = value;
                }
            }
        }

        private List<string> _grades;
        public List<string> Grades
        {
            get { return _grades; }
            set
            {
                if (_readOnly)
                {
                    throw new InvalidOperationException("Qualification is read only.");
                }
                else
                {
                    _grades = value;
                }
            }
        }

        private List<string> _units;
        public List<string> Units
        {
            get { return _units; }
            set
            {
                if (_readOnly)
                {
                    throw new InvalidOperationException("Qualification is read only.");
                }
                else
                {
                    _units = value;
                }
            }
        }
        #endregion

        public QualificationItem(string qualReference = "")
        {
            if (qualReference == "")
            {
                return;
            }
            load(qualReference);
        }

        public StatusMessage load(string qualReference = "")
        {
            StatusMessage result = new StatusMessage(false);
            if (qualReference == "")
            {
                return result;
            }
            using (OleDbCommand query = Program.dbInt.preparedStmt())
            {
                try
                {
                    query.CommandText = "SELECT `qualRef`, `title`, `examBoard`, `level`, `subjectArea`, `start`, `end`, `lastCert`, `grades`, `units`";
                    query.CommandText += " FROM `qualifications`";
                    query.CommandText += " WHERE `qualRef`=@qualRef";

                    query.Parameters.AddWithValue("@qualRef", qualReference);

                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            result.Message = "Qualification with that ID not found!";
                            return result;
                        }
                        while (data.Read())
                        {
                            this._readOnly = true;

                            this._ref = (string)data["qualRef"];
                            this._name = (string)data["title"];
                            this._examBoard = new ExamBoardItem((int)data["examBoard"]);
                            this._level = (string)data["level"];
                            this._subjectArea = (string)data["subjectArea"];
                            this._courseStart = (DateTime)data["start"];
                            if (DBNull.Value == data["end"])
                            {
                                this._courseEnd = DateTime.Now;
                            }
                            else
                            {
                                this._courseEnd = (DateTime)data["end"];
                            }
                            if (DBNull.Value == data["lastCert"])
                            {
                                this._lastCertDate = DateTime.Now;
                            }
                            else
                            {
                                this._lastCertDate = (DateTime)data["end"];
                            }
                            this._grades = _loadGrades((string)data["grades"]);
                            this._units = _loadUnits((string)data["units"]);

                            result.is_Success = true;
                            return result;
                        }
                    }

                }
                catch (Exception ex)
                {
                    result.Message = ex.Message;
                    result.Data = ex.ToString();
                }
            }
            return result;
        }

        private List<string> _loadGrades(string gradeString)
        {
            return gradeString.Split('/').ToList();
        }
        private List<string> _loadUnits(string unitString)
        {
            return unitString.Split(new string[1] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}
