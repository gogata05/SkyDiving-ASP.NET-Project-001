﻿using Skydiving.Core.ViewModels.Offer;
using Skydiving.Core.Services;
using Skydiving.Infrastructure.Data;
using Skydiving.Infrastructure.Data.Common;
using Skydiving.Infrastructure.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.IServices;

namespace Skydiving.UnitTests
{
    public class OfferServiceTests
    {
        private IRepository repo;
        private IOfferService service;
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
        public async Task AcceptOfferAsync()
        {
            service = new OfferService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = true };
            var user2 = new User() { Id = "newUserId2", IsInstructor = false };


            var offers = new List<Offer>()
            {
              new Offer(){Id = 1, Description ="", Owner = user1, OwnerId = user1.Id, IsAccepted = null, IsActive = true, Price = 1},
              new Offer(){Id = 2, Description ="", Owner = user1, OwnerId = user1.Id, IsAccepted = null, IsActive = true, Price = 1},
            };
            await repo.AddRangeAsync(offers);


            var jumps = new List<Jump>()
            {
              new Jump(){Id = 1, Title ="", Description ="", Owner = user2, OwnerId = user2.Id, IsActive = true, JumpCategoryId = 1, IsApproved = true, IsTaken = false, Status = "", StartDate = DateTime.Now, JumpStatusId = 1},

               new Jump(){Id = 2, Title ="", Description ="", Owner = user2, OwnerId = user2.Id, IsActive = true, JumpCategoryId = 1, IsApproved = true, IsTaken = false, Status = "", StartDate = DateTime.Now, JumpStatusId = 1},
            };
            await repo.AddRangeAsync(jumps);

            var jumpOffers = new List<JumpOffer>()
            {
                new JumpOffer(){JumpId = 1, OfferId = 1}
            };
            await repo.AddRangeAsync(jumpOffers);
            await repo.SaveChangesAsync();

            await service.AcceptOfferAsync(1);

            var dbOffer = await repo.GetByIdAsync<Offer>(1);
            var dbJump = await repo.GetByIdAsync<Jump>(1);

            var _dbOffer = await repo.GetByIdAsync<Offer>(2);
            var _dbJump = await repo.GetByIdAsync<Jump>(2);

            Assert.That(dbOffer.IsAccepted == true);
            Assert.That(dbJump.IsTaken == true);
            Assert.That(dbJump.InstructorId == "newUserId1");

            Assert.That(_dbOffer.IsAccepted == null);
            Assert.That(_dbJump.IsTaken == false);
            Assert.That(_dbJump.InstructorId == null);
        }

        [Test]
        public async Task AcceptOfferAsyncThrowsException()
        {
            service = new OfferService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = true };
            var offers = new List<Offer>()
            {
              new Offer(){Id = 1, Description ="", Owner = user1, OwnerId = user1.Id, IsAccepted = null, IsActive = true, Price = 1}
            };
            await repo.AddRangeAsync(offers);
            await repo.SaveChangesAsync();


            Assert.That(async () => await service.AcceptOfferAsync(3),
              Throws.Exception.With.Property("Message")
              .EqualTo("Offer don't exist"));

