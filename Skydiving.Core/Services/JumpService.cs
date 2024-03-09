using Skydiving.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.ViewModels;
using Skydiving.Core.IServices;

namespace Skydiving.Core.Services
{
    public class JumpService : IJumpService
    {
        private readonly IRepository repo;

        public JumpService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddJumpAsync(Jump model)
        {
            var user = await repo.GetByIdAsync<User>("ed630639-ced3-4c6a-90cb-ad0603394d22");
            var jump = new Jump()
            {
                Name = model.Name,
                Description = model.Description,
                Category = model.Category,
                Owner = user,
                OwnerId = user.Id,
                StartDate = DateTime.Now,
            };
            await repo.AddAsync<Jump>(jump);
            await repo.SaveChangesAsync();
        }
    }
}
