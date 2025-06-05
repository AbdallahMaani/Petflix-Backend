using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FullPetflix.UserFiles;

namespace FullPetflix.OrderFiles
{
    public class Order
    {
        [Key]
        public int? OrderId { get; set; } // Auto-incremented primary key

        [Required]
        public int? UserId { get; set; } // Foreign key to User

        [ForeignKey("UserId")]
        public Users? User { get; set; } // Navigation property

        public bool? IncludeDelivery { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Tip { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Status { get; set; } = "Processing"; // Default value

        public DateTime? OrderDate { get; set; } = DateTime.UtcNow; // Timestamp of order creation

        public virtual ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>(); // One-to-many with OrderItems
    }

    public class OrderItem
    {
        [Key]
        public int? OrderItemId { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [Required]
        public int? ItemId { get; set; }

        [Required]
        public int? Quantity { get; set; }

        public int? OwnerId { get; set; } // Nullable foreign key to User (owner/seller)

    }
}