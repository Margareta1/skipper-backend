using skipper_backend.Identity;
using skipper_backend.Models.Project;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddProjectCommentDto
    {
        public Guid ProjectId { get; set; }
        public string Comment { get; set; }

    }
}
