using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [ForeignKey(nameof(SkillsMatrixInput))]
        public Guid SkillsMatrixInputID { get; set; }
        public SkillsMatrixInput SkillsMatrixInput { get; set; }
    }
}
