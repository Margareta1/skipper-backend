using skipper_backend.Identity;
using skipper_backend.Models.SurveySolver;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using skipper_backend.Models.SurveyCreator;

namespace skipper_backend.DTO
{
    public class SolveSurveyDto
    {
        public List<TextInputAnswer>? TextInputAnswer { get; set; }
        public Guid SurveyId { get; set; }
    }

    public class TextInputAnswer
    {
        public int OrderKey { get; set; }
        public string? Input { get; set; }
    }
}
