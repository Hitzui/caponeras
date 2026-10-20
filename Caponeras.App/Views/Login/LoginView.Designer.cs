namespace Caponeras.App.Views.Login
{
    partial class LoginView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            panelBrand = new Panel();
            pictureLogo = new PictureBox();
            lblBrandName = new DevExpress.XtraEditors.LabelControl();
            lblBrandSubtitle = new DevExpress.XtraEditors.LabelControl();
            lblBrandFootnote = new DevExpress.XtraEditors.LabelControl();
            panelLogin = new Panel();
            lblEyebrow = new DevExpress.XtraEditors.LabelControl();
            lblWelcome = new DevExpress.XtraEditors.LabelControl();
            lblDescription = new DevExpress.XtraEditors.LabelControl();
            lblUsername = new DevExpress.XtraEditors.LabelControl();
            panelUsernameField = new Panel();
            btnUsernameIcon = new DevExpress.XtraEditors.SimpleButton();
            txtUsername = new DevExpress.XtraEditors.TextEdit();
            lblPassword = new DevExpress.XtraEditors.LabelControl();
            panelPasswordField = new Panel();
            btnPasswordIcon = new DevExpress.XtraEditors.SimpleButton();
            txtPassword = new DevExpress.XtraEditors.TextEdit();
            btnTogglePassword = new DevExpress.XtraEditors.SimpleButton();
            btnLogin = new DevExpress.XtraEditors.SimpleButton();
            btnCancel = new DevExpress.XtraEditors.SimpleButton();
            lblFooter = new DevExpress.XtraEditors.LabelControl();
            panelBrand.SuspendLayout();
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            SuspendLayout();
            //
            // panelBrand
            //
            panelBrand.BackColor = Color.FromArgb(18, 59, 69);
            panelBrand.Controls.Add(lblBrandFootnote);
            panelBrand.Controls.Add(lblBrandSubtitle);
            panelBrand.Controls.Add(lblBrandName);
            panelBrand.Controls.Add(pictureLogo);
            panelBrand.Dock = DockStyle.Left;
            panelBrand.Location = new Point(0, 0);
            panelBrand.Name = "panelBrand";
            panelBrand.Size = new Size(292, 520);
            panelBrand.TabIndex = 0;
            //
            // pictureLogo
            //
            pictureLogo.BackColor = Color.Transparent;
            pictureLogo.Image = Properties.Resources.rickshaw_83428961;
            pictureLogo.Location = new Point(71, 127);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.Size = new Size(150, 150);
            pictureLogo.TabIndex = 0;
            pictureLogo.TabStop = false;
            //
            // lblBrandName
            //
            lblBrandName.Appearance.Font = new Font("Segoe UI", 23F, FontStyle.Bold);
            lblBrandName.Appearance.ForeColor = Color.White;
            lblBrandName.Appearance.Options.UseFont = true;
            lblBrandName.Appearance.Options.UseForeColor = true;
            lblBrandName.Appearance.Options.UseTextOptions = true;
            lblBrandName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblBrandName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblBrandName.Location = new Point(18, 302);
            lblBrandName.Name = "lblBrandName";
            lblBrandName.Size = new Size(256, 42);
            lblBrandName.TabIndex = 1;
            lblBrandName.Text = "Caponeras";
            //
            // lblBrandSubtitle
            //
            lblBrandSubtitle.Appearance.Font = new Font("Segoe UI", 10F);
            lblBrandSubtitle.Appearance.ForeColor = Color.FromArgb(190, 217, 219);
            lblBrandSubtitle.Appearance.Options.UseFont = true;
            lblBrandSubtitle.Appearance.Options.UseForeColor = true;
            lblBrandSubtitle.Appearance.Options.UseTextOptions = true;
            lblBrandSubtitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblBrandSubtitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblBrandSubtitle.Location = new Point(26, 349);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new Size(240, 24);
            lblBrandSubtitle.TabIndex = 2;
            lblBrandSubtitle.Text = "Gestión de transporte, más simple.";
            //
            // lblBrandFootnote
            //
            lblBrandFootnote.Appearance.Font = new Font("Segoe UI", 8.5F);
            lblBrandFootnote.Appearance.ForeColor = Color.FromArgb(151, 184, 187);
            lblBrandFootnote.Appearance.Options.UseFont = true;
            lblBrandFootnote.Appearance.Options.UseForeColor = true;
            lblBrandFootnote.Appearance.Options.UseTextOptions = true;
            lblBrandFootnote.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblBrandFootnote.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblBrandFootnote.Location = new Point(26, 474);
            lblBrandFootnote.Name = "lblBrandFootnote";
            lblBrandFootnote.Size = new Size(240, 20);
            lblBrandFootnote.TabIndex = 3;
            lblBrandFootnote.Text = "PLATAFORMA DE ADMINISTRACIÓN";
            //
            // panelLogin
            //
            panelLogin.BackColor = Color.White;
            panelLogin.Controls.Add(lblFooter);
            panelLogin.Controls.Add(btnCancel);
            panelLogin.Controls.Add(btnLogin);
            panelLogin.Controls.Add(panelPasswordField);
            panelLogin.Controls.Add(lblPassword);
            panelLogin.Controls.Add(panelUsernameField);
            panelLogin.Controls.Add(lblUsername);
            panelLogin.Controls.Add(lblDescription);
            panelLogin.Controls.Add(lblWelcome);
            panelLogin.Controls.Add(lblEyebrow);
            panelLogin.Dock = DockStyle.Fill;
            panelLogin.Location = new Point(292, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Padding = new Padding(48, 0, 48, 0);
            panelLogin.Size = new Size(468, 520);
            panelLogin.TabIndex = 1;
            //
            // lblEyebrow
            //
            lblEyebrow.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEyebrow.Appearance.ForeColor = Color.FromArgb(14, 145, 125);
            lblEyebrow.Appearance.Options.UseFont = true;
            lblEyebrow.Appearance.Options.UseForeColor = true;
            lblEyebrow.Location = new Point(52, 84);
            lblEyebrow.Name = "lblEyebrow";
            lblEyebrow.Size = new Size(118, 15);
            lblEyebrow.TabIndex = 0;
            lblEyebrow.Text = "ACCESO AL SISTEMA";
            //
            // lblWelcome
            //
            lblWelcome.Appearance.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblWelcome.Appearance.ForeColor = Color.FromArgb(35, 47, 52);
            lblWelcome.Appearance.Options.UseFont = true;
            lblWelcome.Appearance.Options.UseForeColor = true;
            lblWelcome.Location = new Point(48, 115);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(193, 46);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Bienvenido";
            //
            // lblDescription
            //
            lblDescription.Appearance.Font = new Font("Segoe UI", 10F);
            lblDescription.Appearance.ForeColor = Color.FromArgb(112, 124, 129);
            lblDescription.Appearance.Options.UseFont = true;
            lblDescription.Appearance.Options.UseForeColor = true;
            lblDescription.Location = new Point(52, 166);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(232, 17);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Ingresa tus datos para continuar.";
            //
            // lblUsername
            //
            lblUsername.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUsername.Appearance.ForeColor = Color.FromArgb(55, 66, 71);
            lblUsername.Appearance.Options.UseFont = true;
            lblUsername.Appearance.Options.UseForeColor = true;
            lblUsername.Location = new Point(52, 218);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(115, 17);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Nombre de usuario";
            //
            // panelUsernameField
            //
            panelUsernameField.BackColor = Color.White;
            panelUsernameField.Controls.Add(txtUsername);
            panelUsernameField.Controls.Add(btnUsernameIcon);
            panelUsernameField.Location = new Point(52, 239);
            panelUsernameField.Name = "panelUsernameField";
            panelUsernameField.Size = new Size(364, 42);
            panelUsernameField.TabIndex = 4;
            panelUsernameField.Paint += MaterialField_Paint;
            //
            // btnUsernameIcon
            //
            btnUsernameIcon.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btnUsernameIcon.Location = new Point(7, 5);
            btnUsernameIcon.Name = "btnUsernameIcon";
            btnUsernameIcon.Size = new Size(32, 32);
            btnUsernameIcon.TabIndex = 0;
            btnUsernameIcon.TabStop = false;
            btnUsernameIcon.ToolTip = "Usuario";
            //
            // txtUsername
            //
            txtUsername.EnterMoveNextControl = true;
            txtUsername.Location = new Point(44, 7);
            txtUsername.Name = "txtUsername";
            txtUsername.Properties.Appearance.BackColor = Color.FromArgb(247, 249, 250);
            txtUsername.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            txtUsername.Properties.Appearance.Options.UseBackColor = true;
            txtUsername.Properties.Appearance.Options.UseFont = true;
            txtUsername.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            txtUsername.Properties.NullValuePrompt = "Escribe tu usuario";
            txtUsername.Size = new Size(310, 28);
            txtUsername.TabIndex = 0;
            //
            // lblPassword
            //
            lblPassword.Appearance.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.Appearance.ForeColor = Color.FromArgb(55, 66, 71);
            lblPassword.Appearance.Options.UseFont = true;
            lblPassword.Appearance.Options.UseForeColor = true;
            lblPassword.Location = new Point(52, 293);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(67, 17);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Contraseña";
            //
            // panelPasswordField
            //
            panelPasswordField.BackColor = Color.White;
            panelPasswordField.Controls.Add(txtPassword);
            panelPasswordField.Controls.Add(btnTogglePassword);
            panelPasswordField.Controls.Add(btnPasswordIcon);
            panelPasswordField.Location = new Point(52, 314);
            panelPasswordField.Name = "panelPasswordField";
            panelPasswordField.Size = new Size(364, 42);
            panelPasswordField.TabIndex = 6;
            panelPasswordField.Paint += MaterialField_Paint;
            //
            // btnPasswordIcon
            //
            btnPasswordIcon.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btnPasswordIcon.Location = new Point(7, 5);
            btnPasswordIcon.Name = "btnPasswordIcon";
            btnPasswordIcon.Size = new Size(32, 32);
            btnPasswordIcon.TabIndex = 0;
            btnPasswordIcon.TabStop = false;
            btnPasswordIcon.ToolTip = "Contraseña";
            //
            // txtPassword
            //
            txtPassword.Location = new Point(44, 7);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.Appearance.BackColor = Color.FromArgb(247, 249, 250);
            txtPassword.Properties.Appearance.Font = new Font("Segoe UI", 11F);
            txtPassword.Properties.Appearance.Options.UseBackColor = true;
            txtPassword.Properties.Appearance.Options.UseFont = true;
            txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            txtPassword.Properties.NullValuePrompt = "Escribe tu contraseña";
            txtPassword.Properties.PasswordChar = '●';
            txtPassword.Size = new Size(274, 28);
            txtPassword.TabIndex = 0;
            //
            // btnTogglePassword
            //
            btnTogglePassword.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            btnTogglePassword.Location = new Point(322, 5);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(32, 32);
            btnTogglePassword.TabIndex = 1;
            btnTogglePassword.TabStop = false;
            btnTogglePassword.ToolTip = "Mostrar contraseña";
            //
            // btnLogin
            //
            btnLogin.Appearance.BackColor = Color.FromArgb(14, 145, 125);
            btnLogin.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.Appearance.ForeColor = Color.White;
            btnLogin.Appearance.Options.UseBackColor = true;
            btnLogin.Appearance.Options.UseFont = true;
            btnLogin.Appearance.Options.UseForeColor = true;
            btnLogin.AppearanceHovered.BackColor = Color.FromArgb(11, 121, 105);
            btnLogin.AppearanceHovered.Options.UseBackColor = true;
            btnLogin.Location = new Point(52, 376);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(364, 44);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.Click += btnLogin_Click;
            //
            // btnCancel
            //
            btnCancel.Appearance.BackColor = Color.White;
            btnCancel.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.Appearance.ForeColor = Color.FromArgb(93, 108, 113);
            btnCancel.Appearance.Options.UseBackColor = true;
            btnCancel.Appearance.Options.UseFont = true;
            btnCancel.Appearance.Options.UseForeColor = true;
            btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            btnCancel.Location = new Point(52, 430);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(364, 36);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Salir";
            btnCancel.Click += btnCancel_Click;
            //
            // lblFooter
            //
            lblFooter.Appearance.Font = new Font("Segoe UI", 8.5F);
            lblFooter.Appearance.ForeColor = Color.FromArgb(146, 156, 160);
            lblFooter.Appearance.Options.UseFont = true;
            lblFooter.Appearance.Options.UseForeColor = true;
            lblFooter.Appearance.Options.UseTextOptions = true;
            lblFooter.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblFooter.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblFooter.Location = new Point(52, 481);
            lblFooter.Name = "lblFooter";
            lblFooter.Size = new Size(364, 18);
            lblFooter.TabIndex = 9;
            lblFooter.Text = "Acceso seguro para usuarios autorizados";
            //
            // LoginView
            //
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(760, 520);
            Controls.Add(panelLogin);
            Controls.Add(panelBrand);
            FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            IconOptions.Icon = (Icon)resources.GetObject("LoginView.IconOptions.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caponeras | Iniciar sesión";
            panelBrand.ResumeLayout(false);
            panelBrand.PerformLayout();
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtUsername.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ResumeLayout(false);
        }

        private Panel panelBrand;
        private PictureBox pictureLogo;
        private DevExpress.XtraEditors.LabelControl lblBrandName;
        private DevExpress.XtraEditors.LabelControl lblBrandSubtitle;
        private DevExpress.XtraEditors.LabelControl lblBrandFootnote;
        private Panel panelLogin;
        private DevExpress.XtraEditors.LabelControl lblEyebrow;
        private DevExpress.XtraEditors.LabelControl lblWelcome;
        private DevExpress.XtraEditors.LabelControl lblDescription;
        private DevExpress.XtraEditors.LabelControl lblUsername;
        private Panel panelUsernameField;
        private DevExpress.XtraEditors.SimpleButton btnUsernameIcon;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private Panel panelPasswordField;
        private DevExpress.XtraEditors.SimpleButton btnPasswordIcon;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton btnTogglePassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl lblFooter;
    }
}
