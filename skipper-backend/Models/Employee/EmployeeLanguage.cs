using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using skipper_backend.Identity;
using skipper_backend.Models.General;

namespace skipper_backend.Models.Employee
{
    public class EmployeeLanguage
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

        [Required]
        [ForeignKey(nameof(User))]
        public string EmployeeId { get; set; }
        public User Employee { get; set; }

    }
}
