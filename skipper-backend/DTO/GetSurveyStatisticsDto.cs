using skipper_backend.Models.SurveyCreator;
using skipper_backend.Models.SurveySolver;

namespace skipper_backend.DTO
{
    public class GetSurveyStatisticsDto
    {
        public Survey Survey { get; set; }
        public List<TextArea> Questions { get; set; }
        public List<SurveyInput>  Inputs { get; set; }
    }
}
