using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skydiving.Infrastructure.Data.EntityModels;

namespace Skydiving.Infrastructure.Data.Configuration
{
    internal class JumpCategoryConfiguration : IEntityTypeConfiguration<JumpCategory>
    {
        public void Configure(EntityTypeBuilder<JumpCategory> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<JumpCategory> CreateCategories()
        {
            List<JumpCategory> categories = new List<JumpCategory>()
            {
                new JumpCategory()
                {
                    Id = 1,
                    Name = "Dubai, United Arab Emirates"
                },

                new JumpCategory()
                {
                    Id = 2,
                    Name = "Interlaken, Switzerland"
                },

                new JumpCategory()
                {
                    Id = 3,
                    Name = "Sydney, Australia"
                },

                new JumpCategory ()
                {
                    Id = 4,
                    Name = "North Shore, Hawaii, USA"
                },

                new JumpCategory ()
                {
                    Id = 5,
                    Name = "Pokhara, Nepal"
                },

                new JumpCategory ()
                {
                    Id = 6,
                    Name = "Other.."
                },

             };

            return categories;
        }
    }
}
