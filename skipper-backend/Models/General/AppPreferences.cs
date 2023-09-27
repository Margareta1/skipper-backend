using System.ComponentModel.DataAnnotations;

namespace skipper_backend.Models.General
{
    public class AppPreferences
    {
        [Key]
        public Guid Id { get; set; }
        public string? Rgb { get; set; }
        public string? CompanyName { get; set; }
    }
}
