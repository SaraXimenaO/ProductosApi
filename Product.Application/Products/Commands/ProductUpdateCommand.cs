using MediatR;
using Products.Domain.Entities;
using Products.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Products.Commands;

public record ProductUpdateCommand(
    int productId,
    string Name,
    int Stock,
    string Description,
    decimal Price,
    Status Status
    ) : IRequest;
