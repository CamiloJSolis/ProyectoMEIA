﻿using MessageNest.Entities;
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

namespace MessageNest.Forms
{
    public partial class FrmUser : Form
    {
        private UserEntity _currentUser;

        public FrmUser(UserEntity user)
        {
            InitializeComponent();
            _currentUser = user;

            OpenChildForm(new FrmUserInfo(_currentUser));
        }

        #region Call Child Forms

        private Form currentForm = null;

        public void OpenChildForm(Form childForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PnlChildForm.Controls.Add(childForm);
            PnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        #endregion

        #region Botones

        private void BtnCloseUsr_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCloseUsr_MouseHover(object sender, EventArgs e)
        {
            BtnCloseUsr.BackColor = Color.Red;
            BtnCloseUsr.Image = Properties.Resources.exit;
        }

        private void BtnCloseUsr_MouseLeave(object sender, EventArgs e)
        {
            BtnCloseUsr.BackColor = Color.FromArgb(40, 40, 40);
            BtnCloseUsr.Image = Properties.Resources.close_button;
        }

        private void BtnUserInfo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmUserInfo(_currentUser));
        }

        private void BtnModifyUsr_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmEditUser(_currentUser));
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que quiere salir?", "Confirmación", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                FrmLogin frmLogin = new FrmLogin();

                this.Hide();
                frmLogin.Show();
            }
        }

        private void BtnContacts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmContacts(_currentUser));
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmList(_currentUser));
        }

        #endregion

        #region Arrastrar Form

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PnlTopUser_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }


        #endregion
    }
}
