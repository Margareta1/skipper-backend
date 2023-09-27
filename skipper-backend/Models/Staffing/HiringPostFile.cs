using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.Staffing
{
    public class HiringPostFile
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
