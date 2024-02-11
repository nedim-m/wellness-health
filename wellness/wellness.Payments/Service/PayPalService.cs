using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using wellness.Payments.IService;
using wellness.Payments.Model;

public class PayPalService : IPayPalService
{
    private readonly IConfiguration _configuration;

    public PayPalService(IConfiguration configuration)
    {
        _configuration = configuration;
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

    public async Task<bool> CapturePaymentAsync(string orderId)
    {
        try
        {
            var request = new OrdersCaptureRequest(orderId);
            request.RequestBody(new OrderActionRequest());

            var client = new PayPalHttpClient(GetPayPalEnvironment());

            var response = await client.Execute(request);
            var result = response.Result<Order>();

            return result.Status.Equals("COMPLETED", StringComparison.OrdinalIgnoreCase);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to capture payment: {ex}");
            throw;
        }
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
}
