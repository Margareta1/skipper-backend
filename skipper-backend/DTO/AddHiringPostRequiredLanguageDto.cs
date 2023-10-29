using skipper_backend.Models.General;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddHiringPostRequiredLanguageDto
    {

        public string LanguageId { get; set; }
        public string LanguageLevelId { get; set; }
    }
}
