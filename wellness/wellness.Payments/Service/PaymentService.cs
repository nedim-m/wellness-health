using System;
using System.Threading.Tasks;
using wellness.Payments.IService;
using wellness.Service.IServices;

namespace wellness.Payments.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IStripePaymentService _stripePaymentService;
        private readonly ITransactionService _transactionService;

        public PaymentService(IStripePaymentService stripePaymentService, ITransactionService transactionService)
        {
            _stripePaymentService = stripePaymentService;
            _transactionService = transactionService;
        }

        public async Task<string> ProcessPaymentAsync(decimal amount, string currency, string paymentMethod)
        {
            if (!string.IsNullOrEmpty(paymentMethod) && paymentMethod == "Stripe")
            {
                // Assuming CreatePaymentIntent returns a Task<string>
                var paymentIntentClientSecret = await _stripePaymentService.CreatePaymentIntent(amount, currency);

                // Use the ITransactionService to save transaction data
                await _transactionService.SaveTransactionAsync(new wellness.Model.Transaction.Transaction
                {
                    Amount = amount,
                    Currency = currency,
                    PaymentGateway = paymentMethod,
                    Timestamp=DateTime.UtcNow,
                    MemberShipId=3,
                    
                    // Add other properties as needed
                });

                return paymentIntentClientSecret;
            }

            // Handle other payment methods or throw an exception for unsupported methods
            throw new NotSupportedException($"Unsupported payment method: {paymentMethod}");
        }
    }
}
