using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;

namespace Skydiving.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Jump> Jumps { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

    }
}