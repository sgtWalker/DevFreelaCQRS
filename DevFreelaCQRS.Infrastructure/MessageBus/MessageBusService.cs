using DevFreelaCQRS.Core.Services;
using RabbitMQ.Client;

namespace DevFreelaCQRS.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _factory;
        private const string HOST_NAME = "localhost";

        public MessageBusService()
        {
            _factory = new ConnectionFactory { HostName = HOST_NAME };

        }

        public void Publish(string queue, byte[] message)
        {
            using (var connection = _factory.CreateConnection()) 
            { 
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: message);
                };
            };
        }
    }
}
