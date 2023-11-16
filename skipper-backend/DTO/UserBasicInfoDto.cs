using skipper_backend.Identity;
using skipper_backend.Models.Employee;
using skipper_backend.Models.Project;

namespace skipper_backend.DTO
{
    public class UserBasicInfoDto
    {
        public User  User { get; set; }
        public List<string> Languages { get; set; }
        public string Position { get; set; }
        public string Level { get; set; }
        public string UtilizationType { get; set; }
        public string Utilization { get; set; }
        public IList<EmployeeProject> Projects { get; set; }
        public Line Line { get; set; }
    }
}
