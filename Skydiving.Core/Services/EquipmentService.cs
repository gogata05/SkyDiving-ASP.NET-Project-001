using Skydiving.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.ViewModels.Equipment;
using Skydiving.Core.IServices;

namespace Skydiving.Core.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IRepository repo;

        public EquipmentService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<AllEquipmentsQueryModel> AllEquipmentsAsync(string? category = null, string? searchTerm = null, EquipmentSorting sorting = EquipmentSorting.Newest, int currentPage = 1, int equipmentsPerPage = 1)
        {
            var result = new AllEquipmentsQueryModel();
            var equipments = repo.AllReadonly<Equipment>()
                .Where(t => t.IsActive);

            if (string.IsNullOrEmpty(category) == false)
            {
                equipments = equipments
                    .Where(t => t.Category.Name == category);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                equipments = equipments
                    .Where(t => EF.Functions.Like(t.Title.ToLower(), searchTerm) ||
                        EF.Functions.Like(t.Brand.ToLower(), searchTerm) ||
                        EF.Functions.Like(t.Description.ToLower(), searchTerm));
            }

            equipments = sorting switch
            {
                //EquipmentSorting.NotRentedFirst => houses
                //    .OrderBy(h => h.RenterId),


                EquipmentSorting.Price => equipments
                    .OrderBy(t => t.Price),
                _ => equipments.OrderByDescending(t => t.Id)
            };

            result.Equipments = await equipments
                .Skip((currentPage - 1) * equipmentsPerPage)
                .Take(equipmentsPerPage)
                .Select(t => new EquipmentViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Brand = t.Brand,
                    Price = t.Price,
                    Quantity = t.Quantity,
                    ImageUrl = t.ImageUrl,
                    Description = t.Description,
                    Category = t.Category.Name
                })
                .ToListAsync();

            result.TotalEquipmentsCount = await equipments.CountAsync();

            return result;
        }
        /// <summary>
        /// Returns the names of all EquipmentCategory from DB
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<EquipmentCategory>()
                 .Select(c => c.Name)
                 .Distinct()
                 .ToListAsync();
        }
        /// <summary>
        /// Returns all equipments from DB for administration area
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<EquipmentViewModel>> GetAllEquipmentsAsync()
        {
            var equipments = await repo.AllReadonly<Equipment>()
            .Where(t => t.IsActive == true)
            .Include(x => x.Owner)
            .Include(c => c.Category)
            .OrderByDescending(t => t.Id)
            .ToListAsync();

            if (equipments == null)
            {
                throw new Exception("Equipment entity error");
            }

            return equipments.Select(x => new EquipmentViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Brand = x.Brand,
                Description = x.Description,
                Price = x.Price,
                OwnerId = x.Owner.Id,
                OwnerName = x.Owner.UserName,
                Quantity = x.Quantity,
                Category = x.Category.Name,
                ImageUrl = x.ImageUrl
            });
        }
        /// <summary>
        ///  Returns last three added equipments from DB
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<EquipmentServiceViewModel>> GetLastThreeEquipments()
        {
            var result = await repo.AllReadonly<Equipment>()
                           .Where(x => x.IsActive)
                           .OrderByDescending(x => x.Id)
                           .Select(x => new EquipmentServiceViewModel()
                           {
                               Id = x.Id,
                               ImageUrl = x.ImageUrl,
                               Title = x.Title,
                               Brand = x.Brand,
                               Price = x.Price
                           })
                           .Take(3)
                           .ToListAsync();

            if (result == null)
            {
                throw new Exception("Equipment entity error");
            }

            return result;
        }
    }
}
