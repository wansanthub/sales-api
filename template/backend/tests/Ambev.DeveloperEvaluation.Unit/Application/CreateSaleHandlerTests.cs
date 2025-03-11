using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Messaging;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateSaleHandlerTests
    {
        private readonly ISaleRepository _repository;
        private readonly IMessagePublisher _messagePublisher;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _repository = Substitute.For<ISaleRepository>();
            _messagePublisher = Substitute.For<IMessagePublisher>();
            _handler = new CreateSaleHandler(_repository, _messagePublisher);
        }

        [Fact]
        public async Task Should_Create_Sale()
        {
            var saleItemList = new List<SaleItem>
            {
                new SaleItem { ProductName = "Test" }
            };

            var command = new CreateSaleCommand("S123", DateTime.UtcNow, Guid.NewGuid(), Guid.NewGuid(), saleItemList);
            await _handler.Handle(command);

            await _repository.Received(1).AddAsync(Arg.Any<Sale>());
        }
    }
}
