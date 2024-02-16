using Products.Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Products.Infrastructure.Adapters;

public class UnitOfWork : IUnitOfWork
{
    private readonly Context.ApplicationContext _context;
    public UnitOfWork(Context.ApplicationContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(CancellationToken? cancellationToken)
    {
        var token = CancellationToken.None;
        await _context.SaveChangesAsync(token);
    }
}
