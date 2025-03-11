using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SalesTests
    {
        [Fact]
        public void Should_Calculate_TotalAmount_Correctly_When_Items_Are_Added()
        {
            // Arrange
            var sale = new Sale();

            var item1 = new SaleItem { Quantity = 2, UnitPrice = 50 };
            var item2 = new SaleItem { Quantity = 3, UnitPrice = 30 };

            // Act
            sale.AddItem(item1);
            sale.AddItem(item2);

            // Assert
            sale.TotalAmount.Should().Be((2 * 50) + (3 * 30));
        }

        [Fact]
        public void Should_Calculate_TotalAmount_Correctly_When_Items_Are_Set()
        {
            // Arrange
            var sale = new Sale();

            var items = new List<SaleItem>
            {
                new SaleItem { Quantity = 4, UnitPrice = 25 },
                new SaleItem { Quantity = 1, UnitPrice = 100 }
            };

            // Act
            sale.SetItems(items);

            // Assert
            sale.TotalAmount.Should().Be((4 * 25) + (1 * 100));
        }

        [Fact]
        public void Should_Calculate_TotalAmount_With_Discounts_Applied()
        {
            // Arrange
            var sale = new Sale();

            var item1 = new SaleItem { Quantity = 10, UnitPrice = 20, Discount = 10 };
            var item2 = new SaleItem { Quantity = 5, UnitPrice = 40, Discount = 5 };

            // Act
            sale.SetItems(new List<SaleItem> { item1, item2 });

            // Assert
            sale.TotalAmount.Should().Be(((10 * 20) - 10) + ((5 * 40) - 5));
        }

        [Fact]
        public void Should_Update_TotalAmount_When_New_Item_Is_Added()
        {
            // Arrange
            var sale = new Sale();
            sale.SetItems(new List<SaleItem>
            {
                new SaleItem { Quantity = 1, UnitPrice = 100 }
            });

            var newItem = new SaleItem { Quantity = 2, UnitPrice = 50 };

            // Act
            sale.AddItem(newItem);

            // Assert
            sale.TotalAmount.Should().Be((1 * 100) + (2 * 50));
        }
    }
}
