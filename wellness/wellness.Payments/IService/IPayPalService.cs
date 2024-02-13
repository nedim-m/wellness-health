using wellness.Payments.Model;

namespace wellness.Payments.IService
{
    public interface IPayPalService
    {
        Task<PayPalOrderResponse> CreateOrderAsync(decimal amount, string currency);
        Task<bool> CapturePaymentAsync(PayPalCaptureModel request);
    }
}
