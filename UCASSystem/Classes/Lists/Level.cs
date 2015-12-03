using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Lists
{
    public class Level
    {
        public List<Items.dropDownItem> List = new List<Items.dropDownItem>();
        private int _examBoard = -1;
        public Level(int examBoard = -1, bool is_required = true)
        {
            _examBoard = examBoard;
            if (is_required)
            {
                List.Add(new Items.dropDownItem(-1, "Select Level"));
            }
            else
            {
                List.Add(new Items.dropDownItem(-1, "All Levels"));
            }

            _loadLevels();
        }

        private void _loadLevels()
        {
            using (OleDbCommand selectQuery = Program.dbInt.preparedStmt())
            {
                if (_examBoard != -1)
                {
                    selectQuery.CommandText = "SELECT `level` FROM `qualifications` WHERE `examBoard`=@board GROUP BY `level` ORDER BY `level` ASC";
                    selectQuery.Parameters.AddWithValue("@board", _examBoard);
                }
                else
                {
                    selectQuery.CommandText = "SELECT `level` FROM `qualifications` GROUP BY `level` ORDER BY `level` ASC";
                }
                try
                {
                    using (OleDbDataReader data = selectQuery.ExecuteReader())
                    {
                        if (!data.HasRows)
                        {
                            return;
                        }
                        int i = 1;
                        while (data.Read())
                        {
                            List.Add(new Items.dropDownItem(i, (string)data["level"]));
                            i++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to load levels.", GetType().Namespace, ex.Message);
                }
            }
        }
    }
}
