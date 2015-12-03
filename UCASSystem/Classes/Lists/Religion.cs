using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace UCASSys.Classes.Lists
{
    class Religion
    {
        public List<Items.ReligionItem> List = new List<Items.ReligionItem>();

        public Religion(bool no_other = false, bool is_required = true)
        {
            if (is_required)
            {
                List.Add(new Items.ReligionItem(-1, "Select Religion"));
            }
            else
            {
                List.Add(new Items.ReligionItem(-1, "All Religions"));
            }

            _loadReligions();

            if (!no_other && Program.userCtrl.is_admin)
            {
                List.Add(new Items.ReligionItem(-2, "Other..."));
            }
        }

        private void _loadReligions()
        {
            using (OleDbCommand selectQuery = Program.dbInt.preparedStmt())
            {
                selectQuery.CommandText = "SELECT `ID`, `religion` FROM `religions` ORDER BY `religion` ASC";

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
                            List.Add(new Items.ReligionItem((int)data["ID"], (string)data["religion"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to load religions.", GetType().Namespace, ex.Message);
                }
            }
        }
    }
}
