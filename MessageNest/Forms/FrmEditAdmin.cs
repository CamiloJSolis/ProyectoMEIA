using MessageNest.Dao;
using MessageNest.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageNest.Forms
{
    public partial class FrmEditAdmin : Form
    {
        public FrmEditAdmin(UserEntity user)
        {
            InitializeComponent();
            
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

            TxtAdminUsr.Text = user.UserName;
            TxtAdminFirstName.Text = firstName;
            TxtAdminSecondName.Text = secondName;
            TxtAdminFirstSurname.Text = firstSurname;
            TxtAdminSecondSurname.Text = secondSurname;
            TxtAdminPhone.Text = user.PhoneNumber;
            CmbxRol.Text = role;
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

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            UserEntity user = new UserEntity();
            UserDao userDao = new UserDao();

            string password = TxtAdminNewPwd.Text;

            CorrectInput(DtpAdminBD.Value);

            if (IsPasswordSecure(password))
            {
                UserEntity modifyUser = new UserEntity();
                {
                    user.PhoneNumber = PadRight(TxtAdminPhone.Text, 10);
                    user.BirthDate = DtpAdminBD.Value.ToString("dd/MM/yyyy").PadRight(10);
                    user.Role = SetRole(userDao.firstUser) ? 1 : 0;
                    user.PasswordEncrypted = EncryptPassword(TxtAdminNewPwd.Text);

                };

                userDao.ModifyUser(user.Name, user.PhoneNumber, user.BirthDate, user.PasswordEncrypted);
            }
        }

        private void ClearFields()
        {
            this.Close();
            this.Show();
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
            if (DtpAdminBD.Value == DateTime.Now.Date)
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

        private bool SetRole(bool isEmpty)
        {
            bool role = true;
            if (isEmpty == true)
            {
                return role; // 1 para admin
            }
            else
            {
                return role = false; // 0 user
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
