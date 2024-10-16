using MessageNest.Entities;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public void AgregarRegistro(UserEntity user)
        {
            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(@"C:\MEIA");
                }

                if (!File.Exists(filePath))
                {
                    File.Create(@"C:\MEIA\user.txt").Close();
                }

                string userRecord = $"{user.UserName};{user.Surname};{user.PasswordEncrypted};" +
                    $"{user.Role};{user.BirthDate};{user.PhoneNumber};{user.IsActive}";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(userRecord);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los datos: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsFirstUser(string filePath)
        {
            return !File.Exists(filePath) || new FileInfo(filePath).Length == 0;
        }
    }
}
