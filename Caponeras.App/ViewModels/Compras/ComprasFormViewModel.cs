using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.Views.Compras;
using DevExpress.Mvvm;
using NLog;
using System.ComponentModel;
using INavigationService = Caponeras.App.Helpers.INavigationService;

namespace Caponeras.App.ViewModels.Compras;

public class ComprasFormViewModel : BaseViewModel
{
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
    private ComprasService _comprasService;
    private INavigationService _navigationService;

    public ComprasFormViewModel(ComprasService comprasService, INavigationService navigationService)
    {
        _comprasService = comprasService;
        _navigationService = navigationService;
        DetalleCompraBindingList.ListChanged += DetalleCompraBindingList_ListChanged;
        SelectedCompra = (ComprasDto?)_navigationService.Query;
    }

    public BindingList<DetalleCompraDto> DetalleCompraBindingList { get; } = new();

    private ComprasDto? _selectedCompra;

    public ComprasDto? SelectedCompra
    {
        get => _selectedCompra;
        set => SetValue(ref _selectedCompra, value);
    }

    private ProductoDto? _selectedProducto;

    public ProductoDto? SelectedProductoDto
    {
        get => _selectedProducto;
        set => SetValue(ref _selectedProducto, value);
    }

    private bool _aplicaIva;

    public bool AplicaIva
    {
        get => _aplicaIva;
        set => SetValue(ref _aplicaIva, value, RecalcularTotales);
    }

    public TotalesCompras Importes
    {
        get => GetValue<TotalesCompras>();
        set => SetValue(value);
    }

    private ProveedoresDto? _selectedProveedor;

    public ProveedoresDto? SelectedProveedor
    {
        get => _selectedProveedor;
        set => SetValue(ref _selectedProveedor, value);
    }

    private void DetalleCompraBindingList_ListChanged(object? sender, ListChangedEventArgs e)
    {
        RecalcularTotales();
    }

    private void RecalcularTotales()
    {
        var importe = 0m;
        foreach (var detalleCompraDto in DetalleCompraBindingList)
        {
            detalleCompraDto.Importe = detalleCompraDto.Cantidad * detalleCompraDto.PrecioUnitario;
            importe += detalleCompraDto.Importe;
        }

        Importes.SubTotal = importe;
        if (AplicaIva)
        {
            Importes.Iva = Importes.SubTotal * 0.15m;
        }
        else
        {
            Importes.Iva = 0m;
        }

        Importes.Total = Importes.SubTotal + Importes.Iva;
    }

    public bool ShowProductoDialog()
    {
        var productDialogView = _navigationService.ShowDialog<ProductoDialogView>();
        if (productDialogView.DialogResult != DialogResult.OK) return false;
        SelectedProductoDto = productDialogView.SelectedProductoDto;
        return true;
    }

    public void AgregarProducto(ImporteCompraDto importeDto)
    {
        if (SelectedProductoDto is null) return;
        var existe = DetalleCompraBindingList
            .Any(x => x.Idproducto == SelectedProductoDto.IdProducto);
        if (existe)
        {
            GetMessageAlert(TypeAlert.Warning, "Agregar", "Ya existe el item en la lista", _navigationService.MainView);
            return;
        }

        var detalle = new DetalleCompraDto
        {
            Iddetalle = 0,
            Idproducto = SelectedProductoDto.IdProducto,
            Cantidad = importeDto.Cantidad,
            PrecioUnitario = importeDto.Precio,
            Importe = importeDto.Importe,
            Codigo = SelectedProductoDto.Codigo,
            Nombre = SelectedProductoDto.Nombre
        };
        DetalleCompraBindingList.Add(detalle);
    }

    public void ShowAlertProducto()
    {
        GetMessageAlert(
            TypeAlert.Error,
            "Seleccionar Producto",
            "Debe Seleccionar un producto para continuar",
            _navigationService.MainView
        );
    }

    public void QuitarItem(DetalleCompraDto selectedValue)
    {
        DetalleCompraBindingList.Remove(selectedValue);
    }

    public void ShowProveedorDialog()
    {
        var proveedorDialog = _navigationService.ShowDialog<ProveedorDialogView>();
        if (proveedorDialog.DialogResult != DialogResult.OK) return;
        SelectedProveedor = proveedorDialog.SelectedProveedor;
    }

    public async Task<bool> Save()
    {
        try
        {
            if (SelectedProveedor is null)
            {
                GetMessageAlert(TypeAlert.Warning, "Proveedor", "Debe seleccionar un proveedor para la compra",
                    _navigationService.MainView);
                return false;
            }

            if (DetalleCompraBindingList.Count <= 0)
            {
                GetMessageAlert(TypeAlert.Warning, "Productos",
                    "Debe haber al menos un producto en la lista para continuar",
                    _navigationService.MainView);
                return false;
            }

            if (Importes.Total <= 0m)
            {
                GetMessageAlert(TypeAlert.Warning, "Compra", "No se han calculado los totales para la compra.",
                    _navigationService.MainView);
                return false;
            }

            if (SelectedCompra is null)
            {
                GetMessageAlert(TypeAlert.Warning, "Compra", "No se ha cargado la compra para guardar.",
                    _navigationService.MainView);
                return false;
            }

            var save = await _comprasService.SaveCompra(SelectedCompra, SelectedProveedor,
                DetalleCompraBindingList.ToList(), Importes);
            if (save)
            {
                GetMessageAlert(TypeAlert.Informacion, "Guardar", "Se ha guardado la compra de forma correcta",
                    _navigationService.MainView);
                Messenger.Default.Send(new CompraGuardadaMessage());
            }
            else
            {
                GetMessageAlert(TypeAlert.Error, "Error", $"No fue posible guardar la compra. {_comprasService.ErrorMessage}",
                    _navigationService.MainView);
            }

            return save;
        }
        catch (Exception e)
        {
            _logger.Error(e);
            return false;
        }
    }

    public class CompraGuardadaMessage
    {
    }

    public async Task LoadDetalleCompra()
    {
        if (SelectedCompra is null)
        {
            return;
        }

        var detalle = await _comprasService.LoadDetalleCompra(SelectedCompra.Idcompra);
        DetalleCompraBindingList.Clear();
        foreach (var detalleCompraDto in detalle)
        {
            DetalleCompraBindingList.Add(detalleCompraDto);
        }
    }
}