using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.SkillsMatrix
{
    public class SkillsMatrixSingleSkill
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string SkillTitle { get; set; }

        [Required]
        public int RangeFrom { get; set; }

        [Required]
        public int RangeTo { get; set; }

        [Required]
        public int OrderKey { get; set; }

        public string? SkillDescription { get; set; }

    }
}
