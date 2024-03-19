using Skydiving.Core.Services;
using Skydiving.Infrastructure.Data;
using Skydiving.Infrastructure.Data.Common;
using Skydiving.Infrastructure.Data.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Runtime.Intrinsics.X86;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.IServices;

namespace Skydiving.UnitTests
{
    public class CartServiceTests
    {
        private IRepository repo;
        private ICartService service;
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
        public async Task CartExists()
        {
            service = new CartService(repo);

            var user = new User() { Id = "newUserId1", IsInstructor = false };
            await repo.AddAsync(user);
            await repo.SaveChangesAsync();

            var cart = await service.CartExists("newUserId1");

            Assert.IsNotNull(cart);
            Assert.That(cart.UserId, Is.EqualTo("newUserId1"));
        }

        [Test]
        public async Task AddToCart()
        {
            service = new CartService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = false };
            var user2 = new User() { Id = "newUserId2", IsInstructor = false };
            await repo.AddAsync(user1);
            await repo.AddAsync(user2);

            var equipment = new Equipment() { Id = 1, Title = "", Brand = "", Quantity = 1, Description = "", ImageUrl = "", EquipmentCategoryId = 1, OwnerId = "newUserId2", Owner = user2, IsActive = true, Price = 1 };
            await repo.AddAsync(equipment);
            await repo.SaveChangesAsync();

            await service.AddToCart(1, "newUserId1");
            var cart = await repo.AllReadonly<Cart>().Where(x => x.UserId == "newUserId1").FirstOrDefaultAsync();

            var equipmentCart = await repo.AllReadonly<EquipmentCart>().Where(x => x.CartId == cart.Id && x.EquipmentId == 1).AnyAsync();

            Assert.IsTrue(equipmentCart);
        }

        [Test]
        public async Task AddToCartThrowsException()
        {
            service = new CartService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = false };
            var user2 = new User() { Id = "newUserId2", IsInstructor = false };
            await repo.AddAsync(user1);
            await repo.AddAsync(user2);

            var equipment = new Equipment() { Id = 1, Title = "", Brand = "", Quantity = 1, Description = "", ImageUrl = "", EquipmentCategoryId = 1, OwnerId = "newUserId2", Owner = user2, IsActive = true, Price = 1 };
            await repo.AddAsync(equipment);
            await repo.SaveChangesAsync();

            Assert.That(async () => await service.AddToCart(2, "newUserId1"), Throws.Exception
               .With.Property("Message").EqualTo("Equipment don't exist"));

            await service.AddToCart(1, "newUserId1");


