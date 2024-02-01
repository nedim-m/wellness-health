

namespace wellness.Payments.Model

{
    public class PaymentRequestModel
    {
        public bool UseStripeSdk { get; set; }
        public string PaymentMethodId { get; set; }
        public string Currency { get; set; }
        public int MemberShipTypeId { get; set; } 
    }

}
