using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skipper_backend.Models.CV
{
    public class CVItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(CV))]
        public Guid CVId { get; set; }
        public CV CV { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string EducationExperienceOrCert { get; set; }

        public string? Description { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

    }
}
