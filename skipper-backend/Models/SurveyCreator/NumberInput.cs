using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.SurveyCreator
{
    public class NumberInput : ISurveyQuestion
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
        public int MinValue { get; set; }

        [Required]
        public int MaxValue { get; set; }

        public int? DefaultValue { get; set; }
    }
}
