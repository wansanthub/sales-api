
namespace Ambev.DeveloperEvaluation.Domain.Messaging
{
    public interface IMessagePublisher
    {
        Task PublishEventAsync(string eventType, object eventData);
    }
}
