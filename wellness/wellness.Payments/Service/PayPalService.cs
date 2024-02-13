using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using wellness.Model.Membership;
using wellness.Payments.IService;
using wellness.Payments.Model;
using wellness.RabbitMQ;
using wellness.Service.Database;
using wellness.Service.IServices;

public class PayPalService : IPayPalService
{
    private readonly IConfiguration _configuration;
    private readonly DbWellnessContext _context;
    private readonly ITransactionService _transactionService;
    private readonly IMembershipService _membershipService;
    private readonly MailService _mailService;

    public PayPalService(IConfiguration configuration, MailService mailService, IMembershipService membershipService, ITransactionService transactionService, DbWellnessContext context)
    {
        _configuration = configuration;
        _mailService=mailService;
        _membershipService=membershipService;
        _transactionService=transactionService;
        _context=context;
    }

    public async Task<PayPalOrderResponse> CreateOrderAsync(decimal amount, string currency)
    {
        try
        {
            var request = new OrdersCreateRequest();
            request.Headers.Add("prefer", "return=representation");

            request.RequestBody(BuildRequestBody(amount, currency));

            var client = new PayPalHttpClient(GetPayPalEnvironment());

            var response = await client.Execute(request);
            var result = response.Result<Order>();

            var approvalUrl = result.Links.FirstOrDefault(link => link.Rel.Equals("approve", StringComparison.OrdinalIgnoreCase))?.Href;

            return new PayPalOrderResponse
            {
                OrderId = result.Id,
                ApprovalUrl = approvalUrl,
            };
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to create order: {ex}");
            throw;
        }
    }

    


    public async Task<bool> CapturePaymentAsync(PayPalCaptureModel request)
    {
       
        if(request.OrderId != null)
        {
            await AddMembership(request.UserId, request.MemberShipTypeId, request.Amount);

            return true;
        }
        return false;
       
    }



    private PayPalEnvironment GetPayPalEnvironment()
    {
        return new SandboxEnvironment(_configuration["Paypal:ClientId"], _configuration["Paypal:Secret"]);
        
    }

    private OrderRequest BuildRequestBody(decimal amount, string currency)
    {
        var orderRequest = new OrderRequest()
        {
            CheckoutPaymentIntent = "CAPTURE",
            PurchaseUnits = new List<PurchaseUnitRequest>()
        {
            new PurchaseUnitRequest()
            {
                AmountWithBreakdown = new AmountWithBreakdown()
                {
                    CurrencyCode = currency,
                    Value = amount.ToString(),
                },
            },
        },
            ApplicationContext = new ApplicationContext()
            {
                ReturnUrl = "https://www.example.com/success",
                CancelUrl = "https://www.example.com/cancel",
                UserAction = "PAY_NOW"  
            }
        };

        return orderRequest;
    }



    private async Task AddMembership(int userId, int membershipTypeId, decimal amount)
    {
        var search = new MembershipSearchObj
        {
            UserId = userId,
        };

        var user = await _context.Users.FindAsync(userId);
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

                    Console.WriteLine($"Error updating membership: {ex.Message}");
                }
            }
        }

        var transaction = new
        {
            Amount = amount,
            PaymentMethod = "PayPal",
            Currency = "EUR",
            Timestamp = DateTime.Now,
            MemberShipTypeId = membershipTypeId,
        };

        try
        {
            await _transactionService.SaveTransactionAsync(transaction);
            await SendMail(user!.Email, membershipTypeId, amount);
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error saving transaction: {ex.Message}");
        }
    }


    private async Task SendMail(string email, int membershipTypeId, decimal amount)
    {
        var membershipType = await _context.MembershipTypes.FindAsync(membershipTypeId);
        var timestamp = DateTime.Now;

        decimal price = amount;
        string subject = "Potvrda plačanja članstva";
        string body = $"Hvala Vam na uplati članarine : {membershipType!.Name}. \n Uspješno ste uplatili {price} EUR putem PayPala! \n Datum uplate: {timestamp.ToShortDateString()}, \n vrijeme uplate: {timestamp.ToShortTimeString()}. Lijep pozdrav i radujemo se našoj saradnji. Wellness centar - Health.";

        _mailService.SendEmail(email, subject, body);
    }
}
