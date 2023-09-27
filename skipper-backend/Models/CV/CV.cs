using skipper_backend.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skipper_backend.Models.CV
{
    public class CV
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string Status { get; set; }

        public string? About { get; set; }
        public string? ImageUrl { get; set; }
        public string? Rgb { get; set; }


    }
}
