using MessageNest.Entities;
using MessageNest.Forms;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MessageNest.Dao
{
    public class UserDao
    {
        private string dirPath = @"C:\MEIA";
        private string  filePath;
        public bool firstUser;

        public UserDao()
        {
            filePath = Path.Combine(dirPath, "user.txt");
            firstUser = IsFirstUser(filePath);
         }

        public bool AgregarRegistro(UserEntity user)
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

        public UserEntity BuscarRegistro(string userName, string password)
        {
            try
            {
                string[] lines = { };
                if(File.Exists(filePath))
                {
                    lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(';');
                        if (fields[0].Trim().Equals(userName))
                        {
                            if (fields[3].Trim().Equals(password))
                            {
                                int status = int.Parse(fields[7].Trim());
                                return new UserEntity
                                {
                                    UserName = fields[0].Trim(),
                                    Name = fields[1].Trim(),
                                    Surname = fields[2].Trim(),
                                    PasswordEncrypted = fields[3].Trim(),
                                    Role = int.Parse(fields[4].Trim()),
                                    BirthDate = fields[5].Trim(),
                                    PhoneNumber = fields[6].Trim(),
                                    IsActive = status
                                };
                            }
                            else
                            {
                                MessageBox.Show("Contraseña incorrecta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return null;
                            }
                        }

                    }
                    MessageBox.Show("El nombre de usuario no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                else
                {
                    MessageBox.Show("El archivo de usuarios no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar el usuario: {ex}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool IsFirstUser(string filePath)
        {
            return !File.Exists(filePath) || new FileInfo(filePath).Length == 0;
        }

        public void ModifyUser(string userName, string newPhone, string newBirthDay, string newPassword)
        {
            string tempFilePath = Path.Combine(dirPath, "user_temp.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                StreamWriter sw = new StreamWriter(tempFilePath);
               
                foreach (string line in lines)
                {
                    string[] fields = line.Split(';');
                    if (fields[0] == userName)
                    {
                        //fields[3] = sw.WriteLine($"{newPassword}");
                        sw.WriteLine($"{newPassword};{newBirthDay};{newPhone};");
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                }
                File.Delete(filePath);
                File.Move(tempFilePath, filePath);
            }
        }
    }
}
