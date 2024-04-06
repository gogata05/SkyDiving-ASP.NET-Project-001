using Skydiving.Infrastructure.Data.Configuration;
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

        public DbSet<JumpCategory> JumpsCategories { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<EquipmentCategory> EquipmentsCategories { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<JumpOffer> JumpOffer { get; set; }

        public DbSet<JumpStatus> JumpStatus { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Remove comment to seed the DB(Comment to start Unit tests)

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new JumpStatusConfiguration());
            builder.ApplyConfiguration(new JumpCategoryConfiguration());
            builder.ApplyConfiguration(new EquipmentCategoryConfiguration());
            builder.ApplyConfiguration(new EquipmentConfiguration());

            //Remove comment to seed the DB(Comment to start Unit tests)

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<JumpOffer>()
                .HasKey(x => new { x.JumpId, x.OfferId });

            builder.Entity<EquipmentCart>()
                .HasKey(x => new { x.EquipmentId, x.CartId });

            base.OnModelCreating(builder);
        }
    }
}