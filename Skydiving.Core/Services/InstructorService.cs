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
                    //Rating = await InstructorRatingAsync(instructor.Id)
                };
                result.Add(data);
            }

            return result;
        }
    

    }
}
