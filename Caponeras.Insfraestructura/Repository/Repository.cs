using Caponeras.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Caponeras.Insfraestructura.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DataContextCaponeras Context;
    protected readonly DbSet<T> DbSet;

    public Repository(DataContextCaponeras context)
    {
        Context = context;
        DbSet = Context.Set<T>();
    }

    public Task<T?> GetByIdAsync(int id)
        => DbSet.FindAsync(id).AsTask();

    public Task<List<T>> GetAllAsync()
        => DbSet.AsNoTracking().ToListAsync();

    public Task AddAsync(T entity)
        => DbSet.AddAsync(entity).AsTask();

    public void Update(T entity)
        => DbSet.Update(entity);

    public void Remove(T entity)
        => DbSet.Remove(entity);

    public IQueryable<T> Query()
        => DbSet.AsNoTracking();

    public Task<int> SaveChangeAsync()
        => Context.SaveChangesAsync();
}
