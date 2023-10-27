using skipper_backend.Identity;
using skipper_backend.Models.Employee;
using skipper_backend.Models.Project;

namespace skipper_backend.DTO
{
    public class UserBasicInfoDto
    {
        public User  User { get; set; }
        public IList<EmployeeLanguage>   Languages { get; set; }
        public IList<EmployeePositionAndLevel> PositionAndLevel { get; set; }
        public Line Line { get; set; }
        public IList<EmployeeProject> Projects { get; set; }
    }
}
