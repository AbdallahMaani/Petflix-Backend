using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FullPetflix.UserFiles;

namespace FullPetflix.FeedbackFiles
{
    public class Feedback
    {
        [Key]
        public int? FeedbackId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int? UserId { get; set; }

        public virtual Users? User { get; set; }

        [Required]
        [MaxLength(50)]
        public string? FeedbackType { get; set; }

        [Required]
        [MaxLength(2000)]
        public string? Content { get; set; }

        public DateTime? SubmissionDate { get; set; } = DateTime.UtcNow;

        [MaxLength(50)]
        public string? Status { get; set; } = "Pending";

        [MaxLength(100)]
        public string? Response { get; set; }
    }
}