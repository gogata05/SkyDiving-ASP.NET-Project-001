using Skydiving.Core.ViewModels.Instructor;
using Skydiving.Core.Services;
using Skydiving.Infrastructure.Data;
using Skydiving.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.IServices;

namespace Skydiving.UnitTests
{
    public class InstructorServiceTests
    {
        private IRepository repo;
        private IInstructorService service;
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
        public async Task AddInstructorAsync()
        {
            service = new InstructorService(repo);

            var user = new User() { Id = "newUserId1", IsInstructor = false };

            await repo.AddAsync(user);
            await repo.SaveChangesAsync();

            var model = new BecomeInstructorViewModel()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                PhoneNumber = "0899899889"
            };
            await service.AddInstructorAsync(user.Id, model);

            var userEntity = await repo.AllReadonly<User>().Where(x => x.Id == user.Id).FirstAsync();


            Assert.That(userEntity.FirstName, Is.EqualTo("FirstName"));
            Assert.That(userEntity.LastName, Is.EqualTo("LastName"));
            Assert.That(userEntity.PhoneNumber, Is.EqualTo("0899899889"));
            Assert.That(userEntity.IsInstructor, Is.EqualTo(true));
        }

        [Test]
        public async Task AddInstructorAsyncThrowsException()
        {
            service = new InstructorService(repo);

            var user = new User() { Id = "newUserId1", IsInstructor = false };

            await repo.AddAsync(user);
            await repo.SaveChangesAsync();

            var model = new BecomeInstructorViewModel()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                PhoneNumber = "0899899889"
            };


