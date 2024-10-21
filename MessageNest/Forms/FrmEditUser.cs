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
    public partial class FrmEditUser : Form
    {
        public FrmEditUser(UserEntity user)
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

            int isActive = 0;
            if (CmbxActive.Text == "Sí")
            {
                isActive = 1;
            }

            string password = TxtUsrNewPwd.Text;
            string userName = TxtNormalUsr.Text;
            string newBirthDate = DtpUsrBD.Value.ToString("dd/MM/yyyy").PadRight(10);
            string newPhone = PadRight(TxtUsrPhone.Text, 10);

            CorrectInput(DtpUsrBD.Value);

            if (IsPasswordSecure(password))
            {
                if (userDao.ModificarUsuario(userName, EncryptPassword(password), newBirthDate, newPhone, isActive))
                {
                    ClearFields();
                }
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
