using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.SurveyCreator
{
    public class Slider : ISurveyQuestion
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Survey))]
        public Guid SurveyId { get; set; }
        public Survey Survey { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public int OrderKey { get; set; }

        [Required]
        public double DefaultValue { get; set; }

        [Required]
        public double MinValue { get; set; }

        [Required]
        public double MaxValue { get; set; }

        public string? LabelLeft { get; set; }
        public string? LabelRight { get; set; }
    }
}
