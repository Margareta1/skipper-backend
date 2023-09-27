using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.SkillsMatrix
{
    public class SkillsMatrixSingleSkillInput
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Input { get; set; }

        [Required]
        public int OrderKey { get; set; }
    }
}
