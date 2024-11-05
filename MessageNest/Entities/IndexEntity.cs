using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MessageNest.Entities
{
    public class IndexEntity
    {
        private int _record;
        private double _position;
        private string _list_name;
        private string _user;
        private string _associated_user;
        private string _creation_date;
        private int _status;

        public IndexEntity() { }

        public IndexEntity(int record, double position, string list_name, string user, string associated_user, string creationDate, int status)
        {
            _record = record;
            _position = position;
            _list_name = list_name;
            _user = user;
            _associated_user = associated_user;
            _creation_date = creationDate;
            _status = status;
        }

        public int Record
        {
            get { return  _record; } 
            set { _record = value; }
        }

        public double Position
        {
            get { return _position; }
            set { _position = value; }
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
