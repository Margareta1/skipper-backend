using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skipper_backend.Models.Project
{
    public class ProjectComment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string CommentorId { get; set; }
        public User Commentor { get; set; }

        [Required]
        [ForeignKey(nameof(CompanyProject))]
        public Guid ProjectId { get; set; }
        public CompanyProject Project { get; set; }
        public string Comment { get; set; }

    }
}
