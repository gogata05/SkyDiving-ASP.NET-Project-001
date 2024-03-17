using Skydiving.Core.Services;
using Skydiving.Infrastructure.Data;
using Skydiving.Infrastructure.Data.Common;
using Skydiving.Infrastructure.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.IServices;

//Add thrown exceptions
namespace Skydiving.UnitTests
{
    public class EquipmentServiceTests
    {
        private IRepository repo;
        private IEquipmentService service;
        private ApplicationDbContext context;


        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase("Instructors_Hub_DB")
               .Options;

            context = new ApplicationDbContext(contextOptions);
            repo = new Repository(context);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        //[Test]
        //public async Task TestAllEquipmentsAsyncReturnsValidData()
        //{
        //    Assert.Pass();

        //    //Implement logic
        //}

        [Test]
        public async Task TestAllCategoriesNamesReturnsValidData()
        {
            service = new EquipmentService(repo);

            await repo.AddRangeAsync(new List<EquipmentCategory>()
            {
                new EquipmentCategory(){ Id = 101 , Name = "First" },
                new EquipmentCategory(){ Id = 102 , Name = "Second" },
                new EquipmentCategory(){ Id = 103 , Name = "Second" }
            });

            await repo.SaveChangesAsync();

            var categoryNames = await service.AllCategoriesNames();

            Assert.That(2, Is.EqualTo(categoryNames.Count()));
            Assert.AreEqual(categoryNames, new List<string>() { "First", "Second" });
        }

        [Test]
        public async Task TestLastThreeEquipmentsReturnsValidData()
        {
            service = new EquipmentService(repo);

            await repo.AddRangeAsync(new List<Equipment>()
            {
                new Equipment(){Id = 101,ImageUrl ="", Price = 1, OwnerId = "",Description = "", EquipmentCategoryId = 1,Quantity = 1, Brand = "", Title = ""},
                new Equipment(){Id = 102,ImageUrl ="", Price = 1, OwnerId = "",Description = "", EquipmentCategoryId = 1,Quantity = 1, Brand = "", Title = ""},
                new Equipment(){Id = 105,ImageUrl ="", Price = 1, OwnerId = "",Description = "", EquipmentCategoryId = 1,Quantity = 1, Brand = "", Title = ""},
                new Equipment(){Id = 107,ImageUrl ="", Price = 1, OwnerId = "",Description = "", EquipmentCategoryId = 1,Quantity = 1, Brand = "", Title = ""}
            });

            await repo.SaveChangesAsync();

            var equipments = await service.GetLastThreeEquipments();

            Assert.That(3, Is.EqualTo(equipments.Count()));
            Assert.That(equipments.Any(h => h.Id == 101), Is.False);
        }

        [Test]
        public async Task TestGetAllEquipmentsAsyncReturnsValidData()
        {
            var user = new User() { Id = "newUserId", IsInstructor = false };
            var category = new EquipmentCategory() { Id = 1001, Name = "Category" };

            service = new EquipmentService(repo);

            var equipmentList = new List<Equipment>()
            {
                new Equipment(){Id = 107,ImageUrl ="", Price = 1, OwnerId = "",Owner = user, Category = category, Description = "", EquipmentCategoryId = 1,Quantity = 1, Brand = "", Title = ""},
                new Equipment(){Id = 106,ImageUrl ="", Price = 1, OwnerId = "",Owner = user, Category = category, Description = "", EquipmentCategoryId = 1,Quantity = 1, Brand = "", Title = ""},
                new Equipment(){Id = 105,ImageUrl ="", Price = 1, OwnerId = "",Owner = user, Category = category, Description = "", EquipmentCategoryId = 1,Quantity = 1, Brand = "", Title = ""},
                new Equipment(){Id = 104,ImageUrl ="", Price = 1, OwnerId = "",Owner = user, Category = category, Description = "", EquipmentCategoryId = 1,Quantity = 1, Brand = "", Title = ""},
                new Equipment(){Id = 103,ImageUrl ="", Price = 1, OwnerId = "",Owner = user, Category = category, Description = "", EquipmentCategoryId = 1,Quantity = 1, Brand = "", Title = ""},
                new Equipment(){Id = 102,ImageUrl ="", Price = 1, OwnerId = "",Owner = user, Category = category, Description = "", EquipmentCategoryId = 1,Quantity = 1, Brand = "", Title = ""},
                new Equipment(){Id = 101,ImageUrl ="", Price = 1, OwnerId = "",Owner = user, Category = category, Description = "", EquipmentCategoryId = 1,Quantity = 1, Brand = "", Title = ""}
            };

            await repo.AddRangeAsync(equipmentList);

            await repo.SaveChangesAsync();

            var equipments = await service.GetAllEquipmentsAsync();

            Assert.That(7, Is.EqualTo(equipments.Count()));


        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
