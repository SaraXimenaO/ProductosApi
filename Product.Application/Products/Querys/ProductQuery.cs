using MediatR;
using Products.Domain.Dtos;

namespace Products.Application.Products.Querys;

public record ProductQuery(int ProductId) : IRequest<ProductDto>;
