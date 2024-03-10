using Skydiving.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.ViewModels;
using Skydiving.Core.ViewModels.Admin;
using Skydiving.Core.IServices;

namespace Skydiving.Core.Services
{
    public class JumpAdministrationService : IJumpAdministrationService
    {
        private readonly IRepository repo;

        public JumpAdministrationService(IRepository _repo)
        {
            repo = _repo;
        }

        public Task AddJumpAsync(string id, JumpModel model)
        {
            throw new NotImplementedException();
        }

        public async Task ApproveJumpAsync(int id)
        {
            var jump = await repo.GetByIdAsync<Jump>(id);
            jump.IsApproved = true;
            jump.IsActive = true;
            jump.Status = "Active";
            jump.JumpStatusId = 2;
            await repo.SaveChangesAsync();

        }

        public async Task DeclineJumpAsync(int id)
        {
            var jump = await repo.GetByIdAsync<Jump>(id);
            jump.IsApproved = false;
            jump.IsActive = false;
            jump.Status = "Declined";
            jump.JumpStatusId = 3;
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<JumpViewModel>> GetAllJumpsAsync()
        {
            return await repo.All<Jump>().Select(x => new JumpViewModel()
            {
                Id = x.Id,
                //Category = x.Category,
                Description = x.Description,
                OwnerId = x.OwnerId,
                OwnerName = x.OwnerName, // change nullable!!!
                StartDate = x.StartDate,
                Title = x.Title

            }).ToListAsync();
        }

        public Task<JumpModel> GetEditAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<JumpViewModel> JumpDetailsAsync(int id)
        {
            var jump = await repo.GetByIdAsync<Jump>(id);
            var model = new JumpViewModel()
            {
                OwnerId = jump.OwnerId,
                OwnerName = jump.OwnerName,
                Title = jump.Title,
                Description = jump.Description,
                //Category = jump.Category,
                Id = jump.Id,
                StartDate = jump.StartDate,


            };

            return model;
        }

        public Task PostEditAsync(int id, JumpModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<JumpViewAdminModel>> ReviewPendingJumps()
        {
            var result = await repo.All<Jump>().Where(j => j.IsApproved == false && j.JumpStatusId == 1).Select(j => new JumpViewAdminModel()
            {
                //Category = j.Category,
                InstructorId = j.InstructorId,
                Description = j.Description,
                Id = j.Id,
                OwnerId = j.OwnerId,
                OwnerName = j.OwnerName,
                Title = j.Title,
                StartDate = j.StartDate
            }).ToListAsync();

            return result;
        }
        public async Task<IEnumerable<JumpViewAdminModel>> ReviewDeclinedJumps()
        {
            var result = await repo.All<Jump>().Where(j => j.IsApproved == false && j.JumpStatusId == 3 && j.IsActive == false).Select(j => new JumpViewAdminModel()
            {
                //Category = j.Category,
                InstructorId = j.InstructorId,
                Description = j.Description,
                Id = j.Id,
                OwnerId = j.OwnerId,
                OwnerName = j.OwnerName,
                Title = j.Title,
                StartDate = j.StartDate
            }).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<JumpViewAdminModel>> ReviewActiveJumps()
        {
            var result = await repo.All<Jump>().Where(j => j.IsApproved == true && j.JumpStatusId == 2 && j.IsActive == true).Select(j => new JumpViewAdminModel()
            {
                //Category = j.Category,
                InstructorId = j.InstructorId,
                Description = j.Description,
                Id = j.Id,
                OwnerId = j.OwnerId,
                OwnerName = j.OwnerName,
                Title = j.Title,
                StartDate = j.StartDate
            }).ToListAsync();

            return result;
        }
    }
}
