using Skydiving.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json.Serialization;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.ViewModels.Equipment;
using Skydiving.Core.ViewModels.Cart;
using Skydiving.Core.IServices;

namespace Skydiving.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;

        public CartService(IRepository _repo)
        {
            repo = _repo;
        }
        /// <summary>
        /// Add equipment to the user cart
        /// </summary>
        /// <param name="equipmentId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task AddToCart(int equipmentId, string userId)
        {
            var cart = await CartExists(userId);
            var equipment = await repo.AllReadonly<Equipment>().Where(x => x.Id == equipmentId).FirstOrDefaultAsync();

            if (equipment == null)
            {
                throw new Exception("Equipment don't exist");
            }

            bool equipmentCartExist = await repo.AllReadonly<EquipmentCart>()
                .Where(x => x.CartId == cart.Id && x.EquipmentId == equipment.Id)
                .AnyAsync();
            if (equipmentCartExist)
            {
                throw new Exception("Equipment already in cart");
            }

            var equipmentcart = new EquipmentCart()
            {
                CartId = cart.Id,
                EquipmentId = equipment.Id
            };

            await repo.AddAsync(equipmentcart);
            await repo.SaveChangesAsync();
        }
        /// <summary>
        /// Returns user cart, create one if it don't exist
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Cart> CartExists(string userId)
        {
            Cart userCart;
            var cartExist = await repo.AllReadonly<Cart>().Where(x => x.UserId == userId).AnyAsync();

            if (!cartExist)
            {
                var user = await repo.GetByIdAsync<User>(userId);
                userCart = new Cart()
                {
                    User = user,
                    UserId = user.Id
                };
                await repo.AddAsync(userCart);
                await repo.SaveChangesAsync();
            }
            else
            {
                userCart = await repo.AllReadonly<Cart>().Where(x => x.UserId == userId).FirstAsync();
            }
            return userCart;
        }
        /// <summary>
        /// Removes equipment from user cart
        /// </summary>
        /// <param name="equipmentId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task RemoveFromCart(int equipmentId, string userId)
        {
            var cart = await repo.AllReadonly<Cart>()
                .Where(x => x.UserId == userId)
                .FirstOrDefaultAsync();

            if (cart == null)
            {
                throw new Exception("Cart don't exist");
            }

            var equipmentCart = await repo.All<EquipmentCart>()
                .Where(x => x.CartId == cart.Id && x.EquipmentId == equipmentId)
                .FirstOrDefaultAsync();

            if (equipmentCart == null)
            {
                throw new Exception("Equipment not in the cart");
            }

            repo.Delete<EquipmentCart>(equipmentCart);
            await repo.SaveChangesAsync();
        }
        /// <summary>
        /// Removes equipments from user's cart and add them to order entity
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task CheckoutCart(IFormCollection collection, string clientId)
        {
            var count = collection["item.Id"].Count;

            if (count == 0)
            {
                throw new Exception("Invalid data");
            }

            var sb = new StringBuilder();
            sb.AppendLine("{");
            for (int i = 0; i < count; i++)
            {
                sb.AppendLine($"\"item{i + 1}\" : ");
                sb.Append("{");
                sb.AppendLine($"\"itemId\" : \"{collection["item.Id"][i]}\",");
                sb.AppendLine($"\"Available\" : \"{collection["item.Quantity"][i]}\",");
                sb.AppendLine($"\"Ordered\" : \"{collection["item.OrderQuantity"][i]}\",");
                sb.AppendLine($"\"Price\" : \"{collection["item.Price"][i]:F2}\",");
                sb.AppendLine($"\"Cost\" : \"{collection["cost"][i]:F2}\"");
                sb.Append("},");
            }
            sb.Append($"\"TotalCost\":\"{collection["total"]}\",");
            sb.Append($"\"itemsInOrder\":\"{count}\",");
            sb.Append($"\"BuyerId\":\"{clientId}\"");
            sb.Append($"\"Address\":\"{collection["address"]}\"");
            sb.Append($"\"CityId\":\"{collection["City"]}\"");
            sb.Append($"\"OfficeLocation\":\"{collection["Office"]}\"");
            sb.Append("}");

            var itemsDetails = sb.ToString().Trim();

            var order = new Order()
            {
                TotalCost = decimal.Parse($"{collection["total"]:F2}"),
                ClientId = clientId,
                ItemsDetails = itemsDetails,
                ReceivedOn = DateTime.Now,
                Status = "Preparing",
                OrderAdress = collection["address"]
            };

            await repo.AddAsync<Order>(order);

            var equipmentIds = collection["item.Id"];

            foreach (var id in equipmentIds)
            {
                await RemoveFromCart(int.Parse(id), clientId);
            };

            await repo.SaveChangesAsync();
        }
        /// <summary>
        /// Returns view with equipments data from user's cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<EquipmentViewModel>> ViewCart(string userId)
        {
            var cart = await CartExists(userId);

            var equipments = await repo.AllReadonly<EquipmentCart>().Where(c => c.CartId == cart.Id).Include(t => t.Equipment).Include(c => c.Equipment.Category).Include(t => t.Equipment.Owner).Select(x => new EquipmentViewModel()
            {
                Id = x.Equipment.Id,
                Title = x.Equipment.Title,
                Brand = x.Equipment.Brand,
                Price = x.Equipment.Price,
                Quantity = x.Equipment.Quantity,
                Category = x.Equipment.Category.Name,
                Description = x.Equipment.Description,
                OwnerId = x.Equipment.Owner.Id,
                OwnerName = x.Equipment.Owner.UserName
            }).ToListAsync();

            if (equipments == null)
            {
                throw new Exception("Equipments DB error");
            }

            return equipments;

        }
        /// <summary>
        /// Returns details for user's order
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OrderViewModel>> MyOrder(string userId)
        {
            var orders = await repo.AllReadonly<Order>()
                .Where(c => c.ClientId == userId)
                .Select(x => new OrderViewModel
                {
                    OrderNumber = x.Id,
                    OrderAdress = x.OrderAdress,
                    ReceivedOn = x.ReceivedOn,
                    Status = x.Status,
                    CompletedOn = x.CompletedOn,
                    IsCompleted = x.IsCompleted
                })
                .ToListAsync();

            return orders;
        }
    }
}
