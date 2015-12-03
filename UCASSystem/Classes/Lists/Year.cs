using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCASSys.Classes.Lists
{
    public class Year
    {
        public List<Items.dropDownItem> List = new List<Items.dropDownItem>();
        private int _count;
        private int _end = -1;
        private int _sort = SORT_ASC;

        public const int SORT_ASC = 1;
        public const int SORT_DESC = 2;
        public Year(int count, int end = -1, int sort = SORT_ASC, bool is_required = true)
        {
            if (end == -1)
            {
                end = DateTime.Now.Year;
            }
            _count = count;
            _end = end;
            _sort = sort;

            if (is_required)
            {
                List.Add(new Items.dropDownItem(-1, "Select Year"));
            }
            else
            {
                List.Add(new Items.dropDownItem(-1, "All Years"));
            }

            _loadYears();
        }

        private void _loadYears()
        {
            if (_sort == SORT_ASC)
            {
                for (int i = (_end - _count); i <= _end; i++)
                {
                    List.Add(new Items.dropDownItem(i, i.ToString()));
                }
            }
            else
            {
                for (int i = _end; i >= (_end - _count); i--)
                {
                    List.Add(new Items.dropDownItem(i, i.ToString()));
                }
            }
        }
    }
}
