using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.Configuration;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Infrastructure.Migrations;

namespace Skydiving.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Jump> Jumps { get; set; }

        public DbSet<JumpCategory> JumpsCategories { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<EquipmentCategory> EquipmentsCategories { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<JumpOffer> JumpOffer { get; set; }

        public DbSet<JumpStatus> JumpStatus { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new JumpStatusConfiguration());
            builder.ApplyConfiguration(new JumpCategoryConfiguration());
            builder.ApplyConfiguration(new EquipmentCategoryConfiguration());


            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<JumpOffer>()
                .HasKey(x => new { x.JumpId, x.OfferId });

            base.OnModelCreating(builder);
        }
    }
}