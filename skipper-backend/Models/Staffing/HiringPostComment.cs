using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skipper_backend.Models.Staffing
{
    public class HiringPostComment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public DateTime PostedAt { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string CommentorId { get; set; }
        public User Commentor { get; set; }

        [Required]
        [ForeignKey(nameof(HiringPost))]
        public Guid HiringPostId { get; set; }
        public HiringPost HiringPost { get; set; }

    }
}
