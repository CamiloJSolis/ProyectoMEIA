namespace MessageNest
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.PnlTop = new System.Windows.Forms.Panel();
            this.BtnCloseLogin = new System.Windows.Forms.Button();
            this.LblTitleLin = new System.Windows.Forms.Label();
            this.PbUserLin = new System.Windows.Forms.PictureBox();
            this.LblUserLin = new System.Windows.Forms.Label();
            this.pnlEnterUsr = new System.Windows.Forms.Panel();
            this.PnlInsertUsrRight = new System.Windows.Forms.Panel();
            this.TxtUsr = new System.Windows.Forms.TextBox();
            this.PnlInsertUsrLeft = new System.Windows.Forms.Panel();
            this.PnlInsertUsrDown = new System.Windows.Forms.Panel();
            this.PnlInsertUsrUp = new System.Windows.Forms.Panel();
            this.PnlLogin = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LnkLblSignUp = new System.Windows.Forms.LinkLabel();
            this.LblNoUsrPwd = new System.Windows.Forms.Label();
            this.BtnSingIn = new System.Windows.Forms.Button();
            this.PnlPwd = new System.Windows.Forms.Panel();
            this.LblWrongPwd = new System.Windows.Forms.Label();
            this.PnlEnterPwd = new System.Windows.Forms.Panel();
            this.BtnShowHide = new System.Windows.Forms.Button();
            this.TxtPwd = new System.Windows.Forms.TextBox();
            this.PnlInsertPwdRight = new System.Windows.Forms.Panel();
            this.PnlInsertPwdLeft = new System.Windows.Forms.Panel();
            this.PnlInsertPwdUp = new System.Windows.Forms.Panel();
            this.PnlInsertPwdDown = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.PbPwd = new System.Windows.Forms.PictureBox();
            this.PnlUsr = new System.Windows.Forms.Panel();
            this.LblWrongUsr = new System.Windows.Forms.Label();
            this.LblWrongUsrPwd = new System.Windows.Forms.Label();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbUserLin)).BeginInit();
            this.pnlEnterUsr.SuspendLayout();
            this.PnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PnlPwd.SuspendLayout();
            this.PnlEnterPwd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbPwd)).BeginInit();
            this.PnlUsr.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnCloseLogin);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(467, 32);
            this.PnlTop.TabIndex = 0;
            this.PnlTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTop_MouseDown);
            // 
            // BtnCloseLogin
            // 
            this.BtnCloseLogin.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCloseLogin.FlatAppearance.BorderSize = 0;
            this.BtnCloseLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCloseLogin.Image = global::MessageNest.Properties.Resources.close_button;
            this.BtnCloseLogin.Location = new System.Drawing.Point(417, 0);
            this.BtnCloseLogin.Name = "BtnCloseLogin";
            this.BtnCloseLogin.Size = new System.Drawing.Size(50, 32);
            this.BtnCloseLogin.TabIndex = 0;
            this.BtnCloseLogin.UseVisualStyleBackColor = true;
            this.BtnCloseLogin.Click += new System.EventHandler(this.BtnCloseLogin_Click);
            this.BtnCloseLogin.MouseLeave += new System.EventHandler(this.BtnCloseLogin_MouseLeave);
            this.BtnCloseLogin.MouseHover += new System.EventHandler(this.BtnCloseLogin_MouseHover);
            // 
            // LblTitleLin
            // 
            this.LblTitleLin.AutoSize = true;
            this.LblTitleLin.Font = new System.Drawing.Font("Yu Gothic UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitleLin.ForeColor = System.Drawing.Color.White;
            this.LblTitleLin.Location = new System.Drawing.Point(150, 213);
            this.LblTitleLin.Name = "LblTitleLin";
            this.LblTitleLin.Size = new System.Drawing.Size(176, 37);
            this.LblTitleLin.TabIndex = 0;
            this.LblTitleLin.Text = "Iniciar sesión";
            this.LblTitleLin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PbUserLin
            // 
            this.PbUserLin.Image = global::MessageNest.Properties.Resources.user;
            this.PbUserLin.Location = new System.Drawing.Point(20, 274);
            this.PbUserLin.Name = "PbUserLin";
            this.PbUserLin.Size = new System.Drawing.Size(40, 40);
            this.PbUserLin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbUserLin.TabIndex = 1;
            this.PbUserLin.TabStop = false;
            // 
            // LblUserLin
            // 
            this.LblUserLin.AutoSize = true;
            this.LblUserLin.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUserLin.ForeColor = System.Drawing.Color.White;
            this.LblUserLin.Location = new System.Drawing.Point(66, 285);
            this.LblUserLin.Name = "LblUserLin";
            this.LblUserLin.Size = new System.Drawing.Size(65, 21);
            this.LblUserLin.TabIndex = 2;
            this.LblUserLin.Text = "Usuario";
            // 
            // pnlEnterUsr
            // 
            this.pnlEnterUsr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(60)))));
            this.pnlEnterUsr.Controls.Add(this.PnlInsertUsrRight);
            this.pnlEnterUsr.Controls.Add(this.TxtUsr);
            this.pnlEnterUsr.Controls.Add(this.PnlInsertUsrLeft);
            this.pnlEnterUsr.Controls.Add(this.PnlInsertUsrDown);
            this.pnlEnterUsr.Controls.Add(this.PnlInsertUsrUp);
            this.pnlEnterUsr.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEnterUsr.Location = new System.Drawing.Point(0, 0);
            this.pnlEnterUsr.Name = "pnlEnterUsr";
            this.pnlEnterUsr.Size = new System.Drawing.Size(263, 30);
            this.pnlEnterUsr.TabIndex = 4;
            // 
            // PnlInsertUsrRight
            // 
            this.PnlInsertUsrRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PnlInsertUsrRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlInsertUsrRight.Location = new System.Drawing.Point(262, 1);
            this.PnlInsertUsrRight.Name = "PnlInsertUsrRight";
            this.PnlInsertUsrRight.Size = new System.Drawing.Size(1, 28);
            this.PnlInsertUsrRight.TabIndex = 18;
            // 
            // TxtUsr
            // 
            this.TxtUsr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(60)))));
            this.TxtUsr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtUsr.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsr.ForeColor = System.Drawing.Color.DarkGray;
            this.TxtUsr.Location = new System.Drawing.Point(7, 4);
            this.TxtUsr.Name = "TxtUsr";
            this.TxtUsr.Size = new System.Drawing.Size(253, 22);
            this.TxtUsr.TabIndex = 3;
            this.TxtUsr.Text = "Ingrese el usuario";
            this.TxtUsr.Click += new System.EventHandler(this.TxtUsr_Click);
            this.TxtUsr.Enter += new System.EventHandler(this.TxtUsr_Enter);
            this.TxtUsr.Leave += new System.EventHandler(this.TxtUsr_Leave);
            // 
            // PnlInsertUsrLeft
            // 
            this.PnlInsertUsrLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PnlInsertUsrLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlInsertUsrLeft.Location = new System.Drawing.Point(0, 1);
            this.PnlInsertUsrLeft.Name = "PnlInsertUsrLeft";
            this.PnlInsertUsrLeft.Size = new System.Drawing.Size(1, 28);
            this.PnlInsertUsrLeft.TabIndex = 17;
            // 
            // PnlInsertUsrDown
            // 
            this.PnlInsertUsrDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PnlInsertUsrDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlInsertUsrDown.Location = new System.Drawing.Point(0, 29);
            this.PnlInsertUsrDown.Name = "PnlInsertUsrDown";
            this.PnlInsertUsrDown.Size = new System.Drawing.Size(263, 1);
            this.PnlInsertUsrDown.TabIndex = 4;
            // 
            // PnlInsertUsrUp
            // 
            this.PnlInsertUsrUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PnlInsertUsrUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlInsertUsrUp.Location = new System.Drawing.Point(0, 0);
            this.PnlInsertUsrUp.Name = "PnlInsertUsrUp";
            this.PnlInsertUsrUp.Size = new System.Drawing.Size(263, 1);
            this.PnlInsertUsrUp.TabIndex = 17;
            // 
            // PnlLogin
            // 
            this.PnlLogin.Controls.Add(this.LblWrongUsrPwd);
            this.PnlLogin.Controls.Add(this.pictureBox1);
            this.PnlLogin.Controls.Add(this.LnkLblSignUp);
            this.PnlLogin.Controls.Add(this.LblNoUsrPwd);
            this.PnlLogin.Controls.Add(this.BtnSingIn);
            this.PnlLogin.Controls.Add(this.PnlPwd);
            this.PnlLogin.Controls.Add(this.label2);
            this.PnlLogin.Controls.Add(this.PbPwd);
            this.PnlLogin.Controls.Add(this.PnlUsr);
            this.PnlLogin.Controls.Add(this.LblUserLin);
            this.PnlLogin.Controls.Add(this.PbUserLin);
            this.PnlLogin.Controls.Add(this.LblTitleLin);
            this.PnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlLogin.Location = new System.Drawing.Point(0, 32);
            this.PnlLogin.Name = "PnlLogin";
            this.PnlLogin.Size = new System.Drawing.Size(467, 637);
            this.PnlLogin.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::MessageNest.Properties.Resources.appLogo;
            this.pictureBox1.Location = new System.Drawing.Point(155, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 123);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // LnkLblSignUp
            // 
            this.LnkLblSignUp.AutoSize = true;
            this.LnkLblSignUp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.LnkLblSignUp.Location = new System.Drawing.Point(175, 577);
            this.LnkLblSignUp.Name = "LnkLblSignUp";
            this.LnkLblSignUp.Size = new System.Drawing.Size(120, 17);
            this.LnkLblSignUp.TabIndex = 15;
            this.LnkLblSignUp.TabStop = true;
            this.LnkLblSignUp.Text = "Crear nueva cuenta";
            this.LnkLblSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblSignUp_LinkClicked);
            // 
            // LblNoUsrPwd
            // 
            this.LblNoUsrPwd.AutoSize = true;
            this.LblNoUsrPwd.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNoUsrPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.LblNoUsrPwd.Location = new System.Drawing.Point(126, 453);
            this.LblNoUsrPwd.Name = "LblNoUsrPwd";
            this.LblNoUsrPwd.Size = new System.Drawing.Size(226, 17);
            this.LblNoUsrPwd.TabIndex = 12;
            this.LblNoUsrPwd.Text = "Debe ingresar usuario y contraseña.";
            this.LblNoUsrPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblNoUsrPwd.Visible = false;
            // 
            // BtnSingIn
            // 
            this.BtnSingIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(191)))), ((int)(((byte)(74)))));
            this.BtnSingIn.Cursor = System.Windows.Forms.Cursors.Default;
            this.BtnSingIn.FlatAppearance.BorderSize = 0;
            this.BtnSingIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(210)))), ((int)(((byte)(100)))));
            this.BtnSingIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSingIn.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSingIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(102)))));
            this.BtnSingIn.Location = new System.Drawing.Point(131, 516);
            this.BtnSingIn.Name = "BtnSingIn";
            this.BtnSingIn.Size = new System.Drawing.Size(206, 30);
            this.BtnSingIn.TabIndex = 13;
            this.BtnSingIn.Text = "Iniciar sesión";
            this.BtnSingIn.UseVisualStyleBackColor = false;
            this.BtnSingIn.Click += new System.EventHandler(this.BtnSingIn_Click);
            // 
            // PnlPwd
            // 
            this.PnlPwd.Controls.Add(this.LblWrongPwd);
            this.PnlPwd.Controls.Add(this.PnlEnterPwd);
            this.PnlPwd.Location = new System.Drawing.Point(181, 383);
            this.PnlPwd.Name = "PnlPwd";
            this.PnlPwd.Size = new System.Drawing.Size(266, 74);
            this.PnlPwd.TabIndex = 7;
            // 
            // LblWrongPwd
            // 
            this.LblWrongPwd.AutoSize = true;
            this.LblWrongPwd.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWrongPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.LblWrongPwd.Location = new System.Drawing.Point(-3, 33);
            this.LblWrongPwd.Name = "LblWrongPwd";
            this.LblWrongPwd.Size = new System.Drawing.Size(262, 17);
            this.LblWrongPwd.TabIndex = 13;
            this.LblWrongPwd.Text = "Contraseña no válida. Inténtalo de nuevo.";
            this.LblWrongPwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblWrongPwd.Visible = false;
            // 
            // PnlEnterPwd
            // 
            this.PnlEnterPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(60)))));
            this.PnlEnterPwd.Controls.Add(this.BtnShowHide);
            this.PnlEnterPwd.Controls.Add(this.TxtPwd);
            this.PnlEnterPwd.Controls.Add(this.PnlInsertPwdRight);
            this.PnlEnterPwd.Controls.Add(this.PnlInsertPwdLeft);
            this.PnlEnterPwd.Controls.Add(this.PnlInsertPwdUp);
            this.PnlEnterPwd.Controls.Add(this.PnlInsertPwdDown);
            this.PnlEnterPwd.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlEnterPwd.Location = new System.Drawing.Point(0, 0);
            this.PnlEnterPwd.Name = "PnlEnterPwd";
            this.PnlEnterPwd.Size = new System.Drawing.Size(266, 30);
            this.PnlEnterPwd.TabIndex = 8;
            // 
            // BtnShowHide
            // 
            this.BtnShowHide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(60)))));
            this.BtnShowHide.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnShowHide.FlatAppearance.BorderSize = 0;
            this.BtnShowHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowHide.Image = global::MessageNest.Properties.Resources.hide;
            this.BtnShowHide.Location = new System.Drawing.Point(227, 1);
            this.BtnShowHide.Name = "BtnShowHide";
            this.BtnShowHide.Size = new System.Drawing.Size(38, 28);
            this.BtnShowHide.TabIndex = 10;
            this.BtnShowHide.UseVisualStyleBackColor = false;
            this.BtnShowHide.Click += new System.EventHandler(this.BtnShowHide_Click);
            // 
            // TxtPwd
            // 
            this.TxtPwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(60)))));
            this.TxtPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPwd.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPwd.ForeColor = System.Drawing.Color.DarkGray;
            this.TxtPwd.Location = new System.Drawing.Point(7, 4);
            this.TxtPwd.Name = "TxtPwd";
            this.TxtPwd.Size = new System.Drawing.Size(256, 22);
            this.TxtPwd.TabIndex = 9;
            this.TxtPwd.Text = "Contraseña";
            this.TxtPwd.Click += new System.EventHandler(this.TxtPwd_Click);
            this.TxtPwd.Enter += new System.EventHandler(this.TxtPwd_Enter);
            this.TxtPwd.Leave += new System.EventHandler(this.TxtPwd_Leave);
            // 
            // PnlInsertPwdRight
            // 
            this.PnlInsertPwdRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PnlInsertPwdRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlInsertPwdRight.Location = new System.Drawing.Point(265, 1);
            this.PnlInsertPwdRight.Name = "PnlInsertPwdRight";
            this.PnlInsertPwdRight.Size = new System.Drawing.Size(1, 28);
            this.PnlInsertPwdRight.TabIndex = 18;
            // 
            // PnlInsertPwdLeft
            // 
            this.PnlInsertPwdLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PnlInsertPwdLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlInsertPwdLeft.Location = new System.Drawing.Point(0, 1);
            this.PnlInsertPwdLeft.Name = "PnlInsertPwdLeft";
            this.PnlInsertPwdLeft.Size = new System.Drawing.Size(1, 28);
            this.PnlInsertPwdLeft.TabIndex = 18;
            // 
            // PnlInsertPwdUp
            // 
            this.PnlInsertPwdUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PnlInsertPwdUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlInsertPwdUp.Location = new System.Drawing.Point(0, 0);
            this.PnlInsertPwdUp.Name = "PnlInsertPwdUp";
            this.PnlInsertPwdUp.Size = new System.Drawing.Size(266, 1);
            this.PnlInsertPwdUp.TabIndex = 13;
            // 
            // PnlInsertPwdDown
            // 
            this.PnlInsertPwdDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PnlInsertPwdDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlInsertPwdDown.Location = new System.Drawing.Point(0, 29);
            this.PnlInsertPwdDown.Name = "PnlInsertPwdDown";
            this.PnlInsertPwdDown.Size = new System.Drawing.Size(266, 1);
            this.PnlInsertPwdDown.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(66, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contraseña";
            // 
            // PbPwd
            // 
            this.PbPwd.Image = global::MessageNest.Properties.Resources.password_protection;
            this.PbPwd.Location = new System.Drawing.Point(20, 373);
            this.PbPwd.Name = "PbPwd";
            this.PbPwd.Size = new System.Drawing.Size(40, 40);
            this.PbPwd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbPwd.TabIndex = 4;
            this.PbPwd.TabStop = false;
            // 
            // PnlUsr
            // 
            this.PnlUsr.Controls.Add(this.LblWrongUsr);
            this.PnlUsr.Controls.Add(this.pnlEnterUsr);
            this.PnlUsr.Location = new System.Drawing.Point(181, 282);
            this.PnlUsr.Name = "PnlUsr";
            this.PnlUsr.Size = new System.Drawing.Size(263, 74);
            this.PnlUsr.TabIndex = 3;
            // 
            // LblWrongUsr
            // 
            this.LblWrongUsr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LblWrongUsr.AutoSize = true;
            this.LblWrongUsr.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWrongUsr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.LblWrongUsr.Location = new System.Drawing.Point(-3, 33);
            this.LblWrongUsr.Name = "LblWrongUsr";
            this.LblWrongUsr.Size = new System.Drawing.Size(271, 34);
            this.LblWrongUsr.TabIndex = 5;
            this.LblWrongUsr.Text = "Nombre de usuario no válido. Inténtalo de \r\nnuevo.";
            this.LblWrongUsr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblWrongUsr.Visible = false;
            // 
            // LblWrongUsrPwd
            // 
            this.LblWrongUsrPwd.AutoSize = true;
            this.LblWrongUsrPwd.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWrongUsrPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.LblWrongUsrPwd.Location = new System.Drawing.Point(126, 453);
            this.LblWrongUsrPwd.Name = "LblWrongUsrPwd";
            this.LblWrongUsrPwd.Size = new System.Drawing.Size(205, 17);
            this.LblWrongUsrPwd.TabIndex = 17;
            this.LblWrongUsrPwd.Text = "Usuario o contraseña incorrecto.";
            this.LblWrongUsrPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblWrongUsrPwd.Visible = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(467, 669);
            this.Controls.Add(this.PnlLogin);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbUserLin)).EndInit();
            this.pnlEnterUsr.ResumeLayout(false);
            this.pnlEnterUsr.PerformLayout();
            this.PnlLogin.ResumeLayout(false);
            this.PnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PnlPwd.ResumeLayout(false);
            this.PnlPwd.PerformLayout();
            this.PnlEnterPwd.ResumeLayout(false);
            this.PnlEnterPwd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbPwd)).EndInit();
            this.PnlUsr.ResumeLayout(false);
            this.PnlUsr.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlTop;
        private System.Windows.Forms.Button BtnCloseLogin;
        private System.Windows.Forms.Label LblTitleLin;
        private System.Windows.Forms.PictureBox PbUserLin;
        private System.Windows.Forms.Label LblUserLin;
        private System.Windows.Forms.Panel pnlEnterUsr;
        private System.Windows.Forms.TextBox TxtUsr;
        private System.Windows.Forms.Panel PnlLogin;
        private System.Windows.Forms.Panel PnlUsr;
        private System.Windows.Forms.Label LblWrongUsr;
        private System.Windows.Forms.Panel PnlPwd;
        private System.Windows.Forms.Label LblWrongPwd;
        private System.Windows.Forms.Panel PnlEnterPwd;
        private System.Windows.Forms.TextBox TxtPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox PbPwd;
        private System.Windows.Forms.Button BtnSingIn;
        private System.Windows.Forms.Label LblNoUsrPwd;
        private System.Windows.Forms.LinkLabel LnkLblSignUp;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnShowHide;
        private System.Windows.Forms.Panel PnlInsertUsrDown;
        private System.Windows.Forms.Panel PnlInsertUsrUp;
        private System.Windows.Forms.Panel PnlInsertPwdDown;
        private System.Windows.Forms.Panel PnlInsertUsrLeft;
        private System.Windows.Forms.Panel PnlInsertUsrRight;
        private System.Windows.Forms.Panel PnlInsertPwdUp;
        private System.Windows.Forms.Panel PnlInsertPwdRight;
        private System.Windows.Forms.Panel PnlInsertPwdLeft;
        private System.Windows.Forms.Label LblWrongUsrPwd;
    }
}

