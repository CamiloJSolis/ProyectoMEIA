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
            if (File.Exists(filePath))
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
            else
            {
                return null;
            }
        }

        public ContactEntity BuscarContacto(string userName)
        {
            try
            {
                var user = ObtainContact(userName);
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

        private ContactEntity ObtainContact(string userName)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("El archivo de contactos no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] fileds = line.Split(';');
                    if (fileds[0].Trim().Equals(userName))
                    {
                        return GetContact(fileds);
                    }
                }
                MessageBox.Show("El nombre de usuario no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar el usuario: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
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

        public bool ModificarContacto(string userName, string contact, string newTransactionDate, string newTransactionUser, int newStatus)
        {
            try
            {               
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("El archivo de contactos no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string[] lines = File.ReadAllLines(filePath);
                bool founUser = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(';');
                    
                    if (fields[0].Trim().Equals(userName) && fields[1].Trim().Equals(contact))
                    {
                        fields[2] = newTransactionDate;
                        fields[3] = newTransactionUser;
                        fields[4] = newStatus.ToString();

                        lines[i] = string.Join(";", fields);
                        founUser = true;
                        break;
                    }
                }

                if (!founUser)
                {
                    MessageBox.Show("El nombre de usuario o contacto no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                File.WriteAllLines(filePath, lines);

                MessageBox.Show("El contacto ha sido modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al modificar el contacto: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
