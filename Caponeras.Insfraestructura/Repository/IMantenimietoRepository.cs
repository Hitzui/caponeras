using Caponeras.Data.Models;

namespace Caponeras.Insfraestructura.Repository;

public interface IMantenimietoRepository : IRepository<Mantenimientos>
{
    Task<Mantenimientos?> GetMantenimientoById(int id);
}