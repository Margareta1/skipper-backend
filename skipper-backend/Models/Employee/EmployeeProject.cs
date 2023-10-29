using skipper_backend.Identity;
using skipper_backend.Models.General;
using skipper_backend.Models.Project;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skipper_backend.Models.Employee
{

    public class EmployeeProject
    {
        public Guid Id { get; set; }
        public Guid CompanyProjectId { get; set; }
        public CompanyProject CompanyProject { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey(nameof(UtilizationType))]
        public Guid UtilizationTypeId { get; set; }
        public UtilizationType UtilizationType { get; set; }
        public double Utilization { get; set; }
  
    }
}
