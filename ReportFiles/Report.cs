using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FullPetflix.AnimalFiles;
using FullPetflix.ProductFiles;
using FullPetflix.UserFiles;

namespace FullPetflix.ReportFiles
{
    public enum ReportTargetType
    {
        User,
        Animal,
        Product
    }

    public enum ReportStatus
    {
        Pending,
        UnderReview,
        Resolved,
        Rejected
    }

    public class Report
    {
        [Key]
        public int? ReportId { get; set; }

        [Required]
        [ForeignKey("Reporter")]
        public int? ReporterId { get; set; }
        public virtual Users? Reporter { get; set; }

        [Required]
        public ReportTargetType? TargetType { get; set; }

        [ForeignKey("ReportedUser")]
        public int? ReportedUserId { get; set; }
        public virtual Users? ReportedUser { get; set; }

        [ForeignKey("ReportedAnimal")]
        public int? ReportedAnimalId { get; set; }
        public virtual Animal? ReportedAnimal { get; set; }

        [ForeignKey("ReportedProduct")]
        public int? ReportedProductId { get; set; }
        public virtual Product? ReportedProduct { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Content { get; set; }

        [Required]
        public ReportStatus? Status { get; set; } = ReportStatus.Pending;

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ResolvedAt { get; set; } = DateTime.UtcNow;

        [MaxLength(500)]
        public string? ResolutionNotes { get; set; }
    }
}