namespace GeekShopping.Payment.Api.Domain.Dto.Messages
{
    public class PaymentProcessResultSendMsgDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }

        public DateTime MessageCreated { get; set; }
    }
}
