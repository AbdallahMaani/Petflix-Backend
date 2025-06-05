using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FullPetflix.UserFiles;
using FullPetflix.ProductFiles;

public class Cart
{
    [Key]
    public int? CartId { get; set; }

    public int? UserId { get; set; }
    [ForeignKey("UserId")]
    public Users? User { get; set; }

    public List<CartItem>? CartItems { get; set; } = new();
}

public class CartItem
{
    [Key]
    public int? CartItemId { get; set; }

    [ForeignKey("Cart")]
    public int? CartId { get; set; }

    [JsonIgnore]
    public Cart? Cart { get; set; }

    public int? ItemId { get; set; }

    [Required]
    [MaxLength(10)]
    public string? ItemType { get; set; } // "Animal" or "Product"

    public int? Quantity { get; set; }
}