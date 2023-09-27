using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.Project
{
    public class ProjectTag
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Tag))]
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

        [Required]
        [ForeignKey(nameof(CompanyProject))]
        public Guid ProjectId { get; set; }
        public CompanyProject Project { get; set; }
    }
}
