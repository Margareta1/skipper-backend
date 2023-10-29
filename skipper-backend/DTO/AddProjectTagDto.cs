using skipper_backend.Models.Project;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddProjectTagDto
    {
        public string TagId { get; set; } 
        public string ProjectId { get; set; }
    }
}
