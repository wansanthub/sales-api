using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task AddAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task DeleteAsync(Guid saleId);
        Task<Sale> GetByIdAsync(Guid saleId);
        Task<List<Sale>> GetAllAsync();
    }
}
