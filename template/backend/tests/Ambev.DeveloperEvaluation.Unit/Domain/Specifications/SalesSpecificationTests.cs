using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications
{
    public class SalesSpecificationTests
    {
        [Fact]
        public void Should_Apply_Discount_Based_On_Quantity()
        {
            var saleItem = new SaleItem { Quantity = 10, UnitPrice = 20 };

            if (saleItem.Quantity >= 10 && saleItem.Quantity <= 20)
                saleItem.Discount = saleItem.TotalAmount * 0.2m;

            saleItem.Discount.Should().Be(10 * 20 * 0.2m);
        }
    }
}
