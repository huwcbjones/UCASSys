using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCASSys.Classes.Items
{
    class TaskListItem
    {
        private DateTime _deadline;
        public DateTime Deadline
        {
            get { return _deadline; }
            set { _deadline = value; }
        }

        private int _uln;
        public int ULN
        {
            get { return _uln; }
            set { _uln = value; }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public TaskListItem(int ULN = -1, string firstName = "", string lastName = "", DateTime deadline = new DateTime())
        {
            _uln = ULN;
            _firstName = firstName;
            _lastName = lastName;
            _deadline = deadline;
        }
    }
}
