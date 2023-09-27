using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skipper_backend.Identity;
using skipper_backend.Store;
using System.Runtime.InteropServices;

namespace skipper_backend.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly StoreContext _context;

        public AccountController(UserManager<User> userManager, TokenService tokenService,
            StoreContext context)
        {
            _context = context;
            _tokenService = tokenService;
            _userManager = userManager;
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

        //[HttpPost("register")]
        //public async Task<ActionResult> RegisterUser(string username)
        //{
        //    var user = new User { UserName = registerDto.Username, Email = registerDto.Email };

        //    var result = await _userManager.CreateAsync(user, registerDto.Password);

        //    if (!result.Succeeded)
        //    {
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError(error.Code, error.Description);
        //        }

        //        return ValidationProblem();
        //    }

        //    await _userManager.AddToRoleAsync(user, "Member");

        //    return StatusCode(201);
        //}

        //[Authorize]
        //[HttpGet("currentUser")]
        //public async Task<ActionResult<UserDto>> GetCurrentUser()
        //{
        //    var user = await _userManager.FindByNameAsync(User.Identity.Name);

        //    var userBasket = await RetrieveBasket(User.Identity.Name);

        //    return new UserDto
        //    {
        //        Email = user.Email,
        //        Token = await _tokenService.GenerateToken(user),
        //        Basket = userBasket?.MapBasketToDto()
        //    };
        //}

        //[Authorize]
        //[HttpGet("savedAddress")]
        //public async Task<ActionResult<UserAddress>> GetSavedAddress()
        //{
        //    return await _userManager.Users
        //        .Where(x => x.UserName == User.Identity.Name)
        //        .Select(user => user.Address)
        //        .FirstOrDefaultAsync();
        //}

        //private async Task<Basket> RetrieveBasket(string buyerId)
        //{
        //    if (string.IsNullOrEmpty(buyerId))
        //    {
        //        Response.Cookies.Delete("buyerId");
        //        return null;
        //    }

        //    return await _context.Baskets
        //        .Include(i => i.Items)
        //        .ThenInclude(p => p.Product)
        //        .FirstOrDefaultAsync(basket => basket.BuyerId == buyerId);
        //}
    }
}
