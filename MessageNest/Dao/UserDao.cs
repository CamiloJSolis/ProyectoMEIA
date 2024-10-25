using MessageNest.Entities;
using MessageNest.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MessageNest.Dao
{
    public class UserDao
    {
        private string dirPath = @"C:\MEIA";
        private string filePath;
        public bool firstUser;

        public UserDao()
        {
            filePath = Path.Combine(dirPath, "user.txt");
            firstUser = IsFirstUser(filePath);
        }

        public List<UserEntity> GetAllUsers()
        {
            var users = new List<UserEntity>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                UserEntity user = GetUser(fields);
                users.Add(user);
            }

            return users;
        }

        public bool AgregarUsuario(UserEntity user)
        {
            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(@"C:\MEIA");
                }

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                string userRecord = $"{user.UserName};{user.Name};{user.Surname};{user.PasswordEncrypted};{user.Role};{user.BirthDate};{user.PhoneNumber};{user.IsActive}";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(userRecord);
                }

                MessageBox.Show("El usuario ha sido creado exitosamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los datos: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public UserEntity AutenticarUsuario(string userName, string password)
        {
            try
            {
                var user = ObtenerUsuario(userName);
                if (user != null)
                {
                    if (user.PasswordEncrypted.Trim().Equals(password))
                    {
                        return user;
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al autenticar el usuario: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public UserEntity BuscarUsuario(string userName)
        {
            try
            {
                var user = ObtenerUsuario(userName);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar el usuario: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private UserEntity ObtenerUsuario(string userName)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("El archivo de usuarios no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                string[] lines = lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] fields = line.Split(';');
                    if (fields[0].Trim().Equals(userName))
                    {
                        return GetUser(fields);
                    }
                }
                MessageBox.Show("El nombre de usuario no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar el usuario: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private UserEntity GetUser(string[] fields)
        {
            return new UserEntity
            {
                UserName = fields[0].Trim(),
                Name = fields[1].Trim(),
                Surname = fields[2].Trim(),
                PasswordEncrypted = fields[3].Trim(),
                Role = int.Parse(fields[4].Trim()),
                BirthDate = fields[5].Trim(),
                PhoneNumber = fields[6].Trim(),
                IsActive = int.Parse(fields[7].Trim())
            };
        }

        private bool IsFirstUser(string filePath)
        {
            return !File.Exists(filePath) || new FileInfo(filePath).Length == 0;
        }

        public bool ModificarUsuario(string userName, string newEncryptedPassword, string newBirthDate, string newPhoneNumber, int isActive)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("El archivo de usuarios no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string[] lines = File.ReadAllLines(filePath);
                bool foundUser = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(';');
                    if (fields[0].Trim().Equals(userName))
                    {
                        fields[3] = newEncryptedPassword;
                        fields[5] = newBirthDate;
                        fields[6] = newPhoneNumber;
                        fields[7] = isActive.ToString();

                        lines[i] = string.Join(";", fields);
                        foundUser = true;
                        break;
                    }
                }

                if (!foundUser)
                {
                    MessageBox.Show("El nombre de usuario no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                File.WriteAllLines(filePath, lines);

                MessageBox.Show("El usuario ha sido modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al modificar el usuario: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
