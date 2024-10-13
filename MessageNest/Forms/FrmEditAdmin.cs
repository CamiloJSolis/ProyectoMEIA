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
    public partial class FrmEditAdmin : Form
    {
        public FrmEditAdmin()
        {
            InitializeComponent();
        }

        #region Cambiar color

        private void SetAdminPhonePanelsColor (Color color)
        {
            PnlPhoneLeft.BackColor = color;
            PnlPhoneRight.BackColor = color;
            PnlPhoneUP.BackColor = color;
            PnlPhoneDown.BackColor = color;
        }

        private void SetAdminBDPanelsColor(Color color)
        {
            PnlAdminBDLeft.BackColor = color;
            PnlAdminBDRight.BackColor = color;
            PnlAdminBDUp.BackColor = color;
            PnlAdminBDDown.BackColor = color;
        }

        private void SetAdminNewPasswordPanlesColor (Color color)
        {
            PnlAdminNewPwdLeft.BackColor = color;
            PnlAdminNewPwdRight.BackColor = color;
            PnlAdminNewPwdUp.BackColor = color;
            PnlAdminNewPwdDown.BackColor = color;
        }

        #endregion

        #region Botones

        private void BtnShowHideNewPwd_Click(object sender, EventArgs e)
        {
            if (TxtAdminNewPwd.PasswordChar == '●')
            {
                TxtAdminNewPwd.PasswordChar = '\0';
                BtnShowHideNewPwd.Image = Properties.Resources.show;
            }
            else if (TxtAdminNewPwd.Text != "Contraseña")
            {
                TxtAdminNewPwd.PasswordChar = '●';
                BtnShowHideNewPwd.Image = Properties.Resources.hide;
            }
        }

        #endregion

        #region Funciones

        // KeyPress
        private void TxtAdminPhone_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtAdminNewPwd_Click(object sender, EventArgs e)
        {
            if (TxtAdminNewPwd.Text == "Contraseña")
            {
                TxtAdminNewPwd.SelectAll();
            }
        }

        // Date time picker

        private void DtpAdminBD_DropDown(object sender, EventArgs e)
        {
            SetAdminBDPanelsColor(Color.DeepSkyBlue);
        }

        private void DtpAdminBD_CloseUp(object sender, EventArgs e)
        {
            SetAdminBDPanelsColor(Color.FromArgb(50, 50, 50));
        }

        // Enter leave

        private void PnlPhone_Enter(object sender, EventArgs e)
        {
            TxtAdminPhone.ForeColor = Color.White;
            SetAdminPhonePanelsColor(Color.DeepSkyBlue);
        }

        private void PnlPhone_Leave(object sender, EventArgs e)
        {
            TxtAdminPhone.ForeColor = Color.White;
            SetAdminPhonePanelsColor(Color.FromArgb(50, 50, 50));
        }

        private void TxtNewAdminPwd_Enter(object sender, EventArgs e)
        {
            TxtAdminNewPwd.Text = "";
            TxtAdminNewPwd.PasswordChar = '●';
            TxtAdminNewPwd.ForeColor = Color.White;
            SetAdminNewPasswordPanlesColor(Color.DeepSkyBlue);
        }

        private void TxtNewAdminPwd_Leave(object sender, EventArgs e)
        {
            if (TxtAdminNewPwd.Text == "")
            {
                TxtAdminNewPwd.Text = "Contraseña";
                TxtAdminNewPwd.PasswordChar = '\0';
                TxtAdminNewPwd.ForeColor = Color.DarkGray;
                SetAdminNewPasswordPanlesColor(Color.FromArgb(50, 50, 50));
            }
        }

        #endregion
    }
}
