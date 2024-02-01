//using System;
//using System.Threading.Tasks;
//using wellness.Payments.IService;
//using wellness.Service.IServices;

//namespace wellness.Payments.Service
//{
//    public class PaymentService : IPaymentService
//    {
//        private readonly IStripePaymentService _stripePaymentService;
//        private readonly ITransactionService _transactionService;

//        public PaymentService(IStripePaymentService stripePaymentService, ITransactionService transactionService)
//        {
//            _stripePaymentService = stripePaymentService;
//            _transactionService = transactionService;
//        }

//        /*public async Task<string> ProcessPaymentAsync(decimal amount, string currency, string paymentMethod)
//        {
//            if (!string.IsNullOrEmpty(paymentMethod) && paymentMethod == "Stripe")
//            {
                
//                //var paymentIntentClientSecret = await _stripePaymentService.(1,"BAM",false);

 
//                await _transactionService.SaveTransactionAsync(new wellness.Model.Transaction.Transaction
//                {
//                    Amount = amount,
//                    Currency = currency,
//                    PaymentMethod = paymentMethod,
//                    Timestamp=DateTime.UtcNow,
//                    MemberShipTypeId=1,
                  
//                });

//                return paymentIntentClientSecret;
//            }

            
//            throw new NotSupportedException($"Unsupported payment method: {paymentMethod}");
//        }*/
//    }
//}
