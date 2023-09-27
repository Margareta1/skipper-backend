using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.SurveyCreator
{
    public class RadioGroup : ISurveyQuestion
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

        //Radio option dictionary ought to be sent with first string being the value and second being the label
        [Required]
        public List<InputOptions> RadioOptions { get; set; }
    }
}
