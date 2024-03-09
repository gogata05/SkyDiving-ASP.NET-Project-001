using Skydiving.Core.ViewModels;

namespace Skydiving.Core.IServices
{
    public interface IJumpService
    {
        Task AddJumpAsync(string id, JumpModel model);

        Task<IEnumerable<JumpViewModel>> GetAllJumpsAsync();
    }
}
