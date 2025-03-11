namespace Ambev.DeveloperEvaluation.Application.Inferfaces
{
    public interface IExternalIdentityService
    {
        Task<string> GetCustomerNameAsync(Guid customerId);
        Task<string> GetBranchNameAsync(Guid branchId);
        Task<string> GetProductNameAsync(Guid productId);
    }
}