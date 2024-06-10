using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Org.BouncyCastle.Security;
using wellness.RabbitMQ;

partial class Program
{
    static void Main()
    {
        string portEnv = Environment.GetEnvironmentVariable("SIGNAL_R_PORT") ?? "5630";

        int _hubPort;

        if (!int.TryParse(portEnv, out _hubPort))
        {
            throw new ArgumentException("SIGNAL_R_PORT environment variable is not a valid integer");
        }

        var host = CreateWebHostBuilder(_hubPort).Build();
        host.Start();

        var rabbitMQService = new RabbitMQService();
        rabbitMQService.ConsumeNotifications();

        Console.WriteLine("Konzolna aplikacija za RabbitMQ je pokrenuta. Pritisnite ENTER za izlaz.");
        Console.ReadLine();

        Task.Delay(Timeout.Infinite).Wait();

        host.StopAsync().Wait();
    }

    private static IWebHostBuilder CreateWebHostBuilder(int port) =>
        WebHost.CreateDefaultBuilder()
            .UseStartup<Startup>()
            .UseKestrel(options =>
            {
                options.Listen(System.Net.IPAddress.IPv6Any, port);
            });
}
