using MessageNest.Dao;
using MessageNest.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageNest.Forms
{
    public partial class FrmSearchUser : Form
    {
        private UserEntity _user;
        private int _isActive;

        public FrmSearchUser()
        {
            InitializeComponent();
        }

        #region Cambiar Color
        private void SetSearchUserPanelsColor(Color color)
        {
            PnlSearchUsrLeft.BackColor = color;
            PnlSearchtUsrRight.BackColor = color;
            PnlSearchUsrUp.BackColor = color;
            PnlSearchUsrDown.BackColor = color;
        }

        private void SetDtpBirthDatePanelsColor(Color color)
        {
            PnlBDLeft.BackColor = color;
            PnlBDRight.BackColor = color;
            PnlBDUp.BackColor = color;
            PnlBDDown.BackColor = color;
        }

        private void SetPhonePanelsColor(Color color)
        {
            PnlPhoneLeft.BackColor = color;
            PnlPhoneRight.BackColor = color;
            PnlPhoneUp.BackColor = color;
            PnlPhoneDown.BackColor = color;
        }

        #endregion

        #region Botones
        private void TxtSearchUsr_Click(object sender, EventArgs e)
        {
            if (TxtSearchUsr.Text == "Ingrese el usuario a buscar")
            {
                TxtSearchUsr.SelectAll();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string userName = TxtSearchUsr.Text.Trim();

            UserDao userDao = new UserDao();
            UserEntity user = userDao.BuscarUsuario(userName);

            _user = user;
            _isActive = user.IsActive;

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

            string isActive;
            if (user.IsActive == 1)
            {
                isActive = "Sí";
            }
            else
            {
                isActive = "No";
            }

            if (user != null)
            {
                MessageBox.Show("¡Usuario encontrado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtFoundUsr.Text = user.UserName;
                TxtFoundFirstName.Text = firstName;
                TxtFoundSecondName.Text = secondName;
                TxtFoundFirstSurname.Text = firstSurname;
                TxtFoundSecondSurname.Text = secondSurname;
                TxtFoundPwd.Text = user.PasswordEncrypted;
                TxtFoundPwd.PasswordChar = '●';
                TxtFoundPhone.Text = user.PhoneNumber;
                DtpFoundBD.Text = user.BirthDate;
                CmbxFoundRol.Text = role;
                CmbxFoundActive.Text = isActive;
            }

        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            TxtFoundPhone.Enabled = true;
            CmbxFoundActive.Enabled = true;
            DtpFoundBD.Enabled = true;
            BtnSaveChanges.Enabled = true;
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {
            CleanFields();
        }

        private void CleanFields()
        {
            TxtFoundPhone.Enabled = false;
            TxtFoundPhone.Enabled = false;
            CmbxFoundActive.Enabled = false;
            DtpFoundBD.Enabled = false;
            BtnSaveChanges.Enabled = false;

            TxtSearchUsr.Text = "Ingrese el usuario a buscar";
            TxtFoundUsr.Clear();
            TxtFoundFirstName.Clear();
            TxtFoundSecondName.Clear();
            TxtFoundFirstSurname.Clear();
            TxtFoundSecondSurname.Clear();
            TxtFoundPwd.Clear();
            TxtFoundPhone.Clear();
            DtpFoundBD.Value = DateTime.Now;
            CmbxFoundRol.Text = " ";
            CmbxFoundActive.Text = " ";
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            UserDao userDao = new UserDao();

            _user.IsActive = CmbxFoundActive.Text == "Sí" ? 1 : 0;
            _user.PasswordEncrypted = TxtFoundPwd.Text;
            _user.UserName = TxtFoundUsr.Text;
            _user.BirthDate = DtpFoundBD.Value.ToString("dd/MM/yyyy").PadRight(10);
            _user.PhoneNumber = PadRight(TxtFoundPhone.Text, 10);

            userDao.ModificarUsuario(_user.UserName, _user.PasswordEncrypted, _user.BirthDate, _user.PhoneNumber, _user.IsActive);
            UpdateDescUser(_user.UserName);
        }

        private void CorrectInput(DateTime birthDate)
        {
            if (DtpFoundBD.Value == DateTime.Now.Date)
            {
                MessageBox.Show("Debe ingresar una fecha válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string PadRight(string input, int length)
        {
            if (input.Length < length)
            {
                return input.PadRight(length, ' ');
            }
            else if (input.Length > length)
            {
                return input.Substring(0, length); // Recorta si excede la longitud
            }
            return input;
        }

        private void UpdateDescUser(string userName)
        {
            string descFilePath = @"C:\MEIA\desc_user.txt";
            DateTime currentDate = DateTime.Now;

            string[] lines = File.ReadAllLines(descFilePath);
            int totalRecords = int.Parse(lines[5].Split(':')[1].Trim());
            int activeRecords = int.Parse(lines[6].Split(':')[1].Trim());
            int inactiveRecords = int.Parse(lines[7].Split(':')[1].Trim());
            bool wasActive = _isActive == 1;

            if (wasActive && _user.IsActive == 0)
            {
                activeRecords -= 1;
                inactiveRecords += 1;
                MessageBox.Show("El usuario ha sido desactivado", "Informacón", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!wasActive && _user.IsActive == 1)
            {
                activeRecords += 1;
                inactiveRecords -= 1;
                MessageBox.Show("El usuario ha sido activado", "Informacón", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No se ha realizado ningún cambio en el estado.", "Informacón", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            using (StreamWriter writer = new StreamWriter(descFilePath))
            {
                writer.WriteLine(lines[0]); // nombre_simbolico
                writer.WriteLine(lines[1]); // fecha_creacion
                writer.WriteLine(lines[2]); // usuario_creacion
                writer.WriteLine($"fecha_modificacion: {currentDate:dd/MM/yyyy}");
                writer.WriteLine($"usuario_modificacion: {userName}");
                writer.WriteLine($"#_registros: {totalRecords}");
                writer.WriteLine($"registros_activos: {activeRecords}");
                writer.WriteLine($"registros_inactivos: {inactiveRecords}"); // registros_inactivos
                writer.WriteLine(lines[8]); // max_reorganizacion
            }
        }

        #endregion

        #region Funciones

        // Keypress

        private void TxtFoundPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!TxtFoundPhone.ReadOnly == true)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    TxtFoundPhone.Visible = true;
                }
                else
                {
                    TxtFoundPhone.Visible = false;
                }
            }
        }

        // Date time picker

        private void DtpFoundBD_DropDown(object sender, EventArgs e)
        {
            SetDtpBirthDatePanelsColor(Color.DeepSkyBlue);
        }

        private void DtpFoundBD_CloseUp(object sender, EventArgs e)
        {
            SetDtpBirthDatePanelsColor(Color.FromArgb(50, 50, 50));
        }

        // Enter/Leave

        private void TxtSearchUsr_Enter(object sender, EventArgs e)
        {
            TxtSearchUsr.ForeColor = Color.White;
            SetSearchUserPanelsColor(Color.DeepSkyBlue);
        }

        private void TxtSearchUsr_Leave(object sender, EventArgs e)
        {
            TxtSearchUsr.ForeColor = Color.DarkGray;
            SetSearchUserPanelsColor(Color.FromArgb(50, 50, 50));
        }


        private void TxtFoundPhone_Enter(object sender, EventArgs e)
        {
            TxtFoundPhone.ForeColor = Color.White;
            SetPhonePanelsColor(Color.DeepSkyBlue);
        }

        private void TxtFoundPhone_Leave(object sender, EventArgs e)
        {
            TxtFoundPhone.ForeColor = Color.DarkGray;
            SetPhonePanelsColor(Color.FromArgb(50, 50, 50));
        }
        #endregion
    }
}
