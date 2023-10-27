using skipper_backend.Models.CV;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class CVItemDto
    {
        public string Title { get; set; }
        public string EducationExperienceOrCert { get; set; }
        public string? Description { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
