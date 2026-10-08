using System.Windows.Documents;
using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.App.Services;

public class AseguradorasService
{
    private DataContextCaponeras _context;

    public AseguradorasService(DataContextCaponeras context)
    {
        _context = context;
    }

    public Task<List<AseguradorasDto>> GetAseguradoras()
    {
        return _context.Aseguradoras
            .Select(a => new AseguradorasDto(a))
            .ToListAsync();
    }
}