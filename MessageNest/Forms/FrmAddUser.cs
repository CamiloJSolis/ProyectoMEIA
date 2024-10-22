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
    public partial class FrmAddUser : Form
    {
        public FrmAddUser()
        {
            InitializeComponent();
        }

        #region Cambiar color

        // Cambiar de color los panel

        private void SetNewUsrPanelsColor(Color color)
        {
            PnlInsertUsrLeft.BackColor = color;
            PnlInsertUsrRight.BackColor = color;
            PnlInsertUsrUp.BackColor = color;
            PnlInsertUsrDown.BackColor = color;
        }

        private void SetNewFirstNamePanlesColor(Color color)
        {
            PnlFirstNameLeft.BackColor = color;
            PnlFirstNameRight.BackColor = color;
            PnlFirstNameUp.BackColor = color;
            PnlFirstNameDown.BackColor = color;
        }

        private void SetNewSecondNamePanelsColor (Color color)
        {
            PnlSecondNameLeft.BackColor = color;
            PnlSecondNameRight.BackColor = color;
            PnlSecondNameUp.BackColor = color;
            PnlSecondNameDown.BackColor = color;
        }

        private void SetNewFirstSurnamePanelColor (Color color)
        {
            PnlFirstSurnameLeft.BackColor = color;
            PnlFirstSurnameRight.BackColor = color;
            PnlFirstSurnameUp.BackColor = color;
            PnlFirstSurnameDown.BackColor = color;
        }

        private void SetNewSecondSurnamePanelsColor(Color color)
        {
            PnlSecondSurnameLeft.BackColor = color;
            PnlSecondSurnameRight.BackColor = color;
            PnlSecondSurnameUp.BackColor = color;
            PnlSecondSurnameDown.BackColor = color;
        }

        private void SetNewPasswordPanlesColor (Color color)
        {
            PnlInsertPwdLeft.BackColor = color;
            PnlInsertPwdRight.BackColor = color;
            PnlInsertPwdUp.BackColor = color;
            PnlInsertPwdDown.BackColor = color;
        }

        private void SetPhonePanlesColor (Color color)
        {
            PnlPhoneLeft.BackColor = color;
            PnlPhoneRight.BackColor = color;
            PnlPhoneUp.BackColor = color;
            PnlPhoneDown.BackColor = color;
        }
        private void SetBirthDatePanelsColor (Color color)
        {
            PnlBDLeft.BackColor = color;
            PnlBDRight.BackColor = color;
            PnlBDUp.BackColor = color;
            PnlBDDown.BackColor = color;
        }

        #endregion

        #region Botones

        private void BtnShowHide_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrPwd.PasswordChar == '●')
            {
                TxtNewUsrPwd.PasswordChar = '\0';
                BtnShowHide.Image = Properties.Resources.show;
            }
            else if (TxtNewUsrPwd.Text != "Contraseña")
            {
                TxtNewUsrPwd.PasswordChar = '●';
                BtnShowHide.Image = Properties.Resources.hide;
            }
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            BtnCreate.BackColor = Color.FromArgb(255, 210, 100);

            UserEntity user = new UserEntity();
            UserDao userDao = new UserDao();

            string password = TxtNewUsrPwd.Text;
            string userName = TxtNewUsr.Text;
            CorrectInput(TxtNewUsr.Text, TxtNewUsrFirstName.Text, TxtNewUsrFirstSurname.Text, DtpNewUsrBD.Value);

            if (IsPasswordSecure(password) && IsUsercorrect(userName))
            {
                user.UserName = PadRight(TxtNewUsr.Text, 20);
                user.Name = VerifyName(TxtNewUsrFirstName.Text, TxtNewUsrSecondName.Text);
                user.Surname = VerifySurname(TxtNewUsrFirstSurname.Text, TxtNewUsrSecondSurname.Text);
                user.PasswordEncrypted = EncryptPassword(TxtNewUsrPwd.Text);
                user.Role = SetRole(userDao.firstUser) ? 1 : 0;
                user.BirthDate = DtpNewUsrBD.Value.ToString("dd/MM/yyyy").PadRight(10);
                user.PhoneNumber = PadRight(TxtNewUsrPhone.Text, 10);
                user.IsActive = true ? 1 : 0;  // Estatus como '1' (activo) o '0' (inactivo)

                bool isAdded = userDao.AgregarUsuario(user);

                if (isAdded)
                {
                    DialogResult dialogResult = new DialogResult();

                    dialogResult = MessageBox.Show("¿Desea agregar otro usuario?", "Crear usuario",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    UpdateDescUser(userName, user.Name);

                    if (dialogResult == DialogResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        ClearFields();
                    }
                }
            }
            else if (!IsPasswordSecure(password))
            {
                MessageBox.Show("La contraseña no cumple con el nivel mínimo de seguridad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void ClearFields()
        {
            TxtNewUsr.Clear();
            TxtNewUsrFirstName.Clear();
            TxtNewUsrSecondName.Clear();
            TxtNewUsrFirstSurname.Clear();
            TxtNewUsrSecondSurname.Clear();
            TxtNewUsrPwd.Text = "Contraseña";
            TxtNewUsrPhone.Text = "0000000000";
            DtpNewUsrBD.Value = DateTime.Now;

            SetNewUsrPanelsColor(Color.FromArgb(50, 50, 50));
            SetNewFirstNamePanlesColor(Color.FromArgb(50, 50, 50));
            SetNewSecondNamePanelsColor(Color.FromArgb(50, 50, 50));
            SetNewFirstSurnamePanelColor(Color.FromArgb(50, 50, 50));
            SetNewSecondSurnamePanelsColor(Color.FromArgb(50, 50, 50));
            SetNewPasswordPanlesColor(Color.FromArgb(50, 50, 50));
            SetPhonePanlesColor(Color.FromArgb(50, 50, 50));
            SetBirthDatePanelsColor(Color.FromArgb(50, 50, 50));
            SetPhonePanlesColor(Color.FromArgb(50, 50, 50));
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

        private void CorrectInput(string userName, string firstName, string firstLastName, DateTime birthDate)
        {
            IsUsercorrect(userName);

            if (TxtNewUsrFirstName.Text == "Primer nombre")
            {
                MessageBox.Show("Debe ingresar su primer nombre", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (TxtNewUsrFirstSurname.Text == "Primer apellido")
            {
                MessageBox.Show("Debe ingresar su primer apellido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (DtpNewUsrBD.Value == DateTime.Now.Date)
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
                MessageBox.Show("Usuario inválido. Debe tener entre 5 y 20 caracteres. Solo debe contener letras, números y guiones bajos."
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

            if (TxtNewUsrSecondName.Text != "Segundo o tercer nombre")
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

            if (TxtNewUsrSecondSurname.Text != "Segundo apellido")
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

        private void UpdateDescUser(string userName, string name)
        {
            string descFilePath = @"C:\MEIA\desc_user.txt";
            DateTime currentDate = DateTime.Now;
            string symbolicName = name.Replace(" ", "").ToLower();

            // Si el archivo no existe, lo crea con los detalles iniciales
            if (!File.Exists(descFilePath))
            {
                using (StreamWriter writer = new StreamWriter(descFilePath))
                {
                    writer.WriteLine($"nombre_simbolico: {symbolicName}");
                    writer.WriteLine($"fecha_creacion: {currentDate:dd/MM/yyyy}");
                    writer.WriteLine($"usuario_creacion: {userName}");
                    writer.WriteLine($"fecha_modificacion: {currentDate:dd/MM/yyyy}");
                    writer.WriteLine($"usuario_modificacion: {userName}");
                    writer.WriteLine("#_registros: 1");
                    writer.WriteLine("registros_activos: 1");
                    writer.WriteLine("registros_inactivos: 0");
                    writer.WriteLine("max_reorganizacion: 100");
                }
            }
            else
            {
                // Si el archivo existe, actualiza la información de la descripción
                string[] lines = File.ReadAllLines(descFilePath);
                int totalRecords = int.Parse(lines[5].Split(':')[1].Trim()) + 1;
                int activeRecords = int.Parse(lines[6].Split(':')[1].Trim()) + 1;

                using (StreamWriter writer = new StreamWriter(descFilePath))
                {
                    writer.WriteLine(lines[0]); // nombre_simbolico
                    writer.WriteLine(lines[1]); // fecha_creacion
                    writer.WriteLine(lines[2]); // usuario_creacion
                    writer.WriteLine($"fecha_modificacion: {currentDate:dd/MM/yyyy}");
                    writer.WriteLine($"usuario_modificacion: {userName}");
                    writer.WriteLine($"#_registros: {totalRecords}");
                    writer.WriteLine($"registros_activos: {activeRecords}");
                    writer.WriteLine(lines[7]); // registros_inactivos
                    writer.WriteLine(lines[8]); // max_reorganizacion
                }
            }
        }

        #endregion

        #region Funciones

        // Keypress

        private void TxtNewUsrPhone_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxNewUsrFirstName_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstName.Text == "Primer nombre")
            {
                TxtNewUsrFirstName.SelectAll();
            }
        }

        private void TxtNewFirstSurname_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstSurname.Text == "Primer apellido")
            {
                TxtNewUsrFirstSurname.SelectAll();
            }
        }

        private void TxtNewUsrSecondName_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondName.Text == "Segundo o tercer nombre")
            {
                TxtNewUsrSecondName.SelectAll();
            }      
        }

        private void TxtNewUsrSecondSurname_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondSurname.Text == "Segundo apellido")
            {
                TxtNewUsrSecondSurname.SelectAll();
            }
        }

        private void TxtNewUsrPwd_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrPwd.Text == "Contraseña")
            {
                TxtNewUsrPwd.SelectAll();
            }
        }

        private void TxtNewUsrPhone_Click(object sender, EventArgs e)
        {
            if (TxtNewUsrPhone.Text == "0000000000")
            {
                TxtNewUsrPhone.SelectAll();
            }
        }

        //Enter y Leave

        private void TxtNewUsr_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsr.Text == "Ingrese el usuario")
            {
                TxtNewUsr.Text = "";

                TxtNewUsr.ForeColor = Color.White;
                SetNewUsrPanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewUsr_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsr.Text == "")
            {
                TxtNewUsr.Text = "Ingrese el usuario";

                TxtNewUsr.ForeColor = Color.DarkGray;
                SetNewUsrPanelsColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxNewUsrFirstName_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstName.Text == "Primer nombre")
            {
                TxtNewUsrFirstName.Text = "";

                TxtNewUsrFirstName.ForeColor = Color.White;
                SetNewFirstNamePanlesColor(Color.DeepSkyBlue);
            }
        }

        private void TxNewUsrFirstName_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstName.Text == "")
            {
                TxtNewUsrFirstName.Text = "Primer nombre";

                TxtNewUsrFirstName.ForeColor = Color.DarkGray;
                SetNewFirstNamePanlesColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtNewUsrFirstSurname_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstSurname.Text == "Primer apellido")
            {
                TxtNewUsrFirstSurname.Text = "";

                TxtNewUsrFirstSurname.ForeColor = Color.White;
                SetNewFirstSurnamePanelColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewUsrFirstSurname_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrFirstSurname.Text == "")
            {
                TxtNewUsrFirstSurname.Text = "Primer apellido";

                TxtNewUsrFirstSurname.ForeColor = Color.DarkGray;
                SetNewFirstSurnamePanelColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtNewUsrSecondName_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondName.Text == "Segundo o tercer nombre")
            {
                TxtNewUsrSecondName.Text = "";

                TxtNewUsrSecondName.ForeColor = Color.White;
                SetNewSecondNamePanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewUsrSecondName_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondName.Text == "")
            {
                TxtNewUsrSecondName.Text = "Segundo o tercer nombre";

                TxtNewUsrSecondName.ForeColor = Color.DarkGray;
                SetNewSecondNamePanelsColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtNewUsrSecondSurname_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondSurname.Text == "Segundo apellido")
            {
                TxtNewUsrSecondSurname.Text = "";

                TxtNewUsrSecondSurname.ForeColor = Color.White;
                SetNewSecondSurnamePanelsColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewUsrSecondSurname_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrSecondSurname.Text == "")
            {
                TxtNewUsrSecondSurname.Text = "Segundo apellido";

                TxtNewUsrSecondSurname.ForeColor = Color.DarkGray;
                SetNewSecondSurnamePanelsColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtNewUsrPwd_Enter(object sender, EventArgs e)
        {
            TxtNewUsrPwd.Text = "";
            TxtNewUsrPwd.PasswordChar = '●';
            TxtNewUsrPwd.ForeColor = Color.White;
            SetNewPasswordPanlesColor(Color.DeepSkyBlue);
        }

        private void TxtNewUsrPwd_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrPwd.Text == "")
            {
                TxtNewUsrPwd.Text = "Contraseña";
                TxtNewUsrPwd.PasswordChar = '\0';
                TxtNewUsrPwd.ForeColor = Color.DarkGray;
                SetNewPasswordPanlesColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtNewUsrPhone_Enter(object sender, EventArgs e)
        {
            if (TxtNewUsrPhone.Text == "0000000000")
            {
                TxtNewUsrPhone.Text = "";

                TxtNewUsrPhone.ForeColor = Color.White;
                SetPhonePanlesColor(Color.DeepSkyBlue);
            }
        }

        private void TxtNewUsrPhone_Leave(object sender, EventArgs e)
        {
            if (TxtNewUsrPhone.Text == "")
            {
                TxtNewUsrPhone.Text = "0000000000";

                TxtNewUsrPhone.ForeColor = Color.DarkGray;
                SetPhonePanlesColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void DtpNewUsrBD_DropDown(object sender, EventArgs e)
        {
            SetBirthDatePanelsColor(Color.DeepSkyBlue);
        }

        private void DtpNewUsrBD_CloseUp(object sender, EventArgs e)
        {
            SetBirthDatePanelsColor(Color.FromArgb(50, 50, 50));
        }


        #endregion
    }
}
