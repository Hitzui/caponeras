namespace Caponeras.App.Views.Login
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            htmlContentControl1 = new DevExpress.XtraEditors.HtmlContentControl();
            txtPassword = new DevExpress.XtraEditors.TextEdit();
            txtUsername = new DevExpress.XtraEditors.TextEdit();
            panel1 = new Panel();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)htmlContentControl1).BeginInit();
            htmlContentControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureEdit1
            // 
            pictureEdit1.EditValue = Properties.Resources.rickshaw_83428961;
            pictureEdit1.Location = new Point(110, 82);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            pictureEdit1.Size = new Size(241, 207);
            pictureEdit1.TabIndex = 0;
            // 
            // htmlContentControl1
            // 
            htmlContentControl1.Controls.Add(txtPassword);
            htmlContentControl1.Controls.Add(txtUsername);
            htmlContentControl1.HtmlTemplate.Styles = resources.GetString("htmlContentControl1.HtmlTemplate.Styles");
            htmlContentControl1.HtmlTemplate.Template = resources.GetString("htmlContentControl1.HtmlTemplate.Template");
            htmlContentControl1.Location = new Point(27, 325);
            htmlContentControl1.LookAndFeel.SkinName = "WXI";
            htmlContentControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            htmlContentControl1.Name = "htmlContentControl1";
            htmlContentControl1.Size = new Size(416, 301);
            htmlContentControl1.TabIndex = 5;
            htmlContentControl1.ElementMouseClick += htmlContentControl1_ElementMouseClick;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(47, 141);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            txtPassword.Properties.PasswordChar = '*';
            txtPassword.Size = new Size(322, 18);
            txtPassword.TabIndex = 7;
            // 
            // txtUsername
            // 
            txtUsername.EnterMoveNextControl = true;
            txtUsername.Location = new Point(47, 46);
            txtUsername.Name = "txtUsername";
            txtUsername.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            txtUsername.Size = new Size(322, 18);
            txtUsername.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(50, 48, 49);
            panel1.Controls.Add(labelControl1);
            panel1.Controls.Add(simpleButton1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(480, 40);
            panel1.TabIndex = 6;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new Font("Tahoma", 14F);
            labelControl1.Appearance.ForeColor = Color.White;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Appearance.Options.UseForeColor = true;
            labelControl1.Location = new Point(172, 10);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(140, 23);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "INICIAR SESIÓN";
            // 
            // simpleButton1
            // 
            simpleButton1.Appearance.BackColor = Color.FromArgb(50, 48, 49);
            simpleButton1.Appearance.BorderColor = Color.FromArgb(50, 48, 49);
            simpleButton1.Appearance.Options.UseBackColor = true;
            simpleButton1.Appearance.Options.UseBorderColor = true;
            simpleButton1.AutoSize = true;
            simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            simpleButton1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButton1.ImageOptions.SvgImage");
            simpleButton1.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.Full;
            simpleButton1.ImageOptions.SvgImageSize = new Size(28, 28);
            simpleButton1.Location = new Point(431, 4);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new Size(34, 32);
            simpleButton1.TabIndex = 0;
            simpleButton1.Click += simpleButton1_Click;
            // 
            // LoginView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(480, 638);
            Controls.Add(panel1);
            Controls.Add(htmlContentControl1);
            Controls.Add(pictureEdit1);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            FormBorderStyle = FormBorderStyle.None;
            IconOptions.Icon = (Icon)resources.GetObject("LoginView.IconOptions.Icon");
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginView";
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)htmlContentControl1).EndInit();
            htmlContentControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.HtmlContentControl htmlContentControl1;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private Panel panel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}