using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using skipper_backend.Identity;

namespace skipper_backend.Models.Staffing
{
    public class HiringPostApplication
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string ApplicantId { get; set; }
        public User Applicant { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public bool Accepted { get; set; }

        [Required]
        [ForeignKey(nameof(HiringPost))]
        public Guid HiringPostId { get; set; }
        public HiringPost HiringPost { get; set; }

    }
}
