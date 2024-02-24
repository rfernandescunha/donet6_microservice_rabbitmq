namespace GeekShopping.OrderAPI.Messages
{
    public class PaymentUpdateMsgResultDto
    {
        public long OrderId { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
    }
}
