using Products.Domain.Test.DataBuilder;

namespace Product.Domain.Test
{
    public class ProductTest
    {
        [Theory]
        [InlineData(100.00, 20, 80.00 )]
        [InlineData(100.00, 40, 60.00)]
        public void CalculateDiscountPrice_ReturnsCorrectValue(decimal price, int percent, decimal expected)
        {
            // Arrange
            var product = new ProductBuilder()
                .WithPrice(price)
                .Build();

            // Act
            var discountedPrice = product.calculateDiscountPrice(percent);

            // Assert
            Assert.Equal(expected, discountedPrice);

        }
    }
}