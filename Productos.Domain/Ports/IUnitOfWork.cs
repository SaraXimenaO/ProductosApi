namespace Products.Domain.Ports;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken? cancellationToken);
}
