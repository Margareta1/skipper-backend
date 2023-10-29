using skipper_backend.Identity;
using skipper_backend.Models.General;
using skipper_backend.Models.Project;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddEmployeeToProjectDto
    {
        public Guid CompanyProjectId { get; set; }
        public string EmployeeUsername { get; set; }
        public Guid UtilizationTypeId { get; set; }
        public double Utilization { get; set; }
    }
}
