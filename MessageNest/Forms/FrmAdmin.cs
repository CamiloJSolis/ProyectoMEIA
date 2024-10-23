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
using System.Web;
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

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            string sourceFolder = @"C:\MEIA";
            Backup(sourceFolder);
        }

        private void Backup(string sourceFolder)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string destinationFolder = Path.Combine(folderBrowserDialog.SelectedPath, "Backup");

                if (Directory.CreateDirectory(destinationFolder).Exists)
                {
                    Directory.Delete(destinationFolder, true);
                }

                Directory.CreateDirectory(destinationFolder);

                try
                {
                    string[] files = Directory.GetFiles(sourceFolder);

                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        string destination = Path.Combine(destinationFolder, fileName);
                        File.Copy(file, destination, true);
                    }

                    string[] folders = Directory.GetDirectories(sourceFolder);

                    foreach (string folder in folders)
                    {
                        string dirName = Path.GetFileName(folder);
                        string destiniy = Path.Combine(destinationFolder, dirName);

                        Directory.CreateDirectory(destiniy);
                        Backup(destiniy);
                    }

                    BackupLog(destinationFolder);

                    MessageBox.Show("Carpeta almacenada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al guardar la carpeta: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void BackupLog(string destinationFolder)
        {
            string logDestinationFilePath = @"C:\MEIA\bitacora_backup.txt";
            DateTime operationDate = DateTime.Now;

            using (StreamWriter writer = new StreamWriter(logDestinationFilePath, true)) // true para agregar al final
            {
                writer.WriteLine($"ruta_absoluta: {destinationFolder}");
                writer.WriteLine($"user: {_currentUser.UserName}");
                writer.WriteLine($"fecha_operación: {operationDate:dd/MM/yyyy}");
                writer.WriteLine();
            }

            UpdateDescBackup(logDestinationFilePath);
        }

        private void UpdateDescBackup(string logDestinationFilePath)
        {
            string descDestinationFilePath = @"C:\MEIA\desc_bitacora_backup.txt";
            DateTime creationDate = DateTime.Now;


            if (!File.Exists(descDestinationFilePath))
            {
                using (StreamWriter writer = new StreamWriter(descDestinationFilePath))
                {
                    writer.WriteLine($"nombre_simbolico: Descriptor de los backups");
                    writer.WriteLine($"fecha_creacion: {creationDate}");
                    writer.WriteLine($"usuario_creacion: {_currentUser.UserName}");
                    writer.WriteLine($"fecha_modificacion: {creationDate}");
                    writer.WriteLine($"usuario_modificacion: {_currentUser.UserName}");
                    writer.WriteLine($"#_registros: 1");
                }
            }
            else
            {
                string[] lines = File.ReadAllLines(descDestinationFilePath);
                int registrationNumber = 0;

                string[] backupLogLines = File.ReadAllLines(logDestinationFilePath);
               
                foreach (string line in backupLogLines)
                {
                    if (line.Trim() == "")
                    {
                        registrationNumber++;
                    }
                }

                using (StreamWriter writer = new StreamWriter(descDestinationFilePath))
                {
                    writer.WriteLine(lines[0]);
                    writer.WriteLine(lines[1]);
                    writer.WriteLine(lines[2]);
                    writer.WriteLine($"fecha_modificacion: {creationDate}");
                    writer.WriteLine($"usuario_modificacion: {_currentUser.UserName}");
                    writer.WriteLine($"#_registros: {registrationNumber}");
                }

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
    }
}
