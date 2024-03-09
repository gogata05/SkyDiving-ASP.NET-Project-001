using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skydiving.Infrastructure.Data.EntityModels;

namespace Skydiving.Infrastructure.Data.Configuration
{
    public class JumpStatusConfiguration : IEntityTypeConfiguration<JumpStatus>
    {
        public void Configure(EntityTypeBuilder<JumpStatus> builder)
        {
            builder.HasData(JumpStatusUpdate());
        }

        private List<JumpStatus> JumpStatusUpdate()
        {
            var jumpStatus = new List<JumpStatus>();
            //pending
            var status = new JumpStatus()
            {
                Id = 1,
                Name = "Pending"
            };

            jumpStatus.Add(status);
            //approved
            status = new JumpStatus()
            {
                Id = 2,
                Name = "Approved"
            };

            jumpStatus.Add(status);
            //declined
            status = new JumpStatus()
            {
                Id = 3,
                Name = "Declined"
            };

            jumpStatus.Add(status);
            //deleted
            status = new JumpStatus()
            {
                Id = 4,
                Name = "Deleted"
            };

            jumpStatus.Add(status);
            //completed
            status = new JumpStatus()
            {
                Id = 5,
                Name = "Completed"
            };

            jumpStatus.Add(status);
            return jumpStatus;
        }
    }
}
