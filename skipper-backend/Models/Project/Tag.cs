using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.Project
{
    public class Tag
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
