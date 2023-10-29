using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddGoalDto
    {
        public string UserName { get; set; }
        public string Description { get; set; }
    }
}
