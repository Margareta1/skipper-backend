using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skipper_backend.DTO;
using skipper_backend.Identity;
using skipper_backend.Models.Project;
using skipper_backend.Models.SkillsMatrix;
using skipper_backend.Store;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace skipper_backend.Controllers
{
    public class SkillsMatrixController : BaseApiController
    {
        private readonly UserManager<User> userManager;
        private readonly TokenService tokenService;
        private readonly StoreContext context;

        public SkillsMatrixController(UserManager<User> manager, TokenService service,
            StoreContext storeContext)
        {
            userManager = manager;
            tokenService = service;
            context = storeContext;
        }

        //delete matrix not working?
        // check solve

        [Authorize]
        [HttpPost("compareskillsmatrixinput")]
        public async Task<ActionResult<Object>> CompareSkillsMatrixInputs(DeleteSkillsMatrix dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var sm = context.SkillsMatrix.Where(x=> x.Id==Guid.Parse(dto.SkillsMatrixId)).First();

            if (user == null || sm==null)
            {
                return NotFound();
            }
            try
            {
                return context.SkillsMatrixInput.Where(x => x.Id == Guid.Parse(dto.SkillsMatrixId)).ToList();
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }

        [Authorize]
        [HttpPost("deleteskillsmatrix")]
        public async Task<ActionResult<Object>> DeleteSkillsMatrix(DeleteSkillsMatrix dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var sm = context.SkillsMatrix.Where(x=> x.Id==Guid.Parse(dto.SkillsMatrixId)).First();

            if (user == null || sm==null)
            {
                return NotFound();
            }

            if (sm.CreatorId!=user.Id)
            {
                return Unauthorized();
            }

            try
            {
                context.SkillsMatrix.Remove(sm);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }

        [Authorize]
        [HttpPost("solveskillsmatrix")]
        public async Task<ActionResult<Object>> SolveSkillsMatrix(AddSkillsMatrixInputDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var sm = context.SkillsMatrix.Include(x=>x.Inputs).Where(x=> x.Id==Guid.Parse(dto.SkillsMatrixId)).First();

            if (user == null || sm==null)
            {
                return NotFound();
            }

            try
            {

                var newInput = new SkillsMatrixInput
                {
                    // Other properties...
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    Assignee = user,
                    AssigneeId = user.Id

            };
                newInput.Inputs = dto.Inputs.Select(item => new SkillsMatrixSingleSkillInput
                {
                    Id = Guid.NewGuid(),
                    Input = item.Input,
                    OrderKey = item.OrderKey,
                    SkillsMatrixInput = newInput,
                    SkillsMatrixInputID = newInput.Id

                }).ToList();


               sm.Inputs.Add(newInput);
                context.SkillsMatrixInput.Add(newInput);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }


        [Authorize]
        [HttpPost("addskillsmatrix")]
        public async Task<ActionResult<Object>> AddSkillsMatrix(AddSkillsMatrixDto dto)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var newSkillsMatrix = new SkillsMatrix();
                newSkillsMatrix.Id = Guid.NewGuid();
                newSkillsMatrix.Rgb = dto.Rgb;
                newSkillsMatrix.Creator = user;
                newSkillsMatrix.CreatorId = user.Id;
                newSkillsMatrix.CreatedAt = DateTime.Now;
                newSkillsMatrix.Skills = new List<SkillsMatrixSingleSkill>();
                newSkillsMatrix.Assignees = new List<User>();
                foreach (var item in dto.AssigneesIds)
                {
                    var assignee = context.Users.Where(x => x.Id == item).First();
                    newSkillsMatrix.Assignees.Add(assignee);
                }
                foreach (var item in dto.Skills)
                {
                    var singleskill = new SkillsMatrixSingleSkill();
                    singleskill.Id = Guid.NewGuid();
                    singleskill.SkillTitle = item.SkillTitle;
                    singleskill.SkillDescription = item.SkillDescription;
                    singleskill.RangeFrom = item.RangeFrom;
                    singleskill.RangeTo = item.RangeTo;
                    singleskill.OrderKey = item.OrderKey;
                    context.SkillsMatrixSingleSkill.Add(singleskill);
                    newSkillsMatrix.Skills.Add(singleskill);
                }
                context.SkillsMatrix.Add(newSkillsMatrix);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }

        [Authorize]
        [HttpGet("getallskillsmatrixes")]
        public async Task<ActionResult<Object>> GetAllSkillsMatrixes()
        {

            try
            {
                var all= context.SkillsMatrix.Include(x=>x.Assignees).Include(x=>x.Skills).Include(x=>x.Inputs).ToList();
                return all;
            }
            catch (Exception)
            {

                return new JsonResult("Unprocessable");
            }


        }

        [Authorize]
        [HttpGet("getassignedskillsmatrixes")]
        public async Task<ActionResult<Object>> GetAssignedSkillsMatrixes()
        {

            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            try
            {
                var all = context.SkillsMatrix.Include(x=>x.Skills).Include(x=>x.Inputs).Include(x=>x.Assignees).ToList();
                var allM = context.SkillsMatrix.Include(x=>x.Assignees).Where(x => x.Assignees.Any(x=>x.UserName==username)).ToList();
                return allM;
            }
            catch (Exception)
            {

                return new JsonResult("Unprocessable");
            }
        }

        [Authorize]
        [HttpGet("getskillsmatrix/{id}")]
        public async Task<ActionResult<Object>> GetSkillsMatrix([FromRoute] string id)
        {
            var username = User.Identity.Name;
            var user = await userManager.FindByNameAsync(username);
            var skillsm = context.SkillsMatrix.First(x => x.Id == Guid.Parse(id));
            
            if(skillsm == null)
            {
                return Unauthorized();
            }
            try
            {
                return context.SkillsMatrix
    .Include(s => s.Skills)
    .Include(s=>s.Inputs)
    .FirstOrDefault(s => s.Id == Guid.Parse(id));


            }
            catch (Exception e)
            {
                return new JsonResult("Unprocessable");
            }
        }

        [Authorize]
        [HttpGet("getskillsmatrixinput/{matrixid}")]
        public async Task<ActionResult<Object>> GetSkillsMatrixInput([FromRoute] string matrixid)
        {
            try
            {
                var x= context.SkillsMatrixInput.Include(x=>x.Assignee).Include(x=>x.Inputs).ToList();

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                var jsonString = JsonSerializer.Serialize(x, options);
                return jsonString;
            }
            catch (Exception)
            {
                return new JsonResult("Unprocessable");
            }
        }

        

    }
}
