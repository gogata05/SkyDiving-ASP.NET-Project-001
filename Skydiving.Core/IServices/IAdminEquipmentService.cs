using Skydiving.Core.ViewModels;
using Skydiving.Core.ViewModels.Equipment;

namespace Skydiving.Core.IServices
{
    public interface IAdminEquipmentService
    {
        Task AddEquipmentAsync(EquipmentModel model, string id);

        Task<IEnumerable<CategoryViewModel>> AllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<bool> EquipmentExistAsync(int equipmentId);

        Task<EquipmentModel> GetEditAsync(int id, string userId);

        Task PostEditAsync(int id, EquipmentModel model);

        Task RemoveEquipmentAsync(int id, string userId);

    }
}
