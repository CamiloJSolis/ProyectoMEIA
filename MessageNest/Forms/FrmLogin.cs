using MessageNest.Forms;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageNest
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        #region Botones

        private void BtnCloseLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCloseLogin_MouseHover(object sender, EventArgs e)
        {
            BtnCloseLogin.BackColor = Color.Red;
            BtnCloseLogin.Image = Properties.Resources.exit;
        }

        private void BtnCloseLogin_MouseLeave(object sender, EventArgs e)
        {
            BtnCloseLogin.BackColor = Color.FromArgb(30, 30, 30);
            BtnCloseLogin.Image = Properties.Resources.close_button;
        }

        #endregion

        #region Funciones

        private void SetUsrPanelsColor(Color color)
        {
            PnlInsertUsrLeft.BackColor = color;
            PnlInsertUsrRight.BackColor = color;
            PnlInsertUsrUp.BackColor = color;
            PnlInsertUsrDown.BackColor = color;
        }

        private void SetPwdPanelsColor(Color color)
        {
            PnlInsertPwdLeft.BackColor = color;
            PnlInsertPwdRight.BackColor = color;
            PnlInsertPwdUp.BackColor = color;
            PnlInsertPwdDown.BackColor = color;
        }

        private void BtnSingIn_Click(object sender, EventArgs e)
        {
            BtnSingIn.BackColor = Color.FromArgb(255, 210, 100);
            LblWrongUsr.Visible = false;
            LblWrongPwd.Visible = false;
            LblNoUsrPwd.Visible = false;

            if (TxtUsr.Text == "Ingrese el usuario" && TxtPwd.Text != "Contraseña")
            {
                LblWrongUsr.Visible = true;

                SetUsrPanelsColor(Color.FromArgb(255, 100, 100));
            }
            else if (TxtPwd.Text == "Contraseña" && TxtUsr.Text != "Ingrese el usuario")
            {
                LblWrongPwd.Visible = true;

                SetUsrPanelsColor(Color.FromArgb(255, 100, 100));
            }
            else if (TxtUsr.Text == "Ingrese el usuario" && TxtPwd.Text == "Contraseña")
            {
                LblNoUsrPwd.Visible = true;

                SetUsrPanelsColor(Color.FromArgb(255, 100, 100));
                SetPwdPanelsColor(Color.FromArgb(255, 100, 100));
            }
            else
            {

            }
        }

        private void TxtUsr_Enter(object sender, EventArgs e)
        {
            if (TxtUsr.Text == "Ingrese el usuario")
            {
                if (LblWrongUsr.Visible == true)
                {
                    LblWrongUsr.Visible = false;
                }
                
                if (LblNoUsrPwd.Visible == true)
                {
                    LblNoUsrPwd.Visible = false;

                    SetUsrPanelsColor(Color.FromArgb(30, 30, 30));
                }
         
                TxtUsr.Text = "";
                TxtUsr.ForeColor = Color.White;

                SetUsrPanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtUsr_Leave(object sender, EventArgs e)
        {
            if (TxtUsr.Text == "")
            {
                TxtUsr.Text = "Ingrese el usuario";
                TxtUsr.ForeColor = Color.DarkGray;

                SetUsrPanelsColor(Color.FromArgb(50, 53, 60));
            }

        }

        private void TxtPwd_Enter(object sender, EventArgs e)
        {
            if (TxtPwd.Text == "Contraseña")
            {
                if (LblWrongPwd.Visible == true)
                {
                    LblWrongPwd.Visible = false;
                }

                if (LblNoUsrPwd.Visible == true)
                {
                    LblNoUsrPwd.Visible = false;

                    SetUsrPanelsColor(Color.FromArgb(50, 53, 60));
                }

                TxtPwd.Text = "";
                TxtPwd.PasswordChar = '●';
                TxtPwd.ForeColor = Color.White;

                SetPwdPanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtPwd_Leave(object sender, EventArgs e)
        {
            if (TxtPwd.Text == "")
            {
                TxtPwd.Text = "Contraseña";
                TxtPwd.PasswordChar = '\0';
                TxtPwd.ForeColor = Color.DarkGray;

                SetPwdPanelsColor(Color.FromArgb(50, 53, 60));
            }
        }

        private void TxtUsr_Click(object sender, EventArgs e)
        {
            TxtUsr.SelectAll();
        }

        private void TxtPwd_Click(object sender, EventArgs e)
        {
            TxtPwd.SelectAll();
        }

        private void BtnShowHide_Click(object sender, EventArgs e)
        {
            if (TxtPwd.PasswordChar == '●')
            {
                TxtPwd.PasswordChar = '\0';
                BtnShowHide.Image = Properties.Resources.show;
            }
            else
            {
                TxtPwd.PasswordChar = '●';
                BtnShowHide.Image = Properties.Resources.hide;
            }
        }

        #endregion


        #region Drag form

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        #endregion

        private void LnkLblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSignUp frmSignUp = new FrmSignUp();

            this.Hide();
            frmSignUp.Show();
        }
    }
}
