using Skydiving.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.ViewModels.Instructor;
using Skydiving.Core.IServices;

namespace Skydiving.Core.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IRepository repo;

        public InstructorService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddInstructorAsync(string id, BecomeInstructorViewModel model)
        {
            var user = await repo.All<User>().Where(x => x.Id == id).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("User not found!");
            }

            user.PhoneNumber = model.PhoneNumber;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.IsInstructor = true;
            await repo.SaveChangesAsync();
        }

        public async Task<IEnumerable<InstructorViewModel>> AllInstructorsAsync()
        {
            var instructors = await repo.AllReadonly<User>()
                .Where(x => x.IsInstructor == true
                && x.PhoneNumber != null
                && x.FirstName != null
                && x.LastName != null)
                .ToListAsync();

            if (instructors == null)
            {
                throw new Exception("Instructor entity error");
            }

            List<InstructorViewModel> result = new List<InstructorViewModel>();

            foreach (var instructor in instructors)
            {
                var data = new InstructorViewModel()
                {
                    Id = instructor.Id,
                    FirstName = instructor.FirstName ?? "First name",
                    LastName = instructor.LastName ?? "Last name",
                    PhoneNumber = instructor.PhoneNumber,
                    Rating = await InstructorRatingAsync(instructor.Id)
                };
                result.Add(data);
            }

            return result;
        }
    
        public async Task<string> InstructorRatingAsync(string instructorId)
        {
            double allPoints = 0;

            int ratesCount = 0;

            var rates = await repo.AllReadonly<Rating>().Where(x => x.InstructorId == instructorId).ToListAsync();

            if (rates == null)
            {
                throw new Exception("Rating entity error");
            }

            if (rates.Count > 0)
            {
                foreach (var rate in rates)
                {
                    allPoints += rate.Points;
                    ratesCount++;
                }

                return $"{(double)allPoints / ratesCount:F2} / 5 ({ratesCount} completed jumps)";
            }

            return $"Not rated";

        }
     
        public async Task RateInstructorAsync(string userId, string instructorId, int jumpId, InstructorRatingModel model)
        {
            var user = await repo.AllReadonly<User>()
                .Where(x => x.Id == userId).AnyAsync();

            var instructor = await repo.AllReadonly<User>()
                .Where(x => x.Id == instructorId).AnyAsync();

            if (userId == instructorId)
            {
                throw new Exception("You can't rate yourself!");
            }

            if (!user || !instructor)
            {
                throw new Exception("Invalid user Id");
            }

            var jumpExist = await repo.AllReadonly<Jump>()
                .Where(x => x.Id == jumpId)
                .AnyAsync();

            if (!jumpExist)
            {
                throw new Exception("Jump don't exist!");
            }

            var ratingExist = await repo.AllReadonly<Rating>()
                .Where(x => x.JumpId == jumpId && x.UserId == userId && x.InstructorId == instructorId)
                .AnyAsync();

            if (ratingExist)
            {
                throw new Exception("Jump is already rated!");
            }

            var instructorRating = new Rating()
            {
                Comment = model.Comment,
                InstructorId = model.InstructorId,
                UserId = model.UserId,
                Points = model.Points,
                JumpId = model.JumpId,
            };

            await repo.AddAsync(instructorRating);
            await repo.SaveChangesAsync();
        }
    }
}
