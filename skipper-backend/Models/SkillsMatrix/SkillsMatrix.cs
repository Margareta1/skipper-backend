using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skipper_backend.Models.SkillsMatrix
{
    public class SkillsMatrix
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        [Required]
        public List<SkillsMatrixSingleSkill> Skills { get; set; }

        [Required]
        public List<User> Assignees { get; set; }

        public string? Rgb { get; set; }
        public List<SkillsMatrixInput>? Inputs { get; set; }


    }
}
