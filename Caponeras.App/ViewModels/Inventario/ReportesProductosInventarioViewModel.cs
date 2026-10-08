using Caponeras.Data.Models;

namespace Caponeras.App.ViewModels.Inventario;

public class ReportesProductosInventarioViewModel : BaseViewModel
{
    private readonly DataContextCaponeras _context;

    public ReportesProductosInventarioViewModel(DataContextCaponeras context)
    {
        _context = context;
    }

    public List<VwProductosInventarios> ProductosInventariosList()
    {
        return _context.VwProductosInventarios.ToList();
    }
}