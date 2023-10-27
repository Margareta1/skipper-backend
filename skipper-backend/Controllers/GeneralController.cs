using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using skipper_backend.Identity;
using skipper_backend.Store;

namespace skipper_backend.Controllers
{
    public class GeneralController : Controller
    {
        private readonly UserManager<User> manager;
        private readonly StoreContext context;

        public GeneralController(UserManager<User> userManager, StoreContext context)
        {
            context = context;
            manager = userManager;

        }
        //dodaj ručno sve language levele i utilization types

        //add general skill
        //add language
        //add level of experience
        //add position
        //add app preferences
    }
}
