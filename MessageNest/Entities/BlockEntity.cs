using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNest.Entities
{
    public class BlockEntity
    {
        private string _list_name;
        private string _user;
        private string _associated_user;
        private string _description;
        private string _creation_date;
        private int _status;

        public BlockEntity() { }

        public BlockEntity(string list_name, string user, string associated_user, string description, string creation_date, int status)
        {
            _list_name = list_name;
            _user = user;
            _associated_user = associated_user;
            _description = description;
            _creation_date = creation_date;
            _status = status;
        }

        public string ListName
        {
            get { return _list_name; }
            set { _list_name = value; }
        }

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        public string AssociatedUser
        {
            get { return _associated_user; }
            set { _associated_user = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string CreationDate
        {
            get { return _creation_date; }
            set { _creation_date = value; }
        }

        public int Status
        { 
            get { return _status; }
            set { _status = value; }
        }
    }
}
