using Products.Infrastructure.Ports;
using Products.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Infrastructure.Adapters;

public class GenericRepository<T> : IGenericRepository<T> where T : DomainEntity
{
    readonly ApplicationContext _context;
    readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(Context));
        _dbSet = context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    { 
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

    public void Save() => _context.SaveChanges();
}

