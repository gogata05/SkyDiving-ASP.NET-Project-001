using Skydiving.Core.ViewModels.Equipment;
using Skydiving.Core.Services;
using Skydiving.Infrastructure.Data;
using Skydiving.Infrastructure.Data.Common;
using Skydiving.Infrastructure.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.IServices;

namespace Skydiving.UnitTests
{
    public class AdminEquipmentServiceTests
    {
        private IRepository repo;
        private IAdminEquipmentService service;
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

        [Test]
        public async Task AddEquipmentAsync()
        {
            service = new AdminEquipmentService(repo);

            var user = new User() { Id = "userId", IsInstructor = false };
            await repo.AddAsync(user);
            await repo.SaveChangesAsync();

            var model = new EquipmentModel()
            {
                Brand = "Brand",
                Title = "Title",
                Description = "Description",
                Price = 1,
                Quantity = 1,
                CategoryId = 1,
                ImageUrl = "",
            };

            var equipmentBefore = await repo.AllReadonly<Equipment>().Where(x => x.OwnerId == user.Id).AnyAsync();
            Assert.IsFalse(equipmentBefore);

            await service.AddEquipmentAsync(model, user.Id);

            var equipmentAfter = await repo.AllReadonly<Equipment>().Where(x => x.OwnerId == user.Id).AnyAsync();
            Assert.IsTrue(equipmentAfter);
        }

        [Test]
        public void AddEquipmentAsyncThrowsException()
        {
            service = new AdminEquipmentService(repo);

            var model = new EquipmentModel()
            {
                Brand = "Brand",
                Title = "Title",
                Description = "Description",
                Price = 1,
                Quantity = 1,
                CategoryId = 1,
                ImageUrl = "",
            };


            Assert.That(async () => await service.AddEquipmentAsync(model, "invalidId"), Throws.Exception
                .With.Property("Message").EqualTo("User entity error"));
        }

        [Test]
        public async Task AllCategories()
        {
            service = new AdminEquipmentService(repo);

            await repo.AddRangeAsync(new List<EquipmentCategory>()
            {
                new EquipmentCategory(){ Id = 1, Name = "1"},
                new EquipmentCategory(){ Id = 2, Name = "2"},
                new EquipmentCategory(){ Id = 3, Name = "3"}
            });
            await repo.SaveChangesAsync();

            var categories = await service.AllCategories();

            Assert.That(3, Is.EqualTo(categories.Count()));
            Assert.That(categories.ElementAt(0).Name == "1");
            Assert.That(categories.ElementAt(1).Name == "2");
            Assert.That(categories.ElementAt(2).Name == "3");
        }

        [Test]
        public async Task CategoryExists()
        {
            service = new AdminEquipmentService(repo);

            await repo.AddRangeAsync(new List<EquipmentCategory>()
            {
                new EquipmentCategory(){ Id = 1, Name = "1"},
                new EquipmentCategory(){ Id = 2, Name = "2"}
            });
            await repo.SaveChangesAsync();

            var category1 = await service.CategoryExists(1);
            var category2 = await service.CategoryExists(2);
            var category3 = await service.CategoryExists(3);
            var category4 = await service.CategoryExists(4);

            Assert.IsTrue(category1);
            Assert.IsTrue(category2);
            Assert.IsFalse(category3);
            Assert.IsFalse(category4);
        }

        [Test]
        public async Task EquipmentExistAsync()
        {
            service = new AdminEquipmentService(repo);

            await repo.AddRangeAsync(new List<Equipment>()
            {
                new Equipment(){ Id = 1,Brand ="",Quantity = 1,EquipmentCategoryId =1, Description = "", OwnerId ="", IsActive = true, ImageUrl = "", Price = 1, Title =""},
                new Equipment(){ Id = 2,Brand ="",Quantity = 1,EquipmentCategoryId =1, Description = "", OwnerId ="", IsActive = true, ImageUrl = "", Price = 1, Title =""}
            });
            await repo.SaveChangesAsync();

            var equipment1 = await service.EquipmentExistAsync(1);
            var equipment2 = await service.EquipmentExistAsync(2);
            var equipment3 = await service.EquipmentExistAsync(3);
            var equipment4 = await service.EquipmentExistAsync(4);

            Assert.IsTrue(equipment1);
            Assert.IsTrue(equipment2);
            Assert.IsFalse(equipment3);
            Assert.IsFalse(equipment4);
        }

        [Test]
        public async Task GetEdit()
        {
            service = new AdminEquipmentService(repo);

            var user = new User() { Id = "userId" };
            await repo.AddAsync(user);

            await repo.AddAsync(new Equipment()
            {
                Id = 1,
                Brand = "Brand",
                Quantity = 1,
                EquipmentCategoryId = 1,
                Description = "Description",
                OwnerId = user.Id,
                IsActive = true,
                ImageUrl = "",
                Price = 1,
                Title = "Title",
                Owner = user
            });

            await repo.SaveChangesAsync();

            var model = await service.GetEditAsync(1, "userId");

            Assert.That(model.Description, Is.EqualTo("Description"));
            Assert.That(model.Price, Is.EqualTo(1));
            Assert.That(model.Brand, Is.EqualTo("Brand"));
            Assert.That(model.CategoryId, Is.EqualTo(1));
            Assert.That(model.Quantity, Is.EqualTo(1));
            Assert.That(model.Title, Is.EqualTo("Title"));
        }

