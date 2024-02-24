using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Order.Api.Domain.Dto
{
    [Table("order_detail")]
    public class OrderDetailDto
    {
        public long Id { get; set; }
        public long OrderHeaderId { get; set; }

        [ForeignKey("OrderHeaderId")]
        public virtual OrderHeaderDto OrderHeader { get; set; }

        [Column("ProductId")]
        public long ProductId { get; set; }

        [Column("count")]
        public int Count { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
    }
}
