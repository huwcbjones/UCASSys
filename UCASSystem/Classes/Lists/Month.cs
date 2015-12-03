using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace UCASSys.Classes.Lists
{
    public class Month
    {
        public List<Items.dropDownItem> List = new List<Items.dropDownItem>();

        public Month(bool is_required = true)
        {
            if (is_required)
            {
                List.Add(new Items.dropDownItem(-1, "Select Month"));
            }
            else
            {
                List.Add(new Items.dropDownItem(-1, "All Months"));
            }

            _loadMonths();
        }

        private void _loadMonths()
        {
            for (int i = 1; i <= 12; i++)
            {
                List.Add(new Items.dropDownItem(i, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i)));
            }
        }
    }
}
