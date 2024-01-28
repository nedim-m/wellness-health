namespace wellness.Payments.Model
{
    public class PaymentRequest
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = null!;
        public string PaymentMethod { get; set; } = null!;
      
      
      
    }
}
