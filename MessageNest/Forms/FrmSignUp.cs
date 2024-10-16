using MessageNest.Dao;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MessageNest.Entities;
using System.Web;
using System.Security.Cryptography;

namespace MessageNest.Forms
{
    public partial class FrmSignUp : Form
    {
        public FrmSignUp()
        {
            InitializeComponent();
        }

        #region Botones

        private void BtnCloseSignUp_Click(object sender, EventArgs e)
        {
           DialogResult dialog = MessageBox.Show("¿Está seguro que quiere salir? \nSi no ha guardado la información, se perderán todos los datos ingresados.", "Salir", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                FrmLogin frmLogin = new FrmLogin();

                this.Hide();
                frmLogin.Show();
            }
        }

        private void BtnCloseSignUp_MouseHover(object sender, EventArgs e)
        {
            BtnCloseSignUp.BackColor = Color.Red;
            BtnCloseSignUp.Image = Properties.Resources.exit;
        }

        private void BtnCloseSignUp_MouseLeave(object sender, EventArgs e)
        {
            BtnCloseSignUp.BackColor = Color.FromArgb(30, 30, 30);
            BtnCloseSignUp.Image = Properties.Resources.close_button;
        }

        private void BtnShowHide_Click(object sender, EventArgs e)
        {
            if (TxtNewPwd.PasswordChar == '●')
            {
                TxtNewPwd.PasswordChar = '\0';
                BtnShowHide.Image = Properties.Resources.show;
            }
            else if (TxtNewPwd.Text != "Contraseña")
            {
                TxtNewPwd.PasswordChar = '●';
                BtnShowHide.Image = Properties.Resources.hide;
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            BtnCreate.BackColor = Color.FromArgb(255, 210, 100);

            UserEntity user = new UserEntity();
            UserDao userDao = new UserDao();

            string password = TxtNewPwd.Text;

            CorrectInput(TxtNewUsr.Text, TxtNewFirstName.Text, TxtNewFirstSurname.Text, DtpNewBD.Value);

            if (IsPasswordSecure(password))
            {
                user.UserName = PadRight(TxtNewUsr.Text, 20);
                user.Name = VerifyName(TxtNewFirstName.Text, TxtNewSecondName.Text);
                user.Surname = VerifySurname(TxtNewFirstSurname.Text, TxtNewSecondSurname.Text);
                user.PasswordEncrypted = EncryptPassword(TxtNewPwd.Text);
                user.Role = SetRole(userDao.firstUser) ? 1 : 0;
                user.BirthDate = DtpNewBD.Value.ToString("dd/MM/yyyy").PadRight(10);
                user.PhoneNumber = PadRight(TxtPhone.Text, 10);
                user.IsActive = true ? 1 : 0;  // Estatus como '1' (activo) o '0' (inactivo)

                bool isAdded = userDao.AgregarRegistro(user);

                if(isAdded)
                {
                    DialogResult dialogResult = new DialogResult();
                    
                    dialogResult = MessageBox.Show("¿Desea agregar otro usuario?", "Crear usuario", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(dialogResult == DialogResult.No)
                    {
                        FrmLogin frmLogin = new FrmLogin();

                        this.Hide();
                        frmLogin.Show();
                    }
                    else
                    {
                        ClearFields();
                    }
                }
            }
            else
            {
                MessageBox.Show("La contraseña no cumple con el nivel mínimo de seguridad.");
            }
        }

        private void ClearFields()
        {
            //TxtNewUsr.Text = "ngrese el usuario";
            //TxtNewFirstName.Text = "Primer nombre"; 
            //TxtNewSecondName.Text = "Segundo o tercer nombre"; 
            //TxtNewFirstSurname.Text = "Primer apellido"; 
            //TxtNewSecondSurname.Text = "Segundo apellido";
            //TxtNewPwd.Text = "Contraseña";
            //TxtPhone.Text = "0000000000";

            //TxtNewUsr.Clear();
            //TxtNewFirstName.Clear();
            //TxtNewSecondName.Clear();
            //TxtNewFirstSurname.Clear();
            //TxtNewSecondSurname.Clear();
            //TxtNewPwd.Clear();
            //TxtPhone.Clear();

            this.Hide();
            FrmSignUp frmSignUp = new FrmSignUp();
            frmSignUp.Show();

            //this.Refresh();
        }

        private string EncryptPassword(string password)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            var stringBuilder = new StringBuilder();

            //StringBuilder stringBuilder = new StringBuilder(bytes.Length * 2);

            //for (int i = 0; i < bytes.Length; i++)
            //{
            //    // Escribe como hexadecimal
            //    sb.Append(bytes[i].ToString("x2"));
            //}

            foreach (byte b in bytes)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }

            return stringBuilder.ToString().Substring(0,15);
        }