        [Test]
        public async Task GetEditThrowsException()
        {
            service = new AdminEquipmentService(repo);

            var user = new User() { Id = "userId" };
            await repo.AddAsync(user);

            await repo.AddAsync(new Equipment()
            {
                Id = 1,
                Brand = "Brand",
                Quantity = 1,
                EquipmentCategoryId = 1,
                Description = "Description",
                OwnerId = user.Id,
                IsActive = false,
                ImageUrl = "",
                Price = 1,
                Title = "Title",
                Owner = user
            });

            await repo.SaveChangesAsync();

            Assert.That(async () => await service.GetEditAsync(2, "userId"), Throws.Exception
                .With.Property("Message").EqualTo("Equipment don't exist!"));

            Assert.That(async () => await service.GetEditAsync(1, "invalidUserId"), Throws.Exception
                .With.Property("Message").EqualTo("User is not owner"));

            Assert.That(async () => await service.GetEditAsync(1, "userId"), Throws.Exception
                .With.Property("Message").EqualTo("This equipment is not active"));


        }

        [Test]
        public async Task PostEdit()
        {
            service = new AdminEquipmentService(repo);

            await repo.AddAsync(new Equipment() { Id = 1, Brand = "", Quantity = 1, EquipmentCategoryId = 1, Description = "", OwnerId = "", IsActive = true, ImageUrl = "", Price = 1, Title = "" });

            await repo.SaveChangesAsync();

            await service.PostEditAsync(1, new EquipmentModel()
            {
                Brand = "Brand",
                CategoryId = 2,
                Description = "Description",
                ImageUrl = "",
                Price = 200,
                Quantity = 12,
                Title = "Title"
            });

            var equipment = await repo.AllReadonly<Equipment>().Where(x => x.Id == 1).FirstOrDefaultAsync();

            Assert.That(equipment.Description, Is.EqualTo("Description"));
            Assert.That(equipment.Price, Is.EqualTo(200));
            Assert.That(equipment.Brand, Is.EqualTo("Brand"));
            Assert.That(equipment.EquipmentCategoryId, Is.EqualTo(2));
            Assert.That(equipment.Quantity, Is.EqualTo(12));
            Assert.That(equipment.Title, Is.EqualTo("Title"));
        }

        [Test]
        public async Task PostEditThrowsException()
        {
            service = new AdminEquipmentService(repo);

            await repo.AddAsync(new Equipment() { Id = 1, Brand = "", Quantity = 1, EquipmentCategoryId = 1, Description = "", OwnerId = "", IsActive = true, ImageUrl = "", Price = 1, Title = "" });

            await repo.SaveChangesAsync();
            var model = new EquipmentModel()
            {
                Brand = "Brand",
                CategoryId = 2,
                Description = "Description",
                ImageUrl = "",
                Price = 200,
                Quantity = 12,
                Title = "Title"
            };


            Assert.That(async () => await service.PostEditAsync(2, model), Throws.Exception
                .With.Property("Message").EqualTo("Equipment don't exist!"));
        }

        [Test]
        public async Task RemoveEquipmentAsync()
        {
            service = new AdminEquipmentService(repo);

            await repo.AddAsync(new Equipment() { Id = 1, Brand = "", Quantity = 1, EquipmentCategoryId = 1, Description = "", OwnerId = "ownerId", IsActive = true, ImageUrl = "", Price = 1, Title = "" });

            await repo.SaveChangesAsync();

            var equipmentBefore = await repo.AllReadonly<Equipment>().Where(x => x.Id == 1 && x.IsActive == true).AnyAsync();
            Assert.IsTrue(equipmentBefore);

            await service.RemoveEquipmentAsync(1, "ownerId");

            var equipmentAfter = await repo.AllReadonly<Equipment>().Where(x => x.Id == 1 && x.IsActive == false).AnyAsync();
            Assert.IsTrue(equipmentAfter);

        }

        [Test]
        public async Task RemoveEquipmentAsyncThrowsException()
        {
            service = new AdminEquipmentService(repo);

            await repo.AddAsync(new Equipment() { Id = 1, Brand = "", Quantity = 1, EquipmentCategoryId = 1, Description = "", OwnerId = "ownerId", IsActive = true, ImageUrl = "", Price = 1, Title = "" });

            await repo.SaveChangesAsync();


            Assert.That(async () => await service.RemoveEquipmentAsync(2, "ownerId"), Throws.Exception
                .With.Property("Message").EqualTo("Invalid equipment Id"));

            Assert.That(async () => await service.RemoveEquipmentAsync(1, "invalidId"), Throws.Exception
               .With.Property("Message").EqualTo("Invalid user Id"));
        }



        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
