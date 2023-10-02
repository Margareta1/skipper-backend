using skipper_backend.Identity;
using skipper_backend.Models.Project;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skipper_backend.Models.Employee
{
    public class ProjectEmployee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string EmployeeId { get; set; }
        public User? Employee { get; set; }
        [Required]
        [ForeignKey(nameof(CompanyProject))]
        public Guid CompanyProjectId { get; set; }
        public CompanyProject CompanyProject { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
