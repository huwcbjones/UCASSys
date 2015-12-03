using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCASSys.Classes.Lists
{
    class Status
    {
        public List<Items.dropDownItem> List = new List<Items.dropDownItem>();

        public Status(bool include_notStarted = false, bool is_required = true)
        {
            if (is_required)
            {
                List.Add(new Items.dropDownItem(-1, "Select Status"));
            }
            else
            {
                List.Add(new Items.dropDownItem(-1, "All States"));
            }
            if (include_notStarted)
            {
                List.Add(new Items.dropDownItem(Classes.Status.NotStarted, "Not Started"));
            }
            List.Add(new Items.dropDownItem(Classes.Status.InProgress, "In Progress"));
            List.Add(new Items.dropDownItem(Classes.Status.Complete, "Complete"));
        }
    }
}
