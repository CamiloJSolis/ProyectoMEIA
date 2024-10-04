using System;
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

        #region Funciones
        private void BtnSingIn_Click(object sender, EventArgs e)
        {
            LblWrongUsr.Visible = false;
            LblWrongPwd.Visible = false;
            LblNoUsrPwd.Visible = false;

            if (TxtUsr.Text == "Ingrese el usuario" && TxtPwd.Text != "Contraseña")
            {
                try
                {
                    LblWrongPwd.Visible = false;
                    LblNoUsrPwd.Visible =false;
                    LblWrongUsr.Visible = true;
                }
                catch { }
            }
            else if (TxtPwd.Text == "Contraseña" && TxtUsr.Text != "Ingrese el usuario")
            {
                try
                {
                    LblNoUsrPwd.Visible = false;
                    LblWrongUsr.Visible = false;
                    LblWrongPwd.Visible = true;
                }
                catch { }
            }
            else if (TxtUsr.Text == "Ingrese el usuario" && TxtPwd.Text == "Contraseña")
            {
                try
                {
                    LblWrongUsr.Visible = false;
                    LblWrongPwd.Visible = false;
                    LblNoUsrPwd.Visible = true;
                }
                catch { }
            }
        }

        private void TxtUsr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtUsr.Text == "")
                {
                    TxtUsr.Text = "Ingrese el usuario";
                    return;
                }

                TxtUsr.ForeColor = Color.White;
            }
            catch {}
        }

        private void TxtPwd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TxtPwd.Text == "")
                {
                    TxtPwd.Text = "Contraseña";
                    TxtPwd.PasswordChar = '\0';
                }
                else
                {
                    TxtPwd.PasswordChar = '●';
                }

                TxtPwd.ForeColor = Color.White;

                
            }
            catch { }
        }

        private void TxtUsr_Click(object sender, EventArgs e)
        {
            TxtUsr.SelectAll();
        }

        private void TxtPwd_Click(object sender, EventArgs e)
        {
            TxtPwd.SelectAll();
        }

        private void BtnHidePwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtPwd.PasswordChar == '\0')
                {
                    BtnShowPwd.BringToFront();
                    TxtPwd.PasswordChar = '●'; 
                }
            }

            catch
            {

            }
        }

        private void BtnShowPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtPwd.PasswordChar == '●')
                {
                    BtnHidePwd.BringToFront();
                    TxtPwd.PasswordChar = '\0';

                }
            }
            catch
            {

            }
        }

        #endregion
    }

    #region Drag form
    #endregion
}
