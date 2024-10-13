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
    public partial class FrmEditUser : Form
    {
        public FrmEditUser()
        {
            InitializeComponent();
        }


        #region Cambiar color

        private void SetUserPhonePanelsColor(Color color)
        {
            PnlUsrPhoneLeft.BackColor = color;
            PnlUsrPhoneRight.BackColor = color;
            PnlUsrPhoneUp.BackColor = color;
            PnlUsrPhoneDown.BackColor = color;
        }

        private void SetUserBDPanelsColor(Color color)
        {
            PnlUsrBdLeft.BackColor = color;
            PnlUsrBdRight.BackColor = color;
            PnlUsrBdUp.BackColor = color;
            PnlUsrBdDown.BackColor = color;
        }

        private void SetUserNewPasswordPanlesColor(Color color)
        {
            PnlUsrNewPwdLeft.BackColor = color;
            PnlUsrNewPwdRight.BackColor = color;
            PnlUsrNewPwdUp.BackColor = color;
            PnlUsrNewPwdDown.BackColor = color;
        }

        #endregion

        #region Botones

        private void BtnShowHideNewPwd_Click(object sender, EventArgs e)
        {
            if (TxtUsrNewPwd.PasswordChar == '●')
            {
                TxtUsrNewPwd.PasswordChar = '\0';
                BtnShowHideNewPwd.Image = Properties.Resources.show;
            }
            else if (TxtUsrNewPwd.Text != "Contraseña")
            {
                TxtUsrNewPwd.PasswordChar = '●';
                BtnShowHideNewPwd.Image = Properties.Resources.hide;
            }
        }


        #endregion

        #region Funciones 

        // KeyPress

        private void TxtUsrPhone_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtUsrNewPwd_Click(object sender, EventArgs e)
        {
            if (TxtUsrNewPwd.Text == "Contraseña")
            {
                TxtUsrNewPwd.SelectAll();
            }
        }

        // Date time picker

        private void DtpUsrBD_CloseUp(object sender, EventArgs e)
        {
            SetUserBDPanelsColor(Color.FromArgb(50, 50, 50));
        }

        private void DtpUsrBD_DropDown(object sender, EventArgs e)
        {
            SetUserBDPanelsColor(Color.DeepSkyBlue);
        }

        // Enter y leave

        private void TxtUsrNewPwd_Enter(object sender, EventArgs e)
        {
            TxtUsrNewPwd.Text = "";
            TxtUsrNewPwd.PasswordChar = '●';
            TxtUsrNewPwd.ForeColor = Color.White;
            SetUserNewPasswordPanlesColor(Color.DeepSkyBlue);
        }

        private void TxtUsrNewPwd_Leave(object sender, EventArgs e)
        {
            if (TxtUsrNewPwd.Text == "")
            {
                TxtUsrNewPwd.Text = "Contraseña";
                TxtUsrNewPwd.PasswordChar = '\0';
                TxtUsrNewPwd.ForeColor = Color.DarkGray;
                SetUserNewPasswordPanlesColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtUsrPhone_Enter(object sender, EventArgs e)
        {
            TxtUsrPhone.ForeColor = Color.White;
            SetUserPhonePanelsColor(Color.DeepSkyBlue);
        }

        private void TxtUsrPhone_Leave(object sender, EventArgs e)
        {
            TxtUsrPhone.ForeColor = Color.White;
            SetUserPhonePanelsColor(Color.FromArgb(50, 50, 50));
        }

        #endregion
    }
}
