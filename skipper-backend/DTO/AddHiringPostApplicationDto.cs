using skipper_backend.Identity;
using skipper_backend.Models.Staffing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class AddHiringPostApplicationDto
    {
        public string HiringPostId { get; set; }
    }
}
