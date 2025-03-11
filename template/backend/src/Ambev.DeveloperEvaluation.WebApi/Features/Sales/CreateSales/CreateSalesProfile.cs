using Ambev.DeveloperEvaluation.Application.Sales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales
{
    public class CreateSalesProfile : Profile
    {
        public CreateSalesProfile()
        {
            CreateMap<CreateSalesRequest, CreateSaleCommand>();
            CreateMap<CreateSaleResult, CreateSalesResponse>();
        }
    }
}
