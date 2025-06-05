using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using FullPetflix.UserFiles;

namespace FullPetflix.AnimalFiles
{
    public class Animal
    {
        [Key]
        public int animal_id { get; set; }

        [Required]
        [MaxLength(10)]
        public string ItemType { get; set; } = "Animal";

        public double? animal_new_price { get; set; }
        public double? animal_old_price { get; set; }

        [Required]
        public string animal_title { get; set; } = string.Empty;

        public string? animal_category { get; set; }

        [Required]
        public string animal_description { get; set; } = string.Empty;

        public string animal_type { get; set; } = string.Empty;

        public Gender? gender { get; set; }

        public string age { get; set; } = string.Empty;

        public string? vaccineStatus { get; set; }

        public double? animal_weight { get; set; }

        public string animal_size { get; set; } = string.Empty; // Removed [Required] as it should be optional

        public string health_status { get; set; } = string.Empty;

        public string? animal_pic { get; set; } = string.Empty;

        [Required]
        [ForeignKey("User")]
        public int userId { get; set; }

        // Changed to virtual for lazy loading and made nullable
        public virtual Users? User { get; set; }
    }
}