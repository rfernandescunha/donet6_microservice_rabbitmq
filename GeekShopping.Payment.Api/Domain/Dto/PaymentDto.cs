using System;

namespace GeekShopping.Payment.Api.Domain.Dto
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiryMonthYear { get; set; }
        public decimal PurchaseAmount { get; set; }
        public string Email { get; set; }
    }
}
