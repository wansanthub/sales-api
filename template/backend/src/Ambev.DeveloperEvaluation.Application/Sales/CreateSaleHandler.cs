using Ambev.DeveloperEvaluation.Application.Sales;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Messaging;
using Ambev.DeveloperEvaluation.Domain.Repositories;

public class CreateSaleHandler
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMessagePublisher _messagePublisher;

    public CreateSaleHandler(ISaleRepository saleRepository, IMessagePublisher messagePublisher)
    {
        _saleRepository = saleRepository;
        _messagePublisher = messagePublisher;
    }

    public async Task<Sale> Handle(CreateSaleCommand command)
    {
        var sale = new Sale
        {
            SaleNumber = command.SaleNumber,
            SaleDate = command.SaleDate,
            CustomerId = command.CustomerId,
            BranchId = command.BranchId,
            Items = command.Items
        };

        sale.SetItems(command.Items);

        await _saleRepository.AddAsync(sale);
        _messagePublisher.PublishEventAsync("SaleCreated", sale);

        return sale;
    }
}