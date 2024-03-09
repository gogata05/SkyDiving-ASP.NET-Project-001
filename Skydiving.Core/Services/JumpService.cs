﻿using Skydiving.Infrastructure.Data.Common;
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

        public async Task AddJumpAsync(string id, JumpModel model)
        {
            var user = await repo.All<User>().Where(x => x.Id == id).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var jump = new Jump()
            {
                Title = model.Title,
                Description = model.Description,
                JumpCategoryId = model.CategoryId,
                OwnerName = user.UserName,
                Owner = user,
                OwnerId = user.Id,
                StartDate = DateTime.Now,
                IsActive = true
            };
            await repo.AddAsync<Jump>(jump);
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<JumpViewModel>> GetAllJumpsAsync()
        {
            var jumps = await repo.AllReadonly<Jump>().Where(j => j.IsTaken == false && j.IsApproved == true && j.IsActive == true && j.Status == "Active").Include(j => j.Category).ToListAsync();

            if (jumps == null)
            {
                throw new Exception("Jump entity error");
            }

            return jumps
                .Select(j => new JumpViewModel()
                {
                    Id = j.Id,
                    Title = j.Title,
                    Category = j.Category.Name,
                    Description = j.Description,
                    OwnerName = j.OwnerName,
                    OwnerId = j.OwnerId,
                    StartDate = j.StartDate
                });
        }
    }
}
