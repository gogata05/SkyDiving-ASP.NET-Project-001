using Skydiving.Core.ViewModels;
using Skydiving.Core.ViewModels.Admin;

namespace Skydiving.Core.IServices
{
    public interface IJumpAdministrationService
    {

        Task<IEnumerable<JumpViewModel>> GetAllJumpsAsync();

        Task<JumpViewModel> JumpDetailsAsync(int id);

        Task ApproveJumpAsync(int id);

        Task DeclineJumpAsync(int id);

        Task<IEnumerable<JumpViewAdminModel>> ReviewPendingJumps();

        Task<IEnumerable<JumpViewAdminModel>> ReviewDeclinedJumps();

        Task<IEnumerable<JumpViewAdminModel>> ReviewActiveJumps();

        Task<JumpModel> GetEditAsync(int id);

        Task PostEditAsync(int id, JumpModel model);

    }
}
