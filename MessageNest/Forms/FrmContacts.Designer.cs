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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlSearchContact = new System.Windows.Forms.Panel();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.PnlSearchtUsrRight = new System.Windows.Forms.Panel();
            this.TxtSearchContact = new System.Windows.Forms.TextBox();
            this.PnlSearchUsrLeft = new System.Windows.Forms.Panel();
            this.PnlSearchUsrDown = new System.Windows.Forms.Panel();
            this.PnlSearchUsrUp = new System.Windows.Forms.Panel();
            this.LblTitleLin = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.PnlContactsContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlSearchContact.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlContactsContent
            // 
            this.PnlContactsContent.Controls.Add(this.listView1);
            this.PnlContactsContent.Controls.Add(this.pictureBox2);
            this.PnlContactsContent.Controls.Add(this.pictureBox1);
            this.PnlContactsContent.Controls.Add(this.pnlSearchContact);
            this.PnlContactsContent.Controls.Add(this.LblTitleLin);
            this.PnlContactsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContactsContent.Location = new System.Drawing.Point(0, 0);
            this.PnlContactsContent.Name = "PnlContactsContent";
            this.PnlContactsContent.Size = new System.Drawing.Size(784, 626);
            this.PnlContactsContent.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MessageNest.Properties.Resources.user_profile;
            this.pictureBox2.Location = new System.Drawing.Point(513, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 37);
            this.pictureBox2.TabIndex = 47;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MessageNest.Properties.Resources.user_profile;
            this.pictureBox1.Location = new System.Drawing.Point(193, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 37);
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // pnlSearchContact
            // 
            this.pnlSearchContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.pnlSearchContact.Controls.Add(this.BtnSearch);
            this.pnlSearchContact.Controls.Add(this.PnlSearchtUsrRight);
            this.pnlSearchContact.Controls.Add(this.TxtSearchContact);
            this.pnlSearchContact.Controls.Add(this.PnlSearchUsrLeft);
            this.pnlSearchContact.Controls.Add(this.PnlSearchUsrDown);
            this.pnlSearchContact.Controls.Add(this.PnlSearchUsrUp);
            this.pnlSearchContact.Location = new System.Drawing.Point(96, 133);
            this.pnlSearchContact.Name = "pnlSearchContact";
            this.pnlSearchContact.Size = new System.Drawing.Size(592, 34);
            this.pnlSearchContact.TabIndex = 44;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnSearch.FlatAppearance.BorderSize = 0;
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearch.Image = global::MessageNest.Properties.Resources.search_icon;
            this.BtnSearch.Location = new System.Drawing.Point(540, 1);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(51, 32);
            this.BtnSearch.TabIndex = 11;
            this.BtnSearch.UseVisualStyleBackColor = true;
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
            this.TxtSearchContact.Text = "Ingrese el usuario a buscar";
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
            this.LblTitleLin.Location = new System.Drawing.Point(305, 49);
            this.LblTitleLin.Name = "LblTitleLin";
            this.LblTitleLin.Size = new System.Drawing.Size(141, 37);
            this.LblTitleLin.TabIndex = 45;
            this.LblTitleLin.Text = "Contactos";
            this.LblTitleLin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(96, 190);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(592, 405);
            this.listView1.TabIndex = 49;
            this.listView1.UseCompatibleStateImageBehavior = false;
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
            this.PnlContactsContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlSearchContact.ResumeLayout(false);
            this.pnlSearchContact.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlContactsContent;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlSearchContact;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Panel PnlSearchtUsrRight;
        private System.Windows.Forms.TextBox TxtSearchContact;
        private System.Windows.Forms.Panel PnlSearchUsrLeft;
        private System.Windows.Forms.Panel PnlSearchUsrDown;
        private System.Windows.Forms.Panel PnlSearchUsrUp;
        private System.Windows.Forms.Label LblTitleLin;
        private System.Windows.Forms.ListView listView1;
    }
}