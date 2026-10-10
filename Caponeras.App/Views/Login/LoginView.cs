using System.Diagnostics;
using Caponeras.App.ViewModels.Login;
using DevExpress.XtraEditors;

namespace Caponeras.App.Views.Login
{
    public partial class LoginView : DevExpress.XtraEditors.XtraForm
    {
        private LoginViewModel _viewModel;
        public bool LoginSuccess { get; private set; }
        public LoginView(LoginViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            Shown += (_, _) => txtUsername.Focus();
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
