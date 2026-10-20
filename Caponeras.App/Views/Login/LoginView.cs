using System.Diagnostics;
using System.Drawing.Drawing2D;
using Caponeras.App.ViewModels.Login;
using DevExpress.XtraEditors;

namespace Caponeras.App.Views.Login
{
    public partial class LoginView : DevExpress.XtraEditors.XtraForm
    {
        private LoginViewModel _viewModel;
        private bool _passwordVisible;
        public bool LoginSuccess { get; private set; }
        public LoginView(LoginViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            ConfigureMaterialFields();
            Shown += (_, _) => txtUsername.Focus();
        }

        private void ConfigureMaterialFields()
        {
            foreach (var iconButton in new[] { btnUsernameIcon, btnPasswordIcon, btnTogglePassword })
            {
                iconButton.Appearance.BackColor = Color.FromArgb(247, 249, 250);
                iconButton.Appearance.Options.UseBackColor = true;
                iconButton.AppearanceHovered.BackColor = Color.FromArgb(231, 238, 239);
                iconButton.AppearanceHovered.Options.UseBackColor = true;
                iconButton.AllowFocus = false;
            }
            btnUsernameIcon.Paint += (_, e) => DrawUserIcon(e.Graphics);
            btnPasswordIcon.Paint += (_, e) => DrawLockIcon(e.Graphics);
            btnTogglePassword.Paint += (_, e) => DrawEyeIcon(e.Graphics, _passwordVisible);

            txtUsername.Enter += (_, _) => panelUsernameField.Invalidate();
            txtUsername.Leave += (_, _) => panelUsernameField.Invalidate();
            txtPassword.Enter += (_, _) => panelPasswordField.Invalidate();
            txtPassword.Leave += (_, _) => panelPasswordField.Invalidate();
            btnTogglePassword.Click += (_, _) =>
            {
                _passwordVisible = !_passwordVisible;
                txtPassword.Properties.PasswordChar = _passwordVisible ? '\0' : '●';
                btnTogglePassword.ToolTip = _passwordVisible ? "Ocultar contraseña" : "Mostrar contraseña";
                btnTogglePassword.Invalidate();
                txtPassword.Focus();
                txtPassword.SelectionStart = txtPassword.Text.Length;
            };
        }

        private static void DrawUserIcon(Graphics graphics)
        {
            using var pen = CreateIconPen();
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawEllipse(pen, 10F, 4F, 8F, 8F);
            graphics.DrawArc(pen, 5F, 12F, 18F, 16F, 205F, 130F);
        }

        private static void DrawLockIcon(Graphics graphics)
        {
            using var pen = CreateIconPen();
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawArc(pen, 8F, 3F, 16F, 17F, 180F, 180F);
            graphics.DrawLine(pen, 8F, 11.5F, 8F, 14F);
            graphics.DrawLine(pen, 24F, 11.5F, 24F, 14F);
            DrawRoundedRectangle(graphics, pen, new RectangleF(5F, 12F, 22F, 17F), 4F);
            graphics.DrawEllipse(pen, 14.5F, 18F, 3F, 3F);
            graphics.DrawLine(pen, 16F, 21F, 16F, 24F);
        }

        private void DrawEyeIcon(Graphics graphics, bool passwordVisible)
        {
            using var pen = CreateIconPen();
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var path = new GraphicsPath();
            path.AddBezier(4F, 16F, 10F, 7F, 22F, 7F, 28F, 16F);
            path.AddBezier(28F, 16F, 22F, 25F, 10F, 25F, 4F, 16F);
            graphics.DrawPath(pen, path);
            graphics.DrawEllipse(pen, 12F, 12F, 8F, 8F);
            if (passwordVisible)
                graphics.DrawLine(pen, 5F, 5F, 27F, 27F);
        }

        private static Pen CreateIconPen() => new(Color.FromArgb(82, 102, 106), 1.8F)
        {
            StartCap = LineCap.Round,
            EndCap = LineCap.Round,
            LineJoin = LineJoin.Round
        };

        private static void DrawRoundedRectangle(Graphics graphics, Pen pen, RectangleF bounds, float radius)
        {
            using var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            graphics.DrawPath(pen, path);
        }

        private void MaterialField_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel field || field.Width < 4 || field.Height < 4)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var bounds = new RectangleF(0.75F, 0.75F, field.Width - 1.5F, field.Height - 1.5F);
            const float radius = 9F;
            using var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            var focused = field.ContainsFocus;
            using var fill = new SolidBrush(Color.FromArgb(247, 249, 250));
            using var border = new Pen(focused ? Color.FromArgb(14, 145, 125) : Color.FromArgb(196, 207, 210),
                focused ? 1.8F : 1F);
            e.Graphics.FillPath(fill, path);
            e.Graphics.DrawPath(border, path);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginTask();
        }

        private async void LoginTask()
        {
            btnLogin.Enabled = false;
            try
            {
                var username = txtUsername.Text;
                var password = txtPassword.Text;
                txtUsername.ErrorText = string.Empty;
                txtPassword.ErrorText = string.Empty;
                if (string.IsNullOrEmpty(username))
                {
                    txtUsername.ErrorText = "El nombre de usuario es requerido.";
                    txtUsername.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    txtPassword.ErrorText = "La contraseña es requerida.";
                    txtPassword.Focus();
                    return;
                }

                var result = await _viewModel.LoginTask(username, password);
                if (result)
                {
                    await XtraMessageBox.ShowAsync("Inicio de sesión correcto.");
                    DialogResult = DialogResult.OK;
                    LoginSuccess = true;
                }
                else
                {
                    LoginSuccess = false;
                    await XtraMessageBox.ShowAsync(_viewModel.Error);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                await XtraMessageBox.ShowAsync("No fue posible iniciar sesión. Intente nuevamente.");
            }
            finally
            {
                if (!LoginSuccess)
                    btnLogin.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
