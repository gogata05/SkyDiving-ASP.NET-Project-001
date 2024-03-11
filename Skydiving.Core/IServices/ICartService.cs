using Microsoft.AspNetCore.Http;
using Skydiving.Core.ViewModels.Cart;
using Skydiving.Core.ViewModels.Equipment;
using Skydiving.Infrastructure.Data.EntityModels;

namespace Skydiving.Core.IServices
{
    public interface ICartService
    {
        Task<IEnumerable<EquipmentViewModel>> ViewCart(string userId);

        Task<IEnumerable<OrderViewModel>> MyOrder(string userId);

        Task AddToCart(int equipmentId, string userId);

        Task RemoveFromCart(int equipmentId, string userId);

        Task CheckoutCart(IFormCollection collection, string clientId);

        Task<Cart> CartExists(string userId);
    }
}
