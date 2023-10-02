using skipper_backend.Identity;
using skipper_backend.Models.SurveySolver;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skipper_backend.Models.SurveyCreator
{
    public class Survey
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        [NotMapped]
        public List<ISurveyQuestion>? Questions { get; set; }

        public string? Rgb { get; set; }
        public List<SurveyInput>? Inputs { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
    }
}
