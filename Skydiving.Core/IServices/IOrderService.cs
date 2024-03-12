using Skydiving.Core.ViewModels.Cart;

namespace Skydiving.Core.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderServiceViewModel>> AllOrdersAsync();

        Task DispatchAsync(int id);
    }
}
