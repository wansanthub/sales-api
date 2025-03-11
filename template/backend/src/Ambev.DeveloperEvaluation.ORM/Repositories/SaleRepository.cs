using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly List<Sale> _sales = new();

        public async Task AddAsync(Sale sale)
        {
            _sales.Add(sale);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Sale sale)
        {
            var existingSale = _sales.FirstOrDefault(s => s.Id == sale.Id);
            if (existingSale != null)
            {
                _sales.Remove(existingSale);
                _sales.Add(sale);
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid saleId)
        {
            var sale = _sales.FirstOrDefault(s => s.Id == saleId);
            if (sale != null)
            {
                _sales.Remove(sale);
            }
            await Task.CompletedTask;
        }

        public async Task<Sale> GetByIdAsync(Guid saleId)
        {
            return await Task.FromResult(_sales.FirstOrDefault(s => s.Id == saleId));
        }

        public async Task<List<Sale>> GetAllAsync()
        {
            return await Task.FromResult(_sales);
        }
    }
}