            Assert.That(async () => await service.AcceptOfferAsync(1),
              Throws.Exception.With.Property("Message")
              .EqualTo("Jump not found"));

        }


        [Test]
        public void DeclineOfferAsyncThrowsException()
        {
            service = new OfferService(repo);

            Assert.That(async () => await service.DeclineOfferAsync(3),
              Throws.Exception.With.Property("Message")
              .EqualTo("Offer don't exist"));

        }

        [Test]
        public async Task DeclineOfferAsync()
        {
            service = new OfferService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = true };
            var user2 = new User() { Id = "newUserId2", IsInstructor = false };


            var offers = new List<Offer>()
            {
              new Offer(){Id = 1, Description ="", Owner = user1, OwnerId = user1.Id, IsAccepted = null, IsActive = true, Price = 1},
              new Offer(){Id = 2, Description ="", Owner = user1, OwnerId = user1.Id, IsAccepted = null, IsActive = true, Price = 1},
            };
            await repo.AddRangeAsync(offers);


            var jumps = new List<Jump>()
            {
              new Jump(){Id = 1, Title ="", Description ="", Owner = user2, OwnerId = user2.Id, IsActive = true, JumpCategoryId = 1, IsApproved = true, IsTaken = false, Status = "", StartDate = DateTime.Now, JumpStatusId = 1},

               new Jump(){Id = 2, Title ="", Description ="", Owner = user2, OwnerId = user2.Id, IsActive = true, JumpCategoryId = 1, IsApproved = true, IsTaken = false, Status = "", StartDate = DateTime.Now, JumpStatusId = 1},
            };
            await repo.AddRangeAsync(jumps);

            var jumpOffers = new List<JumpOffer>()
            {
                new JumpOffer(){JumpId = 1, OfferId = 1}
            };
            await repo.AddRangeAsync(jumpOffers);
            await repo.SaveChangesAsync();

            await service.DeclineOfferAsync(1);

            var dbOffer = await repo.GetByIdAsync<Offer>(1);
            var dbJump = await repo.GetByIdAsync<Jump>(1);

            var _dbOffer = await repo.GetByIdAsync<Offer>(2);
            var _dbJump = await repo.GetByIdAsync<Jump>(2);

            Assert.That(dbOffer.IsAccepted == false);
            Assert.That(dbJump.IsTaken == false);
            Assert.That(dbJump.InstructorId == null);

            Assert.That(_dbOffer.IsAccepted == null);
            Assert.That(_dbJump.IsTaken == false);
            Assert.That(_dbJump.InstructorId == null);
        }

        [Test]
        public async Task GetOfferAsync()
        {
            service = new OfferService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = true };


            var offers = new List<Offer>()
            {
              new Offer(){Id = 1, Description ="First", Owner = user1, OwnerId = user1.Id, IsAccepted = null, IsActive = true, Price = 1},
              new Offer(){Id = 2, Description ="Second", Owner = user1, OwnerId = user1.Id, IsAccepted = null, IsActive = true, Price = 1},
            };
            await repo.AddRangeAsync(offers);
            await repo.SaveChangesAsync();

            var firstOffer = await service.GetOfferAsync(1);
            var secondOffer = await service.GetOfferAsync(2);

            Assert.That(firstOffer.Description == "First");
            Assert.That(secondOffer.Description == "Second");
        }

        [Test]
        public async Task GetOfferAsyncThrowsException()
        {
            service = new OfferService(repo);

            Assert.That(async () => await service.GetOfferAsync(1),
              Throws.Exception.With.Property("Message")
              .EqualTo("Offer don't exist"));
        }

        [Test]
        public async Task OfferExists()
        {
            service = new OfferService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = true };


            var offers = new List<Offer>()
            {
              new Offer(){Id = 1, Description ="First", Owner = user1, OwnerId = user1.Id, IsAccepted = null, IsActive = true, Price = 1},
              new Offer(){Id = 2, Description ="Second", Owner = user1, OwnerId = user1.Id, IsAccepted = null, IsActive = true, Price = 1},
            };
            await repo.AddRangeAsync(offers);
            await repo.SaveChangesAsync();

            var firstOffer = await service.OfferExists(1);
            var secondOffer = await service.OfferExists(2);
            var thirdOffer = await service.OfferExists(3);

            Assert.That(firstOffer == true);
            Assert.That(secondOffer == true);
            Assert.That(thirdOffer == false);
        }

        [Test]
        public async Task OfferConditionAsync()
        {
            service = new OfferService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = true, FirstName = "", LastName = "", PhoneNumber = "" };
            var user2 = new User() { Id = "newUserId2", IsInstructor = true, FirstName = "", LastName = "", PhoneNumber = "" };
            var user3 = new User() { Id = "newUserId3", IsInstructor = false };


            var offers = new List<Offer>()
            {
              new Offer(){Id = 1, Description ="First", Owner = user1, OwnerId = user1.Id, IsAccepted = null, IsActive = true, Price = 1},
              new Offer(){Id = 2, Description ="Second", Owner = user1, OwnerId = user1.Id, IsAccepted = null, IsActive = true, Price = 1},
                new Offer(){Id = 3, Description ="Third", Owner = user2, OwnerId = user2.Id, IsAccepted = null, IsActive = true, Price = 1}
            };
            await repo.AddRangeAsync(offers);

            var jumpCategory = new JumpCategory() { Id = 1, Name = "Category" };
            await repo.AddAsync(jumpCategory);

            var jumpStatus = new JumpStatus() { Id = 1, Name = "Status" };
            await repo.AddAsync(jumpStatus);


            var jumps = new List<Jump>()
            {
              new Jump(){Id = 1, Title ="", Description ="", Owner = user3, OwnerId = user3.Id, IsActive = true, JumpCategoryId = jumpCategory.Id, Category = jumpCategory, IsApproved = true, IsTaken = false, Status = "Pending", StartDate = DateTime.Now, JumpStatusId = 1, JumpStatus = jumpStatus}
            };
            await repo.AddRangeAsync(jumps);

            var jumpOffers = new List<JumpOffer>()
            {
                new JumpOffer(){JumpId = 1, OfferId = 1},
                new JumpOffer(){JumpId = 1, OfferId = 2},
                new JumpOffer(){JumpId = 1, OfferId = 3}
            };
            await repo.AddRangeAsync(jumpOffers);

            await repo.SaveChangesAsync();

            var offerConditions = await service.OffersConditionAsync(user1.Id);

            Assert.That(2, Is.EqualTo(offerConditions.Count()));
            Assert.That(offerConditions.ElementAt(0).Description == "First");
            Assert.That(offerConditions.ElementAt(1).Description == "Second");
        }

        [Test]
        public async Task RemoveOfferAsync()
        {
            service = new OfferService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = true, FirstName = "", LastName = "", PhoneNumber = "" };

            var offers = new List<Offer>()
            {
              new Offer(){Id = 1, Description ="First", Owner = user1, OwnerId = user1.Id, IsAccepted = false, IsActive = true, Price = 1},
              new Offer(){Id = 2, Description ="Second", Owner = user1, OwnerId = user1.Id, IsAccepted = false, IsActive = true, Price = 1},
                new Offer(){Id = 3, Description ="Third", Owner = user1, OwnerId = user1.Id, IsAccepted = false, IsActive = true, Price = 1}
            };
            await repo.AddRangeAsync(offers);
            await repo.SaveChangesAsync();

            var userActiveOffers = await repo.AllReadonly<Offer>().Where(x => x.OwnerId == user1.Id && x.IsActive == true).ToListAsync();

            Assert.That(3, Is.EqualTo(userActiveOffers.Count()));

            await service.RemoveOfferAsync(user1.Id, 2);

            userActiveOffers = await repo.AllReadonly<Offer>().Where(x => x.OwnerId == user1.Id && x.IsActive == true).ToListAsync();

            Assert.That(2, Is.EqualTo(userActiveOffers.Count()));

            await service.RemoveOfferAsync(user1.Id, 1);

            userActiveOffers = await repo.AllReadonly<Offer>().Where(x => x.OwnerId == user1.Id && x.IsActive == true).ToListAsync();

            Assert.That(1, Is.EqualTo(userActiveOffers.Count()));

            await service.RemoveOfferAsync(user1.Id, 3);

            userActiveOffers = await repo.AllReadonly<Offer>().Where(x => x.OwnerId == user1.Id && x.IsActive == true).ToListAsync();

            Assert.That(0, Is.EqualTo(userActiveOffers.Count()));


        }

        [Test]
        public async Task RemoveOfferAsyncThrowsException()
        {
            service = new OfferService(repo);

            var user1 = new User()
            {
                Id = "newUserId1",
                IsInstructor = true,
                FirstName = "",
                LastName = "",
                PhoneNumber = ""
            };

            var offers = new List<Offer>()
            {
              new Offer(){Id = 1, Description ="First", Owner = user1, OwnerId = user1.Id,
                  IsAccepted = false, IsActive = true, Price = 1},

              new Offer(){Id = 2, Description ="Second", Owner = user1, OwnerId = user1.Id,
                  IsAccepted = true, IsActive = true, Price = 1},

              new Offer(){Id = 3, Description ="Third", Owner = user1, OwnerId = user1.Id,
                    IsAccepted = null, IsActive = true, Price = 1}
            };
            await repo.AddRangeAsync(offers);
            await repo.SaveChangesAsync();


            Assert.That(async () => await service.RemoveOfferAsync(user1.Id, 4),
              Throws.Exception.With.Property("Message")
              .EqualTo("Offer don't exist"));

            Assert.That(async () => await service.RemoveOfferAsync("invalidId", 1),
              Throws.Exception.With.Property("Message")
              .EqualTo("User not owner"));

            Assert.That(async () => await service.RemoveOfferAsync(user1.Id, 2),
              Throws.Exception.With.Property("Message")
              .EqualTo("This offer can't be deleted"));

            Assert.That(async () => await service.RemoveOfferAsync(user1.Id, 3),
              Throws.Exception.With.Property("Message")
              .EqualTo("This offer can't be deleted"));

        }

        [Test]
        public async Task SendOfferAsync()
        {
            service = new OfferService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = true, FirstName = "", LastName = "", PhoneNumber = "" };
            var user3 = new User() { Id = "newUserId3", IsInstructor = false };


            var jumpCategory = new JumpCategory() { Id = 1, Name = "Category" };
            await repo.AddAsync(jumpCategory);

            var jumpStatus = new JumpStatus() { Id = 1, Name = "Status" };
            await repo.AddAsync(jumpStatus);


            var jumps = new List<Jump>()
            {
              new Jump(){Id = 1, Title ="", Description ="", Owner = user3, OwnerId = user3.Id, IsActive = true, JumpCategoryId = jumpCategory.Id, Category = jumpCategory, IsApproved = true, IsTaken = false, Status = "Pending", StartDate = DateTime.Now, JumpStatusId = 1, JumpStatus = jumpStatus}
            };
            await repo.AddRangeAsync(jumps);
            await repo.SaveChangesAsync();

            var model = new OfferViewModel()
            {
                OwnerId = user1.Id,
                Description = "",
                FirstName = user1.FirstName,
                LastName = user1.LastName,
                JumpId = 1,
                Price = 200
            };

            var jumpOfferBefore = await repo.AllReadonly<JumpOffer>()
                .Where(x => x.JumpId == 1 && x.Offer.OwnerId == user1.Id)
                .AnyAsync();

            await service.SendOfferAsync(model, 1, user1.Id);

            var jumpOfferAfter = await repo.AllReadonly<JumpOffer>()
                .Where(x => x.JumpId == 1 && x.Offer.OwnerId == user1.Id)
                .AnyAsync();

            Assert.IsTrue(jumpOfferAfter);
            Assert.IsFalse(jumpOfferBefore);
        }

        [Test]
        public async Task SendOfferAsyncThrowsException()
        {
            service = new OfferService(repo);

            var user1 = new User() { Id = "newUserId1", IsInstructor = true, FirstName = "", LastName = "", PhoneNumber = "" };
            var user3 = new User() { Id = "newUserId3", IsInstructor = false };


            var jumpCategory = new JumpCategory() { Id = 1, Name = "Category" };
            await repo.AddAsync(jumpCategory);

            var jumpStatus = new JumpStatus() { Id = 1, Name = "Status" };
            await repo.AddAsync(jumpStatus);

            var jumps = new List<Jump>()
            {
              new Jump(){Id = 1, Title ="", Description ="", Owner = user3, OwnerId = user3.Id, IsActive = true, JumpCategoryId = jumpCategory.Id, Category = jumpCategory, IsApproved = true, IsTaken = false, Status = "Pending", StartDate = DateTime.Now, JumpStatusId = 1, JumpStatus = jumpStatus}
            };
            await repo.AddRangeAsync(jumps);
            await repo.SaveChangesAsync();

            var model = new OfferViewModel()
            {
                OwnerId = user1.Id,
                Description = "",
                FirstName = user1.FirstName,
                LastName = user1.LastName,
                JumpId = 1,
                Price = 200
            };

            Assert.That(async () => await service.SendOfferAsync(model, 2, user1.Id),
              Throws.Exception.With.Property("Message")
              .EqualTo("Invalid jump Id"));

            await service.SendOfferAsync(model, 1, user1.Id);

            Assert.That(async () => await service.SendOfferAsync(model, 1, user1.Id),
              Throws.Exception.With.Property("Message")
              .EqualTo("One offer per jump"));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
