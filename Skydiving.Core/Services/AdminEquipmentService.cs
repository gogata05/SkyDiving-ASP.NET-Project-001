using Skydiving.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.ViewModels;
using Skydiving.Core.ViewModels.Equipment;
using Skydiving.Core.IServices;

namespace Skydiving.Core.Services
{
    public class AdminEquipmentService : IAdminEquipmentService
    {
        private const string DefaultImageUrl = "https://media.istockphoto.com/id/1178775481/vector/service-equipments-icon-isolated-on-white-background-vector-illustration.jpg?s=612x612&w=0&k=20&c=VoGBYuv5vEW_Zbt2KIqcj2-sfEp21FGUlbZaq6QRfYY=";

        private readonly IRepository repo;

        public AdminEquipmentService(IRepository _repo)
        {
            repo = _repo;
        }
        /// <summary>
        /// Add equipment to DB
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task AddEquipmentAsync(EquipmentModel model, string id)
        {
            var user = await repo.GetByIdAsync<User>(id);

            if (user == null)
            {
                throw new Exception("User entity error");
            }

            var equipment = new Equipment()
            {
                Title = model.Title,
                Brand = model.Brand,
                EquipmentCategoryId = model.CategoryId,
                Description = model.Description,
                Owner = user,
                OwnerId = user.Id,
                Price = model.Price,
                Quantity = model.Quantity,
                IsActive = true,
                ImageUrl = model.ImageUrl != null ? model.ImageUrl : DefaultImageUrl
            };


            await repo.AddAsync(equipment);
            await repo.SaveChangesAsync();

        }
        /// <summary>
        /// Returns List of all EquipmentCategories
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CategoryViewModel>> AllCategories()
        {
            return await repo.AllReadonly<EquipmentCategory>()
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
        }

        /// <summary>
        /// Checks if category exist by id and return bool value
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<bool> CategoryExists(int categoryId) // check if needed
        {
            return await repo.AllReadonly<EquipmentCategory>()
                          .AnyAsync(c => c.Id == categoryId);
        }
        /// <summary>
        /// Check if equipment exist and return bool value
        /// </summary>
        /// <param name="equipmentId"></param>
        /// <returns></returns>
        public async Task<bool> EquipmentExistAsync(int equipmentId) // check if needed
        {
            return await repo.AllReadonly<Equipment>()
                          .AnyAsync(c => c.Id == equipmentId);
        }
        /// <summary>
        /// Returns EquipmentModel for edit for equipment with Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<EquipmentModel> GetEditAsync(int id, string userId)
        {
            if (!await EquipmentExistAsync(id))
            {
                throw new Exception("Equipment don't exist!");
            }

            var equipment = await repo.All<Equipment>().Where(x => x.Id == id).Include(x => x.Owner).FirstOrDefaultAsync();

            if (equipment.Owner.Id != userId)
            {
                throw new Exception("User is not owner");
            }

            if (equipment.IsActive == false)
            {
                throw new Exception("This equipment is not active");
            }

            var model = new EquipmentModel()
            {
                Title = equipment.Title,
                Brand = equipment.Brand,
                CategoryId = equipment.EquipmentCategoryId,
                Description = equipment.Description,
                Price = equipment.Price,
                Quantity = equipment.Quantity,
                ImageUrl = equipment.ImageUrl

            };
            return model;
        }
        /// <summary>
        /// Post the edited equipment to DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task PostEditAsync(int id, EquipmentModel model)
        {
            if (!await EquipmentExistAsync(id))
            {
                throw new Exception("Equipment don't exist!");
            }

            var equipment = await repo.All<Equipment>().Where(x => x.Id == id).FirstOrDefaultAsync();

            equipment.Title = model.Title;
            equipment.Brand = model.Brand;
            equipment.EquipmentCategoryId = model.CategoryId;
            equipment.Description = model.Description;
            equipment.EquipmentCategoryId = model.CategoryId;
            equipment.Quantity = model.Quantity;
            equipment.ImageUrl = model.ImageUrl;
            equipment.Price = model.Price;

            await repo.SaveChangesAsync();
        }
        /// <summary>
        /// Change equipment IsActive value to false
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task RemoveEquipmentAsync(int id, string userId)
        {
            var equipment = await repo.GetByIdAsync<Equipment>(id);

            if (equipment == null)
            {
                throw new Exception("Invalid equipment Id");
            }

            if (equipment.OwnerId != userId)
            {
                throw new Exception("Invalid user Id");
            }

            equipment.IsActive = false;
            await repo.SaveChangesAsync();
        }
    }
}
