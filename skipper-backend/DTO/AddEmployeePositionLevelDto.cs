using skipper_backend.Identity;
using skipper_backend.Models.General;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddEmployeePositionLevelDto
    {

        public string EmployeeUsername { get; set; }
        public Guid LevelOfExperienceId { get; set; }
        public Guid PositionId { get; set; }
    }
}
