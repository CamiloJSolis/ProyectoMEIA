﻿using MessageNest.Dao;
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
    public partial class FrmContacts : Form
    {
        private ContactEntity _contact;
        private string _currentUser;
        private string _selectedUser;

        public FrmContacts(UserEntity user)
        {
            InitializeComponent();

            LoadUsersData();
            LoadContactsData();

            _currentUser = user.UserName;

            // Obtener los usuarios

            searchUserTimer = new System.Windows.Forms.Timer();
            searchUserTimer.Interval = 1000;
            searchUserTimer.Tick += SearchUserTimer_Tick;

            TxtSearchUser.TextChanged += TxtSearchUser_TextChanged;
            ListViewUsers.SelectedIndexChanged += ListViewUsers_SelectedIndexChanged;

            // Obtener los contactos

            searchUserTimer = new System.Windows.Forms.Timer();
            searchUserTimer.Interval = 1000;
            searchUserTimer.Tick += SearchUserTimer_Tick;


        }

        #region Cambiar Color

        private void SetSearchUserPanelsColor(Color color)
        {
            PnlSearchUsrLeft.BackColor = color;
            PnlSearchtUsrRight.BackColor = color;
            PnlSearchUsrUp.BackColor = color;
            PnlSearchUsrDown.BackColor = color;
        }

        private void SetNewContactPanlesColor(Color color)
        {
            PnlContactNameLeft.BackColor = color;
            PnlContactNameRight.BackColor = color;
            PnlContactNameUp.BackColor = color;
            PnlContactNameDown.BackColor = color;
        }

        private void SetSearchContactPanlesColor(Color color)
        {
            PnlContactNameLeft.BackColor = color;
            PnlContactNameRight.BackColor = color;
            PnlContactNameUp.BackColor = color;
            PnlSearchContactDown.BackColor = color;
        }

        #endregion

        #region Botones

        // TabPageUserContacts

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TabPageUserContacts.Hide();
            TabPageAddContact.Show();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            TabPageUserContacts.Hide();
            TabPageEditContact.Show();
        }

        // TabPageAddContact

        private void BtnAddContact_Click(object sender, EventArgs e)
        {

            if (ListViewUsers.Items.Count > 0)
            {
                ContactEntity contact = new ContactEntity();
                ContactDao contactDao = new ContactDao();
                DateTime currentDate = DateTime.Now;

                contact.User = PadRight(_selectedUser, 20);
                contact.Contact = PadRight(TxtNewContactName.Text, 20);
                contact.TransactionDate = PadRight(currentDate.ToString("dd/MM/yyyy"), 10);
                contact.UserTransaction = PadRight(_currentUser, 20);
                contact.Status = 1;

                if (contactDao.AgregarContacto(contact))
                {
                    TxtSearchUser.Text = "Ingrese el usuario, nombres o apellidos a buscar";
                    TxtNewContactName.Clear();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al agregar los al archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #endregion

        #region Funciones

        private void LoadUsersData()
        {
            Cursor.Current = Cursors.WaitCursor;

            UserDao userDao = new UserDao();
            List<UserEntity> users = userDao.GetAllUsers();

            foreach (var user in users)
            {
                ListViewItem item = new ListViewItem(user.UserName);
                item.SubItems.Add(user.Name);
                item.SubItems.Add(user.Surname);
                ListViewUsers.Items.Add(item);
            }
            Cursor.Current = Cursors.Default;
        }

        // TabPageAddContact

        private void TxtSearchUser_Click(object sender, EventArgs e)
        {
            if (TxtSearchUser.Text == "Ingrese el usuario, nombres o apellidos a buscar")
            {
                TxtSearchUser.SelectAll();
            }
        }

        private void TxtSearchUser_Enter(object sender, EventArgs e)
        {
            TxtSearchUser.ForeColor = Color.White;
            SetSearchUserPanelsColor(Color.DeepSkyBlue);
        }

        private void TxtSearchUser_Leave(object sender, EventArgs e)
        {
            TxtSearchUser.ForeColor = Color.DarkGray;
            SetSearchUserPanelsColor(Color.FromArgb(50, 50, 50));
        }

        private void TxtNewContacttName_Enter(object sender, EventArgs e)
        {
            TxtNewContactName.ForeColor = Color.White;
            SetNewContactPanlesColor(Color.DeepSkyBlue);
        }

        private void TxtNewContacttName_Leave(object sender, EventArgs e)
        {
            TxtNewContactName.ForeColor = Color.DarkGray;
            SetNewContactPanlesColor(Color.FromArgb(50, 50, 50));
        }

        private System.Windows.Forms.Timer searchUserTimer;

        private void TxtSearchUser_TextChanged(object sender, EventArgs e)
        {
            searchUserTimer.Stop();
            searchUserTimer.Start();
        }

        private void SearchUserTimer_Tick(object sender, EventArgs e)
        {
            searchUserTimer.Stop();

            UserDao userDao = new UserDao();

            string userName = TxtSearchUser.Text;
            ListViewUsers.Items.Clear();
            List<UserEntity> users = userDao.GetAllUsers();

            foreach (var user in users)
            {
                string[] names = user.Name.Split(' ');
                string firstName = names[0];
                string secondName = "";

                if (names.Length > 1)
                {
                    secondName = names[1];
                }

                string[] surnames = user.Surname.Split(' ');
                string firstSurname = surnames[0];
                string secondSurname = "";

                if (surnames.Length > 1)
                {
                    secondSurname = surnames[1];
                }

                if (user.UserName == TxtSearchUser.Text.Trim() || firstName == TxtSearchUser.Text.Trim() || secondName == TxtSearchUser.Text.Trim()
                    || firstSurname == TxtSearchUser.Text.Trim() || secondSurname == TxtSearchUser.Text.Trim())
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
                TxtNewContactName.Clear();
            }
            else if (ListViewUsers.Items.Count == 0)
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
                ListViewItem selectedItem = ListViewUsers.SelectedItems[0];
                _selectedUser = selectedItem.Text;
                TxtNewContactName.Text = selectedItem.SubItems[1].Text.Replace(" ", "");
            }
            else
            {
                _selectedUser = null;
                TxtNewContactName.Clear();
            }
        }

        // TabPageUserContacts

        private void LoadContactsData()
        {
            Cursor.Current = Cursors.WaitCursor;

            ContactDao contactDao = new ContactDao();
            List<ContactEntity> contacts = contactDao.GetAllContacts();

            foreach (var contact in contacts)
            {
                string isActive;

                if (contact.Status == 1)
                {
                    isActive = "Activo";
                }
                else
                {
                    isActive = "Inactivo";
                }

                ListViewItem item = new ListViewItem(contact.Contact);
                item.SubItems.Add(contact.User);
                item.SubItems.Add(isActive);
                ListViewContacts.Items.Add(item);
            }
            Cursor.Current = Cursors.Default;
        }

        private void TxtSearchContact_Click(object sender, EventArgs e)
        {
            if (TxtSearchContact.Text == "Ingrese el contacto a buscar")
            {
                TxtSearchContact.SelectAll();
            }
        }

        private void TxtSearchContact_Enter(object sender, EventArgs e)
        {
            TxtSearchContact.ForeColor = Color.White;
            SetSearchContactPanlesColor(Color.DeepSkyBlue);
        }

        private void TxtSearchContact_Leave(object sender, EventArgs e)
        {
            TxtSearchContact.ForeColor = Color.DarkGray;
            SetSearchContactPanlesColor(Color.FromArgb(50, 50, 50));
        }

        private System.Windows.Forms.Timer searchContactTimer;

        private void TxtSearchContact_TextChanged(object sender, EventArgs e)
        {
            searchContactTimer.Stop();
            searchContactTimer.Start();
        }

        private void SearcContactTimer_Tick (object sender, EventArgs e)
        {
            searchContactTimer.Start();

            ContactDao contactDao = new ContactDao();
            string contactName = TxtSearchContact.Text;
            ListViewContacts.Items.Clear();
            List<ContactEntity> contacts = contactDao.GetAllContacts();

            foreach (var contact in contacts)
            {
                string isActive;

                if(contact.Status == 1)
                {
                    isActive = "Activo";
                }
                else
                {
                    isActive = "Inactivo";
                }

                if (contact.Contact == TxtSearchContact.Text)
                {
                    if (TxtSearchContact.Text != "")
                    {
                        ListViewItem item = new ListViewItem(contact.Contact);
                        item.SubItems.Add(contact.User);
                        item.SubItems.Add(isActive);
                        ListViewContacts.Items.Add(item);
                    }
                }
            }

            if (ListViewContacts.Items.Count == 0 && TxtSearchContact.Text == "")
            {

            }
        }

        #endregion
    }
}
