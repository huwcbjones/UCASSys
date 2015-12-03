using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Items
{
    public class GenderItem : dropDownItem
    {
        public GenderItem(int ID, string value = "")
            : base(ID, value)
        {
             if (value.Length != 0)
            {
                return;
            }
            using (OleDbCommand query = Program.dbInt.preparedStmt())
            {
                query.CommandText = "SELECT `gender` FROM `genders` WHERE `ID`=@ID";
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
                            base.Text = (string)data["gender"];
                        }
                    }
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to load gender.", GetType().Namespace, ex.Message);
                }
            }
        }
    }
}
