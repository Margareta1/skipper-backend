using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skipper_backend.DTO;
using skipper_backend.Identity;
using skipper_backend.Models.CV;
using skipper_backend.Store;
using System.Security.Claims;

namespace skipper_backend.Controllers
{
    public class CVController : BaseApiController
    {
        private readonly UserManager<User> userManager;
        private readonly TokenService tokenService;
        private readonly StoreContext context;

        public CVController(UserManager<User> manager, TokenService service,
            StoreContext storeContext)
        {
            userManager = manager;
            tokenService = service;
            context = storeContext;

        }

        [Authorize]
        [HttpGet("getall")]
        public async Task<ActionResult<Object>> GetAllCVs()
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            return context.CV.Where(x => x.OwnerId == user.Id).Include(v=> v.CVItems).ToList();
        }

        [Authorize]
        [HttpGet("deletecv")]
        public async Task<ActionResult<Object>> DeleteCV(DeleteCVDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            var cv = context.CV.Where(x=> x.Id==dto.Id).First();
            if (cv.OwnerId != user.Id)
            {
                return Unauthorized();
            }
            try
            {
            context.CV.Remove(cv);
            context.SaveChanges();
                return Ok();

            }
            catch (Exception e)
            {
                return UnprocessableEntity();
            }
        }

        [Authorize]
        [HttpPost("addcv")]
        public async Task<ActionResult<Object>> CreateCV(CVDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                var newCV = new CV()
                {
                    Id = Guid.NewGuid(),
                    Owner = user,
                    OwnerId = user.Id,
                    CreatedAt = DateTime.Now,
                    Status = dto.Status,
                    About = dto.About,
                    Rgb = dto.Rgb
                };
                context.CV.Add(newCV);
                context.SaveChanges();
                var addedCV = context.CV.Find(newCV);
                var newCVItems = new List<CVItem>();
                foreach (var item in dto.Items)
                {
                    newCVItems.Add(new CVItem()
                    {
                        Id = Guid.NewGuid(),
                        CVId = addedCV.Id,
                        Title = item.Title,
                        Description = item.Description,
                        EducationExperienceOrCert = item.EducationExperienceOrCert,
                        From = item.From,
                        To = item.To
                    });
                }
                context.CVItem.AddRange(newCVItems);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return UnprocessableEntity();
            }
        }

    }
}
