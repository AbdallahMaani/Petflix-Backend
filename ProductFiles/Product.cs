using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FullPetflix.UserFiles;

namespace FullPetflix.ProductFiles
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }

        [Required]
        [MaxLength(10)]
        public string ItemType { get; set; } = "Product";

        [Required]
        public string product_title { get; set; } = string.Empty;

        public double? product_new_price { get; set; }
        public double? product_old_price { get; set; }

        [Required]
        public string product_description { get; set; } = string.Empty;

        [Required]
        public string product_category { get; set; } = string.Empty;

        [Required]
        public string product_type { get; set; } = string.Empty;

        public string? product_size { get; set; }
        public double? product_weight { get; set; }
        public DateTime? expiration { get; set; }
        public string? usage { get; set; }

        [Required]
        public string designedFor { get; set; } = string.Empty;

        public string? product_pic { get; set; }

        [Required]
        [ForeignKey("User")]
        public int userId { get; set; }

        public virtual Users? User { get; set; }
    }
}