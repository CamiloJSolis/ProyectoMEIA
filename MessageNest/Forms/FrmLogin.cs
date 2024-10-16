using MessageNest.Dao;
using MessageNest.Entities;
using MessageNest.Forms;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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

        // Cambiar de color los panels al ser seleccionados

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

        // Click

        private void BtnSingIn_Click(object sender, EventArgs e)
        {
            BtnSingIn.BackColor = Color.FromArgb(255, 210, 100);
            ResetLabelsAndColors();

            if (TxtUsr.Text == "Ingrese el usuario" && TxtPwd.Text != "Contraseña")
            {
                LblWrongUsr.Visible = true;
                SetUsrPanelsColor(Color.FromArgb(255, 100, 100));
                return;
            }
            
            if (TxtPwd.Text == "Contraseña" && TxtUsr.Text != "Ingrese el usuario")
            {
                LblWrongPwd.Visible = true;
                SetPwdPanelsColor(Color.FromArgb(255, 100, 100));
                return;
            }
            
            if (TxtUsr.Text == "Ingrese el usuario" && TxtPwd.Text == "Contraseña")
            {
                LblNoUsrPwd.Visible = true;

                SetUsrPanelsColor(Color.FromArgb(255, 100, 100));
                SetPwdPanelsColor(Color.FromArgb(255, 100, 100));
            }

            string userName = TxtUsr.Text.Trim();
            string password = TxtPwd.Text.Trim();

            UserDao userDao = new UserDao();
            UserEntity user = userDao.BuscarRegistro(userName,EncryptPassword(password));

            if ( user != null)
            {
                if(user.IsActive == 1)
                {
                    if (user.Role == 1)
                    {
                        FrmAdmin frmAdmin = new FrmAdmin(user);
                        this.Hide();
                        frmAdmin.Show();
                    }
                    else
                    {
                        FrmUser frmUser = new FrmUser(user);
                        this.Hide();
                        frmUser.Show();
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no esta activo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                LblWrongUsrPwd.Visible = true;
                SetUsrPanelsColor(Color.FromArgb(255, 100, 100));
                SetPwdPanelsColor(Color.FromArgb(255, 100, 100));
            }
        }

        private void ResetLabelsAndColors()
        {
            LblWrongUsrPwd.Visible = false;
            LblWrongUsr.Visible = false;
            LblWrongPwd.Visible = false;
            LblNoUsrPwd.Visible = false;

            SetUsrPanelsColor(Color.FromArgb(30, 30, 30));
            SetUsrPanelsColor(Color.FromArgb(30, 30, 30));
        }

        private string EncryptPassword(string password)
        {
            try
            {
                var sha256 = SHA256.Create();
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                var stringBuilder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    stringBuilder.AppendFormat("{0:x2}", b);
                }

                return stringBuilder.ToString().Substring(0, 15);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al encriptar la contraseña: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return password;
            }
        }

        private void LnkLblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSignUp frmSignUp = new FrmSignUp();

            this.Hide();
            frmSignUp.Show();
        }

        // Enter y leave

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


        #region Arrastrar form

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
    }
}
