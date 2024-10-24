using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNest.Dao
{
    public class ContactEntity
    {
        private string _user;
        private string _contact;
        private string _transaction_date;
        private string _userTransaction;
        private int _status;

        public ContactEntity()
        {

        }

        public ContactEntity(string user, string contact, string transaction_date, string trasaction_user, int status)
        {
            _user = user;
            _contact = contact;
            _transaction_date = transaction_date;
            _userTransaction = trasaction_user;
            _status = status;
        }

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        public string TransactionDate
        {
            get { return _transaction_date; }
            set { _transaction_date = value; }
        }

        public string UserTransaction
        {
            get { return _userTransaction; }
            set { _userTransaction = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
