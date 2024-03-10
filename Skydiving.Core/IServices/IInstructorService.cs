using Skydiving.Core.ViewModels.Instructor;

namespace Skydiving.Core.IServices
{
    public interface IInstructorService
    {
        Task AddInstructorAsync(string id, BecomeInstructorViewModel model);

        Task<IEnumerable<InstructorViewModel>> AllInstructorsAsync();


    }
}
