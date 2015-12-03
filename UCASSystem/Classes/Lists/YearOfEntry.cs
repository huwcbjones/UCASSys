using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Lists
{
    class YearOfEntry
    {
        public List<Items.YearOfEntryItem> List = new List<Items.YearOfEntryItem>();

        public YearOfEntry(bool no_other = false, bool is_required = false)
        {
            if (is_required)
            {
                List.Add(new Items.YearOfEntryItem(-1, "Select Year of Entry"));
            }
            else
            {
                List.Add(new Items.YearOfEntryItem(-1, "All Year of Entries"));
            }

            _loadYearOfEntry();

            if (!no_other && Program.userCtrl.is_admin)
            {
                List.Add(new Items.YearOfEntryItem(-2, "Other..."));
            }
        }

        private void _loadYearOfEntry()
        {
            using (OleDbCommand selectQuery = Program.dbInt.preparedStmt())
            {
                selectQuery.CommandText = "SELECT `ID`, `YearOfEntry` FROM `yearOfEntry` ORDER BY `YearOfEntry` ASC";

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
                            List.Add(new Items.YearOfEntryItem((int)data["ID"], (string)data["YearOfEntry"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to load year of entries.", GetType().Namespace, ex.Message);
                }
            }
        }

    }
}
