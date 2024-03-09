using Skydiving.Core.ViewModels;

namespace Skydiving.Core.IServices
{
    public interface IJumpService
    {
        Task AddJumpAsync(string id, JumpModel model);

        Task<IEnumerable<JumpViewModel>> GetAllJumpsAsync();

        Task<JumpModel> GetEditAsync(int id, string userId);

        Task PostEditAsync(int id, JumpModel model);

        Task<bool> JumpExistAsync(int id);
    }
}
