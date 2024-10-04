namespace MessageNest.Forms
{
    partial class FrmCreateUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateUser));
            this.BtnCloseLogin = new System.Windows.Forms.Button();
            this.PnlTop = new System.Windows.Forms.Panel();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnCloseLogin
            // 
            this.BtnCloseLogin.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnCloseLogin.FlatAppearance.BorderSize = 0;
            this.BtnCloseLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCloseLogin.Image = global::MessageNest.Properties.Resources.close_button__1_;
            this.BtnCloseLogin.Location = new System.Drawing.Point(845, 0);
            this.BtnCloseLogin.Name = "BtnCloseLogin";
            this.BtnCloseLogin.Size = new System.Drawing.Size(50, 32);
            this.BtnCloseLogin.TabIndex = 0;
            this.BtnCloseLogin.UseVisualStyleBackColor = true;
            // 
            // PnlTop
            // 
            this.PnlTop.Controls.Add(this.BtnCloseLogin);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(895, 32);
            this.PnlTop.TabIndex = 1;
            // 
            // FrmCreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(895, 600);
            this.Controls.Add(this.PnlTop);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCreateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OtherLogin";
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnCloseLogin;
        private System.Windows.Forms.Panel PnlTop;
    }
}