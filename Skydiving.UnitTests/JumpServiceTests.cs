using Skydiving.Core.ViewModels;
using Skydiving.Core.Services;
using Skydiving.Infrastructure.Data;
using Skydiving.Infrastructure.Data.Common;
using Skydiving.Infrastructure.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.IServices;

namespace Skydiving.UnitTests
{
    public class JumpServiceTests
    {
        private IRepository repo;
        private IJumpService service;
        private IInstructorService instructorService;
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
        public async Task AddJumpAsync()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user = new User() { Id = "userId1", IsInstructor = false };
            await repo.AddAsync(user);
            await repo.SaveChangesAsync();

            var model = new JumpModel()
            {
                Title = "Test",
                Description = "",
                CategoryId = 1,
                Owner = user,
                OwnerName = ""
            };

            var jumpBefore = await repo.AllReadonly<Jump>()
                .Where(x => x.OwnerId == user.Id && x.Title == "Test")
                .AnyAsync();

            Assert.IsFalse(jumpBefore);

            await service.AddJumpAsync(user.Id, model);

            var jumpAfter = await repo.AllReadonly<Jump>()
                .Where(x => x.OwnerId == user.Id && x.Title == "Test")
                .AnyAsync();

            Assert.IsTrue(jumpAfter);
        }

        [Test]
        public async Task AddJumpAsyncThrowsException()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user = new User() { Id = "userId", IsInstructor = false };
            await repo.AddAsync(user);
            await repo.SaveChangesAsync();

            var model = new JumpModel()
            {
                Title = "Test",
                Description = "",
                CategoryId = 1,
                Owner = user,
                OwnerName = ""
            };

