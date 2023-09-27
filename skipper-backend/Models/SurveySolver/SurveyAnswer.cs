using skipper_backend.Models.SurveyCreator;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.SurveySolver
{
    public class SurveyAnswer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int OrderKey { get; set; }

        public bool? CheckboxOrRadio { get; set; }
        public string? TextInputOrArea { get; set; }
        public double? InputNumberOrRateOrSlider { get; set; }
        //dictionary ought to be sent with first string being the value and second being the label
        public InputOptions? RadioGroupOrSingleSelect { get; set; }
        public List<InputOptions>? MultipleSelect { get; set; }
    }
}
