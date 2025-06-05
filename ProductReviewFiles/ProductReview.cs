using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FullPetflix.ProductFiles;
using FullPetflix.UserFiles;
using FullPetflix.ProductFiles;
using FullPetflix.UserFiles;

namespace FullPetflix.ProductReviewFiles
{
    public class ProductReview
    {
        [Key]
        public int ProductReviewId { get; set; }

        public string? Content { get; set; } = string.Empty; // Comment is now required (or allow null)
        public DateTime? ReviewDate { get; set; } = DateTime.Now;

        [ForeignKey("Reviewer")]
        public int? ReviewerId { get; set; }
        public Users? Reviewer { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}