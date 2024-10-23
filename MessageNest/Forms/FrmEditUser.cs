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
    public partial class FrmEditUser : Form
    {
        private UserEntity _user;
        private int _isActive;

        public FrmEditUser(UserEntity user)
        {
            InitializeComponent();

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

            TxtNormalUsr.Text = user.UserName;
            TxtUsrFirstName.Text = firstName;
            TxtUsrSecondName.Text = secondName;
            TxtUsrFirstSurname.Text = firstSurname;
            TxtUsrSecondSurname.Text = secondSurname;
            TxtUsrPhone.Text = user.PhoneNumber;
            DtpUsrBD.Text = user.BirthDate;
            CmbxRol.Text = role;
            CmbxActive.Text = isActive;
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

        private void BtnModify_Click(object sender, EventArgs e)
        {
            TxtUsrNewPwd.ReadOnly = false;
            DtpUsrBD.Enabled = true;
            TxtUsrPhone.ReadOnly = false;
            CmbxActive.Enabled = true;
            BtnSaveChanges.Enabled = true;
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            UserDao userDao = new UserDao();

            int isActive = CmbxActive.Text == "Sí" ? 1 : 0;
            string actualPassword = _user.PasswordEncrypted;
            string newPassword = TxtUsrNewPwd.Text;
            string userName = TxtNormalUsr.Text.Trim();
            string newBirthDate = DtpUsrBD.Value.ToString("dd/MM/yyyy").PadRight(10);
            string newPhone = PadRight(TxtUsrPhone.Text, 10);

            CorrectInput(DtpUsrBD.Value);

            if (IsPasswordSecure(newPassword) && TxtUsrNewPwd.Text != "Contraseña" && newPassword != actualPassword)
            {
                _user.UserName = userName;
                _user.PasswordEncrypted = EncryptPassword(newPassword);
                _user.BirthDate = newBirthDate;
                _user.PhoneNumber = newPhone;
                _user.IsActive = isActive;

                if (userDao.ModificarUsuario(_user.UserName, _user.PasswordEncrypted, _user.BirthDate, _user.PhoneNumber, _user.IsActive))
                {
                    MessageBox.Show("Modificando desc user");
                    MessageBox.Show(_user.UserName);
                    UpdateDescUser(_user.UserName);
                    ClearFields();
                }
            }
            else
            {
                _user.UserName = userName;
                _user.BirthDate = newBirthDate;
                _user.PhoneNumber = newPhone;
                _user.IsActive = isActive;

                if (userDao.ModificarUsuario(_user.UserName, actualPassword, _user.BirthDate, _user.PhoneNumber, _user.IsActive))
                {
                    MessageBox.Show(_user.UserName);
                    UpdateDescUser(_user.UserName);
                    MessageBox.Show("Modificando desc user");
                    ClearFields();
                }
            }
        }

        private void ClearFields()
        {
            this.Close();
        }

        private string EncryptPassword(string password)
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

        private void CorrectInput(DateTime birthDate)
        {
            if (DtpUsrBD.Value == DateTime.Now.Date)
            {
                MessageBox.Show("Debe ingresar una fecha válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool IsPasswordSecure(string password)
        {
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasMinimumLength = password.Length >= 8;
            bool hasMaxLength = password.Length <= 15;

            return hasUpperCase && hasLowerCase && hasDigit && hasMinimumLength && hasMaxLength;
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

            MessageBox.Show("Comparando", "Informacón", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (wasActive && _user.IsActive == 0)
            {
                activeRecords -= 1;
                inactiveRecords += 1;
                MessageBox.Show("El usuario ha sido desactivado", "Informacón", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No se ha realizado ningún cambio en el estado.", "Informacón", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            MessageBox.Show("Ya comparo", "Info", MessageBoxButtons.OK);

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
