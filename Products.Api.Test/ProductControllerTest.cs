using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Products.Api.Controllers.Products;
using Products.Application.Products.Commands;
using Products.Application.Products.Querys;
using Products.Domain.Dtos;
using Products.Domain.Entities;

namespace Products.Api.Test
{
    public class ProductControllerTest
    {

        [Fact]
        public async Task InsertProduct_ReturnsOkResult()
        {
            // Arrange
            var productCommand = new ProductInsertCommand("Producto Prueba", 10, "Prueba", 1000);

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ProductInsertCommand>(), default(CancellationToken)))
                .ReturnsAsync(new Product());

            var loggerMock = new Mock<ILogger<ProductsController>>();
            var controller = new ProductsController(loggerMock.Object, mediatorMock.Object);

            // Act
            var result = await controller.InsertProduct(productCommand);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateProducts_ReturnsOkResult()
        {
            // Arrange
            var productCommand = new ProductUpdateCommand(3, "Producto Prueba", 5, "Prueba actualizar", 1200, Domain.Enums.Status.Active); 
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ProductUpdateCommand>(), default(CancellationToken)))
                .Returns(Task.FromResult(Unit.Value));

            var loggerMock = new Mock<ILogger<ProductsController>>();
            var controller = new ProductsController(loggerMock.Object, mediatorMock.Object);

            // Act
            var result = await controller.UpdateProducts(productCommand);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetProducts_ReturnsOkResult()
        {
            // Arrange
            int productId = 1;
            var productDto = new ProductDto(3, "Producto de Prueba", "Active", 10, "Producto de peueba",1000,20,800);

            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(m => m.Send(It.IsAny<ProductQuery>(), default(CancellationToken)))
                .ReturnsAsync(productDto);

            var loggerMock = new Mock<ILogger<ProductsController>>();
            var controller = new ProductsController(loggerMock.Object, mediatorMock.Object);

            // Act
            var result = await controller.GetProducts(productId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

    }
}