using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FullPetflix.UserFiles;
using FullPetflix.AnimalFiles; // Assuming you have an Animal class

namespace FullPetflix.AnimalReviewFiles
{
    public class AnimalReview
    {
        [Key]
        public int AnimalReviewId { get; set; }

        public string? Content { get; set; } = string.Empty;
        public DateTime? ReviewDate { get; set; } = DateTime.Now;

        [ForeignKey("Reviewer")]
        public int? ReviewerId { get; set; }
        public Users? Reviewer { get; set; }

        [ForeignKey("Animal")]
        public int? AnimalId { get; set; }
        public Animal? Animal { get; set; }
    }
}