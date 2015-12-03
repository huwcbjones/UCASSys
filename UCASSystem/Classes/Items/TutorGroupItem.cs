using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Items
{
    public class TutorItem : dropDownItem
    {
        #region Properties
        private int _YoE;
        public int YearOfEntry
        {
            get { return _YoE; }
            set { _YoE = value; }
        }

        private int _yearGroup;
        public int YearGroup
        {
            get { return _yearGroup; }
            set { _yearGroup = value; }
        }

        private string _initials = "";
        public string Initials
        {
            get { return _initials; }
            set { _initials = value; }
        }

        new public string Text
        {
            get {
                if (base.Text.Length == 0)
                {
                    return _yearGroup.ToString() + _initials;
                }
                else
                {
                    return base.Text;
                }
            }
        }
        #endregion

        public TutorItem(int ID, string value = "")
            : base(ID, value)
        {
            if (value.Length != 0)
            {
                return;
            }
            using (OleDbCommand query = Program.dbInt.preparedStmt())
            {
                query.CommandText = "SELECT `YoE`, `yearGroup`, `initials` FROM `tutorGroups` WHERE `ID`=@ID";
                query.Parameters.AddWithValue("@ID", ID);

                try
                {
                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            return;
                        }
                        while (data.Read())
                        {
                            this._YoE = (int)data["YoE"];
                            this._yearGroup = (int)data["yearGroup"];
                            this._initials = (string)data["initials"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to load form.", GetType().Namespace, ex.Message);
                }
            }
        }
    }
}
