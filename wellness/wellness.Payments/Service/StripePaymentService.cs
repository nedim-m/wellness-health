using System;
using System.Threading.Tasks;
using Stripe;
using Microsoft.Extensions.Configuration;


public class StripePaymentService : IStripePaymentService
{
    private readonly IConfiguration _configuration;

    public StripePaymentService(IConfiguration configuration)
    {
        _configuration = configuration;
        StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
    }

    public async Task<Dictionary<string, object>> ProcessPaymentMethodIdAsync(
         string paymentMethodId,
         int items,
         string currency,
         bool useStripeSdk)
    {
        // Implement the logic to process payment by payment method ID
        // Call your actual business logic or Stripe API calls here

        var orderAmount = CalculateOrderAmount(items);

        try
        {
            if (!string.IsNullOrEmpty(paymentMethodId))
            {
                // Create new PaymentIntent with a PaymentMethod ID
                var parameters = new PaymentIntentCreateOptions
                {
                    Amount = orderAmount,
                    Confirm = true,
                    ConfirmationMethod = "manual",
                    Currency = currency,
                    PaymentMethod = paymentMethodId,
                    UseStripeSdk = useStripeSdk
                };

                // Replace the following line with your actual Stripe API call
                var intent = await CallYourStripeApiForPaymentIntentCreation(parameters);

                // After create, if the PaymentIntent's status is succeeded, fulfill the order
                Console.WriteLine($"Intent: {intent}");
                return GenerateResponse(intent);
            }

            throw new ArgumentException("Payment method ID is invalid");
        }
        catch (Exception e)
        {
            // Handle exceptions, log errors, etc.
            return new Dictionary<string, object> { { "error", e.Message } };
        }
    }

    public async Task<Dictionary<string, object>> ProcessPaymentIntentIdAsync(string paymentIntentId)
    {
        // Implement the logic to process payment by payment intent ID
        // Call your actual business logic or Stripe API calls here

        try
        {
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                // Confirm the PaymentIntent to finalize payment
                var intent = await CallYourStripeApiForPaymentIntentConfirmation(paymentIntentId);

                // After confirm, if the PaymentIntent's status is succeeded, fulfill the order
                return GenerateResponse(intent);
            }

            throw new ArgumentException("Payment intent ID is invalid");
        }
        catch (Exception e)
        {
            // Handle exceptions, log errors, etc.
            return new Dictionary<string, object> { { "error", e.Message } };
        }
    }

    // Replace the following methods with your actual implementation
    private int CalculateOrderAmount(int membershiptypId)
    {
        // Implement your order amount calculation logic
        return 100; // Replace with your actual calculation
    }

    private async Task<dynamic> CallYourStripeApiForPaymentIntentCreation(object parameters)
    {
        try
        {
            // Log the type information for debugging
            Console.WriteLine($"Type of parameters: {parameters.GetType().FullName}");

            if (parameters is Stripe.PaymentIntentCreateOptions options)
            {
                // Ensure that return_url is set
                options.ReturnUrl = "https://your-website.com/success"; // Replace with your actual success URL

                var service = new PaymentIntentService();
                var intent = await service.CreateAsync(options);

                return new { client_secret = intent.ClientSecret, status = intent.Status };
            }
            else
            {
                throw new ArgumentException("Invalid type for PaymentIntentCreateOptions");
            }
        }
        catch (Exception e)
        {
            // Handle exceptions, log errors, etc.
            Console.WriteLine($"Error creating PaymentIntent: {e.Message}");
            throw;
        }
    }




    private async Task<dynamic> CallYourStripeApiForPaymentIntentConfirmation(string paymentIntentId)
    {
        // Implement your actual Stripe API call for PaymentIntent confirmation
        var service = new PaymentIntentService();
        return await service.ConfirmAsync(paymentIntentId);
    }

    private Dictionary<string, object> GenerateResponse(dynamic intent)
    {
        // Implement your response generation logic
        switch (intent.status)
        {
            case "requires_action":
                return new Dictionary<string, object>
                {
                    { "clientSecret", intent.client_secret },
                    { "requiresAction", true },
                    { "status", intent.status }
                };
            case "requires_payment_method":
                return new Dictionary<string, object>
                {
                    { "error", "Your card was denied, please provide a new payment method" }
                };
            case "succeeded":
                Console.WriteLine("💰 Payment received!");
                return new Dictionary<string, object>
                {
                    { "clientSecret", intent.client_secret },
                    { "status", intent.status }
                };
            default:
                return new Dictionary<string, object> { { "error", "Failed" } };
        }
    }
}
