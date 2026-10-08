using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public interface IMantenimientoRepuestosRepository : IRepository<MantenimientoRepuestos>
{
    Task<List<MantenimientoRepuestos>> GetByMantenimientoId(int mantenimientoId);
    void RemoveRange(List<MantenimientoRepuestos> data);
    Task AddRange(List<MantenimientoRepuestos> data);
}