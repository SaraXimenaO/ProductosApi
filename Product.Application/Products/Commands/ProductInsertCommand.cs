using MediatR;
using Products.Domain.Entities;

namespace Products.Application.Products.Commands;

public record ProductInsertCommand(
    string Name,
    int Stock,
    string Description,
    decimal Price
    ) : IRequest<Product>;
