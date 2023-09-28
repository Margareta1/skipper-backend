using Microsoft.AspNetCore.Identity;
using skipper_backend.Models.Project;

namespace skipper_backend.Identity
{
    public class User : IdentityUser
    {
        public double? BillingPerHour { get; set; }
        public double? FixedSalaryGross { get; set; }
        public string? PictureUrl { get; set; }
        public List<CompanyProject>?  Projects { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

    }
}
