using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skipper_backend.DTO;
using skipper_backend.Identity;
using skipper_backend.Store;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using skipper_backend.Models.Employee;

namespace skipper_backend.Controllers
{

    public class EmployeeController : BaseApiController
    {
        private readonly UserManager<User> manager;
        private readonly StoreContext context;

        public EmployeeController(UserManager<User> userManager,StoreContext context)
        {
            context = context;
            manager = userManager;

        }

        //add employee to line
        //add employee language
        //add employee position and level
        //add employee skill
        //add employee project with utilization
        //employee wants to leave project

        [Authorize]
        [HttpGet("getallemployees")]
        public async Task<ActionResult<Object>> GetAllEmployees()
        {
            try
            {
                var allUsers = new List<UserBasicInfoDto>();
                foreach (var user in context.Users)
                {
                UserBasicInfoDto newUserInfo = new UserBasicInfoDto();
                newUserInfo.User = user;
                newUserInfo.Languages = context.EmployeeLanguage.Where(l => l.EmployeeId == user.Id).ToList();
                newUserInfo.Line = context.Line.Where(l => l.Employees.Contains(user)).First();
                newUserInfo.PositionAndLevel = context.EmployeePositionAndLevel.Where(p => p.EmployeeId == user.Id).ToList();
                newUserInfo.Projects = context.EmployeeProject.Where(p => p.UserId == user.Id).ToList();
                    allUsers.Add(newUserInfo);
                }
                return allUsers;
            }
            catch (Exception)
            {

                return NotFound();
            }
        }


        [Authorize]
        [HttpGet("getbasicinfo")]
        public async Task<ActionResult<Object>> GetBasicInfo(GetBasicInfoDto dto)
        {
            var user = await manager.FindByNameAsync(dto.UserName);
            if (user == null)
            {
                return NotFound();
            }
            try
            {
                UserBasicInfoDto newUserInfo = new UserBasicInfoDto();
                newUserInfo.User = user;
                newUserInfo.Languages = context.EmployeeLanguage.Where(l => l.EmployeeId == user.Id).ToList();
                newUserInfo.Line = context.Line.Where(l => l.Employees.Contains(user)).First();
                newUserInfo.PositionAndLevel = context.EmployeePositionAndLevel.Where(p => p.EmployeeId == user.Id).ToList();
                newUserInfo.Projects = context.EmployeeProject.Where(p => p.UserId==user.Id).ToList();
                return Ok();
            }
            catch (Exception)
            {

                return NotFound();
            }
        }


        [Authorize]
        [HttpGet("getalllines")]
        public async Task<ActionResult<Object>> GetAllLines()
        {
            var username = User.Identity.Name;
            var user = await manager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            return context.Line.ToList();
        }


        [Authorize]
        [HttpGet("getlinesubordinates")]
        public async Task<ActionResult<Object>> GetLineSubordinates()
        {
            var username = User.Identity.Name;
            var user = await manager.FindByNameAsync(username);
            var isManager = await manager.IsInRoleAsync(user, "Manager");
            if (user == null)
            {
                return NotFound();
            }
            if(!isManager)
            {
                return Unauthorized();
            }

            return context.Line.Where(l=> l.LineManagerId==user.Id).Include(k=> k.Employees).First();
        }


        [Authorize]
        [HttpPost("addline")]
        public async Task<ActionResult<Object>> AddLine(AddLineDto dto)
        {
            var username = User.Identity.Name;
            var user = await manager.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var newLine = new Line()
                {
                    Id = Guid.NewGuid(),
                    LineManager = await manager.FindByIdAsync(dto.LineManagerId),
                    LineManagerId = dto.LineManagerId
                };
                foreach (var item in dto.Employees)
                {
                    newLine.Employees.Add(await manager.FindByIdAsync(item));
                }
                context.Line.Add(newLine);
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
