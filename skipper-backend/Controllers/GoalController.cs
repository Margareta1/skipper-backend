using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using skipper_backend.DTO;
using skipper_backend.Identity;
using skipper_backend.Models.Employee;
using skipper_backend.Models.GoalManagement;
using skipper_backend.Store;

namespace skipper_backend.Controllers
{
    public class GoalController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly TokenService tokenService;
        private readonly StoreContext context;

        public GoalController(UserManager<User> manager, TokenService service,
            StoreContext storeContext)
        {
            userManager = manager;
            tokenService = service;
            context = storeContext;
        }

        [Authorize]
        [HttpPost("deletegoal")]
        public async Task<ActionResult<Object>> DeleteGoal(DeleteGoalDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var goal = context.Goal.Where(x => x.Id == Guid.Parse(dto.GoalId)).First();
            if (user == null || goal==null)
            {
                return NotFound();
            }

            if (goal.UserId != user.Id)
            {
                return Unauthorized();
            }

            try
            {
                context.Goal.Remove(goal);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }        
        
        
        [Authorize]
        [HttpPost("addgoal")]
        public async Task<ActionResult<Object>> AddGoal(AddGoalDto dto)
        {
            var user = await userManager.FindByNameAsync(dto.UserName);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var newGoal = new Goal();
                newGoal.Id = Guid.NewGuid();
                newGoal.User = user;
                newGoal.UserId = user.Id;
                newGoal.Description = dto.Description;
                context.Goal.Add(newGoal);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [Authorize]
        [HttpGet("getgoals")]
        public async Task<ActionResult<Object>> GetGoals()
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                return context.Goal.Where(x => x.UserId == user.Id).ToList();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

    }
}
