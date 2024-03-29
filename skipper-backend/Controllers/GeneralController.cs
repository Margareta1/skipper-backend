﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skipper_backend.DTO;
using skipper_backend.Identity;
using skipper_backend.Models.Employee;
using skipper_backend.Models.General;
using skipper_backend.Store;

namespace skipper_backend.Controllers
{
    public class GeneralController : BaseApiController
    {
        private readonly UserManager<User> userManager;
        private readonly TokenService tokenService;
        private readonly StoreContext context;

        public GeneralController(UserManager<User> manager, TokenService service,
            StoreContext storeContext)
        {
            userManager = manager;
            tokenService = service;
            context = storeContext;

        }


        [Authorize]
        [HttpGet("getallutilizationtypes")]
        public async Task<ActionResult<Object>> GetAllUtilizationTypes()
        {
            try
            {
                return context.UtilizationType.ToList();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [Authorize]
        [HttpGet("getalllanguagelevels")]
        public async Task<ActionResult<Object>> GetAllLanguageLevels()
        {
            try
            {
                return context.LanguageLevel.ToList();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("getalllanguages")]
        public async Task<ActionResult<Object>> GetAllLanguages()
        {
            try
            {
                return context.Language.ToList();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [Authorize]
        [HttpGet("getalllevelsofexperience")]
        public async Task<ActionResult<Object>> GetAllLevelsOfExperience()
        {
            try
            {
                return context.LevelOfExperience.ToList();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("getallgeneralskills")]
        public async Task<ActionResult<Object>> GetAllGeneralSkills()
        {
            try
            {
                return context.GeneralSkill.ToList();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [Authorize]
        [HttpGet("getallpositions")]
        public async Task<ActionResult<Object>> GetAllPositions()
        {
            try
            {
                return context.Position.ToList();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet("getapppreferences")]
        public async Task<ActionResult<Object>> GetAppPreferences()
        {
            try
            {
                if (context.AppPreferences.ToList().Count == 0)
                {
                    return Ok("No entry");
                }
                return context.AppPreferences.ToList()[0];
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("changeapppreferences")]
        public async Task<ActionResult<Object>> ChangeAppPreferences(ChangeAppPreferencesDto dto)
        {

            if (context.AppPreferences.ToList().Count ==0)
            {
                try
                {
                    var newAppPreferences = new AppPreferences();
                    newAppPreferences.Id = Guid.NewGuid();
                    newAppPreferences.CompanyName = dto.CompanyName;
                    newAppPreferences.Rgb = dto.Rgb;
                    context.AppPreferences.Add(newAppPreferences);
                    context.SaveChanges();
                    return Ok();

                }
                catch (Exception)
                {
                    return UnprocessableEntity();
                }
            }
            else
            {
                try
                {
                    var appPreferences = context.AppPreferences.ToList()[0];
                    appPreferences.CompanyName = dto.CompanyName;
                    appPreferences.Rgb = dto.Rgb;
                    context.AppPreferences.Update(appPreferences);
                    context.SaveChanges();
                    return Ok();
                }
                catch (Exception)
                {
                    return UnprocessableEntity();
                }
                
            }
        }


        [Authorize]
        [HttpPost("addlevelofexperience")]
        public async Task<ActionResult<Object>> AddLevelOfExperience(AddLevelOfExperienceDto dto)
        {

            if (context.LevelOfExperience.Any(x=> x.Title==dto.Title))
            {
                return BadRequest();
            }

            try
            {
                var newLevelOfExperience = new LevelOfExperience();
                newLevelOfExperience.Title = dto.Title;
                newLevelOfExperience.Id = Guid.NewGuid();
                context.LevelOfExperience.Add(newLevelOfExperience);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [Authorize]
        [HttpPost("addgeneralskill")]
        public async Task<ActionResult<Object>> AddGeneralSkill(AddGeneralSkillDto dto)
        {

            if (context.GeneralSkill.Any(x => x.Name == dto.Name))
            {
                return BadRequest();
            }

            try
            {
                var newGeneralSkill = new GeneralSkill();
                newGeneralSkill.Id = Guid.NewGuid();
                newGeneralSkill.Name = dto.Name;
                context.GeneralSkill.Add(newGeneralSkill);
                context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }
        }

        [Authorize]
        [HttpPost("addlanguage")]
        public async Task<ActionResult<Object>> AddLanguage(AddLanguageDto dto)
        {

            if (context.Language.Any(x=> x.Name==dto.Name))
            {
                return BadRequest();
            }

            try
            {
                var newLanguage = new Language();
                newLanguage.Id = Guid.NewGuid();
                newLanguage.Name = dto.Name;
                context.Language.Add(newLanguage);
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
