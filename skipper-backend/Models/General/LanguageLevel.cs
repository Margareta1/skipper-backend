using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.General
{
    public class LanguageLevel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Level { get; set; }
    }
}
