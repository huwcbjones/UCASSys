using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Items
{
    public class YearOfEntryItem : dropDownItem
    {
        #region Properties
        private DateTime _dl_details;
        public DateTime deadline_Details
        {
            get { return _dl_details; }
            set { _dl_details = value; }
        }
        private DateTime _dl_applications;
        public DateTime deadline_Applications
        {
            get { return _dl_applications; }
            set { _dl_applications = value; }
        }
        private DateTime _dl_reference;
        public DateTime deadline_Reference
        {
            get { return _dl_reference; }
            set { _dl_reference = value; }
        }
        private String _desc;
        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }
        #endregion

        public YearOfEntryItem(int ID, string value = "")
            : base(ID, value)
        {
            if (value.Length != 0)
            {
                return;
            }
            using (OleDbCommand query = Program.dbInt.preparedStmt())
            {
                query.CommandText = "SELECT `YearOfEntry`, `deadline_details`, `deadline_applications`, `deadline_references`, `description` FROM `yearOfEntry` WHERE `ID`=@ID";
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
                            base.Text = (string)data["YearOfEntry"];
                            this._dl_details = (DateTime)data["deadline_details"];
                            this._dl_applications = (DateTime)data["deadline_applications"];
                            this._dl_reference = (DateTime)data["deadline_references"];
                            this._desc = (string)data["description"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to load year of entry.", GetType().Namespace, ex.Message);
                }
            }
        }
    }
}
