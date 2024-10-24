using MessageNest.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageNest.Dao
{
    public class ContactDao
    {
        private string dirPath = @"C:\MEIA";
        private string filePath;

        public ContactDao ()
        {
            filePath = Path.Combine(dirPath, "contactos.txt");
        }

        public bool AgregarContacto(ContactEntity contact)
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

                string userRecord = $"{contact.User};{contact.Contact};{contact.TransactionDate};{contact.UserTransaction};{contact.Status}";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(userRecord);
                }

                MessageBox.Show("El contacto ha sido creado exitosamente.", "Éxito",
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
    }
}
