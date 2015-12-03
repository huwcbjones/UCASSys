using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Items
{
    public class ExamBoardItem : dropDownItem
    {
        private string _abbr;
        public string Abbr
        {
            get { return _abbr; }
        }

        public ExamBoardItem(int orgId = -1, string name = "")
            : base(orgId, name)
        {
            if (name.Length != 0)
            {
                return;
            }
            using (OleDbCommand query = Program.dbInt.preparedStmt())
            {
                query.CommandText = "SELECT `id`, `board`, `abbr` FROM `examBoards` WHERE `id`=@ID";
                query.Parameters.AddWithValue("@ID", orgId);

                try
                {
                    using (OleDbDataReader data = query.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            return;
                        }
                        //TODO: Look at data.ReadAsync()
                        while (data.Read())
                        {
                            base.Text = (string)data["board"];
                            this._abbr = (string)data["abbr"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to load exam board.", GetType().Namespace, ex.Message);
                }
            }
        }
    }
}
