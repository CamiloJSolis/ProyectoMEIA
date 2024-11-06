using MessageNest.Entities;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MessageNest.Dao
{
    public class ListDao
    {
        private string dirPath = @"C:\MEIA";
        private string filePath = "";

        public ListDao()
        {
            filePath = Path.Combine(dirPath, "lista.txt");
        }

        public bool AgregarLista(ListEntity list)
        {
            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                bool listExists = false;
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] fields = line.Split(';');
                    if (fields[0].Trim().Equals(list.ListName.Trim()) && fields[1].Trim().Equals(list.UserName.Trim()))
                    {
                        MessageBox.Show("La lista ya existe. No se guardará nuevamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        listExists = true;
                        break;
                    }
                }


                if (!listExists && list.ListName.Trim() != "" && list.Description.Trim() != "")
                {
                    string listRecord = $"{list.ListName};{list.UserName};{list.Description};{list.UserNumber};{list.CreationDate};{list.Status}";
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(listRecord);
                    }

                    MessageBox.Show("La lista ha sido creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
                else if (listExists)
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("Debe llenar todos los campos de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los datos: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<ListEntity> GetAllLists()
        {
            if(File.Exists(filePath))
            {
                var lists = new List<ListEntity>();
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] fields = line.Split(';');
                    ListEntity list = GetList(fields);
                    lists.Add(list);
                }

                return lists;
            }
            else
            {
                return null;
            }
        }

        private ListEntity GetList(string[] fields)
        {
            return new ListEntity
            { 
                ListName = fields[0].Trim(),
                UserName = fields[1].Trim(),
                Description = fields[2].Trim(),
                UserNumber = fields[3].Trim(),
                CreationDate = fields[4].Trim(),
                Status = int.Parse(fields[5].Trim()),
            };
        }

        public bool ModificarLista(string listName, string userName, string modifiedDescription, string modifiedUserNumber, string modifiedCreationDate, int modifiedStatus)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("El archivo de lista no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string[] lines = File.ReadAllLines(filePath);
                bool foundList = false;

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(';');

                    if (fields[0].Trim().Equals(listName) && fields[1].Trim().Equals(userName))
                    {
                        fields[2] = modifiedDescription;
                        fields[3] = modifiedUserNumber;
                        fields[4] = modifiedCreationDate;
                        fields[5] = modifiedStatus.ToString();

                        lines[i] = string.Join(";", fields);
                        foundList = true;
                        break;
                    }
                }

                if (!foundList)
                {
                    MessageBox.Show("El nombre de la lista o contacto no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                File.WriteAllLines(filePath, lines);

                MessageBox.Show("El contacto ha sido modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al modificar la lista: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Index

        public bool AgregarIndex(IndexEntity index, List<UserEntity> users)
        {
            try
            {
                string indexFilePath = Path.Combine(dirPath, "indice_lista_usuario.txt");

                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                if (!File.Exists(indexFilePath))
                {
                    File.Create(indexFilePath).Close();
                }

                bool indexExists = false;
                string[] lines = File.ReadAllLines(indexFilePath);
                int currentIndex = 0;

                if (lines.Length > 0)
                {
                    var maxIndex = lines.Select(line => int.Parse(line.Split(';')[0].Trim())).Max();
                    currentIndex = maxIndex + 1;
                }
                else
                {
                    currentIndex = 0;
                }

                //if (File.Exists(filePath))
                //{
                //    foreach (string line in lines)
                //    {
                //        string[] fields = line.Split(';');
                //        if (fields[2].Trim().Equals(index.ListName.Trim()) && fields[3].Trim().Equals(index.User.Trim()))
                //        {
                //            MessageBox.Show("La lista ya existe. No se agregará un nuevo índice.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            indexExists = true;
                //            break;
                //        }
                //    }
                //}

                if (string.IsNullOrWhiteSpace(index.ListName) && string.IsNullOrWhiteSpace(index.User))
                {
                    MessageBox.Show("El nombre de la lista y el usuario no deben estar vacíos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!indexExists)
                {
                    using (StreamWriter writer = new StreamWriter(indexFilePath, true))
                    {
                        foreach (var user in users)
                        { 
                            if (!string.IsNullOrEmpty(user.UserName))
                            {
                                index.AssociatedUser = user.UserName;
                                index.Record = currentIndex++;

                                string indexRecord = $"{index.Record};{index.Position};{index.ListName};{index.User};{index.AssociatedUser},{index.CreationDate};{index.Status}";
                                writer.WriteLine(indexRecord);
                            }
                            else
                            {
                                MessageBox.Show("El nombre de usuario asociado está vacío", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                MessageBox.Show(user.UserName);
                            }
                        }
                    }
                    MessageBox.Show("El índice ha sido creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los datos: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
