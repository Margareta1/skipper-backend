using skipper_backend.Identity;
using skipper_backend.Models.General;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.Employee
{
    public class EmployeePositionAndLevel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string EmployeeId { get; set; }
        public User Employee { get; set; }

        [Required]
        [ForeignKey(nameof(LevelOfExperience))]
        public Guid LevelOfExperienceId { get; set; }
        public LevelOfExperience LevelOfExperience { get; set; }

        [Required]
        [ForeignKey(nameof(Position))]
        public Guid PositionId { get; set; }
        public Position Position { get; set; }
    }
}