        private void CorrectInput (string userName, string firstName, string firstLastName, DateTime birthDate)
        {
            IsUsercorrect(userName);

            if (TxtNewFirstName.Text == "Primer nombre")
            {
                MessageBox.Show("Debe ingresar su primer nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            if (TxtNewFirstSurname.Text == "Primer apellido")
            {
                MessageBox.Show("Debe ingresar su primer apellido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            if (DtpNewBD.Value == DateTime.Now.Date)
            {
                MessageBox.Show("Debe ingresar una fecha válida", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsUsercorrect(string userName)
        {
            bool hasNumbers = userName.Any(char.IsNumber);
            bool hasUnderscore = HasUnderscore(userName);
            bool hasMinLength = userName.Length >= 5;
            bool hasMaxLength = userName.Length <= 20;
            bool hasInvalidChar = userName.Any(c => !char.IsLetterOrDigit(c) && c != '_');

            if (!hasMinLength || !hasMaxLength || hasInvalidChar)
            {
                MessageBox.Show("Usuario inválido.Debe tener entre 5 y 20 caracteres y solo contener letras, números y guiones bajos."
                    , "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool HasUnderscore(string userName)
        {
                return userName.Contains('_');
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

        private string VerifyName(string firstName, string secondName)
        {
            string completeName;

            if (TxtNewSecondName.Text != "Segundo o tercer nombre")
            {
                completeName = $"{firstName} {secondName}";
                return PadRight(completeName, 30);
            }
            else
            { 
                return PadRight(firstName, 30);
            }
        }

        private string VerifySurname(string firstSurname, string secondSurname)
        {
            string completeSurname;

            if (TxtNewSecondSurname.Text != "Segundo apellido")
            {
                completeSurname = $"{firstSurname} {secondSurname}";
                return PadRight(completeSurname, 30);
            }
            else
            {
                return PadRight(firstSurname, 30);
            }
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

        #region Cambiar colores

        // Cambiar de color los panel

        private void SetUsrPanelsColor(Color color)
        {
            PnlInsertUsrLeft.BackColor = color;
            PnlInsertUsrRight.BackColor = color;
            PnlInsertUsrUp.BackColor = color;
            PnlInsertUsrDown.BackColor = color;
        }

        private void SetFirstNamePanelsColor(Color color)
        {
            PnlFirstNameLeft.BackColor = color;
            PnlFirstNameRight.BackColor = color;
            PnlFirstNameUp.BackColor = color;
            PnlFirstNameDown.BackColor = color;
        }

        private void SetSecondNamePanelsColor(Color color)
        {
            PnlSecondNameLeft.BackColor = color;
            PnlSecondNameRight.BackColor = color;
            PnlSecondNameUp.BackColor = color;
            PnlSecondNameDown.BackColor = color;
        }

        private void SetFirstSurnamePanelsColor(Color color)
        {
            PnlFirstSurnameLeft.BackColor = color;
            PnlFirstSurnameRight.BackColor = color;
            PnlFirstSurnameUp.BackColor = color;
            PnlFirstSurnameDown.BackColor = color;
        }

        private void SetSecondSurnamePanelsColor(Color color)
        {
            PnlSecondSurnameLeft.BackColor = color;
            PnlSecondSurnameRight.BackColor = color;
            PnlSecondSurnameUp.BackColor = color;
            PnlSecondSurnameDown.BackColor = color;
        }

        private void SetPwdPanelsColor(Color color)
        {
            PnlInsertPwdLeft.BackColor = color;
            PnlInsertPwdRight.BackColor = color;
            PnlInsertPwdUp.BackColor = color;
            PnlInsertPwdDown.BackColor = color;
        }

        private void SetPhonePanlesColor(Color color)
        {
            PnlPhoneLeft.BackColor = color;
            PnlPhoneRight.BackColor = color;
            PnlPhoneUp.BackColor = color;
            PnlPhoneDown.BackColor = color;
        }

        #endregion

        #region Funciones

        // Keypress

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtNewUsr_Click(object sender, EventArgs e)
        {
            if (TxtNewUsr.Text == "Ingrese el usuario")
            {
                TxtNewUsr.SelectAll();
            }
        }

        private void TxtNewFirstName_Click(object sender, EventArgs e)
        {
            if (TxtNewFirstName.Text == "Primer nombre")
            {
                TxtNewFirstName.SelectAll();
            }
        }

        private void TxtNewFirstSurname_Click(object sender, EventArgs e)
        {
            if (TxtNewFirstSurname.Text == "Primer apellido")
            {
                TxtNewFirstSurname.SelectAll();
            }
        }

        private void TxtNewSecondName_Click(object sender, EventArgs e)
        {
            if (TxtNewSecondName.Text == "Segundo o tercer nombre")
            {
                TxtNewSecondName.SelectAll();
            }
        }

        private void TxtNewSecondSurname_Click(object sender, EventArgs e)
        {
            if (TxtNewSecondSurname.Text == "Segundo apellido")
            {
                TxtNewSecondSurname.SelectAll();
            }
        }

        private void TxtNewPwd_Click(object sender, EventArgs e)
        {
            if (TxtNewPwd.Text == "Contraseña")
            {
                TxtNewPwd.SelectAll();
            }
        }

        private void TxtPhone_Click(object sender, EventArgs e)
        {
            if (TxtPhone.Text == "0000000000")
            {
                TxtPhone.SelectAll();
            }
        }

        private void LnkLblForgotPwd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();

            this.Hide();
            frmLogin.Show();
        }

        // Double click

        private void TxtNewUsr_DoubleClick(object sender, EventArgs e)
        {
            TxtNewUsr.SelectAll();
        }

        private void TxtNewFirstName_DoubleClick(object sender, EventArgs e)
        {
            TxtNewFirstName.SelectAll();
        }

        private void TxtNewFirstSurname_DoubleClick(object sender, EventArgs e)
        {
            TxtNewFirstSurname.SelectAll();
        }

        private void TxtNewSecondName_DoubleClick(object sender, EventArgs e)
        {
            TxtNewSecondName.SelectAll();
        }

        private void TxtNewSecondSurname_DoubleClick(object sender, EventArgs e)
        {
            TxtNewSecondSurname.SelectAll();
        }

        private void TxtNewPwd_DoubleClick(object sender, EventArgs e)
        {
            TxtNewPwd.SelectAll();
        }

        private void TxtPhone_DoubleClick(object sender, EventArgs e)
        {
            TxtPhone.SelectAll();
        }

        // Enter y leave

        private void TxtNewUsr_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsr.Text == "Ingrese el usuario")
            {
                TxtNewUsr.Text = "";

                TxtNewUsr.ForeColor = Color.White;
                SetUsrPanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewUsr_Leave(object sender, EventArgs e)
        {
            try 
            {
                if (TxtNewUsr.Text == "")
                {
                    TxtNewUsr.Text = "Ingrese el usuario";

                    TxtNewUsr.ForeColor = Color.DarkGray;
                    SetUsrPanelsColor(Color.FromArgb(50, 53, 60));
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error con los txt: {ex}");
            }
        }

        private void TxtNewFirstName_Enter(object sender, EventArgs e)
        {
            if (TxtNewFirstName.Text == "Primer nombre")
            {
                TxtNewFirstName.Text = "";

                TxtNewFirstName.ForeColor = Color.White;
                SetFirstNamePanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewFirstName_Leave(object sender, EventArgs e)
        {
            if (TxtNewFirstName.Text == "")
            {
                TxtNewFirstName.Text = "Primer nombre";

                TxtNewFirstName.ForeColor = Color.DarkGray;
                SetFirstNamePanelsColor(Color.FromArgb(50, 53, 60));
            }
        }

        private void TxtNewFirstSurname_Enter(object sender, EventArgs e)
        {
            if (TxtNewFirstSurname.Text == "Primer apellido")
            {
                TxtNewFirstSurname.Text = "";

                TxtNewFirstSurname.ForeColor = Color.White;
                SetFirstSurnamePanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewFirstSurname_Leave(object sender, EventArgs e)
        {
            if (TxtNewFirstSurname.Text == "")
            {
                TxtNewFirstSurname.Text = "Primer apellido";

                TxtNewFirstSurname.ForeColor = Color.DarkGray;
                SetFirstSurnamePanelsColor(Color.FromArgb(50, 53, 60));
            }
        }

        private void TxtNewSecondName_Enter(object sender, EventArgs e)
        {
            if (TxtNewSecondName.Text == "Segundo o tercer nombre")
            {
                TxtNewSecondName.Text = "";

                TxtNewSecondName.ForeColor = Color.White;
                SetSecondNamePanelsColor(Color.DeepSkyBlue);
            } 
        } 

        private void TxtNewSecondName_Leave(object sender, EventArgs e)
        {
            if (TxtNewSecondName.Text == "")
            {
                TxtNewSecondName.Text = "Segundo o tercer nombre";

                TxtNewSecondName.ForeColor = Color.DarkGray;
                SetSecondNamePanelsColor(Color.FromArgb(50, 53, 60));
            }
        }

        private void TxtNewSecondSurname_Enter(object sender, EventArgs e)
        {
            if (TxtNewSecondSurname.Text == "Segundo apellido")
            {
                TxtNewSecondSurname.Text = "";

                TxtNewSecondSurname.ForeColor = Color.White;
                SetSecondSurnamePanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewSecondSurname_Leave(object sender, EventArgs e)
        {
            if (TxtNewSecondSurname.Text == "")
            {
                TxtNewSecondSurname.Text = "Segundo apellido";

                TxtNewSecondSurname.ForeColor = Color.DarkGray;
                SetSecondSurnamePanelsColor(Color.FromArgb(50, 53, 60));
            }
        }

        private void TxtNewPwd_Enter(object sender, EventArgs e)
        {
            TxtNewPwd.Text = "";
            TxtNewPwd.PasswordChar = '●';
            TxtNewPwd.ForeColor = Color.White;
            SetPwdPanelsColor(Color.DeepSkyBlue);
        }

        private void TxtNewPwd_Leave(object sender, EventArgs e)
        {
            if (TxtNewPwd.Text == "")
            {
                TxtNewPwd.Text = "Contraseña";
                TxtNewPwd.PasswordChar = '\0';
                TxtNewPwd.ForeColor = Color.DarkGray;

                SetPwdPanelsColor(Color.FromArgb(50, 53, 60));
            }
        }

        private void TxtPhone_Enter(object sender, EventArgs e)
        {
            if (TxtPhone.Text == "0000000000")
            {
                TxtPhone.Text = "";

                TxtPhone.ForeColor = Color.White;
                SetPhonePanlesColor(Color.DeepSkyBlue);
            }
        }

        private void TxtPhone_Leave(object sender, EventArgs e)
        {
            if (TxtPhone.Text == "")
            {
                TxtPhone.Text = "0000000000";

                TxtPhone.ForeColor = Color.DarkGray;
                SetPhonePanlesColor(Color.FromArgb(50, 53, 60));
            }
        }

        #endregion

        #region Drag form

        [DllImport("user32.Dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.Dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PnlTopSignUp_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        #endregion
    }
}
