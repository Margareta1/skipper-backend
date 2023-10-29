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
using System.Runtime.ExceptionServices;

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

        [Authorize]
        [HttpPost("addemployeetoproject")]
        public async Task<ActionResult<Object>> AddEmployeeToProject(AddEmployeeToProjectDto dto)
        {
            var user = await manager.FindByNameAsync(dto.EmployeeUsername);
            var project = context.CompanyProject.Where(x => x.Id == dto.CompanyProjectId).First();
            var utilizationType = context.UtilizationType.Where(x => x.Id == dto.UtilizationTypeId).First();

            if (user == null || project ==null || utilizationType==null)
            {
                return NotFound();
            }

            try
            {
                var newEmployeeProject = new EmployeeProject();
                newEmployeeProject.Id = Guid.NewGuid();
                newEmployeeProject.User = user;
                newEmployeeProject.UserId = user.Id;
                newEmployeeProject.CompanyProject = project;
                newEmployeeProject.CompanyProjectId = project.Id;
                newEmployeeProject.Utilization = dto.Utilization;
                newEmployeeProject.UtilizationTypeId = utilizationType.Id;
                newEmployeeProject.UtilizationType = utilizationType;
                context.EmployeeProject.Add(newEmployeeProject);
                context.SaveChanges();
                return Ok();
                
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }               
        
        [Authorize]
        [HttpPost("addemployeeskill")]
        public async Task<ActionResult<Object>> AddEmployeeSkill(AddEmployeeSkillDto dto)
        {
            var user = await manager.FindByNameAsync(dto.EmployeeUsername);
            var skill = context.GeneralSkill.Where(x => x.Id == dto.GeneralSkillId).First();
            if (user == null || skill ==null)
            {
                return NotFound();
            }

            try
            {
                var newEmployeeSkill = new EmployeeSkill();
                newEmployeeSkill.GeneralSkill = skill;
                newEmployeeSkill.GeneralSkillId = skill.Id;
                newEmployeeSkill.Id = Guid.NewGuid();
                newEmployeeSkill.EmployeeId = user.Id;
                newEmployeeSkill.Employee = user;
                context.EmployeeSkill.Add(newEmployeeSkill);
               context.SaveChanges();
                return Ok();
                
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }                  
        
        [Authorize]
        [HttpPost("addemployeepositionlevel")]
        public async Task<ActionResult<Object>> AddEmployeePositionLevel(AddEmployeePositionLevelDto dto)
        {
            var user = await manager.FindByNameAsync(dto.EmployeeUsername);
            var position = context.Position.Where(x => x.Id == dto.PositionId).First();
            var level = context.LevelOfExperience.Where(x => x.Id == dto.LevelOfExperienceId).First();
            if (user == null || position ==null || level==null)
            {
                return NotFound();
            }

            try
            {
                var newPositionLevel = new EmployeePositionAndLevel();
                newPositionLevel.Position = position;
                newPositionLevel.PositionId = position.Id;
                newPositionLevel.Id = Guid.NewGuid();
                newPositionLevel.Employee = user;
                newPositionLevel.EmployeeId = user.Id;
                newPositionLevel.LevelOfExperienceId = level.Id;
                newPositionLevel.LevelOfExperience = level;
                context.EmployeePositionAndLevel.Add(newPositionLevel);
               context.SaveChanges();
                return Ok();
                
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }           
        
        
        [Authorize]
        [HttpPost("addemployeelanguage")]
        public async Task<ActionResult<Object>> AddEmployeeToLine(AddEmployeeLanguageDto dto)
        {
            var user = await manager.FindByNameAsync(dto.EmployeeUsername);
            var language = context.Language.Where(x => x.Id == dto.LanguageId).First();
            var languageLevel = context.LanguageLevel.Where(x => x.Id == dto.LanguageLevelId).First();
            if (user == null || language ==null || languageLevel==null)
            {
                return NotFound();
            }

            try
            {
                var newEmployeeLanguage = new EmployeeLanguage();
                newEmployeeLanguage.Id = Guid.NewGuid();
                newEmployeeLanguage.Language = language;
                newEmployeeLanguage.LanguageId = language.Id;
                newEmployeeLanguage.LanguageLevel = languageLevel;
                newEmployeeLanguage.LanguageLevelId = languageLevel.Id;
                newEmployeeLanguage.Employee = user;
                newEmployeeLanguage.EmployeeId = user.Id;
                context.EmployeeLanguage.Add(newEmployeeLanguage);
               context.SaveChanges();
                return Ok();
                
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }        
        
        [Authorize]
        [HttpPost("addemployeetoline")]
        public async Task<ActionResult<Object>> AddEmployeeToLine(AddEmployeeToLineDto dto)
        {
            var user = await manager.FindByNameAsync(dto.EmployeeUsername);
            var lineManager = await manager.FindByEmailAsync(dto.ManagerUsername);
            if (user == null || lineManager ==null)
            {
                return NotFound();
            }

            try
            {
                var line = context.Line.Where(x=> x.LineManager==lineManager).First().Employees.Append(user);
               context.SaveChanges();
                return Ok();
                
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }


        }


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
