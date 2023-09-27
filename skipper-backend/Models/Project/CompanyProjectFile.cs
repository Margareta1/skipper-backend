using skipper_backend.Models.Staffing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.Project
{
    public class CompanyProjectFile
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(CompanyProject))]
        public Guid CompanyProjectId { get; set; }
        public CompanyProject CompanyProject { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
