using skipper_backend.Models.SurveyCreator;

namespace skipper_backend.DTO
{
    public class GetSurveysWithAssigneesDto
    {
        public IList<SurveyWithAssigneesDto> SurveysWithAssignees { get; set; }
    }

    public class SurveyWithAssigneesDto
    {

        public Survey Survey { get; set; }
        public IList<SurveyAssignee> Assignees { get; set; }
    }
}
