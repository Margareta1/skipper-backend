using skipper_backend.Models.SkillsMatrix;

namespace skipper_backend.DTO
{
    public class GetSkillsMatrixDto
    {
        public SkillsMatrix Matrix { get; set; }
        public List<SkillsMatrixInput> UserInputs{ get; set; }
    }
}
