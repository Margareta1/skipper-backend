using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.SkillsMatrix
{
    public class SkillsMatrixInput
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string AssigneeId { get; set; }
        public User Assignee { get; set; } 

        [Required]
        public List<SkillsMatrixSingleSkillInput> Inputs { get; set; }

    }
}
