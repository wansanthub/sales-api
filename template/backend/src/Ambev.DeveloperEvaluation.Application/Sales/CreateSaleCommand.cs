using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation.Results;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public string SaleNumber { get; set; } = string.Empty;
        public DateTime SaleDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BranchId { get; set; }
        public List<SaleItem> Items { get; set; } = new();

        public CreateSaleCommand(string saleNumber, DateTime saleDate, Guid customerId, Guid branchId, List<SaleItem> items)
        {
            SaleNumber = saleNumber;
            SaleDate = saleDate;
            CustomerId = customerId;
            BranchId = branchId;
            Items = items;
        }

        public ValidationResult Validate()
        {
            var validator = new CreateSaleCommandValidator();
            return validator.Validate(this);
        }
    }
}
