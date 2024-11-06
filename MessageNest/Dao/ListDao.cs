using MessageNest.Entities;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MessageNest.Dao
{
    public class ListDao
    {
        private string dirPath = @"C:\MEIA";
        private string filePath = "";
        private int userDataPosition;
        private string blockFilePath;
        string indexFilePath ;

        public ListDao()
        {
            filePath = Path.Combine(dirPath, "lista.txt");
            blockFilePath = Path.Combine(dirPath, "lista_usuario.txt");
            indexFilePath = Path.Combine(dirPath, "index_lista_usuario.txt");
        }

        public bool AgregarLista(ListEntity list)
        {
            try
            {
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

        public List<ListEntity> GetAllLists(string currentUser)
        {
            if(File.Exists(filePath) && currentUser != string.Empty)
            {
                var lists = new List<ListEntity>();
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] fields = line.Split(';');
                    ListEntity list = GetList(fields);
                    if (currentUser == list.UserName)
                    {
                        lists.Add(list);
                    }
                }
                 
                return lists;
            }
            else
            {
                return null;
            }
        }

        public List<BlockEntity> GetUsersOfList(string listName, string currentUser)
        {
            if (File.Exists(blockFilePath) && listName != string.Empty && currentUser != string.Empty)
            {
                var users = new List<BlockEntity>();
                string[] lines = File.ReadAllLines(blockFilePath);

                foreach(string line in lines)
                {
                    string[] fields = line.Split(';');
                    BlockEntity block = GetUserList(fields);
                    if (listName == block.ListName && currentUser == block.User)
                    {
                        users.Add(block);
                    }
                }
                return users;
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

        private BlockEntity GetUserList(string[] fields)
        {
            return new BlockEntity
            {
                ListName = fields[0].Trim(),
                User = fields[1].Trim(),
                AssociatedUser = fields[2].Trim(),
                Description = fields[3].Trim(),
                CreationDate = fields[4].Trim(),
                Status = int.Parse(fields[5].Trim()),
            };
        }

        public bool ModificarLista(string listName, string userName, string modifiedDescription, string modifiedCreationDate, int modifiedStatus)
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

                    if (fields[0].Equals(listName) && fields[1].Equals(userName))
                    {
                        fields[2] = modifiedDescription;
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

        // Block

        public bool AgregarBloque(BlockEntity block, List<UserEntity> users)
        {
            try
            {
                if (!File.Exists(blockFilePath))
                {
                    File.Create(blockFilePath).Close();
                }

                bool blockExists = false;

                if (string.IsNullOrWhiteSpace(block.ListName) && string.IsNullOrWhiteSpace(block.User))
                {
                    MessageBox.Show("El nombre de la lista y el usuario no deben estar vacíos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!blockExists)
                {
                    using (StreamWriter writer = new StreamWriter(blockFilePath, true))
                    {
                        foreach (var user in users)
                        {
                            if (!string.IsNullOrEmpty(user.UserName))
                            {
                                block.AssociatedUser = user.UserName;

                                string blockRecord = $"{block.ListName};{block.User};{block.AssociatedUser};{block.Description};{block.CreationDate};{block.Status}";
                                writer.WriteLine(blockRecord);
                            }

                        }
                    }
                    MessageBox.Show("El bloque ha sido creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar los datos en el boque: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        static int RECORD_SIZE = 84;
        static string GetRecord(string path, int posicion)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                fs.Seek(posicion * RECORD_SIZE, SeekOrigin.Begin);

                byte[] line = reader.ReadBytes(RECORD_SIZE);
                string record = Encoding.ASCII.GetString(line).Trim();

                return record;
            }
        }

        //public bool ModificarBloque(string listName, string currentUser, string modifiedUser, int newSatus)
        //{
        //    try
        //    {
        //        //if (!File.Exists(indexFilePath))
        //        //{
        //        //    MessageBox.Show("El archivo de índices no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //    return false;
        //        //}

        //        //if (!File.Exists(blockFilePath))
        //        //{
        //        //    MessageBox.Show("El archivo de bloques no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //    return false;
        //        //}

        //        //string[] indexLines = File.ReadAllLines(indexFilePath);
        //        //int blockPosition = -1;

        //        //for (int i = 0; i < indexLines.Length; i++)
        //        //{
        //        //    string[] indexFields = indexLines[i].Split(';');

        //        //    if (indexFields[2].Equals(listName) && indexFields[3].Equals(currentUser) && indexFields[4].Equals(modifiedUser))
        //        //    {
        //        //        blockPosition = int.Parse(indexFields[0].Trim());
        //        //        break;
        //        //    }
        //        //}

        //        //if (blockPosition == -1)
        //        //{
        //        //    MessageBox.Show("El usuario no se encontró en el índice", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        //    return false;
        //        //}

        //        //string[] blockLines = File.ReadAllLines(blockFilePath);

        //        //if (blockPosition < 0 || blockPosition >= blockLines.Length)
        //        //{
        //        //    MessageBox.Show("La posición de índice está incorrecta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        //    return false;
        //        //}

        //        //string[] blockFields = blockLines[blockPosition].Split(';');

        //        //blockFields[5] = newSatus.ToString();

        //        //blockLines[blockPosition] = string.Join(";", blockFields);

        //        //File.WriteAllLines(blockFilePath, blockLines);

        //        //MessageBox.Show("Usuario se modificó exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        //return true;
        //        //if (!blockExists)
        //        //{
        //        //    using (StreamWriter writer = new StreamWriter(blockFilePath, true))
        //        //    {
        //        //        foreach (var user in users)
        //        //        {
        //        //            if (!string.IsNullOrEmpty(user.UserName))
        //        //            {
        //        //                block.AssociatedUser = user.UserName;

        //        //                string blockRecord = $"{block.ListName};{block.User};{block.AssociatedUser};{block.Description};{block.CreationDate};{block.Status}";
        //        //                writer.WriteLine(blockRecord);
        //        //            }

        //        //        }
        //        //    }
        //        //    MessageBox.Show("El bloque ha sido creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        //    return true;
        //        //}
        //        //else
        //        //{
        //        //    return false;
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Ocurrió un error al modificar el usuario en el boque: {ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}

        // Index

        public bool AgregarIndex(IndexEntity index, List<UserEntity> users)
        {
            try
            {
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
                int currentIndex = 1;

                if (lines.Length > 0)
                {
                    var maxIndex = lines.Select(line => int.Parse(line.Split(';')[0].Trim())).Max();
                    currentIndex = maxIndex + 1;
                }

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
                                index.Record = currentIndex;
                                index.Position = currentIndex - 1;
                                currentIndex++;

                                string indexRecord = $"{PadRight(index.Record.ToString(), 3)};{PadRight(index.Position.ToString(), 3)};{index.ListName};{index.User};{index.AssociatedUser};{index.CreationDate};{index.Status}";
                                writer.WriteLine(indexRecord);
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

    }
}
