using Microsoft.AspNetCore.Mvc;
using wellness.Payments.IService;
using wellness.Payments.Model;

namespace wellness.Payments.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PayPalController : ControllerBase
    {
        private readonly IPayPalService _payPalService;

        public PayPalController(IPayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequestModel model)
        {
            try
            {
                decimal amount = model.Amount;
                string currency = model.Currency;

                Console.WriteLine($"Creating order for amount {amount} {currency}");

                var orderResponse = await _payPalService.CreateOrderAsync(amount, currency);

                Console.WriteLine($"Order created successfully. OrderId: {orderResponse.OrderId}, ApprovalUrl: {orderResponse.ApprovalUrl}");

                return Ok(new { OrderId = orderResponse.OrderId, ApprovalUrl = orderResponse.ApprovalUrl });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to create order: {ex}");
                return StatusCode(500, new { error = "Failed to create order." });
            }
        }


        [HttpPost("capture-payment")]
        public async Task<IActionResult> CapturePayment([FromBody] PayPalCaptureModel request)
        {
            try
            {
                bool success = await _payPalService.CapturePaymentAsync(request);

                if (success)
                {
                    return Ok(new { Message = "Payment captured successfully." });
                }
                else
                {
                    return BadRequest(new { Message = "Failed to capture payment." });
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Failed to capture order: {ex}");
                return StatusCode(500, new { error = "Failed to capture order." });
            }
        }
    }
}
