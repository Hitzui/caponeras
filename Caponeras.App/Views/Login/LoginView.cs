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
            htmlContentControl1.Controls.Add(txtUsername);
            htmlContentControl1.Controls.Add(txtPassword);
            txtUsername.Focus();
        }

        private void htmlContentControl1_ElementMouseClick(object sender,
            DevExpress.Utils.Html.DxHtmlElementMouseEventArgs e)
        {
            if (e.ElementId == "btnCancelar")
            {
                Close();
            }
            else
            {
                LoginTask();
            }
        }

        private async void LoginTask()
        {
            try
            {
                var username = txtUsername.Text;
                var password = txtPassword.Text;
                if (string.IsNullOrEmpty(username))
                {
                    txtUsername.ErrorText = "El nombre de usuario es requerido.";
                    return;
                }

                if (string.IsNullOrEmpty(password))
                {
                    txtPassword.ErrorText = "La contraseña es requerida.";
                    return;
                }

                var result = await _viewModel.LoginTask(username, password);
                if (result)
                {
                    await XtraMessageBox.ShowAsync("Inicio de sesión de forma crrecta...");
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
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}