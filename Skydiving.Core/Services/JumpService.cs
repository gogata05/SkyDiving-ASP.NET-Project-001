using Skydiving.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.ViewModels;
using Skydiving.Core.IServices;
using System;
using Skydiving.Core.ViewModels.Offer;

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

        public async Task<JumpModel> GetEditAsync(int id, string userId)
        {
            if (!await JumpExistAsync(id))
            {
                throw new Exception("Jump not found");
            }

            var owner = await repo.AllReadonly<User>().Where(x => x.Id == userId).FirstOrDefaultAsync();

            if (owner == null)
            {
                throw new Exception("Owner not found");
            }

            var jump = await repo.All<Jump>().Where(x => x.Id == id).Include(x => x.Owner).FirstOrDefaultAsync();

            if (jump.Owner?.Id != userId)
            {
                throw new Exception("User is not owner");
            }


            if (jump.IsTaken == true)
            {
                throw new Exception("Can't edit ongoing jump");
            }


            if (jump.IsApproved != true)
            {
                throw new Exception("This jump is not approved");
            }

            var model = new JumpModel()
            {
                Title = jump.Title,
                Description = jump.Description,
                CategoryId = jump.JumpCategoryId,
                Owner = owner,
                OwnerName = jump.OwnerName
            };
            return model;
        }

        public async Task PostEditAsync(int id, JumpModel model)
        {
            if (!await JumpExistAsync(id))
            {
                throw new Exception("Jump not found");
            }

            var jump = await repo.All<Jump>().Where(x => x.Id == id).Include(x => x.Owner).FirstOrDefaultAsync();

            jump.Title = model.Title;
            jump.Description = model.Description;
            jump.JumpCategoryId = model.CategoryId;

            await repo.SaveChangesAsync();
        }

        public async Task<JumpViewModel> JumpDetailsAsync(int id)
        {
            if (!await JumpExistAsync(id))
            {
                throw new Exception("Jump not found");
            }

            var jump = await repo.AllReadonly<Jump>()
                .Where(j => j.Id == id)
                .Include(c => c.Category)
                .FirstAsync();


            var model = new JumpViewModel()
            {
                OwnerId = jump.OwnerId,
                OwnerName = jump.OwnerName,
                Title = jump.Title,
                Description = jump.Description,
                Category = jump.Category.Name,
                Id = jump.Id
            };

            return model;

        }

        public async Task<bool> JumpExistAsync(int id)
        {
            var result = await repo.AllReadonly<Jump>().Where(x => x.Id == id).AnyAsync();

            return result;
        }

        public async Task<IEnumerable<MyJumpViewModel>> GetMyJumpsAsync(string userId)
        {
            var myJumps = await repo.AllReadonly<Jump>()
                .Where(j => j.OwnerId == userId && j.IsActive == true)
                .Include(j => j.Category)
                .ToListAsync();

            if (myJumps == null)
            {
                throw new Exception("Jump entity error");
            }

            return myJumps
                .Select(j => new MyJumpViewModel()
                {
                    Id = j.Id,
                    OwnerId = j.OwnerId,
                    Title = j.Title,
                    Category = j.Category.Name,
                    Description = j.Description,
                    IsTaken = j.IsTaken,
                    IsActive = j.IsActive,
                    IsApproved = j.IsApproved,
                    InstructorId = j.InstructorId,
                    EndDate = j.EndDate,
                    StartDate = j.StartDate,
                    Status = j.Status
                });
        }

        public async Task<IEnumerable<OfferServiceViewModel>> JumpOffersAsync(string userId)
        {
            var jumpOffers = await repo.AllReadonly<JumpOffer>()
                .Where(x => x.Jump.OwnerId == userId && x.Offer.IsAccepted == null
                                                     && x.Jump.IsTaken == false && x.Offer.IsActive == true && x.Jump.IsActive == true).Include(j => j.Jump).Include(c => c.Jump.Category).Include(o => o.Offer).Include(u => u.Offer.Owner).ToListAsync();

            if (jumpOffers == null)
            {
                throw new Exception("JumpOffer entity error");
            }

            List<OfferServiceViewModel> offers = new List<OfferServiceViewModel>();

            foreach (var x in jumpOffers)
            {
                offers.Add(new OfferServiceViewModel()
                {
                    Id = x.OfferId,
                    Description = x.Offer.Description,
                    JumpDescription = x.Jump.Description,
                    InstructorName = $"{x.Offer.Owner.FirstName} {x.Offer.Owner.LastName}",
                    InstructorPhoneNumber = x.Offer.Owner.PhoneNumber,
                    JumpId = x.JumpId,
                    JumpTitle = x.Jump.Title,
                    JumpCategory = x.Jump.Category.Name,
                    OwnerId = x.Offer.OwnerId,
                    //Rating = await instructorService.InstructorRatingAsync(x.Offer.OwnerId),
                    Price = x.Offer.Price
                });
            }
            return offers;
        }

        public async Task<IEnumerable<CategoryViewModel>> AllCategories()
        {
            return await repo.AllReadonly<JumpCategory>()
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
        }
        public async Task<bool> CategoryExists(int categoryId) // check if needed
        {
            return await repo.AllReadonly<JumpCategory>()
                .AnyAsync(c => c.Id == categoryId);
        }
    }
}
