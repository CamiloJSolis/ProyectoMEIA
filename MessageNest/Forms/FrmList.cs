using MessageNest.Dao;
using MessageNest.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MessageNest.Forms
{
    public partial class FrmList : Form
    {
        private string _currentUser;
        int numberOfUsers = 0;
        private List<UserEntity> _selectedUsers = new List<UserEntity>();

        public FrmList(UserEntity user)
        {
            InitializeComponent();

            _currentUser = user.UserName.Trim();

            LoadListsData();
            LoadUsersData();

            // Obtener los usuarios

            searchUserTimer = new System.Windows.Forms.Timer();
            searchUserTimer.Interval = 1000;
            searchUserTimer.Tick += SearchUserTime_Tick;
            TxtSearchUser.TextChanged += TxtSearchUser_TextChanged;
            ListViewUsers.SelectedIndexChanged += ListViewUsers_SelectedIndexChanged;

            // Obtener los contactos

            searchListTimer = new System.Windows.Forms.Timer();
            searchListTimer.Interval = 1000;
            searchListTimer.Tick += SearchListTimer_Tick;
            TxtSearchList.TextChanged += TxtSearchList_TextChanged;
        }
        #region Cambiar Color

        private void SetSearchUserPanelsColor(Color color)
        {
            PnlSearchUsrLeft.BackColor = color;
            PnlSearchtUsrRight.BackColor = color;
            PnlSearchUsrUp.BackColor = color;
            PnlSearchUsrDown.BackColor = color;
        }

        private void SetListNamePanelsColor(Color color)
        {
            PnlListNameLeft.BackColor = color;
            PnlListNameRight.BackColor = color;
            PnlListNameUp.BackColor = color;
            PnlListNameDown.BackColor = color;
        }

        private void SetListDescriptionPanlesColor(Color color)
        {
            PnlListDescriptionLeft.BackColor = color;
            PnlListDescriptionRight.BackColor = color;
            PnlListDescriptionUp.BackColor = color;
            PnlListDescriptionDown.BackColor = color;
        }

        private void SetSearchListPanelsColor(Color color)
        {
            PnlSearchListLeft.BackColor = color;
            PnlSearchListRight.BackColor = color;
            PnlSearchListUp.BackColor = color;
            PnlSearchListDown.BackColor = color;
        }

        #endregion

        #region Botones

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void BtnCreateList_Click(object sender, EventArgs e)
        {
            if (ListViewUsers.Items.Count > 0)
            {
                IndexEntity index = new IndexEntity();
                BlockEntity block = new BlockEntity();
                ListEntity list = new ListEntity();
                ListDao listDao = new ListDao();

                list.ListName = PadRight(TxtListName.Text.Trim(), 30);
                list.UserName = PadRight(_currentUser, 20);
                list.Description = PadRight(TxtListDescription.Text.Trim(), 40);
                list.UserNumber = PadRight(numberOfUsers.ToString(), 3);
                list.CreationDate = DateTime.Now.ToString("dd/MM/yyyy");
                list.Status = 1;

                index.ListName = PadRight(TxtListName.Text.Trim(), 30); 
                index.User = PadRight(_currentUser, 20);
                index.CreationDate = DateTime.Now.ToString("dd/MM/yyyy"); ;
                index.Status = 1;

                listDao.AgregarIndex(index, _selectedUsers);

                if (listDao.AgregarLista(list))
                {
                    TxtSearchUser.Text = "Ingrese el usuario, nombres o apellidos a buscar";
                    TxtListName.Clear();
                    TxtListDescription.Clear();
                    TxtSearchUser.Clear();
                    LoadListsData();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al agregar los datos al archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnModifyContact_Click(object sender, EventArgs e)
        {

        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {

        }

        private void BtnClean_Click(object sender, EventArgs e)
        {

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

        #region Funciones

        // TabPageAddList

        private void LoadUsersData()
        {
            Cursor.Current = Cursors.WaitCursor;

            ListViewUsers.Items.Clear();
            UserDao userDao = new UserDao();
            List<UserEntity> users = userDao.GetAllUsers();

            foreach (UserEntity user in users)
            {
                if (user.UserName.Trim().Equals(_currentUser))
                {
                    continue;
                }

                ListViewItem item = new ListViewItem(user.UserName);
                item.SubItems.Add(user.Name);
                item.SubItems.Add(user.Surname);
                ListViewUsers.Items.Add(item);
            }

            Cursor.Current = Cursors.Default;
        }

        private void TxtSearchUser_Click(object sender, EventArgs e)
        {
            if (TxtSearchUser.Text == "Ingrese el usuario, nombres o apellidos a buscar")
            {
                TxtSearchUser.SelectAll();
            }
        }

        private void TxtListName_Enter(object sender, EventArgs e)
        {
            TxtListName.ForeColor = Color.White;
            SetListNamePanelsColor(Color.DeepSkyBlue);
        }

        private void TxtListName_Leave(object sender, EventArgs e)
        {
            if (TxtListName.Text.Trim() != "")
            TxtListName.ForeColor = Color.DarkGray;
            SetListNamePanelsColor(Color.FromArgb(50, 50, 50));
        }

        private void TxtListDescription_Enter(object sender, EventArgs e)
        {
            TxtListDescription.ForeColor = Color.White;
            SetListDescriptionPanlesColor(Color.DeepSkyBlue);
        }

        private void TxtListDescription_Leave(object sender, EventArgs e)
        {
            if (TxtListDescription.Text.Trim() != "")
            {
                TxtListDescription.ForeColor = Color.White;
                SetListDescriptionPanlesColor(Color.FromArgb(50, 50, 50));
            }
        }

        private void TxtSearchUser_Enter(object sender, EventArgs e)
        {
            TxtSearchUser.ForeColor = Color.White;
            SetSearchUserPanelsColor(Color.DeepSkyBlue);
        }

        private void TxtSearchUser_Leave(object sender, EventArgs e)
        {
            if (TxtListDescription.Text.Trim() != "")
            {
                TxtSearchUser.ForeColor = Color.White;
                SetSearchUserPanelsColor(Color.FromArgb(50, 50, 50));
            }
        }

        private System.Windows.Forms.Timer searchUserTimer;

        private void TxtSearchUser_TextChanged(object sender, EventArgs e)
        {
            searchUserTimer.Stop();
            searchUserTimer.Start();
        }

        private void SearchUserTime_Tick(object sender, EventArgs e)
        {
            searchUserTimer.Stop();

            UserDao userDao = new UserDao();

            string userName = TxtSearchUser.Text;
            ListViewUsers.Items.Clear();
            List<UserEntity> users = userDao.GetAllUsers();

            foreach (var user in users)
            {
                if (user.UserName.Contains(userName) || user.Name.Contains(userName))
                {
                    if (TxtSearchUser.Text != "")
                    {
                        ListViewItem item = new ListViewItem(user.UserName);
                        item.SubItems.Add(user.Name);
                        item.SubItems.Add(user.Surname);
                        ListViewUsers.Items.Add(item);
                    }
                }
            }

            if (ListViewUsers.Items.Count == 0 && TxtSearchUser.Text == "")
            {
                LoadUsersData();
            }
            else if (ListViewUsers.Items.Count == 0 && TxtSearchUser.Text != "")
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("No se encontró el usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dialog == DialogResult.OK)
                {
                    LoadUsersData();
                }
            }
        }

        private void ListViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {      
            if (ListViewUsers.SelectedItems.Count > 0)
            {
                _selectedUsers.Clear();
                foreach (ListViewItem selectedItem in ListViewUsers.SelectedItems)
                {
                    string userName = selectedItem.Text;
                    UserEntity user = new UserEntity();
                    user.UserName = userName;
                    //PadRight(user.UserName, 20);
                    _selectedUsers.Add(user);
                }
                numberOfUsers = _selectedUsers.Count;

                foreach (UserEntity userEntity in _selectedUsers)
                {
                    foreach (ListViewItem item in ListViewUsers.Items)
                    {
                        if (item.Text == userEntity.UserName)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                numberOfUsers = 0;
            }
        }

        // TabPageUserListw

        private void LoadListsData()
        {
            Cursor.Current = Cursors.WaitCursor;

            ListViewLists.Items.Clear();
            ListDao listDao = new ListDao();
            List<ListEntity> lists = listDao.GetAllLists();

            if (lists != null)
            {
                foreach (var list in lists)
                {
                    string isActive;

                    if (list.Status == 1)
                    {
                        isActive = "Sí";
                    }
                    else
                    {
                        isActive = "No";
                    }

                    ListViewItem item = new ListViewItem(list.ListName);
                    item.SubItems.Add(list.UserName);
                    item.SubItems.Add(list.Description);
                    item.SubItems.Add(list.UserNumber);
                    item.SubItems.Add(list.CreationDate);
                    item.SubItems.Add(isActive);
                    ListViewLists.Items.Add(item);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void TxtSearchList_Click(object sender, EventArgs e)
        {
            if (TxtSearchList.Text == "Ingrese el nombre de la lista")
            {
                TxtSearchList.SelectAll();
            }
        }

        private void TxtSearchList_Enter(object sender, EventArgs e)
        {
            TxtSearchList.ForeColor = Color.White;
            SetSearchListPanelsColor(Color.DeepSkyBlue);
        }

        private void TxtSearchList_Leave(object sender, EventArgs e)
        {
            TxtSearchList.ForeColor = Color.DarkGray;
            SetSearchListPanelsColor(Color.FromArgb(50, 50, 50));
        }

        private System.Windows.Forms.Timer searchListTimer;

        private void TxtSearchList_TextChanged(object sender, EventArgs e)
        {
            searchListTimer.Stop();
            searchListTimer.Start();
        }

        private void SearchListTimer_Tick(Object sender, EventArgs e)
        {
            searchListTimer.Stop();

            ListDao listDao = new ListDao();
            string listName = TxtSearchList.Text;
            ListViewLists.Items.Clear();
            List<ListEntity> listEntities = listDao.GetAllLists();

            foreach (var list in listEntities)
            {
                string isActive;

                if (list.Status == 1)
                {
                    isActive = "Sí";
                }
                else
                {
                    isActive = "No";
                }

                if (list.ListName.Contains(listName))
                {
                    if (TxtSearchList.Text != "")
                    {
                        ListViewItem item = new ListViewItem(list.ListName);
                        item.SubItems.Add(list.UserName);
                        item.SubItems.Add(list.Description);
                        item.SubItems.Add(list.UserNumber);
                        item.SubItems.Add(list.CreationDate);
                        item.SubItems.Add(isActive);
                        ListViewLists.Items.Add(item);
                    }
                }
            }

            if (ListViewLists.Items.Count == 0 && TxtSearchList.Text == "")
            {
                LoadListsData();
            }
            else if (ListViewLists.Items.Count == 0 && TxtSearchList.Text != "")
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("No se encontró la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dialog == DialogResult.OK)
                {
                    LoadListsData();
                }
            }
        }

        #endregion
    }
}
