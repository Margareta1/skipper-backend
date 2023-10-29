using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using skipper_backend.Identity;
using skipper_backend.Store;

namespace skipper_backend.Controllers
{
    public class SurveyController : Controller
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

        //create survey
        //delete survey
        //solve survey
        //did solve survey
        //get survey statistics



        [Authorize]
        [HttpGet("getallassignedsurveys")]
        public async Task<ActionResult<Object>> GetAllAssignedSurveys()
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            try
            {
                var allSurveys = context.SurveyAssignee.Where(x => x.ASssignee == user).ToList();
                if (allSurveys != null)
                {
                    return context.Survey.Where(x => allSurveys.Exists(c => c.SurveyId == x.Id)).ToList();
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


    }
}
