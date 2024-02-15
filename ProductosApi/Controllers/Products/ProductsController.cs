using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Products.Querys;

namespace Products.Api.Controllers.Products
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProducts(int productId)
        {
            try
            {
                var productDto = await _mediator.Send(new ProductQuery(productId));
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting product");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
