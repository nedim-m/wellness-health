//// wellness.Payments project
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Threading.Tasks;
//using wellness.Payments.IService;
//using wellness.Payments.Model;
//using wellness.Service.IServices;

//namespace wellness.Payments.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class PaymentsController : ControllerBase
//    {
//        private readonly IPaymentService _paymentService;

//        public PaymentsController(IPaymentService paymentService)
//        {
//            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
//        }

//        [HttpPost("process-payment")]
//        public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest request)
//        {
//            try
//            {
//                if (request == null || request.Amount <= 0 || string.IsNullOrEmpty(request.Currency) || string.IsNullOrEmpty(request.PaymentMethod))
//                {
//                    return BadRequest("Invalid payment request");
//                }

           

//                var paymentIntentClientSecret = await _paymentService.ProcessPaymentAsync(request.Amount, request.Currency, request.PaymentMethod);

//                return Ok(new { ClientSecret = paymentIntentClientSecret });
//            }
//            catch (Exception ex) { 
         
//                Console.WriteLine($"Error processing payment: {ex.Message}");
//                return StatusCode(500, "Internal Server Error");
//            }
//        }
//    }

   
//}
