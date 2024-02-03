using wellness.RabbitMQ;

class Program
{
    static void Main()
    {
        var rabbitMQService = new RabbitMQService();
        rabbitMQService.ConsumeNotifications();

        Console.WriteLine("Konzolna aplikacija za RabbitMQ je pokrenuta. Pritisnite ENTER za izlaz.");
        Console.ReadLine();
    }
}