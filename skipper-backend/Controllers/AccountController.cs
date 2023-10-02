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
        private readonly UserManager<User> manager;
        private readonly TokenService tokenService;
        private readonly StoreContext context;

        public AccountController(UserManager<User> userManager, TokenService tokenService,
            StoreContext context)
        {
            context = context;
            tokenService = tokenService;
            manager = userManager;
        }

        [Authorize]
        [HttpGet("something")]
        public async Task<ActionResult<string>> Something()
        {

            return User.Identity.Name;
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }
            var user = await manager.FindByNameAsync(dto.Username);
            if (user == null || !await manager.CheckPasswordAsync(user, dto.Password))
            {
                return Unauthorized();
            }

            var roles = await manager.GetRolesAsync(user);
           
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

            var result = await manager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();
            }

            await manager.AddToRoleAsync(user, "Member");
            var roles = await manager.GetRolesAsync(user);

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
            var roles = await manager.GetRolesAsync(user);
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
