using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddSkillsMatrixSingleSkillDto
    {
        public string SkillTitle { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
        public int OrderKey { get; set; }
        public string? SkillDescription { get; set; }
    }
}
