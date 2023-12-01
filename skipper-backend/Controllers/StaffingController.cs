using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skipper_backend.DTO;
using skipper_backend.Identity;
using skipper_backend.Models.Employee;
using skipper_backend.Models.General;
using skipper_backend.Models.Project;
using skipper_backend.Models.SkillsMatrix;
using skipper_backend.Models.Staffing;
using skipper_backend.Store;

namespace skipper_backend.Controllers
{
    public class StaffingController : BaseApiController
    {
        private readonly UserManager<User> userManager;
        private readonly TokenService tokenService;
        private readonly StoreContext context;

        public StaffingController(UserManager<User> manager, TokenService service,
            StoreContext storeContext)
        {
            userManager = manager;
            tokenService = service;
            context = storeContext;
        }



        [Authorize]
        [HttpPost("gethiringpostcomments")]
        public async Task<ActionResult<Object>> GetHiringPostComments(GetHiringPostApplicationsOrCommentDto dto)
        {
            var hiringPost = context.HiringPost.Where(x => x.Id == Guid.Parse(dto.HiringPostId)).First();
            if (hiringPost == null)
            {
                return NotFound();
            }

            try
            {
                return context.HiringPostComment.Where(x => x.HiringPostId == Guid.Parse(dto.HiringPostId)).ToList();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }

        [Authorize]
        [HttpGet("gethiringpostapplications/{id}")]
        public async Task<ActionResult<Object>> GetHiringPostApplications([FromRoute] string id)
        {
            var hiringPost = context.HiringPost.Where(x => x.Id == Guid.Parse(id)).First();
            if (hiringPost == null)
            {
                return NotFound();
            }

            try
            {
                return context.HiringPostApplication.Where(x => x.HiringPostId == Guid.Parse(id)).Include(x=>x.Applicant).ToList();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }

        [Authorize]
        [HttpPost("deletehiringpostapplication")]
        public async Task<ActionResult<Object>> DeleteHiringPostApplication(AddHiringPostApplicationDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var hiringPostApplication = context.HiringPostApplication.Where(x => x.Id == Guid.Parse(dto.HiringPostId)).First();

            if (user == null || hiringPostApplication != null)
            {
                return NotFound();
            }

            if (hiringPostApplication.ApplicantId!=user.Id)
            {
                return Unauthorized();
            }

            try
            {
                context.HiringPostApplication.Remove(hiringPostApplication);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }

        [Authorize]
        [HttpPost("addhiringpostapplication")]
        public async Task<ActionResult<Object>> AddHiringPostApplication(AddHiringPostApplicationDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var hiringPost = context.HiringPost.Where(x => x.Id == Guid.Parse(dto.HiringPostId)).First();

            if (user == null || hiringPost == null)
            {
                return NotFound();
            }

            try
            {
                var newHiringPostApplication = new HiringPostApplication();
                newHiringPostApplication.Id = Guid.NewGuid();
                newHiringPostApplication.Applicant = user;
                newHiringPostApplication.ApplicantId = user.Id;
                newHiringPostApplication.CreatedAt = DateTime.Now;
                newHiringPostApplication.Accepted = false;
                newHiringPostApplication.HiringPost = hiringPost;
                newHiringPostApplication.HiringPostId = hiringPost.Id;

                context.HiringPostApplication.Add(newHiringPostApplication);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }

        [Authorize]
        [HttpPost("addhiringpostcomment")]
        public async Task<ActionResult<Object>> AddHiringPostComment(AddHiringPostCommentDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var hiringPost = context.HiringPost.Where(x => x.Id == Guid.Parse(dto.HiringPostId)).First();

            if (user == null || hiringPost == null)
            {
                return NotFound();
            }

            try
            {
                var newHiringPostComment = new HiringPostComment();
                newHiringPostComment.Id = Guid.NewGuid();
                newHiringPostComment.PostedAt = DateTime.Now;
                newHiringPostComment.Comment = dto.Comment;
                newHiringPostComment.Commentor = user;
                newHiringPostComment.CommentorId = user.Id;
                newHiringPostComment.HiringPost = hiringPost;
                newHiringPostComment.HiringPostId = hiringPost.Id;
                context.HiringPostComment.Add(newHiringPostComment);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }


        [Authorize]
        [HttpPost("addhiringpost")]
        public async Task<ActionResult<Object>> AddHiringPost(AddHiringPostDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var project = context.CompanyProject.Where(x => x.Id == Guid.Parse(dto.CompanyProjectId)).First();
            var level = context.LevelOfExperience.Where(x => x.Id == Guid.Parse(dto.EmployeeLevelOfExperienceId)).First();
            if (user == null || project==null || level==null)
            {
                return NotFound();
            }

            try
            {
                var newHiringPost = new HiringPost();
                newHiringPost.Id = Guid.NewGuid();
                newHiringPost.Creator = user;
                newHiringPost.CreatorId = user.Id;
                newHiringPost.CreatedAt = DateTime.Now;
                newHiringPost.Position = dto.Position;
                newHiringPost.UtilizationTypeId = context.UtilizationType.Where(x => x.Name == "Percentage").FirstOrDefault().Id;
                newHiringPost.UtilizationType = context.UtilizationType.Where(x => x.Name=="Percentage").FirstOrDefault();
                newHiringPost.CompanyProject = project;
                newHiringPost.CompanyProjectId = project.Id;
                newHiringPost.UtilizationAmount = dto.UtilizationAmount;
                newHiringPost.EmployeeLevelOfExperience = level;
                newHiringPost.EmployeeLevelOfExperienceId = level.Id;
                newHiringPost.Rgb = dto.Rgb;
                newHiringPost.ExpiresAt = dto.ExpiresAt;
                newHiringPost.Title = dto.Title;
                newHiringPost.Budget = dto.Budget;
                newHiringPost.PrefferedStart = dto.PrefferedStart;
                newHiringPost.GeneralSkills = new List<GeneralSkill>();
                newHiringPost.RequiredLanguages = new List<HiringPostRequiredLanguage>();
                foreach (var item in dto.GeneralSkills)
                {
                    if (context.GeneralSkill.First(x=>x.Name==item.Name)!=null)
                    {
                        newHiringPost.GeneralSkills.Add(context.GeneralSkill.First(x => x.Name == item.Name));
                    }
                    else
                    {
                        var newSkill = new GeneralSkill();
                        newSkill.Id = Guid.NewGuid();
                        newSkill.Name = item.Name;
                        context.GeneralSkill.Add(newSkill);
                        newHiringPost.GeneralSkills.Add(newSkill);
                    }
                }

                foreach (var item in dto.RequiredLanguages)
                {
                    var language = context.Language.Where(x => x.Id == Guid.Parse(item.LanguageId)).First();
                    var languageLevel = context.LanguageLevel.Where(x => x.Id == Guid.Parse(item.LanguageLevelId)).First();
                    var reqLanguage = new HiringPostRequiredLanguage();
                    reqLanguage.Id = Guid.NewGuid();
                    reqLanguage.Language = language;
                    reqLanguage.LanguageId = language.Id;
                    reqLanguage.LanguageLevel = languageLevel;
                    reqLanguage.LanguageLevelId = languageLevel.Id;
                    context.HiringPostRequiredLanguage.Add(reqLanguage);
                    newHiringPost.RequiredLanguages.Add(reqLanguage);
                }

                context.HiringPost.Add(newHiringPost);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }


        [Authorize]
        [HttpPost("deletehiringpost")]
        public async Task<ActionResult<Object>> GetHiringPosts(DeleteHiringPostDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var post = context.HiringPost.Where(x => x.Id == Guid.Parse(dto.HiringPostId)).First();
            if (post == null)
            {
                return NotFound();
            }

            if (post.CreatorId!=user.Id)
            {
                return Unauthorized();
            }

            try
            {
                context.HiringPost.Remove(post);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }


        }
        
        [Authorize]
        [HttpGet("gethiringposts/{id}")]
        public async Task<ActionResult<Object>> GetHiringPosts([FromRoute] string id)
        {
            var project = context.CompanyProject.Where(x => x.Id == Guid.Parse(id)).First();
            if (project == null)
            {
                return NotFound();
            }

            try
            {
                return context.HiringPost.Where(x => x.CompanyProjectId == project.Id).Include(x=> x.RequiredLanguages).Include(x=> x.GeneralSkills).Include(x=>x.EmployeeLevelOfExperience).ToList();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }


    }
}
