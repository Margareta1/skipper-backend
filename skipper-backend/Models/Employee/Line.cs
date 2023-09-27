using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.Employee
{
    public class Line
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string LineManagerId { get; set; }
        public User LineManager { get; set; }

        public IList<User> Employees { get; set; }
    }
}
