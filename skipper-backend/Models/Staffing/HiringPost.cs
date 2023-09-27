using skipper_backend.Identity;
using skipper_backend.Models.General;
using skipper_backend.Models.Project;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skipper_backend.Models.Staffing
{
    public class HiringPost
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [ForeignKey(nameof(UtilizationType))]
        public Guid UtilizationTypeId { get; set; }
        public UtilizationType UtilizationType { get; set; }

        [Required]
        public double UtilizationAmount { get; set; }

        [ForeignKey(nameof(LevelOfExperience))]
        public Guid? EmployeeLevelOfExperienceId { get; set; }
        public LevelOfExperience? EmployeeLevelOfExperience { get; set; }

        public string? Rgb { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string? Title { get; set; }
        public double? Budget { get; set; }
        public DateTime? PrefferedStart { get; set; }
        public List<GeneralSkill>? GeneralSkills { get; set; }
        public List<HiringPostRequiredLanguage>? RequiredLanguages { get; set; }
        public List<HiringPostApplication>? Applications { get; set; }
        public List<HiringPostComment>? Comments { get; set; }
        public List<HiringPostFile>? Files { get; set; }

    }
}
