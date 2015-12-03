using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Lists
{
    class Gender
    {
        public List<Items.GenderItem> List = new List<Items.GenderItem>();

        public Gender(bool no_other = false, bool is_required = true)
        {
            if (is_required)
            {
                List.Add(new Items.GenderItem(-1, "Select Gender"));
            }
            else
            {
                List.Add(new Items.GenderItem(-1, "All Genders"));
            }

            _loadGenders();

            if (!no_other && Program.userCtrl.is_admin)
            {
                List.Add(new Items.GenderItem(-2, "Other..."));
            }
        }

        private void _loadGenders()
        {
            using (OleDbCommand selectQuery = Program.dbInt.preparedStmt())
            {
                selectQuery.CommandText = "SELECT `ID`, `gender` FROM `genders` ORDER BY `gender` ASC";

                try
                {
                    using (OleDbDataReader data = selectQuery.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            return;
                        }

                        while (data.Read())
                        {
                            List.Add(new Items.GenderItem((int)data["ID"], (string)data["gender"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to load genders.", GetType().Namespace, ex.Message);
                }
            }
        }
    }
}
