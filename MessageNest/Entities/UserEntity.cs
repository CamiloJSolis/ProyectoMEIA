using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNest.Entities
{
    public class UserEntity
    {
        private string _userName;
        private string _name;
        private string _surname;
        private string _passwordEncrypted;
        private bool _role;
        private DateTime _birthDate;
        private int _phoneNumber;
        private bool _isActive; // Es lo mismo que estatus


        // Constructor vacio

        public UserEntity()
        {
        }

        // Constructor que inicializa las propiedades

        public UserEntity(string userName, string name, string surname, string passwordEncrypted,
            bool role, DateTime birthDate, int phoneNumber, bool isActive)
        {
            _userName = userName;
            _name = name;
            _surname = surname;
            _passwordEncrypted = passwordEncrypted;
            _role = role;
            _birthDate = birthDate;
            _phoneNumber = phoneNumber;
            _isActive = isActive;
        }

        // Propiedades

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string PasswordEncrypted
        {
            get { return _passwordEncrypted; }
            set { _passwordEncrypted = value; }
        }

        public bool Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
    }
}
