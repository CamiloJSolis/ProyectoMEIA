using MessageNest.Dao;
using MessageNest.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageNest.Forms
{
    public partial class FrmAdmin : Form
    {
        private UserEntity _currentUser;

        public FrmAdmin(UserEntity user)
        {
            InitializeComponent();
            _currentUser = user;

            OpenChildForm(new FrmAdminInfo(_currentUser));
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

        private void BtnCloseAdmin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCloseAdmin_MouseHover(object sender, EventArgs e)
        {
            BtnCloseAdmin.BackColor = Color.Red;
            BtnCloseAdmin.Image = Properties.Resources.exit;
        }

        private void BtnCloseAdmin_MouseLeave(object sender, EventArgs e)
        {
            BtnCloseAdmin.BackColor = Color.FromArgb(40, 40, 40);
            BtnCloseAdmin.Image = Properties.Resources.close_button;
        }

        private void BtnAdminInfo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmAdminInfo(_currentUser));
        }

        private void BtnModifyAdmin_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmEditAdmin(_currentUser));
        }

        private void BtnAddUsr_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmAddUser());
        }

        private void BtnSrchUsr_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmSearchUser());
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

        #endregion

        #region Arrastrar Form

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PnlTopAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        #endregion

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            string source = @"C:\MEIA\user.txt";
            Backup(source);
        }

        private void Backup(string source)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string destinationFolder = folderBrowserDialog.SelectedPath;
                //string fileName = Path.GetFileName(source);
                string fileName = "Backup.txt";
                string destinationPath = Path.Combine(destinationFolder, fileName);

                try
                {
                    File.Copy(source, destinationPath, overwrite: true);
                    MessageBox.Show("Archivo almacenado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ocurrió un error al guardar el archivo", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
