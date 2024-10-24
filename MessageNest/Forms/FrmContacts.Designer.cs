namespace MessageNest.Forms
{
    partial class FrmContacts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContacts));
            this.PnlContactsContent = new System.Windows.Forms.Panel();
            this.TabCtrlContacts = new System.Windows.Forms.TabControl();
            this.TabPageFindContact = new System.Windows.Forms.TabPage();
            this.PnlEnterNewFirstName = new System.Windows.Forms.Panel();
            this.PnlContactNameRight = new System.Windows.Forms.Panel();
            this.TxtNewContactName = new System.Windows.Forms.TextBox();
            this.PnlContactNameLeft = new System.Windows.Forms.Panel();
            this.PnlContactNameDown = new System.Windows.Forms.Panel();
            this.PnlContactNameUp = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnAddContact = new System.Windows.Forms.Button();
            this.ListViewUsers = new System.Windows.Forms.ListView();
            this.ColUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColNames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColSurnames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlSearchContact = new System.Windows.Forms.Panel();
            this.PnlSearchtUsrRight = new System.Windows.Forms.Panel();
            this.TxtSearchContact = new System.Windows.Forms.TextBox();
            this.PnlSearchUsrLeft = new System.Windows.Forms.Panel();
            this.PnlSearchUsrDown = new System.Windows.Forms.Panel();
            this.PnlSearchUsrUp = new System.Windows.Forms.Panel();
            this.LblTitleLin = new System.Windows.Forms.Label();
            this.TabPageSaveContact = new System.Windows.Forms.TabPage();
            this.PnlContactsContent.SuspendLayout();
            this.TabCtrlContacts.SuspendLayout();
            this.TabPageFindContact.SuspendLayout();
            this.PnlEnterNewFirstName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlSearchContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlContactsContent
            // 
            this.PnlContactsContent.Controls.Add(this.TabCtrlContacts);
            this.PnlContactsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContactsContent.Location = new System.Drawing.Point(0, 0);
            this.PnlContactsContent.Name = "PnlContactsContent";
            this.PnlContactsContent.Size = new System.Drawing.Size(784, 626);
            this.PnlContactsContent.TabIndex = 0;
            // 
            // TabCtrlContacts
            // 
            this.TabCtrlContacts.Controls.Add(this.TabPageFindContact);
            this.TabCtrlContacts.Controls.Add(this.TabPageSaveContact);
            this.TabCtrlContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabCtrlContacts.Font = new System.Drawing.Font("Yu Gothic UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabCtrlContacts.Location = new System.Drawing.Point(0, 0);
            this.TabCtrlContacts.Name = "TabCtrlContacts";
            this.TabCtrlContacts.SelectedIndex = 0;
            this.TabCtrlContacts.Size = new System.Drawing.Size(784, 626);
            this.TabCtrlContacts.TabIndex = 51;
            // 
            // TabPageFindContact
            // 
            this.TabPageFindContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.TabPageFindContact.Controls.Add(this.PnlEnterNewFirstName);
            this.TabPageFindContact.Controls.Add(this.label3);
            this.TabPageFindContact.Controls.Add(this.BtnAddContact);
            this.TabPageFindContact.Controls.Add(this.ListViewUsers);
            this.TabPageFindContact.Controls.Add(this.pictureBox2);
            this.TabPageFindContact.Controls.Add(this.pictureBox1);
            this.TabPageFindContact.Controls.Add(this.pnlSearchContact);
            this.TabPageFindContact.Controls.Add(this.LblTitleLin);
            this.TabPageFindContact.Location = new System.Drawing.Point(4, 22);
            this.TabPageFindContact.Name = "TabPageFindContact";
            this.TabPageFindContact.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageFindContact.Size = new System.Drawing.Size(776, 600);
            this.TabPageFindContact.TabIndex = 0;
            this.TabPageFindContact.Text = "tabPage1";
            // 
            // PnlEnterNewFirstName
            // 
            this.PnlEnterNewFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.PnlEnterNewFirstName.Controls.Add(this.PnlContactNameRight);
            this.PnlEnterNewFirstName.Controls.Add(this.TxtNewContactName);
            this.PnlEnterNewFirstName.Controls.Add(this.PnlContactNameLeft);
            this.PnlEnterNewFirstName.Controls.Add(this.PnlContactNameDown);
            this.PnlEnterNewFirstName.Controls.Add(this.PnlContactNameUp);
            this.PnlEnterNewFirstName.Location = new System.Drawing.Point(261, 456);
            this.PnlEnterNewFirstName.Name = "PnlEnterNewFirstName";
            this.PnlEnterNewFirstName.Size = new System.Drawing.Size(423, 27);
            this.PnlEnterNewFirstName.TabIndex = 57;
            // 
            // PnlContactNameRight
            // 
            this.PnlContactNameRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlContactNameRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlContactNameRight.Location = new System.Drawing.Point(422, 1);
            this.PnlContactNameRight.Name = "PnlContactNameRight";
            this.PnlContactNameRight.Size = new System.Drawing.Size(1, 25);
            this.PnlContactNameRight.TabIndex = 9;
            // 
            // TxtNewContactName
            // 
            this.TxtNewContactName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.TxtNewContactName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNewContactName.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNewContactName.ForeColor = System.Drawing.Color.DarkGray;
            this.TxtNewContactName.Location = new System.Drawing.Point(7, 3);
            this.TxtNewContactName.Name = "TxtNewContactName";
            this.TxtNewContactName.Size = new System.Drawing.Size(413, 22);
            this.TxtNewContactName.TabIndex = 6;
            this.TxtNewContactName.Enter += new System.EventHandler(this.TxtNewContacttName_Enter);
            this.TxtNewContactName.Leave += new System.EventHandler(this.TxtNewContacttName_Leave);
            // 
            // PnlContactNameLeft
            // 
            this.PnlContactNameLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlContactNameLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlContactNameLeft.Location = new System.Drawing.Point(0, 1);
            this.PnlContactNameLeft.Name = "PnlContactNameLeft";
            this.PnlContactNameLeft.Size = new System.Drawing.Size(1, 25);
            this.PnlContactNameLeft.TabIndex = 7;
            // 
            // PnlContactNameDown
            // 
            this.PnlContactNameDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlContactNameDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlContactNameDown.Location = new System.Drawing.Point(0, 26);
            this.PnlContactNameDown.Name = "PnlContactNameDown";
            this.PnlContactNameDown.Size = new System.Drawing.Size(423, 1);
            this.PnlContactNameDown.TabIndex = 10;
            // 
            // PnlContactNameUp
            // 
            this.PnlContactNameUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlContactNameUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlContactNameUp.Location = new System.Drawing.Point(0, 0);
            this.PnlContactNameUp.Name = "PnlContactNameUp";
            this.PnlContactNameUp.Size = new System.Drawing.Size(423, 1);
            this.PnlContactNameUp.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(88, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 21);
            this.label3.TabIndex = 58;
            this.label3.Text = "Nombre de contacto:";
            // 
            // BtnAddContact
            // 
            this.BtnAddContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(191)))), ((int)(((byte)(74)))));
            this.BtnAddContact.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnAddContact.FlatAppearance.BorderSize = 0;
            this.BtnAddContact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(100)))));
            this.BtnAddContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddContact.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.BtnAddContact.Location = new System.Drawing.Point(285, 534);
            this.BtnAddContact.Name = "BtnAddContact";
            this.BtnAddContact.Size = new System.Drawing.Size(206, 30);
            this.BtnAddContact.TabIndex = 56;
            this.BtnAddContact.Text = "Agregar";
            this.BtnAddContact.UseVisualStyleBackColor = false;
            this.BtnAddContact.Click += new System.EventHandler(this.BtnAddContact_Click);
            // 
            // ListViewUsers
            // 
            this.ListViewUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.ListViewUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColUserName,
            this.ColNames,
            this.ColSurnames});
            this.ListViewUsers.ForeColor = System.Drawing.Color.White;
            this.ListViewUsers.FullRowSelect = true;
            this.ListViewUsers.HideSelection = false;
            this.ListViewUsers.Location = new System.Drawing.Point(92, 184);
            this.ListViewUsers.Name = "ListViewUsers";
            this.ListViewUsers.Size = new System.Drawing.Size(592, 238);
            this.ListViewUsers.TabIndex = 55;
            this.ListViewUsers.UseCompatibleStateImageBehavior = false;
            this.ListViewUsers.View = System.Windows.Forms.View.Details;
            this.ListViewUsers.SelectedIndexChanged += new System.EventHandler(this.ListViewUsers_SelectedIndexChanged);
            // 
            // ColUserName
            // 
            this.ColUserName.Text = "Usuario";
            this.ColUserName.Width = 197;
            // 
            // ColNames
            // 
            this.ColNames.Text = "Nombres";
            this.ColNames.Width = 196;
            // 
            // ColSurnames
            // 
            this.ColSurnames.Text = "Apellidos";
            this.ColSurnames.Width = 196;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MessageNest.Properties.Resources.user_profile;
            this.pictureBox2.Location = new System.Drawing.Point(527, 39);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 37);
            this.pictureBox2.TabIndex = 54;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MessageNest.Properties.Resources.user_profile;
            this.pictureBox1.Location = new System.Drawing.Point(189, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 37);
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // pnlSearchContact
            // 
            this.pnlSearchContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.pnlSearchContact.Controls.Add(this.PnlSearchtUsrRight);
            this.pnlSearchContact.Controls.Add(this.TxtSearchContact);
            this.pnlSearchContact.Controls.Add(this.PnlSearchUsrLeft);
            this.pnlSearchContact.Controls.Add(this.PnlSearchUsrDown);
            this.pnlSearchContact.Controls.Add(this.PnlSearchUsrUp);
            this.pnlSearchContact.Location = new System.Drawing.Point(92, 114);
            this.pnlSearchContact.Name = "pnlSearchContact";
            this.pnlSearchContact.Size = new System.Drawing.Size(592, 34);
            this.pnlSearchContact.TabIndex = 51;
            // 
            // PnlSearchtUsrRight
            // 
            this.PnlSearchtUsrRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlSearchtUsrRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlSearchtUsrRight.Location = new System.Drawing.Point(591, 1);
            this.PnlSearchtUsrRight.Name = "PnlSearchtUsrRight";
            this.PnlSearchtUsrRight.Size = new System.Drawing.Size(1, 32);
            this.PnlSearchtUsrRight.TabIndex = 9;
            // 
            // TxtSearchContact
            // 
            this.TxtSearchContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.TxtSearchContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtSearchContact.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearchContact.ForeColor = System.Drawing.Color.DarkGray;
            this.TxtSearchContact.Location = new System.Drawing.Point(6, 6);
            this.TxtSearchContact.Name = "TxtSearchContact";
            this.TxtSearchContact.Size = new System.Drawing.Size(581, 22);
            this.TxtSearchContact.TabIndex = 6;
            this.TxtSearchContact.Text = "Ingrese el usuario, nombres o apellidos a buscar";
            this.TxtSearchContact.Click += new System.EventHandler(this.TxtSearchContact_Click);
            this.TxtSearchContact.TextChanged += new System.EventHandler(this.TxtSearchContact_TextChanged);
            this.TxtSearchContact.Enter += new System.EventHandler(this.TxtSearchContact_Enter);
            this.TxtSearchContact.Leave += new System.EventHandler(this.TxtSearchContact_Leave);
            // 
            // PnlSearchUsrLeft
            // 
            this.PnlSearchUsrLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlSearchUsrLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlSearchUsrLeft.Location = new System.Drawing.Point(0, 1);
            this.PnlSearchUsrLeft.Name = "PnlSearchUsrLeft";
            this.PnlSearchUsrLeft.Size = new System.Drawing.Size(1, 32);
            this.PnlSearchUsrLeft.TabIndex = 7;
            // 
            // PnlSearchUsrDown
            // 
            this.PnlSearchUsrDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlSearchUsrDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlSearchUsrDown.Location = new System.Drawing.Point(0, 33);
            this.PnlSearchUsrDown.Name = "PnlSearchUsrDown";
            this.PnlSearchUsrDown.Size = new System.Drawing.Size(592, 1);
            this.PnlSearchUsrDown.TabIndex = 10;
            // 
            // PnlSearchUsrUp
            // 
            this.PnlSearchUsrUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlSearchUsrUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlSearchUsrUp.Location = new System.Drawing.Point(0, 0);
            this.PnlSearchUsrUp.Name = "PnlSearchUsrUp";
            this.PnlSearchUsrUp.Size = new System.Drawing.Size(592, 1);
            this.PnlSearchUsrUp.TabIndex = 8;
            // 
            // LblTitleLin
            // 
            this.LblTitleLin.AutoSize = true;
            this.LblTitleLin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.LblTitleLin.Font = new System.Drawing.Font("Yu Gothic UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitleLin.ForeColor = System.Drawing.Color.White;
            this.LblTitleLin.Location = new System.Drawing.Point(260, 39);
            this.LblTitleLin.Name = "LblTitleLin";
            this.LblTitleLin.Size = new System.Drawing.Size(246, 37);
            this.LblTitleLin.TabIndex = 52;
            this.LblTitleLin.Text = "Agregar Contactos";
            this.LblTitleLin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TabPageSaveContact
            // 
            this.TabPageSaveContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.TabPageSaveContact.Location = new System.Drawing.Point(4, 22);
            this.TabPageSaveContact.Name = "TabPageSaveContact";
            this.TabPageSaveContact.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageSaveContact.Size = new System.Drawing.Size(776, 600);
            this.TabPageSaveContact.TabIndex = 1;
            this.TabPageSaveContact.Text = "Buscar contacto";
            // 
            // FrmContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(784, 626);
            this.Controls.Add(this.PnlContactsContent);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmContacts";
            this.Text = "FrmContacts";
            this.PnlContactsContent.ResumeLayout(false);
            this.TabCtrlContacts.ResumeLayout(false);
            this.TabPageFindContact.ResumeLayout(false);
            this.TabPageFindContact.PerformLayout();
            this.PnlEnterNewFirstName.ResumeLayout(false);
            this.PnlEnterNewFirstName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlSearchContact.ResumeLayout(false);
            this.pnlSearchContact.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlContactsContent;
        private System.Windows.Forms.TabControl TabCtrlContacts;
        private System.Windows.Forms.TabPage TabPageFindContact;
        private System.Windows.Forms.Button BtnAddContact;
        private System.Windows.Forms.ListView ListViewUsers;
        private System.Windows.Forms.ColumnHeader ColUserName;
        private System.Windows.Forms.ColumnHeader ColNames;
        private System.Windows.Forms.ColumnHeader ColSurnames;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlSearchContact;
        private System.Windows.Forms.Panel PnlSearchtUsrRight;
        private System.Windows.Forms.TextBox TxtSearchContact;
        private System.Windows.Forms.Panel PnlSearchUsrLeft;
        private System.Windows.Forms.Panel PnlSearchUsrDown;
        private System.Windows.Forms.Panel PnlSearchUsrUp;
        private System.Windows.Forms.Label LblTitleLin;
        private System.Windows.Forms.TabPage TabPageSaveContact;
        private System.Windows.Forms.Panel PnlEnterNewFirstName;
        private System.Windows.Forms.Panel PnlContactNameRight;
        private System.Windows.Forms.TextBox TxtNewContactName;
        private System.Windows.Forms.Panel PnlContactNameLeft;
        private System.Windows.Forms.Panel PnlContactNameDown;
        private System.Windows.Forms.Panel PnlContactNameUp;
        private System.Windows.Forms.Label label3;
    }
}