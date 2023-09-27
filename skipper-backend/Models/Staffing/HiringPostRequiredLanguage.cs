using skipper_backend.Models.General;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skipper_backend.Models.Staffing
{
    public class HiringPostRequiredLanguage
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey(nameof(Language))]
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }

        [Required]
        [ForeignKey(nameof(LanguageLevel))]
        public Guid LanguageLevelId { get; set; }
        public LanguageLevel LanguageLevel { get; set; }

    }
}
