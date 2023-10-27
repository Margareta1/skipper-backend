using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using skipper_backend.Identity;
using skipper_backend.Store;

namespace skipper_backend.Controllers
{
    public class ProjectController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly TokenService tokenService;
        private readonly StoreContext context;

        public ProjectController(UserManager<User> manager, TokenService service,
            StoreContext storeContext)
        {
            userManager = manager;
            tokenService = service;
            context = storeContext;
        }

        //get all projects with hiring posts
        //add project
        //edit project
        //add project file
        //delete project file
        //add project comment
        //delete project comment
        //add project tag
        //add tag
        //delete project tag
        //remove employee from project
    }
}
