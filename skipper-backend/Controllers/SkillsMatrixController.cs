using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using skipper_backend.DTO;
using skipper_backend.Identity;
using skipper_backend.Models.Project;
using skipper_backend.Models.SkillsMatrix;
using skipper_backend.Store;

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
            var sm = context.SkillsMatrix.Where(x=> x.Id==Guid.Parse(dto.SkillsMatrixId)).First();

            if (user == null || sm==null)
            {
                return NotFound();
            }

            try
            {
                var newInput = new SkillsMatrixInput();
                newInput.Id = Guid.NewGuid();
                newInput.CreatedAt = DateTime.Now;
                newInput.Assignee = user;
                newInput.AssigneeId = user.Id;
                newInput.Inputs = new List<SkillsMatrixSingleSkillInput>();

                foreach (var item in dto.Inputs)
                {

                    newInput.Inputs.Add(new SkillsMatrixSingleSkillInput
                    {
                        Id = Guid.NewGuid(),
                        Input = item.Input,
                        OrderKey = item.OrderKey
                    });
                }
                sm.Inputs.Add(newInput);
                context.SkillsMatrix.Update(sm);
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
                return context.SkillsMatrix.ToList();
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
                return context.SkillsMatrix.Where(x => x.Assignees.Contains(user)).ToList();
            }
            catch (Exception)
            {

                return new JsonResult("Unprocessable");
            }
        }

    }
}
