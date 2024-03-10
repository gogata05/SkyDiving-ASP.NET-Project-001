using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skydiving.Infrastructure.Data.EntityModels;

namespace Skydiving.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(AddUsers());
        }

        private List<User> AddUsers()
        {
            var users = new List<User>();
            var hasher = new PasswordHasher<User>();

            //delete comment
            var user = new User()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "instructor",
                NormalizedUserName = "INSTRUCTOR",
                Email = "instructor@mail.com",
                NormalizedEmail = "INSTRUCTOR@MAIL.COM"
            };

            user.PasswordHash = hasher.HashPassword(user, "instructor");
            users.Add(user);

            user = new User()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "jumper",
                NormalizedUserName = "JUMPER",
                Email = "jumper@mail.com",
                NormalizedEmail = "JUMPER@MAIL.COM"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "jumper");

            users.Add(user);

            user = new User()
            {
                Id = "d6b3ac1f-4fc8-d726-83d9-6d5800ce591e",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "admin");

            users.Add(user);

            return users;
        }
    }
}



//[AllowAnonymous]
//public async Task<IActionResult> CreateRoles()
//{
//    await roleManager.CreateAsync(new IdentityRole(RoleConstants.Jumper));
//    await roleManager.CreateAsync(new IdentityRole(RoleConstants.Instructor));
//    await roleManager.CreateAsync(new IdentityRole(RoleConstants.Administrator));

//    return RedirectToAction("Index", "Home");
//}