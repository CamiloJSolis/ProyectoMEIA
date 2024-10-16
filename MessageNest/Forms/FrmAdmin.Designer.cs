namespace MessageNest.Forms
{
    partial class FrmAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmin));
            this.PnlTopAdmin = new System.Windows.Forms.Panel();
            this.PbTitle = new System.Windows.Forms.PictureBox();
            this.BtnCloseAdmin = new System.Windows.Forms.Button();
            this.BtnBackup = new System.Windows.Forms.Button();
            this.BtnModifyAdmin = new System.Windows.Forms.Button();
            this.PnlChildForm = new System.Windows.Forms.Panel();
            this.BtnAddUsr = new System.Windows.Forms.Button();
            this.BtnSrchUsr = new System.Windows.Forms.Button();
            this.FwlPnlButton = new System.Windows.Forms.FlowLayoutPanel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.BtnAdminInfo = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.BtnLogOut = new System.Windows.Forms.Button();
            this.PnlTopAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbTitle)).BeginInit();
            this.FwlPnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTopAdmin
            // 
            this.PnlTopAdmin.Controls.Add(this.PbTitle);
            this.PnlTopAdmin.Controls.Add(this.BtnCloseAdmin);
            this.PnlTopAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTopAdmin.Location = new System.Drawing.Point(0, 0);
            this.PnlTopAdmin.Name = "PnlTopAdmin";
            this.PnlTopAdmin.Size = new System.Drawing.Size(1038, 32);
            this.PnlTopAdmin.TabIndex = 2;
            this.PnlTopAdmin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTopAdmin_MouseDown);
            // 
            // PbTitle
            // 
            this.PbTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.PbTitle.Image = global::MessageNest.Properties.Resources.otraPropuestadeLogo;
            this.PbTitle.Location = new System.Drawing.Point(0, 0);
            this.PbTitle.Name = "PbTitle";
            this.PbTitle.Size = new System.Drawing.Size(260, 32);
            this.PbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PbTitle.TabIndex = 45;
            this.PbTitle.TabStop = false;
            // 
            // BtnCloseAdmin
            // 
            this.BtnCloseAdmin.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCloseAdmin.FlatAppearance.BorderSize = 0;
            this.BtnCloseAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCloseAdmin.Image = global::MessageNest.Properties.Resources.close_button;
            this.BtnCloseAdmin.Location = new System.Drawing.Point(988, 0);
            this.BtnCloseAdmin.Name = "BtnCloseAdmin";
            this.BtnCloseAdmin.Size = new System.Drawing.Size(50, 32);
            this.BtnCloseAdmin.TabIndex = 0;
            this.BtnCloseAdmin.UseVisualStyleBackColor = true;
            this.BtnCloseAdmin.Click += new System.EventHandler(this.BtnCloseAdmin_Click);
            this.BtnCloseAdmin.MouseLeave += new System.EventHandler(this.BtnCloseAdmin_MouseLeave);
            this.BtnCloseAdmin.MouseHover += new System.EventHandler(this.BtnCloseAdmin_MouseHover);
            // 
            // BtnBackup
            // 
            this.BtnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnBackup.FlatAppearance.BorderSize = 0;
            this.BtnBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(100)))));
            this.BtnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBackup.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.BtnBackup.Image = global::MessageNest.Properties.Resources.backup;
            this.BtnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBackup.Location = new System.Drawing.Point(7, 3);
            this.BtnBackup.Name = "BtnBackup";
            this.BtnBackup.Size = new System.Drawing.Size(236, 39);
            this.BtnBackup.TabIndex = 3;
            this.BtnBackup.Text = "Respaldo";
            this.BtnBackup.UseVisualStyleBackColor = false;
            this.BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // BtnModifyAdmin
            // 
            this.BtnModifyAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnModifyAdmin.FlatAppearance.BorderSize = 0;
            this.BtnModifyAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(100)))));
            this.BtnModifyAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnModifyAdmin.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModifyAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.BtnModifyAdmin.Image = global::MessageNest.Properties.Resources.editUsr;
            this.BtnModifyAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnModifyAdmin.Location = new System.Drawing.Point(7, 0);
            this.BtnModifyAdmin.Name = "BtnModifyAdmin";
            this.BtnModifyAdmin.Size = new System.Drawing.Size(236, 39);
            this.BtnModifyAdmin.TabIndex = 0;
            this.BtnModifyAdmin.Text = "Modificar Datos";
            this.BtnModifyAdmin.UseVisualStyleBackColor = false;
            this.BtnModifyAdmin.Click += new System.EventHandler(this.BtnModifyAdmin_Click);
            // 
            // PnlChildForm
            // 
            this.PnlChildForm.AutoScroll = true;
            this.PnlChildForm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PnlChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlChildForm.Location = new System.Drawing.Point(254, 32);
            this.PnlChildForm.Name = "PnlChildForm";
            this.PnlChildForm.Size = new System.Drawing.Size(784, 626);
            this.PnlChildForm.TabIndex = 4;
            // 
            // BtnAddUsr
            // 
            this.BtnAddUsr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnAddUsr.FlatAppearance.BorderSize = 0;
            this.BtnAddUsr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(100)))));
            this.BtnAddUsr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddUsr.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddUsr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.BtnAddUsr.Image = global::MessageNest.Properties.Resources.addUser;
            this.BtnAddUsr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAddUsr.Location = new System.Drawing.Point(7, 3);
            this.BtnAddUsr.Name = "BtnAddUsr";
            this.BtnAddUsr.Size = new System.Drawing.Size(236, 39);
            this.BtnAddUsr.TabIndex = 1;
            this.BtnAddUsr.Text = "Agregar usuario";
            this.BtnAddUsr.UseVisualStyleBackColor = false;
            this.BtnAddUsr.Click += new System.EventHandler(this.BtnAddUsr_Click);
            // 
            // BtnSrchUsr
            // 
            this.BtnSrchUsr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnSrchUsr.FlatAppearance.BorderSize = 0;
            this.BtnSrchUsr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(100)))));
            this.BtnSrchUsr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSrchUsr.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSrchUsr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.BtnSrchUsr.Image = global::MessageNest.Properties.Resources.searchUser;
            this.BtnSrchUsr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSrchUsr.Location = new System.Drawing.Point(7, 3);
            this.BtnSrchUsr.Name = "BtnSrchUsr";
            this.BtnSrchUsr.Size = new System.Drawing.Size(236, 39);
            this.BtnSrchUsr.TabIndex = 2;
            this.BtnSrchUsr.Text = "Buscar Usuario";
            this.BtnSrchUsr.UseVisualStyleBackColor = false;
            this.BtnSrchUsr.Click += new System.EventHandler(this.BtnSrchUsr_Click);
            // 
            // FwlPnlButton
            // 
            this.FwlPnlButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FwlPnlButton.Controls.Add(this.panel13);
            this.FwlPnlButton.Controls.Add(this.PbLogo);
            this.FwlPnlButton.Controls.Add(this.panel1);
            this.FwlPnlButton.Controls.Add(this.panel10);
            this.FwlPnlButton.Controls.Add(this.panel9);
            this.FwlPnlButton.Controls.Add(this.panel2);
            this.FwlPnlButton.Controls.Add(this.panel3);
            this.FwlPnlButton.Controls.Add(this.panel4);
            this.FwlPnlButton.Controls.Add(this.panel5);
            this.FwlPnlButton.Controls.Add(this.panel6);
            this.FwlPnlButton.Controls.Add(this.panel7);
            this.FwlPnlButton.Controls.Add(this.panel8);
            this.FwlPnlButton.Controls.Add(this.panel14);
            this.FwlPnlButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.FwlPnlButton.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FwlPnlButton.Location = new System.Drawing.Point(0, 32);
            this.FwlPnlButton.Name = "FwlPnlButton";
            this.FwlPnlButton.Size = new System.Drawing.Size(254, 626);
            this.FwlPnlButton.TabIndex = 5;
            // 
            // panel13
            // 
            this.panel13.Location = new System.Drawing.Point(3, 3);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(251, 23);
            this.panel13.TabIndex = 46;
            // 
            // PbLogo
            // 
            this.PbLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PbLogo.Image = global::MessageNest.Properties.Resources.appLogo;
            this.PbLogo.Location = new System.Drawing.Point(64, 32);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(129, 102);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbLogo.TabIndex = 45;
            this.PbLogo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 45);
            this.panel1.TabIndex = 45;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.BtnAdminInfo);
            this.panel10.Location = new System.Drawing.Point(3, 191);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(251, 45);
            this.panel10.TabIndex = 51;
            // 
            // BtnAdminInfo
            // 
            this.BtnAdminInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnAdminInfo.FlatAppearance.BorderSize = 0;
            this.BtnAdminInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(100)))));
            this.BtnAdminInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdminInfo.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdminInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.BtnAdminInfo.Image = global::MessageNest.Properties.Resources.userInfo;
            this.BtnAdminInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAdminInfo.Location = new System.Drawing.Point(7, 3);
            this.BtnAdminInfo.Name = "BtnAdminInfo";
            this.BtnAdminInfo.Size = new System.Drawing.Size(236, 39);
            this.BtnAdminInfo.TabIndex = 2;
            this.BtnAdminInfo.Text = "Información";
            this.BtnAdminInfo.UseVisualStyleBackColor = false;
            this.BtnAdminInfo.Click += new System.EventHandler(this.BtnAdminInfo_Click);
            // 
            // panel9
            // 
            this.panel9.Location = new System.Drawing.Point(3, 242);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(251, 10);
            this.panel9.TabIndex = 53;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnModifyAdmin);
            this.panel2.Location = new System.Drawing.Point(3, 258);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 45);
            this.panel2.TabIndex = 46;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(3, 309);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(251, 10);
            this.panel3.TabIndex = 47;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BtnAddUsr);
            this.panel4.Location = new System.Drawing.Point(3, 325);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(251, 45);
            this.panel4.TabIndex = 48;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(3, 376);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(251, 10);
            this.panel5.TabIndex = 49;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.BtnSrchUsr);
            this.panel6.Location = new System.Drawing.Point(3, 392);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(251, 45);
            this.panel6.TabIndex = 50;
            // 
            // panel7
            // 
            this.panel7.Location = new System.Drawing.Point(3, 443);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(251, 10);
            this.panel7.TabIndex = 51;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.BtnBackup);
            this.panel8.Location = new System.Drawing.Point(3, 459);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(251, 45);
            this.panel8.TabIndex = 52;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.BtnLogOut);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(3, 510);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(251, 113);
            this.panel14.TabIndex = 53;
            // 
            // BtnLogOut
            // 
            this.BtnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BtnLogOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnLogOut.FlatAppearance.BorderSize = 0;
            this.BtnLogOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(100)))));
            this.BtnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogOut.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.BtnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("BtnLogOut.Image")));
            this.BtnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogOut.Location = new System.Drawing.Point(0, 74);
            this.BtnLogOut.Name = "BtnLogOut";
            this.BtnLogOut.Size = new System.Drawing.Size(251, 39);
            this.BtnLogOut.TabIndex = 4;
            this.BtnLogOut.Text = "Cerrar Sesión";
            this.BtnLogOut.UseVisualStyleBackColor = false;
            this.BtnLogOut.Click += new System.EventHandler(this.BtnLogOut_Click);
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1038, 658);
            this.Controls.Add(this.PnlChildForm);
            this.Controls.Add(this.FwlPnlButton);
            this.Controls.Add(this.PnlTopAdmin);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAdmin";
            this.PnlTopAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbTitle)).EndInit();
            this.FwlPnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlTopAdmin;
        private System.Windows.Forms.Button BtnCloseAdmin;
        private System.Windows.Forms.Button BtnModifyAdmin;
        private System.Windows.Forms.Panel PnlChildForm;
        private System.Windows.Forms.Button BtnBackup;
        private System.Windows.Forms.FlowLayoutPanel FwlPnlButton;
        private System.Windows.Forms.Button BtnSrchUsr;
        private System.Windows.Forms.Button BtnAddUsr;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox PbTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button BtnLogOut;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button BtnAdminInfo;
    }
}