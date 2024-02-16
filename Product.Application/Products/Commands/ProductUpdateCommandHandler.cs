using AutoMapper;
using MediatR;
using Products.Domain.Entities;
using Products.Domain.Ports;

namespace Products.Application.Products.Commands;

public class ProductUpdateCommandHandler : AsyncRequestHandler<ProductUpdateCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IResponseTimeLogger _responseTimeLogger;

    public ProductUpdateCommandHandler(IProductRepository productRepository, IMapper mapper, IResponseTimeLogger responseTimeLogger)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _responseTimeLogger = responseTimeLogger;
    }

    protected override async Task Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        DateTime requestTime = DateTime.Now;
        var product = _mapper.Map<Product>(request);
        await _productRepository.UpdateAsync(product);

        _responseTimeLogger.LogResponseTime(requestTime, nameof(ProductUpdateCommand));
    }
}
