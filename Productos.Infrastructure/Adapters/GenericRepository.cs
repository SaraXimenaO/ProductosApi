using Products.Domain.Entities;
using Products.Infrastructure.Ports;
using Products.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Products.Infrastructure.Adapters;

public class GenericRepository<T> : IGenericRepository<T> where T : DomainEntity
{
    readonly Context.Context  _context;
    readonly DbSet<T> _dbSet;

    public GenericRepository(Context.Context context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(Context));
        _dbSet = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        _ = entity ?? throw new ArgumentNullException(nameof(entity));
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));
    }

    public void UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
    }
}

