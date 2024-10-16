﻿using MessageNest.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageNest.Forms
{
    public partial class FrmUserInfo : Form
    {
        public FrmUserInfo(UserEntity user)
        {
            InitializeComponent();

            string[] names = user.Name.Split(' ');
            string firstName = names[0];
            string secondName;

            if (names.Length > 1)
            {
                secondName = string.Join(" ", names.Skip(1));
            }
            else
            {
                secondName = "";
            }

            string[] surnames = user.Surname.Split(' ');
            string firstSurname = surnames[0];
            string secondSurname;

            if (surnames.Length > 1)
            {
                secondSurname = string.Join(" ", surnames.Skip(1));
            }
            else
            {
                secondSurname = "";
            }

            string role;
            if (user.Role == 1)
            {
                role = "Administrador";
            }
            else
            {
                role = "Usuario";
            }

            TxtUsrName.Text = user.Name;
            TxtUsrFirstName.Text = firstName;
            TxtUsrSecondName.Text = secondName;
            TxtUsrFirstSurname.Text = firstSurname;
            TxtUsrSecondSurname.Text = secondSurname;
            TxtUsrPhone.Text = user.PhoneNumber;
            CmbxRol.Text = role;
        }
    }
}
