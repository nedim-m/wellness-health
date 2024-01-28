namespace wellness.Payments.IService
{
    public interface IPaymentService
    {
        Task<string> ProcessPaymentAsync(decimal amount, string currency, string paymentMethod);
        
    }
}
