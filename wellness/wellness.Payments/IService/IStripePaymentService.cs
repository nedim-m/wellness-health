namespace wellness.Payments.IService
{
    public interface IStripePaymentService
    {
        Task<string> CreatePaymentIntent(decimal amount, string currency);
    }
}