            Assert.That(async () => await service.AddInstructorAsync("invalidUserId", model), Throws.Exception
             .With.Property("Message").EqualTo("User not found!"));
        }


        [Test]
        public async Task AllInstructorsAsync()
        {
            service = new InstructorService(repo);

            var newUsers = new List<User>()
            {
                new User() { Id = "newUserId1", IsInstructor = true, FirstName = "", LastName = "", PhoneNumber = "" },
                new User() { Id = "newUserId2", IsInstructor = true, FirstName = "", LastName = "", PhoneNumber = "" },
                new User() { Id = "newUserId3", IsInstructor = true, FirstName = "", LastName = "", PhoneNumber = "" },
                new User() { Id = "newUserId4", IsInstructor = false }
            };

            await repo.AddRangeAsync(newUsers);
            await repo.SaveChangesAsync();

            var result = await service.AllInstructorsAsync();

            Assert.That(3, Is.EqualTo(result.Count()));
            Assert.That(result.ElementAt(0).Id == "newUserId1");
            Assert.That(result.ElementAt(1).Id == "newUserId2");
            Assert.That(result.ElementAt(2).Id == "newUserId3");
        }

        [Test]
        public async Task RateInstructorAsync_InstructorRatingAsync()
        {
            service = new InstructorService(repo);

            var newUsers = new List<User>()
            {
                new User() { Id = "newUserId1", IsInstructor = true, FirstName = "", LastName = "", PhoneNumber = "" },
                new User() { Id = "newUserId2", IsInstructor = false },
                new User() { Id = "newUserId3", IsInstructor = false }
            };
            await repo.AddRangeAsync(newUsers);

            var jumps = new List<Jump>()
            {
                new Jump(){ Id = 1, IsActive = true, IsTaken = true, InstructorId = "newUserId1", OwnerId ="newUserId2", Description ="", Title = ""},
                 new Jump(){ Id = 2, IsActive = true, IsTaken = true, InstructorId = "newUserId1", OwnerId ="newUserId3", Description = "", Title = ""},
            };
            await repo.AddRangeAsync(jumps);
            await repo.SaveChangesAsync();

            var model1 = new InstructorRatingModel()
            {
                InstructorId = "newUserId1",
                Comment = "comment1",
                JumpId = 1,
                Points = 5,
                UserId = "newUserId2"
            };

            await service.RateInstructorAsync("newUserId2", "newUserId1", 1, model1);

            var firstRatingIsAdded = await repo.AllReadonly<Rating>().Where(x => x.JumpId == 1 && x.UserId == "newUserId2" && x.InstructorId == "newUserId1" && x.Comment == "comment1" && x.Points == 5).AnyAsync();

            Assert.True(firstRatingIsAdded);


            var model2 = new InstructorRatingModel()
            {
                InstructorId = "newUserId1",
                Comment = "comment2",
                JumpId = 2,
                Points = 4,
                UserId = "newUserId3"
            };

            await service.RateInstructorAsync("newUserId3", "newUserId1", 2, model2);

            var secondRatingIsAdded = await repo.AllReadonly<Rating>().Where(x => x.JumpId == 2 && x.UserId == "newUserId3" && x.InstructorId == "newUserId1" && x.Comment == "comment2" && x.Points == 4).AnyAsync();

            Assert.True(secondRatingIsAdded);


            var ratingData = await service.InstructorRatingAsync("newUserId1");
            var data = "4.50 / 5 (2 completed jumps)";

            Assert.That(ratingData, Is.EqualTo(data));
        }


        [Test]
        public async Task RateInstructorAsyncThrowsException()
        {
            service = new InstructorService(repo);

            var newUsers = new List<User>()
            {
                new User() { Id = "newUserId1", IsInstructor = true, FirstName = "", LastName = "", PhoneNumber = "" },
                new User() { Id = "newUserId2", IsInstructor = false },
            };
            await repo.AddRangeAsync(newUsers);

            var jumps = new List<Jump>()
            {
                new Jump(){ Id = 1, IsActive = true, IsTaken = true, InstructorId = "newUserId1", OwnerId ="newUserId2", Description ="", Title = ""}
            };
            await repo.AddRangeAsync(jumps);
            await repo.SaveChangesAsync();

            var model1 = new InstructorRatingModel()
            {
                InstructorId = "newUserId1",
                Comment = "comment1",
                JumpId = 1,
                Points = 5,
                UserId = "newUserId2"
            };


            Assert.That(async () => await service.RateInstructorAsync("newUserId1", "newUserId1", 1, model1),
                Throws.Exception.With.Property("Message").EqualTo("You can't rate yourself!"));


            Assert.That(async () => await service.RateInstructorAsync("invalid", "newUserId1", 1, model1),
                Throws.Exception.With.Property("Message").EqualTo("Invalid user Id"));


            Assert.That(async () => await service.RateInstructorAsync("newUserId2", "invalid", 1, model1),
                Throws.Exception.With.Property("Message").EqualTo("Invalid user Id"));


            Assert.That(async () => await service.RateInstructorAsync("newUserId2", "newUserId1", 2, model1),
                Throws.Exception.With.Property("Message").EqualTo("Jump don't exist!"));


            await service.RateInstructorAsync("newUserId2", "newUserId1", 1, model1);

            Assert.That(async () => await service.RateInstructorAsync("newUserId2", "newUserId1", 1, model1),
                Throws.Exception.With.Property("Message").EqualTo("Jump is already rated!"));

            //await service.RateInstructorAsync("newUserId2", "newUserId1", 1, model1);

            //var firstRatingIsAdded = await repo.AllReadonly<Rating>().Where(x => x.JumpId == 1 && x.UserId == "newUserId2" && x.InstructorId == "newUserId1" && x.Comment == "comment1" && x.Points == 5).AnyAsync();

            //Assert.True(firstRatingIsAdded);


            //var model2 = new InstructorRatingModel()
            //{
            //    InstructorId = "newUserId1",
            //    Comment = "comment2",
            //    JumpId = 2,
            //    Points = 4,
            //    UserId = "newUserId3"
            //};

            //await service.RateInstructorAsync("newUserId3", "newUserId1", 2, model2);

            //var secondRatingIsAdded = await repo.AllReadonly<Rating>().Where(x => x.JumpId == 2 && x.UserId == "newUserId3" && x.InstructorId == "newUserId1" && x.Comment == "comment2" && x.Points == 4).AnyAsync();

            //Assert.True(secondRatingIsAdded);


            //var ratingData = await service.InstructorRatingAsync("newUserId1");
            //var data = "4.50 / 5 (2 completed jumps)";

            //Assert.That(ratingData, Is.EqualTo(data));
        }



        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
