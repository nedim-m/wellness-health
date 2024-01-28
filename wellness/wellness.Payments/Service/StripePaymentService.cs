// StripePaymentService.cs

using System;
using System.Threading.Tasks;
using Stripe;
using Microsoft.Extensions.Configuration;
using wellness.Payments.IService;

public class StripePaymentService : IStripePaymentService
{
    private readonly IConfiguration _configuration;

    public StripePaymentService(IConfiguration configuration)
    {
        _configuration = configuration;
        StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
    }

    public async Task<string> CreatePaymentIntent(decimal amount, string currency)
    {
        try
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)amount * 100, // Stripe amounts are in cents
                Currency = currency,
            };

            var service = new PaymentIntentService();
            var paymentIntent = await service.CreateAsync(options);

            return paymentIntent.ClientSecret;
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately for your application
            Console.WriteLine($"Error creating payment intent: {ex.Message}");
            throw;
        }
    }

    // Add other methods for handling Stripe-related operations as needed
}
