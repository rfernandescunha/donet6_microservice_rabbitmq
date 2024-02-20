using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Product.Api.Domain.Entities
{
    [Table("product")]
    public class Product:BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string  Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1,10000)]
        public decimal Price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("category_name")]
        [Required]
        [StringLength(80)]
        public string CategoryName { get; set; }

        [Column("img_url")]
        [Required]
        [StringLength(300)]
        public string ImgUrl { get; set; }
    }
}
