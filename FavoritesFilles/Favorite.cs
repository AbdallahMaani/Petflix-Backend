using FullPetflix.AnimalFiles;
using FullPetflix.ProductFiles;
using FullPetflix.UserFiles;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FullPetflix.AnimalFiles;
using FullPetflix.ProductFiles;
using FullPetflix.UserFiles;

namespace FullPetflix.FavoritesFiles
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        public Users? User { get; set; }  // Reference to the user who favorited

        public int? ItemId { get; set; } // ID of the favorited item (animal or product)

        // Foreign key to Animal (optional)
        [ForeignKey("Animal")]
        public int? AnimalId { get; set; }
        public Animal? Animal { get; set; }

        // Foreign key to Product (optional)
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        // Optional: Keep ItemType as a computed property or remove it
        public string? ItemType
        {
            get
            {
                if (AnimalId.HasValue) return "Animal";
                if (ProductId.HasValue) return "Product";
                return null;
            }
        }
    }
}