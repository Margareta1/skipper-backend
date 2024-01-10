using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using skipper_backend.Identity;
using skipper_backend.Models.CV;
using skipper_backend.Models.Employee;
using skipper_backend.Models.General;
using skipper_backend.Models.GoalManagement;
using skipper_backend.Models.Project;
using skipper_backend.Models.SkillsMatrix;
using skipper_backend.Models.Staffing;
using skipper_backend.Models.SurveyCreator;
using skipper_backend.Models.SurveySolver;
using System.Data;
using static skipper_backend.Models.Employee.EmployeeProject;
using System.Reflection.Emit;

namespace skipper_backend.Store
{
    public class StoreContext : IdentityDbContext<User>
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }  

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
                    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Member", NormalizedName = "MEMBER" },
                    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" }
                );
            builder.Entity<EmployeeProject>()
       .HasKey(ep => new { ep.CompanyProjectId, ep.UserId });

            builder.Entity<EmployeeProject>()
                .HasOne(ep => ep.CompanyProject)
                .WithMany(p => p.Employees)
                .HasForeignKey(ep => ep.CompanyProjectId)
                .OnDelete(DeleteBehavior.Restrict);


        }

        public DbSet<CV> CV { get; set; }
        public DbSet<CVItem> CVItem { get; set; }
        public DbSet<EmployeeLanguage> EmployeeLanguage { get; set; }
        public DbSet<EmployeePositionAndLevel> EmployeePositionAndLevel { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkill { get; set; }
        public DbSet<Line> Line { get; set; }
        public DbSet<AppPreferences> AppPreferences { get; set; }
        public DbSet<GeneralSkill> GeneralSkill { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<LanguageLevel> LanguageLevel { get; set; }
        public DbSet<LevelOfExperience> LevelOfExperience { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<UtilizationType> UtilizationType { get; set; }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<CompanyProject> CompanyProject { get; set; }
        public DbSet<CompanyProjectFile> CompanyProjectFile { get; set; }
        public DbSet<ProjectComment> ProjectComment { get; set; }
        public DbSet<ProjectTag> ProjectTag { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<SkillsMatrix> SkillsMatrix { get; set; }
        public DbSet<SkillsMatrixInput> SkillsMatrixInput { get; set; }
        public DbSet<SkillsMatrixSingleSkill> SkillsMatrixSingleSkill { get; set; }
        public DbSet<SkillsMatrixSingleSkillInput> SkillsMatrixSingleSkillInput { get; set; }
        public DbSet<HiringPost> HiringPost { get; set; }
        public DbSet<HiringPostApplication> HiringPostApplication { get; set; }
        public DbSet<HiringPostComment> HiringPostComment { get; set; }
        public DbSet<HiringPostFile> HiringPostFile { get; set; }
        public DbSet<HiringPostRequiredLanguage> HiringPostRequiredLanguage { get; set; }
        public DbSet<Checkbox> Checkbox { get; set; }
        public DbSet<InputOptions> InputOptions { get; set; }
        public DbSet<NumberInput> NumberInput { get; set; }
        public DbSet<Radio> Radio { get; set; }
        public DbSet<RadioGroup> RadioGroup { get; set; }
        public DbSet<Rate> Rate { get; set; }
        public DbSet<SelectMultiple> SelectMultiple { get; set; }
        public DbSet<SelectSingle> SelectSingle { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<SurveyAssignee> SurveyAssignee { get; set; }
        public DbSet<TextArea> TextArea { get; set; }
        public DbSet<TextInput> TextInput { get; set; }
        public DbSet<SurveyInput> SurveyInput { get; set; }
        public DbSet<ProjectLead> ProjectLead { get; set; }
        public DbSet<EmployeeProject> EmployeeProject { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswer { get; set; }
    }
    
}
