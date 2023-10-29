using skipper_backend.Identity;
using skipper_backend.Models.General;
using skipper_backend.Models.Project;
using skipper_backend.Models.Staffing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddHiringPostDto
    {
        public string Position { get; set; }
        public string UtilizationTypeId { get; set; }
        public string CompanyProjectId { get; set; }
        public double UtilizationAmount { get; set; }
        public string EmployeeLevelOfExperienceId { get; set; }
        public string? Rgb { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string? Title { get; set; }
        public double? Budget { get; set; }
        public DateTime? PrefferedStart { get; set; }
        public List<AddGeneralSkillDto> GeneralSkills { get; set; }
        public List<AddHiringPostRequiredLanguageDto> RequiredLanguages { get; set; }

    }
}
