using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using wellness.RabbitMQ;

partial class Program
{
    static void Main()
    {
        var host = CreateWebHostBuilder().Build();
        host.Start();

        var rabbitMQService = new RabbitMQService();
        rabbitMQService.ConsumeNotifications();

        Console.WriteLine("Konzolna aplikacija za RabbitMQ je pokrenuta. Pritisnite ENTER za izlaz.");
        Console.ReadLine();

        Task.Delay(Timeout.Infinite).Wait();

        host.StopAsync().Wait();
    }

    private static IWebHostBuilder CreateWebHostBuilder() =>
        WebHost.CreateDefaultBuilder()
            .UseStartup<Startup>()
            .UseKestrel(options =>
            {
                // Omogući podršku za IPv6
                options.Listen(System.Net.IPAddress.IPv6Any, 5630);
            });
}
