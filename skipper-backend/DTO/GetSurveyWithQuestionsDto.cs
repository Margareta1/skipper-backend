using skipper_backend.Models.SurveyCreator;

namespace skipper_backend.DTO
{
    public class GetSurveyWithQuestionsDto
    {
        public SurveyWithAssigneesDto Survey { get; set; }
        public List<TextArea> Questions { get; set; }
    }
}
