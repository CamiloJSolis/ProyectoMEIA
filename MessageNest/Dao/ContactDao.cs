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

        public List<ContactEntity> GetAllContacts()
        {
            var users = new List<ContactEntity>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] fields = line.Split(';');
                ContactEntity contact = GetContact(fields);
                users.Add(contact);
            }

            return users;
        }

        private ContactEntity GetContact(string[] fields)
        {
            return new ContactEntity
            {
                User = fields[0].Trim(),
                Contact = fields[1].Trim(),
                TransactionDate = fields[2].Trim(),
                UserTransaction = fields[3].Trim(),
                Status = int.Parse(fields[4].Trim()),
            };
        }
    }
}
