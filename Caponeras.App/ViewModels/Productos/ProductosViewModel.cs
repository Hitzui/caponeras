using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.Views.Productos;
using DevExpress.Mvvm;
using NLog;
using System.ComponentModel;
using static Caponeras.App.ViewModels.Productos.ProductosFormViewModel;

namespace Caponeras.App.ViewModels.Productos;

public class ProductosViewModel : BaseViewModel, ICrudViewModel
{
    private ProductosService _productosService;
    private Helpers.INavigationService _navigationService;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
    private ProductoDto? selectedProductoDto;
    public BindingList<ProductoDto> ProdctoBindingList { get; } = new();

    public ProductosViewModel(ProductosService productosService, Helpers.INavigationService navigationService)
    {
        _productosService = productosService;
        _navigationService = navigationService;
        Messenger.Default.Register<ProductoGuardadoMessage>(
            this,
            async void (_) =>
            {
                try
                {
                    await Load();
                }
                catch (Exception e)
                {
                    _logger.Error(e);
                }
            }
        );
    }

    public async Task Load()
    {
        var getAll = await _productosService.GetAll();
        ProdctoBindingList.Clear();
        foreach (var item in getAll)
        {
            item.Imagen = await _productosService.DescargarImagenAsync(item.UrlImage);
            ProdctoBindingList.Add(item);
        }
    }

    public void ItemAddClick(ProductoDto? producto)
    {
        _navigationService.ShowDialog<ProductosFormView>(query: producto);
    }

    public async Task DeleteAsync<TDto>(TDto? dto)
    {
        try
        {
            if (dto is not ProductoDto productoDto)
            {
                GetMessageAlert(TypeAlert.Warning, "Eliminar", "Debe indicar un registro a eliminar",
                    _navigationService.MainView);
                return;
            }

            var result = await _productosService.Delete(productoDto);
            if (result > 0)
            {
                Messenger.Default.Send(new ProductoGuardadoMessage());
                GetMessageAlert(TypeAlert.Success, "Eliminar", "Se ha eliminado el registro de forma correcta",
                    _navigationService.MainView);
            }
            else
            {
                GetMessageAlert(TypeAlert.Error, "Eliminar",
                    string.IsNullOrWhiteSpace(_productosService.ErrorMessage)
                        ? "No fue posible eliminar el registro."
                        : _productosService.ErrorMessage,
                    _navigationService.MainView);
            }
        }
        catch (Exception e)
        {
            _logger.Error(e);
        }
    }

    public Task SaveAsync<TDto>(TDto? dto)
    {
        return SaveProductoAsync(dto);
    }

    private async Task SaveProductoAsync<TDto>(TDto? dto)
    {
        if (dto is not ProductoDto productoDto)
        {
            GetMessageAlert(TypeAlert.Warning, "Guardar producto", "Indique un producto válido.",
                _navigationService.MainView);
            return;
        }

        var result = await _productosService.Save(productoDto);
        if (result > 0)
        {
            Messenger.Default.Send(new ProductoGuardadoMessage());
            GetMessageAlert(TypeAlert.Success, "Guardar producto", "El producto se guardó correctamente.",
                _navigationService.MainView);
        }
        else
        {
            GetMessageAlert(TypeAlert.Error, "Guardar producto",
                string.IsNullOrWhiteSpace(_productosService.ErrorMessage)
                    ? "No fue posible guardar el producto."
                    : _productosService.ErrorMessage,
                _navigationService.MainView);
        }
    }

    public void EditAsync<TDto>(TDto? dto)
    {
        if (dto is not ProductoDto productoDto)
        {
            GetMessageAlert(TypeAlert.Warning, "Editar producto", "Seleccione un producto.",
                _navigationService.MainView);
            return;
        }

        selectedProductoDto = productoDto;
        _navigationService.Query = productoDto;
        _navigationService.ShowDialog<ProductosFormView>(query: productoDto);
    }

    public void AddAsync()
    {
        selectedProductoDto = null;
        _navigationService.Query = null;
        _navigationService.ShowDialog<ProductosFormView>();
    }

    public void SetSelectedItem(ProductoDto? productoDto)
    {
        selectedProductoDto = productoDto;
        _navigationService.Query = productoDto;
    }
}
