using Xunit;
using NorthwindCatalog.Services.DTOs;
namespace NorthwindCatalog.Tests
{
    public class ProductTests
    {
        [Fact]
        public void InventoryValue_Should_Return_Correct_Value()
        {
            var product = new ProductDto
            {
                ProductName = "Chai",
                UnitPrice = 20,
                UnitsInStock = 5
            };

            var result = product.InventoryValue;

            Assert.Equal(100, result);
        }

        [Fact]
        public void InventoryValue_Should_Return_Zero_When_Stock_Zero()
        {
            var product = new ProductDto
            {
                ProductName = "Coffee",
                UnitPrice = 50,
                UnitsInStock = 0
            };

            var result = product.InventoryValue;

            Assert.Equal(0, result);
        }

        [Fact]
        public void InventoryValue_Should_Return_Zero_When_Price_Zero()
        {
            var product = new ProductDto
            {
                ProductName = "Milk",
                UnitPrice = 0,
                UnitsInStock = 10
            };

            var result = product.InventoryValue;

            Assert.Equal(0, result);
        }
    }
}