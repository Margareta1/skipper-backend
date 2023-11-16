using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skipper_backend.DTO;
using skipper_backend.Identity;
using skipper_backend.Models.GoalManagement;
using skipper_backend.Models.SurveyCreator;
using skipper_backend.Models.SurveySolver;
using skipper_backend.Store;

namespace skipper_backend.Controllers
{
    public class SurveyController : BaseApiController
    {
        private readonly UserManager<User> userManager;
        private readonly TokenService tokenService;
        private readonly StoreContext context;

        public SurveyController(UserManager<User> manager, TokenService service,
            StoreContext storeContext)
        {
            userManager = manager;
            tokenService = service;
            context = storeContext;
        }

        [Authorize]
        [HttpGet("getsurveystatistics")]
        public async Task<ActionResult<Object>> GetSurveyStatistics(GetSurveyDto dto)
        {

            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var sur= context.Survey.Include(x => x.Inputs).First(x => x.Id == Guid.Parse(dto.SurveyId));
            if (sur.CreatorId!=user.Id)
            {
                return Unauthorized();
            }
            try
            {
                return sur.Inputs;

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("getsurvey")]
        public async Task<ActionResult<Object>> GetSurvey(GetSurveyDto dto)
        {
            try
            {
                SurveyWithAssigneesDto sur = new SurveyWithAssigneesDto();
                sur.Survey = context.Survey.Include(x=>x.Inputs).First(x => x.Id == Guid.Parse(dto.SurveyId));
                if (sur.Survey != null)
                {
                    sur.Assignees = context.SurveyAssignee.Where(x => x.SurveyId == sur.Survey.Id).ToList();
                }
                GetSurveyWithQuestionsDto newDto = new GetSurveyWithQuestionsDto();
                newDto.Survey = sur;
                newDto.Questions = context.TextArea.Where(x=> x.SurveyId==Guid.Parse(dto.SurveyId)).ToList();
                return newDto;

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }        
        
        [Authorize]
        [HttpGet("getallsurveys")]
        public async Task<ActionResult<Object>> GetAllSurveys()
        {
            try
            {
                GetSurveysWithAssigneesDto dto = new GetSurveysWithAssigneesDto();
                dto.SurveysWithAssignees = new List<SurveyWithAssigneesDto>();
                var sur = context.Survey.Include(x => x.Inputs).ToList();
                foreach (var item in sur)
                {
                    SurveyWithAssigneesDto newSWA = new SurveyWithAssigneesDto();
                    newSWA.Survey = item;
                    newSWA.Assignees = context.SurveyAssignee.Where(x => x.SurveyId == item.Id).ToList();
                    dto.SurveysWithAssignees.Add(newSWA);
                }

                return dto;

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("getallassignedsurveys")]
        public async Task<ActionResult<Object>> GetAllAssignedSurveys()
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            try
            {
                var allSurveys = context.SurveyAssignee.Where(x => x.AssigneeId == user.Id).ToList();
                if (allSurveys != null)
                {
                    var surveys = new List<Survey>();
                    foreach (var item in allSurveys)
                    {
                        surveys.Add(context.Survey.First(x => x.Id == item.SurveyId));
                    }
                    return surveys;
                }
                else
                {
                    return new List<Object>();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("addsurvey")]
        public async Task<ActionResult<Object>> AddSurvey(AddSurveyDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            //var isManager = await userManager.IsInRoleAsync(user, "Manager");
            if (user == null)
            {
                return BadRequest();
            }

            try
            {
                var newSurvey = new Survey();
                newSurvey.Id = Guid.NewGuid();
                newSurvey.Creator = user;
                newSurvey.CreatorId = user.Id;
                newSurvey.Rgb = dto.Rgb;
                newSurvey.StartDate = dto.StartDate;
                newSurvey.EndDate = dto.EndDate;
                context.Survey.Add(newSurvey);
                foreach (var item in dto.AssigneesUsernames)
                {
                    var assignee = await userManager.FindByNameAsync(item);
                    if (assignee != null)
                    {
                        var newAssignee = new SurveyAssignee();
                        newAssignee.Id = Guid.NewGuid();
                        newAssignee.ASssignee = assignee;
                        newAssignee.AssigneeId = assignee.Id;
                        newAssignee.Survey = newSurvey;
                        newAssignee.SurveyId = newSurvey.Id;
                        context.SurveyAssignee.Add(newAssignee);
                    }
                }

                foreach (var item in dto.Questions)
                {
                    var newQ = new TextArea();
                    newQ.Id = Guid.NewGuid();
                    newQ.OrderKey = item.OrderKey;
                    newQ.Placeholder = item.Placeholder;
                    newQ.Label = item.Label;
                    newQ.Survey = newSurvey;
                    newQ.SurveyId = newSurvey.Id;
                    context.TextArea.Add(newQ);
                }

                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [Authorize]
        [HttpPost("solvesurvey")]
        public async Task<ActionResult<Object>> SolveSurvey(SolveSurveyDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var survey = context.Survey.Where(x => x.Id == dto.SurveyId).First();
            var isAssigned = context.SurveyAssignee.First(y=> y.AssigneeId==user.Id && y.SurveyId==dto.SurveyId);
            if (user == null || survey == null || isAssigned==null)
            {
                return BadRequest();
            }

            try
            {
                var newSurveyInput = new SurveyInput();
                newSurveyInput.Id = Guid.NewGuid();
                newSurveyInput.RespondentId = user.Id;
                newSurveyInput.Respondent = user;
                foreach (var item in dto.TextInputAnswer)
                {
                    var newInput = new SurveyAnswer();
                    newInput.TextInputOrArea = item.Input;
                    newInput.OrderKey = item.OrderKey;
                    newInput.Id = Guid.NewGuid();
                    newSurveyInput.Answers.Add(newInput);
                }
                survey.Inputs.Add(newSurveyInput);
                context.SurveyInput.Add(newSurveyInput);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpPost("deletesurvey")]
        public async Task<ActionResult<Object>> DeleteSurvey(DeleteSurveyDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var survey = context.Survey.Where(x => x.Id == Guid.Parse(dto.SurveyId)).First();
            var isOwner = survey.Creator == user;
            if (user == null || survey == null || !isOwner)
            {
                return BadRequest();
            }

            try
            {
                context.Survey.Remove(survey);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [HttpPost("didsolvesurvey")]
        public async Task<ActionResult<Object>> DidSolveSurvey(DeleteSurveyDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var survey = context.Survey.Where(x => x.Id == Guid.Parse(dto.SurveyId)).Include(x=> x.Inputs).First();
            var isAssigned = context.SurveyAssignee.First(x => x.AssigneeId == user.Id && x.SurveyId == survey.Id);
            if (user == null || survey == null || isAssigned==null)
            {
                return BadRequest();
            }

            try
            {
                var didSolve = survey.Inputs.Exists(x => x.RespondentId == user.Id);
                return Ok(didSolve);

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }


    }
}
