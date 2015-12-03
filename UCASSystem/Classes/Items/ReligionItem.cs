using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Items
{
    public class ReligionItem : dropDownItem
    {
        public ReligionItem(int ID, string value = "")
            : base(ID, value)
        {
            if (value.Length != 0)
            {
                return;
            }
            using (OleDbCommand query = Program.dbInt.preparedStmt())
            {
                query.CommandText = "SELECT `religion` FROM `religions` WHERE `ID`=@ID";
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
                            base.Text = (string)data["religion"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to load religion.", GetType().Namespace, ex.Message);
                }
            }
        }
    }
}
