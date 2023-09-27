using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.General
{
    public class Position
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
