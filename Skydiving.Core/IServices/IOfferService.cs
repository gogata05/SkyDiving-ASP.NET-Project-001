using Skydiving.Core.ViewModels.Offer;
using Skydiving.Infrastructure.Data.EntityModels;

namespace Skydiving.Core.IServices
{
    public interface IOfferService
    {
        Task SendOfferAsync(OfferViewModel model, int jumpId, string userId);

        Task<IEnumerable<OfferServiceViewModel>> OffersConditionAsync(string userId);

        Task<bool> OfferExists(int id);

        Task<Offer> GetOfferAsync(int id);

        Task AcceptOfferAsync(int offerId);

        Task DeclineOfferAsync(int offerId);

        Task RemoveOfferAsync(string id, int offerId);
    }
}
