using MailKit;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Pkix;
using wellness.Payments.IService;
using wellness.RabbitMQ;
using wellness.Service.Database;
using wellness.Service.IServices;
using wellness.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IStripePaymentService, StripePaymentService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IMembershipService, MembershipService>();
builder.Services.AddScoped<IPayPalService, PayPalService>();
builder.Services.AddAutoMapper(typeof(AuthService));
builder.Services.AddScoped<wellness.RabbitMQ.MailService>();



builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(builder => builder.AddConsole());

builder.Services.AddDbContext<DbWellnessContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableServiceProviderCaching(false); 
}, ServiceLifetime.Scoped);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
