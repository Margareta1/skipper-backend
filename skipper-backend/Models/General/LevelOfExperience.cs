using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.General
{
    public class LevelOfExperience
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
