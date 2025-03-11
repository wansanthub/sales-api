using Ambev.DeveloperEvaluation.Application.Inferfaces;

namespace Ambev.DeveloperEvaluation.ORM.Services
{
    public class ExternalIdentityService : IExternalIdentityService
    {
        public Task<string> GetCustomerNameAsync(Guid customerId) => Task.FromResult($"Customer-{customerId}");
        public Task<string> GetBranchNameAsync(Guid branchId) => Task.FromResult($"Branch-{branchId}");
        public Task<string> GetProductNameAsync(Guid productId) => Task.FromResult($"Product-{productId}");
    }
}
