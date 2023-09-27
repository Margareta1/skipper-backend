using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using skipper_backend.Models.General;

namespace skipper_backend.Models.Employee
{
    public class EmployeeSkill
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string EmployeeId { get; set; }
        public User Employee { get; set; }

        [Required]
        [ForeignKey(nameof(GeneralSkill))]
        public Guid GeneralSkillId { get; set; }
        public GeneralSkill GeneralSkill { get; set; }
    }
}
