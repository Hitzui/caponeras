using Caponeras.App.Views;
using Caponeras.Data.Models;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Microsoft.Extensions.DependencyInjection;

namespace Caponeras.App.Helpers;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _provider;
    private XtraForm? _mainForm;

    public Dictionary<Type, Form> OpenedForms { get; } = new();

    public NavigationService(IServiceProvider provider)
    {
        _provider = provider;
    }

    public Usuarios CurrentUser { get; set; }

    public void SetMain(XtraForm mainForm)
    {
        _mainForm = mainForm;
        MainView = _mainForm;
    }

    public TForm Show<TForm>(SplashScreenManager? splashScreenManager, object? query = null) where TForm : Form
    {
        if (_mainForm == null)
            throw new InvalidOperationException("Main form not set in NavigationService");
        Query = query;
        var type = typeof(TForm);
        splashScreenManager ??= new SplashScreenManager(_mainForm, typeof(WaitForm1), true, true);
        splashScreenManager.ShowWaitForm();
        if (OpenedForms.TryGetValue(type, out var form))
        {
            if (!form.IsDisposed)
            {
                form.BringToFront();
                form.Activate();
                splashScreenManager.CloseWaitForm();
                return (TForm)form;
            }

            OpenedForms.Remove(type);
        }

        var newForm = _provider.GetRequiredService<TForm>();
        newForm.StartPosition = FormStartPosition.CenterScreen;
        newForm.WindowState = FormWindowState.Maximized;
        newForm.MdiParent = _mainForm;
        newForm.FormClosed += (_, _) => OpenedForms.Remove(type);

        OpenedForms[type] = newForm;
        newForm.Show();
        splashScreenManager.CloseWaitForm();
        return newForm;
    }

    public TForm ShowDialog<TForm>(SplashScreenManager? splashScreenManager, object? query = null,
        bool showDialog = true) where TForm : Form
    {
        // Modal NO se cachea
        var form = _provider.GetRequiredService<TForm>();
        Query = query;
        splashScreenManager ??= new SplashScreenManager(MainView, typeof(WaitForm1), true, true);
        splashScreenManager.ShowWaitForm();
        // Centro respecto al Main si existe
        if (_mainForm != null)
        {
            form.StartPosition = FormStartPosition.CenterParent;
            splashScreenManager.CloseWaitForm();
            form.ShowDialog(_mainForm);
            return form;
        }

        splashScreenManager.CloseWaitForm();
        if (showDialog) form.ShowDialog();
        return form;
    }

    public object? Query { get; set; }
    public XtraForm MainView { get; private set; }
    public AlertControl AlertControl { get; set; }
}