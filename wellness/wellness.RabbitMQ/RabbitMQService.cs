using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;

public class RabbitMQService
{
    private readonly IModel _channel;
    private readonly HubConnection _hubConnection;

    public RabbitMQService()
    {
        var factory = new ConnectionFactory() { Uri = new Uri("amqp://guest:guest@localhost:5672") };
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();

        _channel.QueueDeclare(queue: "notifications_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

        _hubConnection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/notificationHub")
            .Build();

        _hubConnection.StartAsync().Wait();
    }

    public void SendNotification(string message)
    {
        _channel.BasicPublish(exchange: "", routingKey: "notifications_queue", basicProperties: null, body: Encoding.UTF8.GetBytes(message));

        _hubConnection.InvokeAsync("ReceiveNotification", message).Wait();
    }

    public void ConsumeNotifications()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var receivedBody = ea.Body.ToArray();
            var receivedMessage = Encoding.UTF8.GetString(receivedBody);
            Console.WriteLine($" [x] Received notification: {receivedMessage}");

            _hubConnection.InvokeAsync("ReceiveNotification", receivedMessage).Wait();
        };

        _channel.BasicConsume(queue: "notifications_queue", autoAck: true, consumer: consumer);
    }
}
