using skipper_backend.Identity;
using skipper_backend.Models.SkillsMatrix;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddSkillsMatrixDto
    {
        public List<AddSkillsMatrixSingleSkillDto> Skills { get; set; }

        public List<string> AssigneesIds { get; set; }

        public string? Rgb { get; set; }
    }
}
