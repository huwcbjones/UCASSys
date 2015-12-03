using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace UCASSys.Classes.Lists
{

    class TutorGroup
    {

        public List<Items.TutorItem> List = new List<Items.TutorItem>();
        public TutorGroup(int yearOfEntry = -1, bool no_other = false, bool is_required = true)
        {
            if (is_required)
            {
                if (yearOfEntry == -1)
                {
                    List.Add(new Items.TutorItem(-1, "Select Year of Entry"));
                    return;
                }
                else
                {
                    List.Add(new Items.TutorItem(-1, "Select Tutor Group"));
                }
            }
            else
            {
                List.Add(new Items.TutorItem(-1, "All Tutor Groups"));
            }

            _loadForm(yearOfEntry);

            if (!no_other && Program.userCtrl.is_admin)
            {
                List.Add(new Items.TutorItem(-2, "Other..."));
            }
        }

        private void _loadForm(int yearOfEntry)
        {
            using (OleDbCommand selectQuery = Program.dbInt.preparedStmt())
            {
                selectQuery.CommandText = "SELECT `ID` FROM `tutorGroups` WHERE `YoE`=@YoE ORDER BY `YoE`, `yearGroup`, `initials` ASC";
                selectQuery.Parameters.AddWithValue("@YoE", yearOfEntry);
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
                            List.Add(new Items.TutorItem((int)data["ID"]));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Database.Interface.databaseError("Failed to load tutor groups.", GetType().Namespace, ex.Message);
                }
            }
        }
    }
}
