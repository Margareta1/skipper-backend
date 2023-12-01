using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using skipper_backend.DTO;
using skipper_backend.Identity;
using skipper_backend.Models.Employee;
using skipper_backend.Models.Project;
using skipper_backend.Store;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace skipper_backend.Controllers
{
    public class ProjectController : BaseApiController
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


        [Authorize]
        [HttpGet("getprojects")]
        public async Task<ActionResult<Object>> GetProjects()
        {

            try
            {
                return context.CompanyProject.ToList();
            }
            catch (Exception)
            {

                return new JsonResult("Unprocessable");
            }
        }




        [Authorize]
        [HttpGet("getprojectoverview")]
        public async Task<ActionResult<List<GetProjectOverviewDto>>> GetProjectOverview()
        {

            try
            {
                var newList = new List<GetProjectOverviewDto>();
                var allProjects = context.CompanyProject.ToList();
                foreach (var item in allProjects)
                {
                    var newOverview = new GetProjectOverviewDto();
                    newOverview.Key = item.Id.ToString();
                    newOverview.Active = item.Active ? "True" : "False";
                    newOverview.Name = item.Name;
                    newOverview.Description = item.Description;
                    var allHPs = context.HiringPost.Where(x => x.CompanyProjectId == item.Id && x.ExpiresAt > DateTime.Now).ToList();
                    newOverview.Hiring = allHPs.Count > 0 ? "True" : "False";
                    var allTags = context.ProjectTag.Where(x => x.ProjectId == item.Id).ToList();
                    string t = "";
                    foreach (var tag in allTags)
                    {
                        tag.Tag = context.Tag.Where(x => x.Id == tag.TagId).FirstOrDefault();
                        t += tag.Tag.Title;
                        t += "  ";
                    }
                    newOverview.Tags = t.TrimEnd();
                    newList.Add(newOverview);
                }
                return newList;
            }
            catch (Exception)
            {

                return new JsonResult("Unprocessable");
            }
        }        
        
        [Authorize]
        [HttpGet("getproject/{id}")]
        public async Task<ActionResult<Object>> GetProjectById([FromRoute]string id)
        {

            try
            {
                return context.CompanyProject.FirstOrDefault(x => x.Id == Guid.Parse(id));
            }
            catch (Exception)
            {

                return new JsonResult("Unprocessable");
            }
        }

        [Authorize]
        [HttpGet("getprojectlead/{id}")]
        public async Task<ActionResult<Object>> GetProjectLeadById([FromRoute]string id)
        {

            try
            {
                var lead = context.ProjectLead.FirstOrDefault(x => x.ProjectId == Guid.Parse(id));
                lead.Lead = context.Users.FirstOrDefault(x => x.Id == lead.LeadId);
                return lead;
            }
            catch (Exception)
            {

                return new JsonResult("Unprocessable");
            }
        }






        [Authorize]
        [HttpGet("getprojectemployees/{id}")]
        public async Task<ActionResult<Object>> GetProjectEmployees([FromRoute] string id)
        {

            try
            {
               var allProj = context.EmployeeProject.Where(x=> x.CompanyProjectId==Guid.Parse(id)).ToList();
                foreach (var item in allProj)
                {
                    item.User = context.Users.FirstOrDefault(x => x.Id == item.UserId);
                }
                return allProj;
            }
            catch (Exception)
            {

                return new JsonResult("Unprocessable");
            }
        }
        [Authorize]
        [HttpGet("getprojecttags/{id}")]
        public async Task<ActionResult<Object>> GetProjectTags([FromRoute] string id)
        {

            try
            {
                var projectTags =  context.ProjectTag.Where(x=> x.ProjectId==Guid.Parse(id)).ToList();
                var tags = new List<Tag>();
                foreach (var item in projectTags)
                {
                    tags.Add(context.Tag.FirstOrDefault(x => x.Id == item.TagId));
                }
                return tags;
            }
            catch (Exception)
            {

                return new JsonResult("Unprocessable");
            }
        }

        [Authorize]
        [HttpGet("getprojectcomments/{id}")]
        public async Task<ActionResult<Object>> GetProjectComments([FromRoute] string id)
        {

            try
            {
                var allComm = context.ProjectComment.Where(x=> x.ProjectId==Guid.Parse(id)).ToList();
                foreach (var item in allComm)
                {
                    item.Commentor = context.Users.FirstOrDefault(x => x.Id == item.CommentorId);
                }
                return allComm;
            }
            catch (Exception)
            {

                return new JsonResult("Unprocessable");
            }
        }


        [Authorize]
        [HttpPost("removeemployeefromproject")]
        public async Task<ActionResult<Object>> RemoveEmployeeFromProject(RemoveEmployeeFromProjectDto dto)
        {
            try
            {
                var employeeProject = context.EmployeeProject.Where(x => x.CompanyProjectId == Guid.Parse(dto.CompanyProjectId) && x.UserId == dto.UserId).First();
                if(employeeProject != null)
                {
                    context.EmployeeProject.Remove(employeeProject);
                context.SaveChanges();
                return Ok(); 
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }

        [Authorize]
        [HttpPost("deleteprojecttag")]
        public async Task<ActionResult<Object>> DeleteProjectTag(DeleteProjectTagDto dto)
        {
            var tag = context.ProjectTag.First(x => x.Id == Guid.Parse(dto.TagId));
            if(tag==null)
            {
                return NotFound();
            }

            try
            {
                context.ProjectTag.Remove(tag);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }

        [Authorize]
        [HttpPost("addprojecttag")]
        public async Task<ActionResult<Object>> AddProjectTag(AddProjectTagDto dto)
        {
            var project = context.CompanyProject.First(x => x.Id == Guid.Parse(dto.ProjectId));
            var tag = context.Tag.First(x => x.Id == Guid.Parse(dto.TagId));
            if( project == null || tag==null)
            {
                return NotFound();
            }

            try
            {
                
                var newProjectTag = new ProjectTag();
                newProjectTag.Id = Guid.NewGuid();
                newProjectTag.Project = project;
                newProjectTag.ProjectId = project.Id;
                newProjectTag.TagId = tag.Id;
                newProjectTag.Tag = tag;
                context.ProjectTag.Add(newProjectTag);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }

        [Authorize]
        [HttpPost("addtag")]
        public async Task<ActionResult<Object>> AddTag(AddTagDto dto)
        {

            try
            {
                var newTag = new Tag();
                newTag.Id = Guid.NewGuid();
                newTag.Title = dto.Name;
                context.Tag.Add(newTag);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }
                
        
        [HttpPost("deleteprojectcomment")]
        public async Task<ActionResult<Object>> DeleteProjectComment(DeleteProjectCommentDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var comment = context.ProjectComment.Where(x => x.Id == Guid.Parse(dto.CommentId)).First();
            if (user == null || comment == null)
            {
                return NotFound();
            }
            if (comment.CommentorId!=user.Id)
            {
                return Unauthorized();
            }

            try
            {
                context.ProjectComment.Remove(comment);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }



        [Authorize]
        [HttpPost("addprojectcomment")]
        public async Task<ActionResult<Object>> AddProjectComment(AddProjectCommentDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var project = context.CompanyProject.Where(x => x.Id == dto.ProjectId).First();
            if (user == null || project==null)
            {
                return NotFound();
            }

            try
            {
                var newComment = new ProjectComment();
                newComment.Id = Guid.NewGuid();
                newComment.ProjectId = dto.ProjectId;
                newComment.Project = project;
                newComment.Commentor = user;
                newComment.CommentorId = user.Id;
                newComment.Comment = dto.Comment;
                context.ProjectComment.Add(newComment);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }        
        
        
        
        [Authorize]
        [HttpPost("addproject")]
        public async Task<ActionResult<Object>> AddCompanyProject(AddCompanyProjectDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var newProject = new CompanyProject();
                newProject.Id = Guid.NewGuid();
                newProject.Name = dto.Name;
                newProject.Description = dto.Description;
                newProject.Active = true;
                newProject.Comments = new List<ProjectComment>();
                newProject.Employees = new List<EmployeeProject>();
                context.CompanyProject.Add(newProject);

                foreach (var item in dto.TagIds)
                {
                    var newtag = new Tag();
                    newtag.Id = Guid.NewGuid();
                    newtag.Title = item;
                    context.Tag.Add(newtag);
                    var newProjectTag = new ProjectTag();
                    newProjectTag.Id = Guid.NewGuid();
                    newProjectTag.TagId = newtag.Id;
                    newProjectTag.ProjectId = newProject.Id;
                    context.ProjectTag.Add(newProjectTag);

                }
                context.SaveChanges();
                var newLead = new ProjectLead();
                newLead.Id = Guid.NewGuid();
                newLead.LeadId=dto.ProjectLeadId;
                newLead.ProjectId = newProject.Id;
                context.ProjectLead.Add(newLead);

                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }


        }


    }
}
