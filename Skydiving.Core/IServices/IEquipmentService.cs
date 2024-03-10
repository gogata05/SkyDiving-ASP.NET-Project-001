using Skydiving.Core.ViewModels.Equipment;

namespace Skydiving.Core.IServices
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentViewModel>> GetAllEquipmentsAsync();

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<AllEquipmentsQueryModel> AllEquipmentsAsync(
            string? category = null,
            string? searchTerm = null,
            EquipmentSorting sorting = EquipmentSorting.Newest,
            int currentPage = 1,
            int equipmentsPerPage = 1);

        Task<IEnumerable<EquipmentServiceViewModel>> GetLastThreeEquipments();
    }
}
