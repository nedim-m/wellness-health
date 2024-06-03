using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using wellness.RabbitMQ;

public class RabbitMQService
{
    private readonly IModel _channel;
    private readonly HubConnection _hubConnection;
    private readonly MailService _mailService;

    private readonly string _host;
    private readonly string _username;
    private readonly string _password;

    public RabbitMQService()
    {

       
        _host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? throw new ArgumentNullException("RABBITMQ_HOST environment variable is not set");
        _username = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? throw new ArgumentNullException("RABBITMQ_USERNAME environment variable is not set");
        _password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? throw new ArgumentNullException("RABBITMQ_PASSWORD environment variable is not set");

        var factory = new ConnectionFactory
        {
            HostName = _host,
            UserName = _username,
            Password = _password
        };

        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();

        _channel.QueueDeclare(queue: "notifications_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

        try
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5630/notificationHub")
                .Build();

            _hubConnection.StartAsync().Wait();
            Console.WriteLine("Povezan na SignalR hub.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Greška prilikom povezivanja na SignalR hub: {ex}");
        }

        _mailService = new MailService();
    }

    public void SendNotification(NotificationData notificationData)
    {
        var message = JsonConvert.SerializeObject(notificationData);
        _channel.BasicPublish(exchange: "", routingKey: "notifications_queue", basicProperties: null, body: Encoding.UTF8.GetBytes(message));
    }

    public void ConsumeNotifications()
    {
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += async (model, ea) =>
        {
            var receivedBody = ea.Body.ToArray();
            var receivedMessage = Encoding.UTF8.GetString(receivedBody);

            var notificationData = JsonConvert.DeserializeObject<NotificationData>(receivedMessage);
            Console.WriteLine($" [x] Received notification: {notificationData}");

            string signalRnotification = $"Mobile id: {notificationData!.UserID}";
            if (notificationData.SentFromMobile)
            {
                signalRnotification = "Desktop";
            }
            else
            {
                _mailService.SendMailNotification(notificationData!);
            }

            await _hubConnection.InvokeAsync("ReceiveNotification", signalRnotification);
        };

        _channel.BasicConsume(queue: "notifications_queue", autoAck: true, consumer: consumer);
    }
}
