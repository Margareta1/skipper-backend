using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.Project
{
    public class ProjectLead
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string LeadId { get; set; }
        public User Lead { get; set; }
        [Required]
        [ForeignKey(nameof(CompanyProject))]
        public Guid ProjectId { get; set; }
        public CompanyProject Project { get; set; }
    }
}
