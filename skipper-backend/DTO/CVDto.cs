using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace skipper_backend.DTO
{
    public class CVDto
    {
        public string Status { get; set; }
        public string? About { get; set; }
        public string? Rgb { get; set; }
        public IList<CVItemDto> Items { get; set; }
    }
}
