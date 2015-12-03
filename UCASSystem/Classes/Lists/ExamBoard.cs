using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Lists
{
    public class ExamBoard
    {
        public List<Items.ExamBoardItem> List = new List<Items.ExamBoardItem>();

        public ExamBoard(bool no_other = false, bool is_required = true)
        {
            if (is_required)
            {
                List.Add(new Items.ExamBoardItem(-1, "Select Exam Board"));
            }
            else
            {
                List.Add(new Items.ExamBoardItem(-1, "All Exam Boards"));
            }

            _loadOrganisations();

            if (!no_other && Program.userCtrl.is_admin)
            {
                List.Add(new Items.ExamBoardItem(-2, "Other..."));
            }
        }

        private void _loadOrganisations()
        {
            using (OleDbCommand query = Program.dbInt.preparedStmt())
            {
                query.CommandText = "SELECT `id` FROM `examBoards` ORDER BY `board` ASC";

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
                            List.Add(new Items.ExamBoardItem((int)data["id"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to load exam boards.", GetType().Namespace, ex.Message);
                }
            }
        }
    }
}
