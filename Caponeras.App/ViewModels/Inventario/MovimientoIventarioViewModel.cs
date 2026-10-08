using System.ComponentModel;
using System.Diagnostics;
using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using Caponeras.App.Views.Reportes.Inventario;
using DevExpress.Data.Linq;
using DevExpress.XtraEditors;

namespace Caponeras.App.ViewModels.Inventario;

public class MovimientoIventarioViewModel : BaseViewModel
{
    private MovimientoInventarioService _service;
    private INavigationService _navigationService;
    public int PageSize { get; set; } = 10;
    public int CurrentPage { get; private set; }
    public int TotalRecords { get; private set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);

    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }
    public object? Tipo { get; set; }
    public object? Referencia { get; set; }
    public string? SearchProducto { get; set; }

    public BindingList<MovimientoInventarioGridDto> Items { get; } = new();

    public MovimientoIventarioViewModel(INavigationService navigationService, MovimientoInventarioService service)
    {
        _navigationService = navigationService;
        _service = service;
    }

    public async Task LoadPageAsync()
    {
        var start = CurrentPage * PageSize;

        var result = await _service.Search(
            Desde, Hasta, Tipo, Referencia, SearchProducto, start, PageSize);

        TotalRecords = result.Total;

        Items.Clear();
        foreach (var item in result.Data)
            Items.Add(item);
    }

    public async Task NextPageAsync()
    {
        if (CurrentPage < TotalPages - 1)
        {
            CurrentPage++;
            await LoadPageAsync();
        }
    }

    public async Task PreviousPageAsync()
    {
        if (CurrentPage > 0)
        {
            CurrentPage--;
            await LoadPageAsync();
        }
    }

    public async Task FirstPageAsync()
    {
        CurrentPage = 0;
        await LoadPageAsync();
    }

    public async Task LastPageAsync()
    {
        CurrentPage = TotalPages - 1;
        await LoadPageAsync();
    }

    public async Task ShowReporteInventario(DateTime desde, DateTime hasta)
    {
        var datos = await _service.GetReporteInventario(desde, hasta);

        if (!datos.Any())
        {
            XtraMessageBox.Show(
                "No se encontraron movimientos.",
                "Inventario",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }

        var reporte = new ReporteInventario();
        reporte.Parameters[0].Value = desde;
        reporte.Parameters[1].Value = hasta;
        reporte.DataSource = datos;

        HelperMethods.LoadReport(reporte, "Movimiento de Inventario");
    }
}