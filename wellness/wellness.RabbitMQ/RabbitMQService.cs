using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.RabbitMQ
{
    public class RabbitMQService
    {
        private readonly IModel _channel;

       
        private readonly string _connectionString = "amqp://guest:guest@localhost:5672";

        public RabbitMQService()
        {
            var factory = new ConnectionFactory() { Uri = new Uri(_connectionString) };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();

            _channel.QueueDeclare(queue: "notifications_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);
        }

        public void SendNotification(string message)
        {
            _channel.BasicPublish(exchange: "", routingKey: "notifications_queue", basicProperties: null, body: Encoding.UTF8.GetBytes(message));
        }

        public void ConsumeNotifications()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var receivedBody = ea.Body.ToArray();
                var receivedMessage = Encoding.UTF8.GetString(receivedBody);
                Console.WriteLine($" [x] Received notification: {receivedMessage}");
            };

            _channel.BasicConsume(queue: "notifications_queue", autoAck: true, consumer: consumer);
        }
    }
}
