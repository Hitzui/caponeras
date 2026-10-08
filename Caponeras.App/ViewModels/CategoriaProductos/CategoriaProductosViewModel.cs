using System.ComponentModel;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using NLog;

namespace Caponeras.App.ViewModels.CategoriaProductos;

public class CategoriaProductosViewModel : BaseViewModel
{
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
    private CategoriaProductosService _categoriaProductosService;
    private INavigationService _navigationService;
    public BindingList<CategoriaProductoDto> CategoriaProductoBindingList { get; } = new();
    public string ErrorMessage => _categoriaProductosService.ErrorMessage;
    public CategoriaProductosViewModel(CategoriaProductosService categoriaProductosService, INavigationService navigationService)
    {
        _categoriaProductosService = categoriaProductosService;
        _navigationService = navigationService;
    }

    public async Task Load()
    {
        try
        {
            var data = await _categoriaProductosService.GetAllAsync();
            CategoriaProductoBindingList.Clear();
            foreach (var item in data)
            {
                CategoriaProductoBindingList.Add(item);
            }
        }
        catch (Exception e)
        {
            _logger.Error(e);
        }
    }

    public async Task<int> Save(CategoriaProductoDto? categoriaProductoDto)
    {
        if (categoriaProductoDto is null)
        {
            GetMessageAlert(TypeAlert.Warning, "Guardar", "Indique una categoría válida.",
                _navigationService.MainView);
            return -1;
        }
        try
        {
            return await _categoriaProductosService.Save(categoriaProductoDto);
        }
        catch (Exception e)
        {
            _logger.Error(e);
            GetMessageAlert(TypeAlert.Error, "Guardar categoría",
                $"No fue posible guardar la categoría: {e.GetBaseException().Message}",
                _navigationService.MainView);
            return -1;
        }
    }

    public async Task Delete(CategoriaProductoDto row)
    {
        if (row is null || row.IdCategoria <= 0)
        {
            GetMessageAlert(TypeAlert.Warning, "Eliminar", "Seleccione una categoría válida.",
                _navigationService.MainView);
            return;
        }

        var delete = await _categoriaProductosService.Delete(row);
        if (delete > 0)
        {
            CategoriaProductoBindingList.Remove(row);
            GetMessageAlert(TypeAlert.Informacion, "Eliminar", "Se eliminó la categoría correctamente.",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, "Eliminar",
                string.IsNullOrWhiteSpace(_categoriaProductosService.ErrorMessage)
                    ? "No fue posible eliminar la categoría."
                    : _categoriaProductosService.ErrorMessage,
                _navigationService.MainView);
        }

        await Load();
    }
}
