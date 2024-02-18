using Products.Domain.Test.DataBuilder;

namespace Product.Domain.Test
{
    public class ProductTest
    {
        [Fact]
        public void CalculateDiscountPrice_ReturnsCorrectValue()
        {
            // Arrange
            var product = new ProductBuilder()
                .WithPrice(100.00m)
                .Build();

            // Act
            var discountedPrice = product.calculateDiscountPrice(20);

            // Assert
            Assert.Equal(80.00m, discountedPrice);

        }
    }
}