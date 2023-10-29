using skipper_backend.Identity;
using skipper_backend.Models.SkillsMatrix;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddSkillsMatrixInputDto
    {
        public List<AddSkillsMatrixSingleSkillInputDto> Inputs { get; set; }
        public string SkillsMatrixId { get; set; }
    }
}
