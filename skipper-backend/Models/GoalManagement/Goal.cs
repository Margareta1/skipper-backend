using skipper_backend.Identity;
using skipper_backend.Models.General;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.GoalManagement
{
    public class Goal
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public User User { get; set; }

        public string Description { get; set; }
    }
}
