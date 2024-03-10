using Skydiving.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.ViewModels.Offer;
using Skydiving.Core.IServices;

namespace Skydiving.Core.Services
{
    public class OfferService : IOfferService
    {
        private readonly IRepository repo;

        public OfferService(IRepository _repo)
        {
            repo = _repo;
        }
 
        public async Task AcceptOfferAsync(int offerId)
        {
            if (await OfferExists(offerId))
            {
                int jumpId = await repo.AllReadonly<JumpOffer>().Where(o => o.OfferId == offerId).Select(x => x.JumpId).FirstOrDefaultAsync();

                if (jumpId == 0)
                {
                    throw new Exception("Jump not found");
                }

                var offer = await GetOfferAsync(offerId);
                offer.IsAccepted = true;

                var jump = await repo.GetByIdAsync<Jump>(jumpId);
                jump.InstructorId = offer.OwnerId;
                jump.IsTaken = true;

                await repo.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Offer don't exist");
            }
        }

        public async Task DeclineOfferAsync(int offerId)
        {
            if (await OfferExists(offerId))
            {
                var offer = await GetOfferAsync(offerId);
                offer.IsAccepted = false;
                await repo.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Offer don't exist");
            }
        }
        
        public async Task<Offer> GetOfferAsync(int id)
        {
            var offer = await repo.All<Offer>()
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            if (offer == null)
            {
                throw new Exception("Offer don't exist");
            }
            return offer;
        }

        public async Task<bool> OfferExists(int id)
        {
            return await repo.AllReadonly<Offer>().AnyAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<OfferServiceViewModel>> OffersConditionAsync(string userId)
        {
            var offersCondition = await repo.AllReadonly<JumpOffer>().Where(j => j.Offer.OwnerId == userId && j.Offer.IsActive == true)
                .Select(x => new OfferServiceViewModel()
                {
                    Description = x.Offer.Description,
                    InstructorName = x.Offer.Owner.UserName,
                    JumpCategory = x.Jump.Category.Name ?? "include category!",
                    JumpTitle = x.Jump.Title,
                    IsAccepted = x.Offer.IsAccepted,
                    Id = x.Offer.Id,
                    Price = x.Offer.Price,
                    InstructorPhoneNumber = x.Offer.Owner.PhoneNumber,
                    FirstName = x.Offer.Owner.FirstName,
                    LastName = x.Offer.Owner.LastName,
                    JumpDescription = x.Jump.Description,
                    JumpId = x.JumpId,
                    OwnerId = userId,
                    Rating = "Rating"

                }).ToListAsync();

            if (offersCondition == null)
            {
                throw new Exception("JumpOffer entity error");
            }

            return offersCondition;
        }
  
        public async Task RemoveOfferAsync(string id, int offerId)
        {
            if (!await OfferExists(offerId))
            {
                throw new Exception("Offer don't exist");
            }

            var offer = await repo.GetByIdAsync<Offer>(offerId);

            if (offer.OwnerId != id)
            {
                throw new Exception("User not owner");
            }

            if (offer.IsAccepted == true || offer.IsAccepted == null)
            {
                throw new Exception("This offer can't be deleted");
            }

            offer.IsActive = false;
            await repo.SaveChangesAsync();
        }

        public async Task SendOfferAsync(OfferViewModel model, int jumpId, string userId)
        {
            var jump = await repo.GetByIdAsync<Jump>(jumpId);
            if (jump == null)
            {
                throw new Exception("Invalid jump Id");
            }

            var userOfferExist = await repo.AllReadonly<JumpOffer>()
                .Where(x => x.Offer.OwnerId == userId
                && x.JumpId == jumpId
                && x.Offer.IsAccepted != false)
                .AnyAsync();

            if (userOfferExist)
            {
                throw new Exception("One offer per jump");
            }

            var offer = new Offer()
            {
                Description = model.Description,
                OwnerId = userId,
                Price = model.Price

            };
            await repo.AddAsync<Offer>(offer);

            var jumpOffer = new JumpOffer()
            {
                JumpId = jump.Id,
                Jump = jump,
                Offer = offer,
                OfferId = offer.Id
            };

            await repo.AddAsync<JumpOffer>(jumpOffer);

            await repo.SaveChangesAsync();

        }
    }
}
