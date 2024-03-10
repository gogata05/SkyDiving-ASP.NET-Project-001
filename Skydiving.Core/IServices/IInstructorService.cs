using Skydiving.Core.ViewModels.Instructor;

namespace Skydiving.Core.IServices
{
    public interface IInstructorService
    {
        Task AddInstructorAsync(string id, BecomeInstructorViewModel model);

        Task<IEnumerable<InstructorViewModel>> AllInstructorsAsync();

        Task<string> InstructorRatingAsync(string instructorId);

        public Task RateInstructorAsync(string userId, string instructorId, int jumpId, InstructorRatingModel model);

    }
}
