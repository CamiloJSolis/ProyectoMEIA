using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNest.Entities
{
    public class ListEntity
    {
        private string _list_name;
        private string _user_name;
        private string _description;
        private string _user_number;
        private string _creation_date;
        private int _status;

        public ListEntity() { }

        public ListEntity(string list_name, string user_name, string description, string user_number, string creation_date, int status)
        {
            _list_name = list_name;
            _user_name = user_name;
            _description = description;
            _user_number = user_number;
            _creation_date = creation_date;
            _status = status;
        }

        public string ListName
        {
            get { return _list_name; }
            set { _list_name = value; }
        }

        public string UserName
        {
            get { return _user_name;  }
            set { _user_name = value; }
        }

        public string Description
        {
            get { return _description;  }
            set { _description = value; }
        }

        public string UserNumber
        { 
            get { return _user_number; }
            set { _user_number = value; }
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
