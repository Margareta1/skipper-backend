using skipper_backend.Identity;
using skipper_backend.Models.Employee;
using skipper_backend.Models.Project;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class GetProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<ProjectComment> Comments { get; set; }
        public IList<EmployeeProject> Employees { get; set; }
        public User  ProjectLead { get; set; }
        public IList<ProjectTag> Tags { get; set; }
    }
}
