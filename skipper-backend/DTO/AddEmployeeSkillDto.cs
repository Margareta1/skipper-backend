using skipper_backend.Identity;
using skipper_backend.Models.General;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddEmployeeSkillDto
    {

        public string EmployeeUsername { get; set; }
        public Guid GeneralSkillId { get; set; }
    }
}
