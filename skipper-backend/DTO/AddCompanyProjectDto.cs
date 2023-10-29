using skipper_backend.Models.Employee;
using skipper_backend.Models.Project;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddCompanyProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectLeadId { get; set; }
        public IList<string> TagIds { get; set; }
    }

}