            Assert.That(async () => await service.AddToCart(1, "newUserId1"), Throws.Exception
               .With.Property("Message").EqualTo("Equipment already in cart"));
        }


        [Test]
        public async Task RemoveFromCart()
        {
            service = new CartService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = false };
            var user2 = new User() { Id = "newUserId2", IsInstructor = false };
            await repo.AddAsync(user1);
            await repo.AddAsync(user2);

            var equipment = new Equipment() { Id = 1, Title = "", Brand = "", Quantity = 1, Description = "", ImageUrl = "", EquipmentCategoryId = 1, OwnerId = "newUserId2", Owner = user2, IsActive = true, Price = 1 };
            await repo.AddAsync(equipment);
            await repo.SaveChangesAsync();

            await service.AddToCart(1, "newUserId1");

            var cart = await repo.AllReadonly<Cart>().Where(x => x.UserId == "newUserId1").FirstOrDefaultAsync();

            var equipmentCart = await repo.AllReadonly<EquipmentCart>().Where(x => x.CartId == cart.Id && x.EquipmentId == 1).AnyAsync();

            Assert.IsTrue(equipmentCart);

            await service.RemoveFromCart(1, "newUserId1");

            var _cart = await repo.AllReadonly<Cart>().Where(x => x.UserId == "newUserId1").FirstOrDefaultAsync();

            var _equipmentCart = await repo.AllReadonly<EquipmentCart>().Where(x => x.CartId == cart.Id && x.EquipmentId == 1).AnyAsync();

            Assert.IsFalse(_equipmentCart);
        }

        [Test]
        public async Task RemoveFromCartThrowsException()
        {
            service = new CartService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = false };
            var user2 = new User() { Id = "newUserId2", IsInstructor = false };
            await repo.AddAsync(user1);
            await repo.AddAsync(user2);

            var equipment = new Equipment() { Id = 1, Title = "", Brand = "", Quantity = 1, Description = "", ImageUrl = "", EquipmentCategoryId = 1, OwnerId = "newUserId2", Owner = user2, IsActive = true, Price = 1 };
            await repo.AddAsync(equipment);
            await repo.SaveChangesAsync();

            await service.AddToCart(1, "newUserId1");


            Assert.That(async () => await service.RemoveFromCart(1, "invalidUserId"), Throws.Exception
               .With.Property("Message").EqualTo("Cart don't exist"));

            await service.RemoveFromCart(1, "newUserId1");

            Assert.That(async () => await service.RemoveFromCart(1, "newUserId1"), Throws.Exception
             .With.Property("Message").EqualTo("Equipment not in the cart"));
        }

        [Test]
        public async Task ViewCart()
        {
            service = new CartService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = false };
            var user2 = new User() { Id = "newUserId2", IsInstructor = false };
            await repo.AddAsync(user1);
            await repo.AddAsync(user2);

            var equipmentCategoty = new EquipmentCategory() { Id = 1, Name = "Category" };
            await repo.AddAsync(equipmentCategoty);

            var equipment = new Equipment() { Id = 1, Title = "", Brand = "", Quantity = 1, Description = "", ImageUrl = "", EquipmentCategoryId = equipmentCategoty.Id, Category = equipmentCategoty, OwnerId = "newUserId2", Owner = user2, IsActive = true, Price = 1 };
            await repo.AddAsync(equipment);
            await repo.SaveChangesAsync();

            await service.AddToCart(1, "newUserId1");

            var cart = await repo.AllReadonly<Cart>().Where(x => x.UserId == "newUserId1").FirstOrDefaultAsync();

            var equipmentCart = await repo.AllReadonly<EquipmentCart>().Where(x => x.CartId == cart.Id && x.EquipmentId == 1).AnyAsync();

            Assert.IsTrue(equipmentCart);

            var cartItem = await service.ViewCart("newUserId1");

            Assert.That(1, Is.EqualTo(cartItem.Count()));
            Assert.That(cartItem.ElementAt(0).Quantity, Is.EqualTo(1));
        }

        [Test]
        public async Task CheckoutCart_MyOrder()
        {
            service = new CartService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = false };
            var user2 = new User() { Id = "newUserId2", IsInstructor = false };
            await repo.AddAsync(user1);
            await repo.AddAsync(user2);

            var equipmentCategoty = new EquipmentCategory() { Id = 1, Name = "Category" };
            await repo.AddAsync(equipmentCategoty);

            var equipment = new Equipment() { Id = 1, Title = "", Brand = "", Quantity = 1, Description = "", ImageUrl = "", EquipmentCategoryId = equipmentCategoty.Id, Category = equipmentCategoty, OwnerId = "newUserId2", Owner = user2, IsActive = true, Price = 1 };
            await repo.AddAsync(equipment);
            await repo.SaveChangesAsync();

            await service.AddToCart(1, "newUserId1");

            var cart = await repo.AllReadonly<Cart>().Where(x => x.UserId == "newUserId1").FirstOrDefaultAsync();

            var equipmentCart = await repo.AllReadonly<EquipmentCart>().Where(x => x.CartId == cart.Id && x.EquipmentId == 1).AnyAsync();

            Assert.IsTrue(equipmentCart);

            var cartItem = await service.ViewCart("newUserId1");

            Assert.That(1, Is.EqualTo(cartItem.Count()));
            Assert.That(cartItem.ElementAt(0).Quantity, Is.EqualTo(1));

            var collection = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
            {
                { "item.Id", "1" },
                { "item.Quantity", "1" },
                { "item.OrderQuantity", "1" },
                { "item.Price", "1" },
                { "cost", "1" },
                { "total", "1" },
                { "address", "address" }
            });

            await service.CheckoutCart(collection, "newUserId1");

            var _cartItem = await service.ViewCart("newUserId1");
            Assert.That(0, Is.EqualTo(_cartItem.Count()));

            var order = await repo.AllReadonly<Order>().Where(x => x.ClientId == "newUserId1").AnyAsync();

            Assert.IsTrue(order);

            var myOrder = await service.MyOrder("newUserId1");

            Assert.That(1, Is.EqualTo(myOrder.Count()));
        }

        [Test]
        public void CheckoutCartThrowsException()
        {
            service = new CartService(repo);

            var collection = new FormCollection(new Dictionary<string, Microsoft.Extensions.Primitives.StringValues> { });

            Assert.That(async () => await service.CheckoutCart(collection, "someValidId"), Throws.Exception
             .With.Property("Message").EqualTo("Invalid data"));

        }

        //[Test]
        //public async Task ViewCartThrowsException()
        //{          
        //    var repoMock = new Mock<IRepository>();
        //    repoMock.Setup(x => x.AllReadonly<EquipmentCart>()).Returns(value: null);
        //    repo = repoMock.Object;
        //    service = new CartService(repo); 


        //    var user1 = new User() { Id = "newUserId1", IsInstructor = false };
        //    await repo.AddAsync(user1);
        //    await repo.SaveChangesAsync();

        //    Assert.That(async () => await service.ViewCart("newUserId1"), Throws.Exception
        //     .With.Property("Message").EqualTo("Equipments DB error"));
        //}

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}

