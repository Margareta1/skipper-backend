using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.SurveyCreator
{
    public class InputOptions
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string Label { get; set; }
    }
}
