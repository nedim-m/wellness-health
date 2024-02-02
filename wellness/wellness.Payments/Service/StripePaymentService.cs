using System;
using System.Threading.Tasks;
using Stripe;
using Microsoft.Extensions.Configuration;
using wellness.Service.Database;
using wellness.Service.IServices;
using Microsoft.EntityFrameworkCore;
using wellness.Model.Membership;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Stripe.FinancialConnections;
using wellness.Models.User;

public class StripePaymentService : IStripePaymentService
{
    private readonly IConfiguration _configuration;
    private readonly DbWellnessContext _context;
    private readonly ITransactionService _transactionService;
    private readonly IMembershipService _membershipService;


    public StripePaymentService(IConfiguration configuration, DbWellnessContext context, ITransactionService transactionService, IMembershipService membershipService)
    {
        _configuration = configuration;
        StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        _context=context;
        _transactionService=transactionService;
        _membershipService=membershipService;
    }

    public async Task<Dictionary<string, object>> ProcessPaymentMethodIdAsync(
     string paymentMethodId,
     int items,
     string currency,
     bool useStripeSdk, int userId)
    {
        // Implement the logic to process payment by payment method ID
        // Call your actual business logic or Stripe API calls here

        var amount = await CalculateOrderAmount(items);

        try
        {
            if (!string.IsNullOrEmpty(paymentMethodId))
            {
                // Create new PaymentIntent with a PaymentMethod ID
                var parameters = new PaymentIntentCreateOptions
                {
                    Amount = amount,
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
                var response = GenerateResponse(intent);

                // Check if membership should be added
                if (ShouldAddMembership(response))
                {
                    await AddMembership(userId, items, amount);
                }

                return response;
            }

            throw new ArgumentException("Payment method ID is invalid");
        }
        catch (Exception e)
        {
            // Handle exceptions, log errors, etc.
            return new Dictionary<string, object> { { "error", e.Message } };
        }
    }

    private bool ShouldAddMembership(Dictionary<string, object> response)
    {

        if (response.TryGetValue("status", out var status) && status.ToString() == "succeeded")
        {
            return true;
        }

        return false;
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

                var response = GenerateResponseAfterConfirmation(intent);
                if (ShouldAddMembership(response))
                {
                    //await AddMembership(userId, items, amount); //can you refactor this code?
                }
                return response;
            }

            throw new ArgumentException("Payment intent ID is invalid");
        }
        catch (Exception e)
        {
            // Handle exceptions, log errors, etc.
            return new Dictionary<string, object> { { "error", e.Message } };
        }
    }


    private async Task<int> CalculateOrderAmount(int membershipTypeId)
    {
        var membershipType = await _context.MembershipTypes.FindAsync(membershipTypeId);

        if (membershipType == null)
        {
            throw new ArgumentException("There is no this type of membership");
        }

        int amount = Convert.ToInt32(membershipType.Price * 100);

        return amount;
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
        try
        {
            // Set the return_url for the confirmation
            var options = new PaymentIntentConfirmOptions
            {
                ReturnUrl = "https://your-website.com/success", // Replace with your custom URL scheme
            };

            var service = new PaymentIntentService();
            return await service.ConfirmAsync(paymentIntentId, options);
        }
        catch (Exception e)
        {
            // Handle exceptions, log errors, etc.
            Console.WriteLine($"Error confirming PaymentIntent: {e.Message}");
            throw;
        }
    }




    private Dictionary<string, object> GenerateResponse(dynamic intent)
    {


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

    private Dictionary<string, object> GenerateResponseAfterConfirmation(dynamic intent)
    {




        switch (intent.Status)
        {
            case "requires_action":
                return new Dictionary<string, object>
                {
                    { "clientSecret", intent.ClientSecret },
                    { "requiresAction", true },
                    { "status", intent.Status }
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
                    { "clientSecret", intent.ClientSecret },
                    { "status", intent.Status }
                };
            default:
                return new Dictionary<string, object> { { "error", "Failed" } };
        }
    }


    private async Task AddMembership(int userId, int membershipTypeId, int amount)
    {
        var search = new MembershipSearchObj
        {
            UserId = userId,
        };

        var membership = await _membershipService.Get(search);

        if (membership.Count==0)
        {
            var insert = new MembershipPostRequest
            {
                UserId = userId!,
                MemberShipTypeId = membershipTypeId!
            };

            try
            {
                await _membershipService.Insert(insert);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, rethrow, etc.)
                Console.WriteLine($"Error inserting membership: {ex.Message}");
            }
        }
        else
        {
            var membershipId = membership.Result?.FirstOrDefault()?.Id;

            if (membershipId.HasValue)
            {
                var update = new MembershipUpdateRequest
                {
                    MemberShipTypeId = membershipTypeId
                };

                try
                {
                    await _membershipService.Update(membershipId.Value, update);
                }
                catch (Exception ex)
                {
                    // Handle the exception (log, rethrow, etc.)
                    Console.WriteLine($"Error updating membership: {ex.Message}");
                }
            }
        }

        var transaction = new
        {
            Amount = amount,
            PaymentMethod = "Stripe",
            Currency = "BAM",
            Timestamp = DateTime.Now,
            MemberShipTypeId = membershipTypeId,
        };

        try
        {
            await _transactionService.SaveTransactionAsync(transaction);
        }
        catch (Exception ex)
        {
            // Handle the exception (log, rethrow, etc.)
            Console.WriteLine($"Error saving transaction: {ex.Message}");
        }
    }








}