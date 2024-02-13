using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using wellness.RabbitMQ;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://10.0.2.2:5000")  
                    .AllowCredentials());
        });

        services.AddSignalR(hubOptions =>
        {
            hubOptions.EnableDetailedErrors = true;
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseCors("CorsPolicy");
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<NotificationHub>("/notificationHub");
        });
    }
}
