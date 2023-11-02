using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using skipper_backend.DTO;
using skipper_backend.Identity;
using skipper_backend.Store;

namespace skipper_backend.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<User> userManager;
        private readonly TokenService tokenService;
        private readonly StoreContext context;

        public AccountController(UserManager<User> manager, TokenService service,
            StoreContext storeContext)
        {
            userManager = manager ;
            tokenService = service;
            context = storeContext;

        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }
            var user = await userManager.FindByNameAsync(dto.Username);
            if (user == null || !await userManager.CheckPasswordAsync(user, dto.Password))
            {
                return Unauthorized();
            }

            var roles = await userManager.GetRolesAsync(user);
           
            var accessToken = await tokenService.GenerateToken(user);
            var refreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
            context.SaveChanges();
            return Ok(new AuthenticatedResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticatedResponse>> RegisterUser(RegisterDto dto)
        {
            var user = new User { UserName = dto.Email, Email = dto.Email };
            if(context.Users.Where(x=> x.UserName == dto.Email).ToList().Count >0)
            {
                return BadRequest();
            }

            var result = await userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();
            }

            await userManager.AddToRoleAsync(user, "Member");
            var roles = await userManager.GetRolesAsync(user);

            var accessToken = await tokenService.GenerateToken(user);
            var refreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
            context.SaveChanges();
            return Ok(new AuthenticatedResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });

        }

        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult<AuthenticatedResponse>> RefreshAsync(RefreshDto dto)
        {
            if (dto is null)
            {
                return BadRequest();

            }
            string accessToken = dto.AccessToken;
            string refreshToken = dto.RefreshToken;
            var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = context.Users.SingleOrDefault(u => u.UserName == username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest();
            }
            var newAccessToken = await tokenService.GenerateToken(user);
            var newRefreshToken = tokenService.GenerateRefreshToken();
            var roles = await userManager.GetRolesAsync(user);
            user.RefreshToken = newRefreshToken;
            context.SaveChanges();
            return Ok(new AuthenticatedResponse()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

    }
}
