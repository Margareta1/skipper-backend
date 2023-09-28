using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skipper_backend.DTO;
using skipper_backend.Identity;
using skipper_backend.Store;
using System.Runtime.InteropServices;
using System.Security.Claims;

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

        [Authorize]
        [HttpGet("something")]
        public async Task<ActionResult<string>> Something()
        {

            return "Great";
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto dto)
        {
            if (dto is null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                return Unauthorized();
            }

            var roles = await _userManager.GetRolesAsync(user);
           
            var accessToken = await _tokenService.GenerateToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
            _context.SaveChanges();
            return Ok(new AuthenticatedResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Roles = roles
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticatedResponse>> RegisterUser(RegisterDto dto)
        {
            var user = new User { UserName = dto.Email, Email = dto.Email };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();
            }

            await _userManager.AddToRoleAsync(user, "Member");
            var roles = await _userManager.GetRolesAsync(user);

            var accessToken = await _tokenService.GenerateToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
            _context.SaveChanges();
            return Ok(new AuthenticatedResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Roles = roles
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
            var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = _context.Users.SingleOrDefault(u => u.UserName == username);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest();
            }
            var newAccessToken = await _tokenService.GenerateToken(user);
            var newRefreshToken = _tokenService.GenerateRefreshToken();
            var roles = await _userManager.GetRolesAsync(user);
            user.RefreshToken = newRefreshToken;
            _context.SaveChanges();
            return Ok(new AuthenticatedResponse()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                Roles = roles
            });
        }

    }
}
