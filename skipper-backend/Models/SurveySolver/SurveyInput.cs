using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using skipper_backend.Models.SurveyCreator;

namespace skipper_backend.Models.SurveySolver
{
    public class SurveyInput
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string RespondentId { get; set; }
        public User Respondent { get; set; }

        public List<SurveyAnswer>? Answers { get; set; }

    }
}
