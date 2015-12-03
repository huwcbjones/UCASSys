using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCASSys.Classes.Lists
{
    class Grades
    {
        public List<Items.dropDownItem> List = new List<Items.dropDownItem>();
        public Grades(List<string> grades = null, bool is_required = true)
        {
            if (is_required)
            {
                List.Add(new Items.dropDownItem(-1, "Select Grade"));
            }
            else
            {
                List.Add(new Items.dropDownItem(-1, "All Grades"));
            }

            if (grades != null) _loadGrades(grades);
        }

        private void _loadGrades(List<string> grades)
        {
            int i = 1;
            foreach (string grade in grades)
            {
                List.Add(new Items.dropDownItem(i, grade));
                i++;
            }
        }
    }
}
