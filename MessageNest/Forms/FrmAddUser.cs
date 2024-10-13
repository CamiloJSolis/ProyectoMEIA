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
    public partial class FrmAddUser : Form
    {
        public FrmAddUser()
        {
            InitializeComponent();
        }

        #region Cambiar color

        // Cambiar de color los panel

        private void SetNewUsrPanelsColor(Color color)
        {
            PnlInsertUsrLeft.BackColor = color;
            PnlInsertUsrRight.BackColor = color;
            PnlInsertUsrUp.BackColor = color;
            PnlInsertUsrDown.BackColor = color;
        }

        private void SetNewFirstNamePanlesColor(Color color)
        {
            PnlFirstNameLeft.BackColor = color;
            PnlFirstNameRight.BackColor = color;
            PnlFirstNameUp.BackColor = color;
            PnlFirstNameDown.BackColor = color;
        }

        private void SetNewSecondNamePanelsColor (Color color)
        {
            PnlSecondNameLeft.BackColor = color;
            PnlSecondNameRight.BackColor = color;
            PnlSecondNameUp.BackColor = color;
            PnlSecondNameDown.BackColor = color;
        }

        private void SetNewFirstSurnamePanelColor (Color color)
        {
            PnlFirstSurnameLeft.BackColor = color;
            PnlFirstSurnameRight.BackColor = color;
            PnlFirstSurnameUp.BackColor = color;
            PnlFirstSurnameDown.BackColor = color;
        }

        private void SetNewSecondSurnamePanelsColor(Color color)
        {
            PnlSecondSurnameLeft.BackColor = color;
            PnlSecondSurnameRight.BackColor = color;
            PnlSecondSurnameUp.BackColor = color;
            PnlSecondSurnameDown.BackColor = color;
        }

        private void SetNewPasswordPanlesColor (Color color)
        {
            PnlInsertPwdLeft.BackColor = color;
            PnlInsertPwdRight.BackColor = color;
            PnlInsertPwdUp.BackColor = color;
            PnlInsertPwdDown.BackColor = color;
        }

        private void SetPhonePanlesColor (Color color)
        {
            PnlPhoneLeft.BackColor = color;
            PnlPhoneRight.BackColor = color;
            PnlPhoneUp.BackColor = color;
            PnlPhoneDown.BackColor = color;
        }
        private void SetBirthDatePanelsColor (Color color)
        {
            PnlBDLeft.BackColor = color;
            PnlBDRight.BackColor = color;
            PnlBDUp.BackColor = color;
            PnlBDDown.BackColor = color;
        }

        #endregion

        #region Botones

        private void BtnShowHide_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrPwd.PasswordChar == '●')
            {
                TxtNewUsrPwd.PasswordChar = '\0';
                BtnShowHide.Image = Properties.Resources.show;
            }
            else if (TxtNewUsrPwd.Text != "Contraseña")
            {
                TxtNewUsrPwd.PasswordChar = '●';
                BtnShowHide.Image = Properties.Resources.hide;
            }
        }

        #endregion

        #region Funciones

        // Keypress

        private void TxtNewUsrPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                LblWrongPhoneInput.Visible = true;
            }
            else
            {
                LblWrongPhoneInput.Visible = false;
            }
        }

        // Click

        private void TxtNewUsr_Click(object sender, EventArgs e)
        {
            if (TxtNewUsr.Text == "Ingrese el usuario")
            {
                TxtNewUsr.SelectAll();
            }   
        }

        private void TxNewUsrFirstName_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstName.Text == "Primer nombre")
            {
                TxtNewUsrFirstName.SelectAll();
            }
        }

        private void TxtNewFirstSurname_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstSurname.Text == "Primer apellido")
            {
                TxtNewUsrFirstSurname.SelectAll();
            }
        }

        private void TxtNewUsrSecondName_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondName.Text == "Segundo nombre")
            {
                TxtNewUsrSecondName.SelectAll();
            }      
        }

        private void TxtNewUsrSecondSurname_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondSurname.Text == "Segundo apellido")
            {
                TxtNewUsrSecondSurname.SelectAll();
            }
        }

        private void TxtNewUsrPwd_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrPwd.Text == "Contraseña")
            {
                TxtNewUsrPwd.SelectAll();
            }
        }

        private void TxtNewUsrPhone_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrPhone.Text == "0000000000")
            {
                TxtNewUsrPhone.SelectAll();
            }
        }

        //Enter y Leave

        private void TxtNewUsr_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsr.Text == "Ingrese el usuario")
            {
                TxtNewUsr.Text = "";

                TxtNewUsr.ForeColor = Color.White;
                SetNewUsrPanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewUsr_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsr.Text == "")
            {
                TxtNewUsr.Text = "Ingrese el usuario";

                TxtNewUsr.ForeColor = Color.DarkGray;
                SetNewUsrPanelsColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxNewUsrFirstName_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstName.Text == "Primer nombre")
            {
                TxtNewUsrFirstName.Text = "";

                TxtNewUsrFirstName.ForeColor = Color.White;
                SetNewFirstNamePanlesColor(Color.DeepSkyBlue);
            }
        }

        private void TxNewUsrFirstName_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstName.Text == "")
            {
                TxtNewUsrFirstName.Text = "Primer nombre";

                TxtNewUsrFirstName.ForeColor = Color.DarkGray;
                SetNewFirstNamePanlesColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtNewUsrFirstSurname_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstSurname.Text == "Primer apellido")
            {
                TxtNewUsrFirstSurname.Text = "";

                TxtNewUsrFirstSurname.ForeColor = Color.White;
                SetNewFirstSurnamePanelColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewUsrFirstSurname_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstSurname.Text == "")
            {
                TxtNewUsrFirstSurname.Text = "Primer apellido";

                TxtNewUsrFirstSurname.ForeColor = Color.DarkGray;
                SetNewFirstSurnamePanelColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtNewUsrSecondName_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondName.Text == "Segundo nombre")
            {
                TxtNewUsrSecondName.Text = "";

                TxtNewUsrSecondName.ForeColor = Color.White;
                SetNewSecondNamePanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewUsrSecondName_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondName.Text == "")
            {
                TxtNewUsrSecondName.Text = "Segundo nombre";

                TxtNewUsrSecondName.ForeColor = Color.DarkGray;
                SetNewSecondNamePanelsColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtNewUsrSecondSurname_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondSurname.Text == "Segundo apellido")
            {
                TxtNewUsrSecondSurname.Text = "";

                TxtNewUsrSecondSurname.ForeColor = Color.White;
                SetNewSecondSurnamePanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewUsrSecondSurname_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondSurname.Text == "")
            {
                TxtNewUsrSecondSurname.Text = "Segundo apellido";

                TxtNewUsrSecondSurname.ForeColor = Color.DarkGray;
                SetNewSecondSurnamePanelsColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtNewUsrPwd_Enter(object sender, EventArgs e)
        {
            TxtNewUsrPwd.Text = "";
            TxtNewUsrPwd.PasswordChar = '●';
            TxtNewUsrPwd.ForeColor = Color.White;
            SetNewPasswordPanlesColor(Color.DeepSkyBlue);
        }

        private void TxtNewUsrPwd_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrPwd.Text == "")
            {
                TxtNewUsrPwd.Text = "Contraseña";
                TxtNewUsrPwd.PasswordChar = '\0';
                TxtNewUsrPwd.ForeColor = Color.DarkGray;
                SetNewPasswordPanlesColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtNewUsrPhone_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsrPhone.Text == "0000000000")
            {
                TxtNewUsrPhone.Text = "";

                TxtNewUsrPhone.ForeColor = Color.White;
                SetPhonePanlesColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewUsrPhone_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrPhone.Text == "")
            {
                TxtNewUsrPhone.Text = "0000000000";

                TxtNewUsrPhone.ForeColor = Color.DarkGray;
                SetPhonePanlesColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void DtpNewUsrBD_DropDown(object sender, EventArgs e)
        {
            SetBirthDatePanelsColor(Color.DeepSkyBlue);
        }

        private void DtpNewUsrBD_CloseUp(object sender, EventArgs e)
        {
            SetBirthDatePanelsColor(Color.FromArgb(50, 50, 50));
        }


        #endregion
    }
}
