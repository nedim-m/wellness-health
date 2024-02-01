using System;
using System.Threading.Tasks;
using Stripe;
using Microsoft.Extensions.Configuration;
using wellness.Service.Database;
using wellness.Service.IServices;
using Microsoft.EntityFrameworkCore;
using wellness.Model.Membership;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                return GenerateResponse(intent,amount,userId,items);
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
                return GenerateResponse(intent,0,0,0);
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
        // Implement your actual Stripe API call for PaymentIntent confirmation
        var service = new PaymentIntentService();
        return await service.ConfirmAsync(paymentIntentId);
    }

    private Dictionary<string, object> GenerateResponse(dynamic intent, int amount, int userId,int membershiptypeId)
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

               // if (userId!=0|| membershiptypeId!=0|| amount!=0)
                     //AddMembership(userId,membershiptypeId,amount);

                return new Dictionary<string, object>
                {
                    { "clientSecret", intent.client_secret },
                    { "status", intent.status }
                };
            default:
                return new Dictionary<string, object> { { "error", "Failed" } };
        }
    }



    private async void AddMembership(int userId,int membershiptypeId, int amount)
    {
       
        var search = new MembershipSearchObj
        {
            UserId=userId,
        };

        var membership = await _membershipService.Get(search);

        if(membership == null)
        {
            var insert = new MembershipPostRequest
            {
                UserId = userId!,
                MemberShipTypeId=membershiptypeId!
            };
          await _membershipService.Insert(insert);
        }
        else
        {
            var membershipId = membership.Result!.FirstOrDefault()!.Id;
            var update = new MembershipUpdateRequest
            {
                MemberShipTypeId=membershiptypeId
            };
            await _membershipService.Update(membershipId, update);
        }

        var transaction = new 
        {
            Amount=amount,
            PaymentMethod="Stripe",
            Currency="BAM",
            Timestamp=DateTime.Now,
            MemberShipTypeId= membershiptypeId,
        };
        
        
        await _transactionService.SaveTransactionAsync(transaction);



       

    }


    


   

}
