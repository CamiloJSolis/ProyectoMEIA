using MessageNest.Dao;
using MessageNest.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MessageNest.Forms
{
    public partial class FrmContacts : Form
    {
        private ContactEntity _contact;
        private string _currentUser;

        public FrmContacts(UserEntity user)
        {
            InitializeComponent();

            LoadData();

            _currentUser = user.UserName;

            searchTimer = new System.Windows.Forms.Timer();
            searchTimer.Interval = 1000;
            searchTimer.Tick += SearchTimer_Tick;

            TxtSearchContact.TextChanged += TxtSearchContact_TextChanged;
            ListViewUsers.SelectedIndexChanged += ListViewUsers_SelectedIndexChanged;
        }

        #region Cambiar Color

        private void SetSearchContactPanelsColor(Color color)
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

        #endregion

        #region Botones

        private void BtnAddContact_Click(object sender, EventArgs e)
        {

            if (ListViewUsers.Items.Count > 0)
            {
                ContactEntity contact = new ContactEntity();
                ContactDao contactDao = new ContactDao();
                ListViewItem selectedItem = ListViewUsers.Items[0];
                DateTime currentDate = DateTime.Now;

                contact.User = PadRight(selectedItem.Text, 20);
                contact.Contact = PadRight(TxtNewContactName.Text, 20);
                contact.TransactionDate = PadRight(currentDate.ToString("dd/MM/yyyy"), 10);
                contact.UserTransaction = PadRight(_currentUser, 20);
                contact.Status = 1;

                if (contactDao.AgregarContacto(contact))
                {
                    TxtSearchContact.Text = "Ingrese el usuario, nombres o apellidos a buscar";
                    TxtNewContactName.Clear();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al agregar los al archivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

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

        private void LoadData()
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

        private void TxtSearchContact_Enter(object sender, EventArgs e)
        {
            TxtSearchContact.ForeColor = Color.White;
            SetSearchContactPanelsColor(Color.DeepSkyBlue);
        }

        private void TxtSearchContact_Leave(object sender, EventArgs e)
        {
            TxtSearchContact.ForeColor = Color.DarkGray;
            SetSearchContactPanelsColor(Color.FromArgb(50, 50, 50));
        }

        private void TxtSearchContact_Click(object sender, EventArgs e)
        {
            if (TxtSearchContact.Text == "Ingrese el usuario, nombres o apellidos a buscar")
            {
                TxtSearchContact.SelectAll();
            }
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

        private System.Windows.Forms.Timer searchTimer;

        private void TxtSearchContact_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();

            UserDao userDao = new UserDao();

            string userName = TxtSearchContact.Text;
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

                if (user.UserName == TxtSearchContact.Text.Trim() || firstName == TxtSearchContact.Text.Trim() || secondName == TxtSearchContact.Text.Trim()
                    || firstSurname == TxtSearchContact.Text.Trim() || secondSurname == TxtSearchContact.Text.Trim())
                {
                    if (TxtSearchContact.Text != "")
                    {
                        ListViewItem item = new ListViewItem(user.UserName);
                        item.SubItems.Add(user.Name);
                        item.SubItems.Add(user.Surname);
                        ListViewUsers.Items.Add(item);
                    }
                }
            }

            if (ListViewUsers.Items.Count == 0 && TxtSearchContact.Text == "")
            {
                LoadData();
                TxtNewContactName.Clear();
            }
            else if (ListViewUsers.Items.Count == 0)
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("No se encontró el usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (dialog == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void ListViewUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewUsers.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = ListViewUsers.SelectedItems[0];
                TxtNewContactName.Text = selectedItem.SubItems[1].Text.Replace(" ", "");
            }
            else
            {
                TxtNewContactName.Clear();
            }
        }

        #endregion
    }
}
