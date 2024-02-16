using AutoMapper;
using MediatR;
using Products.Domain.Entities;
using Products.Domain.Ports;

namespace Products.Application.Products.Commands;

public class ProductUpdateCommandHandler : AsyncRequestHandler<ProductUpdateCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductUpdateCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    protected override async Task Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        await _productRepository.UpdateAsync(product);
    }
}
