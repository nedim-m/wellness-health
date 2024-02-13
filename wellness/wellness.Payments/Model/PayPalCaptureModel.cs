namespace wellness.Payments.Model
{
    public class PayPalCaptureModel
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public int MemberShipTypeId { get; set; }
        public int UserId { get; set; }
    }
}
