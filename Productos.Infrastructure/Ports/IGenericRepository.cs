using Products.Domain.Entities;

namespace Products.Infrastructure.Ports;

    public interface IRepository<T> where T : DomainEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        void UpdateAsync(T entity);

    }

