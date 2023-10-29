using skipper_backend.Identity;
using skipper_backend.Models.Project;

namespace skipper_backend.DTO
{
    public class RemoveEmployeeFromProjectDto
    {
        public string CompanyProjectId { get; set; }
        public string UserId { get; set; }
    }
}
