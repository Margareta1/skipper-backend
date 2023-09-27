using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using skipper_backend.Identity;
using skipper_backend.Store;

namespace skipper_backend.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly UserManager<User> manager;
        private readonly StoreContext context;

        public EmployeeController(UserManager<User> userManager,StoreContext context)
        {
            context = context;
            manager = userManager;
        }



        [HttpPost("login")]
        public async Task<ActionResult<JsonResult>> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
                return Unauthorized();

            var roles = _userManager.GetRolesAsync(user);

            return new JsonResult("ok");
        }

    }
}
