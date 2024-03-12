using Skydiving.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.ViewModels.Cart;
using Skydiving.Core.IServices;

namespace Skydiving.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repo;
        public OrderService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<OrderServiceViewModel>> AllOrdersAsync()
        {
            var result = await repo.AllReadonly<Order>().ToListAsync();

            return result.Select(x => new OrderServiceViewModel()
            {
                Details = x.ItemsDetails,
                TotalCost = x.TotalCost,
                OrderNumber = x.Id,
                OrderAdress = x.OrderAdress,
                CompletedOn = x.CompletedOn,
                ReceivedOn = x.ReceivedOn,
                IsCompleted = x.IsCompleted,
                Status = x.Status
            });
        }

        public async Task DispatchAsync(int id)
        {
            //check quantity
            var order = await repo.GetByIdAsync<Order>(id);
            order.IsCompleted = true;
            order.CompletedOn = DateTime.Now;
            order.Status = "Dispatched";
            await repo.SaveChangesAsync();
        }
    }
}
