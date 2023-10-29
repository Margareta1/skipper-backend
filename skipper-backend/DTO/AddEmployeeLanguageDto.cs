using skipper_backend.Identity;
using skipper_backend.Models.General;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddEmployeeLanguageDto
    {

        public Guid LanguageId { get; set; }
        public Guid LanguageLevelId { get; set; }
        public string EmployeeUsername { get; set; }
    }
}
