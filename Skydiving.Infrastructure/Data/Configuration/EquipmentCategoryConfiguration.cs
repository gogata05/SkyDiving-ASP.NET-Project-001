using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skydiving.Infrastructure.Data.EntityModels;

namespace Skydiving.Infrastructure.Data.Configuration
{
    internal class EquipmentCategoryConfiguration : IEntityTypeConfiguration<EquipmentCategory>
    {
        public void Configure(EntityTypeBuilder<EquipmentCategory> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<EquipmentCategory> CreateCategories()
        {
            List<EquipmentCategory> categories = new List<EquipmentCategory>()
            {
                new EquipmentCategory()
                {
                    Id = 1,
                    Name = "Helmets"
                },

                new EquipmentCategory()
                {
                    Id = 2,
                    Name = "Goggles"
                },

                new EquipmentCategory()
                {
                    Id = 3,
                    Name = "JumpSuits"
                },

                new EquipmentCategory ()
                {
                    Id = 4,
                    Name = "Containers"
                },

                new EquipmentCategory ()
                {
                    Id = 5,
                    Name = "Altimeters"
                },

                new EquipmentCategory ()
                {
                    Id = 6,
                    Name = "Parachutes"
                },

                new EquipmentCategory ()
                {
                    Id = 7,
                    Name = "Other.."
                }

             };

            return categories;
        }
    }
}
