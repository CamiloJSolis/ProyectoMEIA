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

        public FrmContacts()
        {
            InitializeComponent();

            LoadData();

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
                ListViewItem selectedItem = ListViewUsers.Items[0];
                string userName = selectedItem.Text;
                string contact = TxtNewContactName.Text;


            }
            else
            {

            }
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
                if (user.UserName == TxtSearchContact.Text.Trim())
                {
                    ListViewItem item = new ListViewItem(user.UserName);
                    item.SubItems.Add(user.Name);
                    item.SubItems.Add(user.Surname);
                    ListViewUsers.Items.Add(item);

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
