using Ambev.DeveloperEvaluation.Domain.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Ambev.DeveloperEvaluation.ORM.Messaging
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly ConnectionFactory _rabbitMqFactory;

        public MessagePublisher()
        {
            _rabbitMqFactory = new ConnectionFactory() { HostName = "localhost" };
        }

        public async Task PublishEventAsync(string eventType, object eventData)
        {
            await using var connection = await _rabbitMqFactory.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "sales_events", durable: true, exclusive: false, autoDelete: false, arguments: null);
            var message = new { EventType = eventType, Data = eventData };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            var properties = new BasicProperties
            {
                DeliveryMode = DeliveryModes.Persistent
            };

            await channel.BasicPublishAsync(exchange: "", routingKey: "sales_events", false ,basicProperties: properties, body: body);
        }
    }
}