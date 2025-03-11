using Ambev.DeveloperEvaluation.Application.Inferfaces;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Messaging;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMessagePublisher _messagePublisher;
        private readonly IExternalIdentityService _externalIdentityService;

        public SaleService(ISaleRepository saleRepository, IMessagePublisher messagePublisher, IExternalIdentityService externalIdentityService)
        {
            _saleRepository = saleRepository;
            _messagePublisher = messagePublisher;
            _externalIdentityService = externalIdentityService;
        }

        public async Task<Sale> CreateSaleAsync(Sale sale)
        {
            sale.CustomerName = await _externalIdentityService.GetCustomerNameAsync(sale.CustomerId);
            sale.BranchName = await _externalIdentityService.GetBranchNameAsync(sale.BranchId);

            foreach (var item in sale.Items)
            {
                item.ProductName = await _externalIdentityService.GetProductNameAsync(item.ProductId);
                ApplyDiscountRules(item);
            }

            await _saleRepository.AddAsync(sale);
            _messagePublisher.PublishEventAsync("SaleCreated", sale);
            return sale;
        }

        private static void ApplyDiscountRules(SaleItem item)
        {
            if (item.Quantity > 20)
                throw new InvalidOperationException("Cannot sell more than 20 identical items.");

            if (item.Quantity >= 10)
                item.Discount = item.UnitPrice * item.Quantity * 0.2m;
            else if (item.Quantity >= 4)
                item.Discount = item.UnitPrice * item.Quantity * 0.1m;
            else
                item.Discount = 0;
        }
    }
}