using Microsoft.AspNetCore.Identity;
using skipper_backend.Identity;
using skipper_backend.Store;

namespace skipper_backend.Data
{
    public static class Initializer
    {
        public static async Task Initialize(StoreContext context, UserManager<User> manager)
        {
            if (!manager.Users.Any())
            {
                var user = new User
                {
                    UserName = "margareta",
                    Email = "margareta@test.com"
                };

                await manager.CreateAsync(user, "Pa$$w0rd");
                await manager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                await manager.CreateAsync(admin, "Pa$$w0rd");
                await manager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
            }

        }
    }
}
