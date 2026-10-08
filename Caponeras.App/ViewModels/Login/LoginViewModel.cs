using Caponeras.App.Helpers;
using Caponeras.App.Views;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.App.ViewModels.Login;

public class LoginViewModel : BaseViewModel
{
    private DataContextCaponeras _context;
    private INavigationService _navigationService;
    public string Error { get; private set; }

    public LoginViewModel(DataContextCaponeras context, INavigationService navigationService)
    {
        _context = context;
        _navigationService = navigationService;
    }

    public async Task<bool> LoginTask(string username, string password)
    {
        var findUsername = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);
        if (findUsername is null)
        {
            Error = "NO existe el usuario con ese nombre";
            return false;
        }

        if (string.Equals(findUsername.Password, password))
        {
            _navigationService.CurrentUser = findUsername;
            return true;
        }
        Error = "Contraseña incorrecta, intente nuevamente";
        return false;

    }

    public void ShowMainView()
    {
        _navigationService.Show<MainView>();
    }
}