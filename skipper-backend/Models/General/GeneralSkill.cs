using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.General
{
    public class GeneralSkill
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
