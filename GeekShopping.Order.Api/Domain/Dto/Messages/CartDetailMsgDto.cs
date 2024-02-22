namespace GeekShopping.Order.Api.Domain.Dto.Messages
{
    public class CartDetailMsgDto
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; }
        public long ProductId { get; set; }
        public virtual ProductMsgDto Product { get; set; }

        public int Count { get; set; }
    }
}