            Assert.That(async () => await service.AddJumpAsync("invalidId", model),
                Throws.Exception.With.Property("Message").EqualTo("User not found"));
        }

        [Test]
        public async Task GetEditAsync()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user = new User() { Id = "userId", IsInstructor = false };
            await repo.AddAsync(user);

            var jump = new Jump()
            {
                Title = "TestTitle",
                Description = "TestDescription",
                JumpCategoryId = 1,
                Id = 1,
                IsActive = true,
                IsApproved = true,
                IsTaken = false,
                JumpStatusId = 1,
                Owner = user,
                OwnerId = user.Id,
                StartDate = DateTime.Now,
                Status = ""
            };
            await repo.AddAsync(jump);
            await repo.SaveChangesAsync();

            var jumpAdded = await repo.AllReadonly<Jump>()
                .Where(x => x.OwnerId == user.Id && x.Title == "TestTitle" && x.Description == "TestDescription")
                .AnyAsync();

            Assert.IsTrue(jumpAdded);

            var model = await service.GetEditAsync(1, user.Id);

            Assert.That(model.Description, Is.EqualTo("TestDescription"));
            Assert.That(model.Title, Is.EqualTo("TestTitle"));
        }

        [Test]
        public async Task GetEditAsyncThrowsExcepion()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user = new User() { Id = "userId", IsInstructor = false };
            await repo.AddAsync(user);

            var user2 = new User() { Id = "userId2", IsInstructor = false };
            await repo.AddAsync(user2);

            var jump = new Jump()
            {
                Title = "TestTitle",
                Description = "TestDescription",
                JumpCategoryId = 1,
                Id = 1,
                IsActive = true,
                IsApproved = true,
                IsTaken = false,
                JumpStatusId = 1,
                Owner = user,
                OwnerId = user.Id,
                StartDate = DateTime.Now,
                Status = ""
            };
            await repo.AddAsync(jump);
            var jump2 = new Jump()
            {
                Title = "TestTitle",
                Description = "TestDescription",
                JumpCategoryId = 1,
                Id = 2,
                IsActive = true,
                IsApproved = true,
                IsTaken = true,
                JumpStatusId = 1,
                Owner = user,
                OwnerId = user.Id,
                StartDate = DateTime.Now,
                Status = ""
            };
            await repo.AddAsync(jump2);
            var jump3 = new Jump()
            {
                Title = "TestTitle",
                Description = "TestDescription",
                JumpCategoryId = 1,
                Id = 3,
                IsActive = true,
                IsApproved = false,
                IsTaken = false,
                JumpStatusId = 1,
                Owner = user,
                OwnerId = user.Id,
                StartDate = DateTime.Now,
                Status = ""
            };
            await repo.AddAsync(jump3);
            await repo.SaveChangesAsync();

            var jumpAdded = await repo.AllReadonly<Jump>()
                .Where(x => x.OwnerId == user.Id && x.Title == "TestTitle" && x.Description == "TestDescription")
                .AnyAsync();

            Assert.IsTrue(jumpAdded);


            Assert.That(async () => await service.GetEditAsync(4, user.Id),
                Throws.Exception.With.Property("Message")
                .EqualTo("Jump not found"));

            Assert.That(async () => await service.GetEditAsync(1, "invalidId"),
               Throws.Exception.With.Property("Message")
               .EqualTo("Owner not found"));

            Assert.That(async () => await service.GetEditAsync(1, user2.Id),
                Throws.Exception.With.Property("Message")
                .EqualTo("User is not owner"));

            Assert.That(async () => await service.GetEditAsync(2, user.Id),
                Throws.Exception.With.Property("Message")
                .EqualTo("Can't edit ongoing jump"));


            Assert.That(async () => await service.GetEditAsync(3, user.Id),
                Throws.Exception.With.Property("Message")
                .EqualTo("This jump is not approved"));
        }


        [Test]
        public async Task PostEditAsync()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user = new User() { Id = "userId", IsInstructor = false };
            await repo.AddAsync(user);

            var jump = new Jump()
            {
                Title = "TestTitle",
                Description = "TestDescription",
                JumpCategoryId = 1,
                Id = 1,
                IsActive = true,
                IsApproved = true,
                IsTaken = false,
                JumpStatusId = 1,
                Owner = user,
                OwnerId = user.Id,
                StartDate = DateTime.Now,
                Status = ""
            };
            await repo.AddAsync(jump);
            await repo.SaveChangesAsync();

            var jumpAdded = await repo.AllReadonly<Jump>()
                .Where(x => x.OwnerId == user.Id && x.Title == "TestTitle" && x.Description == "TestDescription")
                .AnyAsync();

            Assert.IsTrue(jumpAdded);

            var model = new JumpModel()
            {
                Title = "EditTitle",
                Description = "EditDescription",
                CategoryId = 2,
                Owner = user
            };

            await service.PostEditAsync(1, model);

            var editedJump = await repo.AllReadonly<Jump>()
                .Where(x => x.OwnerId == user.Id)
                .FirstAsync();

            Assert.That(editedJump.Title, Is.EqualTo("EditTitle"));
            Assert.That(editedJump.Description, Is.EqualTo("EditDescription"));
            Assert.That(editedJump.JumpCategoryId, Is.EqualTo(2));
        }

        [Test]
        public async Task PostEditAsyncThrowsException()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user = new User() { Id = "userId", IsInstructor = false };
            await repo.AddAsync(user);

            var jump = new Jump()
            {
                Title = "TestTitle",
                Description = "TestDescription",
                JumpCategoryId = 1,
                Id = 1,
                IsActive = true,
                IsApproved = true,
                IsTaken = false,
                JumpStatusId = 1,
                Owner = user,
                OwnerId = user.Id,
                StartDate = DateTime.Now,
                Status = ""
            };
            await repo.AddAsync(jump);
            await repo.SaveChangesAsync();

            var jumpAdded = await repo.AllReadonly<Jump>()
                .Where(x => x.OwnerId == user.Id && x.Title == "TestTitle" && x.Description == "TestDescription")
                .AnyAsync();

            Assert.IsTrue(jumpAdded);

            var model = new JumpModel()
            {
                Title = "EditTitle",
                Description = "EditDescription",
                CategoryId = 2,
                Owner = user
            };

            Assert.That(async () => await service.PostEditAsync(2, model),
               Throws.Exception.With.Property("Message")
               .EqualTo("Jump not found"));
            ;
        }

        [Test]
        public async Task GetAllJumpsAsync()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user = new User() { Id = "userId", IsInstructor = false };
            await repo.AddAsync(user);

            var category = new JumpCategory() { Id = 1, Name = "category" };

            await repo.AddAsync(category);

            await repo.AddRangeAsync(new List<Jump>()
            {
                new Jump(){Id = 1, Category = category, JumpCategoryId =1,  Description ="active1", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 2, Category = category, JumpCategoryId =1, Description ="taken", Title = "", IsActive = true, IsApproved = true, IsTaken = true, Status = "Taken", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 3, Category = category, JumpCategoryId =1, Description ="active2", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 4, Category = category, JumpCategoryId =1, Description ="pending" ,Title = "", IsActive = true, IsApproved = false, IsTaken = false, Status = "Pending", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 5, Category = category, JumpCategoryId =1, Description ="removed", Title = "", IsActive = false, IsApproved = true, IsTaken = false, Status = "Removed", Owner = user, OwnerId = user.Id}
            });
            await repo.SaveChangesAsync();


            var jumps = await service.GetAllJumpsAsync();

            Assert.That(2, Is.EqualTo(jumps.Count()));

            Assert.That(jumps.ElementAt(0).Description, Is.EqualTo("active1"));
            Assert.That(jumps.ElementAt(1).Description, Is.EqualTo("active2"));
        }

        [Test]
        public async Task JumpDetailsAsync()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user = new User() { Id = "userId", IsInstructor = false };
            await repo.AddAsync(user);

            var category = new JumpCategory() { Id = 1, Name = "category" };

            await repo.AddAsync(category);

            await repo.AddRangeAsync(new List<Jump>()
            {
                new Jump(){Id = 1, Category = category, JumpCategoryId =1,  Description ="active1", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 2, Category = category, JumpCategoryId =1, Description ="taken", Title = "", IsActive = true, IsApproved = true, IsTaken = true, Status = "Taken", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 3, Category = category, JumpCategoryId =1, Description ="active2", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 4, Category = category, JumpCategoryId =1, Description ="pending" ,Title = "", IsActive = true, IsApproved = false, IsTaken = false, Status = "Pending", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 5, Category = category, JumpCategoryId =1, Description ="removed", Title = "", IsActive = false, IsApproved = true, IsTaken = false, Status = "Removed", Owner = user, OwnerId = user.Id}
            });
            await repo.SaveChangesAsync();

            var jumpsDetails = await service.JumpDetailsAsync(3);

            Assert.That(jumpsDetails.Category, Is.EqualTo("category"));
            Assert.That(jumpsDetails.Description, Is.EqualTo("active2"));
        }

        [Test]
        public async Task JumpDetailsAsyncThrowsException()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user = new User() { Id = "userId", IsInstructor = false };
            await repo.AddAsync(user);

            var category = new JumpCategory() { Id = 1, Name = "category" };

            await repo.AddAsync(category);

            await repo.AddRangeAsync(new List<Jump>()
            {
                new Jump(){Id = 1, Category = category, JumpCategoryId =1,  Description ="active1", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 2, Category = category, JumpCategoryId =1, Description ="taken", Title = "", IsActive = true, IsApproved = true, IsTaken = true, Status = "Taken", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 3, Category = category, JumpCategoryId =1, Description ="active2", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 4, Category = category, JumpCategoryId =1, Description ="pending" ,Title = "", IsActive = true, IsApproved = false, IsTaken = false, Status = "Pending", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 5, Category = category, JumpCategoryId =1, Description ="removed", Title = "", IsActive = false, IsApproved = true, IsTaken = false, Status = "Removed", Owner = user, OwnerId = user.Id}
            });
            await repo.SaveChangesAsync();

            Assert.That(async () => await service.JumpDetailsAsync(6),
               Throws.Exception.With.Property("Message")
               .EqualTo("Jump not found"));
        }
        [Test]
        public async Task JumpExistAsync()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user = new User() { Id = "userId", IsInstructor = false };
            await repo.AddAsync(user);

            var category = new JumpCategory() { Id = 1, Name = "category" };

            await repo.AddAsync(category);

            await repo.AddRangeAsync(new List<Jump>()
            {
                new Jump(){Id = 1, Category = category, JumpCategoryId =1,  Description ="active1", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 2, Category = category, JumpCategoryId =1, Description ="taken", Title = "", IsActive = true, IsApproved = true, IsTaken = true, Status = "Taken", Owner = user, OwnerId = user.Id},

                new Jump(){Id = 3, Category = category, JumpCategoryId =1, Description ="active2", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user, OwnerId = user.Id},
            });
            await repo.SaveChangesAsync();

            var firstJumpExist = await service.JumpExistAsync(1);
            var secondJumpExist = await service.JumpExistAsync(2);
            var thirdJumpExist = await service.JumpExistAsync(3);
            var nonExistingJump = await service.JumpExistAsync(4);

            Assert.IsTrue(firstJumpExist);
            Assert.IsTrue(secondJumpExist);
            Assert.IsTrue(thirdJumpExist);
            Assert.IsFalse(nonExistingJump);
        }

        [Test]
        public async Task JumpOffersAsync()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user1 = new User() { Id = "userId1", IsInstructor = false };
            var user2 = new User() { Id = "userId2", IsInstructor = true, PhoneNumber = "", FirstName = "", LastName = "" };
            var user3 = new User() { Id = "userId3", IsInstructor = true, PhoneNumber = "", FirstName = "", LastName = "" };
            var user4 = new User() { Id = "userId4", IsInstructor = false };
            await repo.AddAsync(user1);
            await repo.AddAsync(user2);
            await repo.AddAsync(user3);
            await repo.AddAsync(user4);

            var category = new JumpCategory() { Id = 1, Name = "category" };

            await repo.AddAsync(category);

            await repo.AddRangeAsync(new List<Jump>()
            {
                new Jump(){Id = 1, Category = category, JumpCategoryId =1,  Description ="active1", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user1, OwnerId = user1.Id},

                new Jump(){Id = 2, Category = category, JumpCategoryId =1, Description ="active2", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user1, OwnerId = user1.Id},

                new Jump(){Id = 3, Category = category, JumpCategoryId =1, Description ="active2", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user4, OwnerId = user4.Id},

            });

            await repo.AddRangeAsync(new List<Offer>()
            {
                new Offer(){Id = 1, Description = "offer1" , IsActive = true, Owner = user2, OwnerId = user2.Id, Price = 1},

                new Offer(){Id = 2, Description = "offer2" , IsActive = true, Owner = user2, OwnerId = user2.Id, Price = 1},

                new Offer(){Id = 3, Description = "offer3" , IsActive = true, Owner = user3, OwnerId = user3.Id, Price = 1},

                 new Offer(){Id = 4, Description = "offer4" , IsActive = true, Owner = user3, OwnerId = user3.Id, Price = 1}

            });

            await repo.AddRangeAsync(new List<JumpOffer>()
            {
                new JumpOffer(){ JumpId = 1, OfferId = 1},
                new JumpOffer(){ JumpId = 2, OfferId = 2},
                new JumpOffer(){ JumpId = 1, OfferId = 3},
                new JumpOffer(){ JumpId = 3, OfferId = 4}
            });

            await repo.SaveChangesAsync();

            var threeOffersUser = await service.JumpOffersAsync(user1.Id);

            var oneOfferUser = await service.JumpOffersAsync(user4.Id);

            Assert.That(3, Is.EqualTo(threeOffersUser.Count()));
            Assert.That(threeOffersUser.ElementAt(0).Description, Is.EqualTo("offer1"));
            Assert.That(threeOffersUser.ElementAt(1).Description, Is.EqualTo("offer2"));
            Assert.That(threeOffersUser.ElementAt(2).Description, Is.EqualTo("offer3"));

            Assert.That(1, Is.EqualTo(oneOfferUser.Count()));
            Assert.That(oneOfferUser.ElementAt(0).Description, Is.EqualTo("offer4"));
        }

        [Test]
        public async Task AllCategories()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            await repo.AddRangeAsync(new List<JumpCategory>()
            {
                new JumpCategory(){Id =1 ,Name = "1"},
                new JumpCategory(){Id =2 ,Name = "2"},
                new JumpCategory(){Id =3 ,Name = "3"},
            });

            await repo.SaveChangesAsync();

            var categories = await service.AllCategories();

            Assert.That(3, Is.EqualTo(categories.Count()));
            Assert.That(categories.ElementAt(0).Name, Is.EqualTo("1"));
            Assert.That(categories.ElementAt(1).Name, Is.EqualTo("2"));
            Assert.That(categories.ElementAt(2).Name, Is.EqualTo("3"));
        }


        [Test]
        public async Task CategoryExists()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            await repo.AddRangeAsync(new List<JumpCategory>()
            {
                new JumpCategory(){Id =1 ,Name = "1"}
            });

            await repo.SaveChangesAsync();

            var firstCategory = await service.CategoryExists(1);
            var secondCategory = await service.CategoryExists(2);

            Assert.IsTrue(firstCategory);
            Assert.IsFalse(secondCategory);
        }

        [Test]
        public async Task GetMyJumpsAsync()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user1 = new User() { Id = "userId1", IsInstructor = false };
            var user2 = new User() { Id = "userId2", IsInstructor = false };
            await repo.AddAsync(user1);
            await repo.AddAsync(user2);

            var category = new JumpCategory() { Id = 1, Name = "category" };

            await repo.AddAsync(category);

            await repo.AddRangeAsync(new List<Jump>()
            {
                new Jump(){Id = 1, Category = category, JumpCategoryId =1,  Description ="active1", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user1, OwnerId = user1.Id},

                new Jump(){Id = 2, Category = category, JumpCategoryId =1, Description ="taken", Title = "", IsActive = true, IsApproved = true, IsTaken = true, Status = "Taken", Owner = user1, OwnerId = user1.Id},

                new Jump(){Id = 3, Category = category, JumpCategoryId =1, Description ="active2", Title = "", IsActive = true, IsApproved = true, IsTaken = false, Status = "Active", Owner = user1, OwnerId = user1.Id},

                new Jump(){Id = 4, Category = category, JumpCategoryId =1, Description ="pending" ,Title = "", IsActive = true, IsApproved = false, IsTaken = false, Status = "Pending", Owner = user2, OwnerId = user2.Id},

                new Jump(){Id = 5, Category = category, JumpCategoryId =1, Description ="removed", Title = "", IsActive = false, IsApproved = true, IsTaken = false, Status = "Removed", Owner = user2, OwnerId = user2.Id}
            });
            await repo.SaveChangesAsync();

            var user1Jumps = await service.GetMyJumpsAsync(user1.Id);
            var user2Jumps = await service.GetMyJumpsAsync(user2.Id);

            Assert.That(3, Is.EqualTo(user1Jumps.Count()));
            Assert.That(user1Jumps.Any(h => h.Id == 4), Is.False);
            Assert.That(user1Jumps.Any(h => h.Id == 5), Is.False);
            Assert.That(1, Is.EqualTo(user2Jumps.Count()));
            Assert.That(user2Jumps.Any(h => h.Id == 5), Is.False);

        }

        [Test]
        public async Task CompleteJump()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user1 = new User() { Id = "userId1", IsInstructor = false };
            var user2 = new User() { Id = "userId2", IsInstructor = true };
            await repo.AddAsync(user1);
            await repo.AddAsync(user2);

            var category = new JumpCategory() { Id = 1, Name = "category" };

            await repo.AddAsync(category);

            await repo.AddAsync(new Jump()
            {
                Id = 1,
                Category = category,
                JumpCategoryId = 1,
                Description = "active1",
                Title = "",
                IsActive = true,
                IsApproved = true,
                IsTaken = true,
                Status = "Active",
                Owner = user1,
                OwnerId = user1.Id,
                InstructorId = user2.Id
            });
            await repo.SaveChangesAsync();

            string instructorId = await service.CompleteJump(1, "userId1");
            var jump = await repo.AllReadonly<Jump>().Where(x => x.Id == 1).FirstAsync();

            Assert.IsNotNull(jump);
            Assert.That(jump.Status, Is.EqualTo("Completed"));
            Assert.That(jump.IsActive, Is.False);
            Assert.That(instructorId, Is.EqualTo("userId2"));
        }

        [Test]
        public async Task CompleteJumpThrowsException()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user1 = new User() { Id = "userId1", IsInstructor = false };
            var user2 = new User() { Id = "userId2", IsInstructor = true };
            await repo.AddAsync(user1);
            await repo.AddAsync(user2);

            var category = new JumpCategory() { Id = 1, Name = "category" };

            await repo.AddAsync(category);

            await repo.AddRangeAsync(new List<Jump>(){
                new Jump()
                {
                Id = 1,
                Category = category,
                JumpCategoryId = 1,
                Description = "active1",
                Title = "",
                IsActive = true,
                IsApproved = true,
                IsTaken = true,
                Status = "Active",
                Owner = user1,
                OwnerId = user1.Id,
                InstructorId = user2.Id
                },
                new Jump()
                {
                Id = 2,
                Category = category,
                JumpCategoryId = 1,
                Description = "active1",
                Title = "",
                IsActive = true,
                IsApproved = true,
                IsTaken = false,
                Status = "Active",
                Owner = user1,
                OwnerId = user1.Id,
                InstructorId = user2.Id
                },
                new Jump()
                {
                Id = 3,
                Category = category,
                JumpCategoryId = 1,
                Description = "active1",
                Title = "",
                IsActive = true,
                IsApproved = true,
                IsTaken = true,
                Status = "Active",
                Owner = user1,
                OwnerId = user1.Id,
                }

            });
            await repo.SaveChangesAsync();

            Assert.That(async () => await service.CompleteJump(4, "userId1"),
               Throws.Exception.With.Property("Message")
               .EqualTo("Jump not found"));


            Assert.That(async () => await service.CompleteJump(2, "userId1"),
               Throws.Exception.With.Property("Message")
               .EqualTo("Jump is not taken"));


            Assert.That(async () => await service.CompleteJump(3, "userId1"),
               Throws.Exception.With.Property("Message")
               .EqualTo("Jump is not taken"));


            Assert.That(async () => await service.CompleteJump(1, "invalidId"),
               Throws.Exception.With.Property("Message")
               .EqualTo("Invalid user Id"));
        }

        [Test]
        public async Task DeleteJumpAsync()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user1 = new User() { Id = "userId1", IsInstructor = false };
            await repo.AddAsync(user1);

            var user2 = new User()
            {
                Id = "userId2",
                IsInstructor = true,
                FirstName = "",
                LastName = "",
                PhoneNumber = ""
            };
            await repo.AddAsync(user2);

            var category = new JumpCategory() { Id = 1, Name = "category" };
            await repo.AddAsync(category);
            await repo.AddAsync(new Jump()
            {
                Id = 1,
                Category = category,
                JumpCategoryId = 1,
                Description = "active1",
                Title = "",
                IsActive = true,
                IsApproved = true,
                IsTaken = false,
                Status = "Active",
                Owner = user1,
                OwnerId = user1.Id,
            });

            await repo.AddAsync(new Offer()
            {
                Description = "",
                Id = 1,
                IsActive = true,
                Owner = user2,
                OwnerId = user2.Id,
                Price = 1,
                IsAccepted = false
            });

            await repo.AddAsync(new JumpOffer() { JumpId = 1, OfferId = 1 });

            await repo.SaveChangesAsync();

            await service.DeleteJumpAsync(1, user1.Id);

            var jump = await repo.AllReadonly<Jump>().Where(x => x.Id == 1).FirstOrDefaultAsync();
            var offer = await repo.AllReadonly<Offer>().Where(x => x.Id == 1).FirstOrDefaultAsync();

            Assert.IsNotNull(jump);
            Assert.IsNotNull(offer);
            //Assert.That(jump.Status, Is.EqualTo("Deleted"));
            Assert.That(jump.IsActive, Is.False);
            Assert.That(offer.IsActive, Is.False);
        }

        [Test]
        public async Task DeleteJumpAsyncThrowsException()
        {
            instructorService = new InstructorService(repo);
            service = new JumpService(repo, instructorService);

            var user1 = new User() { Id = "userId1", IsInstructor = false };
            await repo.AddAsync(user1);

            var category = new JumpCategory() { Id = 1, Name = "category" };
            await repo.AddAsync(category);
            await repo.AddAsync(new Jump()
            {
                Id = 1,
                Category = category,
                JumpCategoryId = 1,
                Description = "active1",
                Title = "",
                IsActive = true,
                IsApproved = true,
                IsTaken = true,
                Status = "Active",
                Owner = user1,
                OwnerId = user1.Id,
                InstructorId = ""
            });

            await repo.AddAsync(new Jump()
            {
                Id = 2,
                Category = category,
                JumpCategoryId = 1,
                Description = "active1",
                Title = "",
                IsActive = true,
                IsApproved = false,
                IsTaken = false,
                Status = "Pending",
                Owner = user1,
                OwnerId = user1.Id,
            });


            await repo.AddAsync(new Jump()
            {
                Id = 3,
                Category = category,
                JumpCategoryId = 1,
                Description = "active1",
                Title = "",
                IsActive = true,
                IsApproved = true,
                IsTaken = false,
                Status = "Active",
                Owner = user1,
                OwnerId = user1.Id,
            });

            await repo.SaveChangesAsync();


            Assert.That(async () => await service.DeleteJumpAsync(101, user1.Id),
               Throws.Exception.With.Property("Message")
               .EqualTo("Jump not found"));


            Assert.That(async () => await service.DeleteJumpAsync(2, user1.Id),
               Throws.Exception.With.Property("Message")
               .EqualTo("Jump not reviewed"));

            Assert.That(async () => await service.DeleteJumpAsync(1, user1.Id),
              Throws.Exception.With.Property("Message")
              .EqualTo("Can't delete ongoing jump"));


            Assert.That(async () => await service.DeleteJumpAsync(3, "invalidId"),
              Throws.Exception.With.Property("Message")
              .EqualTo("User is not owner"));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
