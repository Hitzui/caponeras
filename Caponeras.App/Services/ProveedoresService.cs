using Caponeras.App.Dto;
using Caponeras.Data.Models;
using Caponeras.Insfraestructura.Repository;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Caponeras.App.Services;

public class ProveedoresService
{
    private IProveedorRepository _proveedorRepository;
    private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

    public ProveedoresService(IProveedorRepository proveedorRepository)
    {
        _proveedorRepository = proveedorRepository;
        Message = string.Empty;
    }

    public string Message { get; private set; }
    public Task<List<ProveedoresDto>> GetAllAsync()
    {
        return _proveedorRepository.Query().Select(p => ProveedoresDto.FromEntity(p)).ToListAsync();
    }

    public async Task<int> Save(ProveedoresDto proveedor)
    {
        Message = string.Empty;

        try
        {
            proveedor.Nombre = proveedor.Nombre?.Trim() ?? string.Empty;
            proveedor.Ruc = proveedor.Ruc?.Trim();
            proveedor.Telefono = proveedor.Telefono?.Trim();
            proveedor.Email = proveedor.Email?.Trim();
            proveedor.Direccion = proveedor.Direccion?.Trim();
            proveedor.Contacto = proveedor.Contacto?.Trim();

            if (string.IsNullOrWhiteSpace(proveedor.Nombre) || string.IsNullOrWhiteSpace(proveedor.Ruc))
            {
                Message = "El nombre y el RUC son obligatorios.";
                return -1;
            }

            var rucEnUso = await _proveedorRepository.Query()
                .AnyAsync(p => p.Ruc == proveedor.Ruc && p.Idproveedor != proveedor.IdProveedor);
            if (rucEnUso)
            {
                Message = "Ya existe un proveedor registrado con ese RUC.";
                return -1;
            }

            if (proveedor.IdProveedor <= 0)
            {
                var ahora = DateTime.Now;
                proveedor.Activo = true;
                if (proveedor.FechaRegistro == default)
                    proveedor.FechaRegistro = ahora;
                if (proveedor.CreatedAt == default)
                    proveedor.CreatedAt = ahora;
                proveedor.UpdatedAt = ahora;
                await _proveedorRepository.AddAsync(ProveedoresDto.ToEntity(proveedor));
            }
            else
            {
                var find = await _proveedorRepository.GetByIdAsync(proveedor.IdProveedor);
                if (find is null)
                {
                    Message = "No existe el proveedor a actualizar";
                    return -1;
                }

                proveedor.UpdatedAt = DateTime.Now;
                ProveedoresDto.UpdateEntity(find, proveedor);
                _proveedorRepository.Update(find);
            }

            return await _proveedorRepository.SaveChangeAsync();
        }
        catch (Exception e)
        {
            _logger.Error(e);
            Message = e.GetBaseException().Message;
            return -10;
        }
    }

    public async Task<int> Delete(ProveedoresDto? proveedorDto)
    {
        if (proveedorDto is null)
        {
            return -3;
        }
        var find = await _proveedorRepository.GetByIdAsync(proveedorDto.IdProveedor);
        if (find is null)
        {
            return -1;
        }

        _proveedorRepository.Remove(find);
        return await _proveedorRepository.SaveChangeAsync();
    }
}
