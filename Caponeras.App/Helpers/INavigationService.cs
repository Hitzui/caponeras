using Caponeras.Data.Models;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace Caponeras.App.Helpers;

public interface INavigationService
{
    Usuarios CurrentUser { get; set; }
    void SetMain(XtraForm mainForm);
    TForm Show<TForm>(SplashScreenManager? splash = null, object? query = null) where TForm : Form;
    TForm ShowDialog<TForm>(SplashScreenManager? splashScreenManager = null, object? query = null, bool showDialog = true) where TForm : Form;
    public Dictionary<Type, Form> OpenedForms { get; }
    public object? Query { get; set; }
    XtraForm MainView { get; }
    AlertControl AlertControl { get; set; }
}
