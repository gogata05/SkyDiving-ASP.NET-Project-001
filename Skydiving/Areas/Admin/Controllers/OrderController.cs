using Microsoft.AspNetCore.Mvc;
using Skydiving.Core.IServices;

namespace Skydiving.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService service;

        public OrderController(IOrderService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> All()
        {
            var model = await service.AllOrdersAsync();
            return View(model);
        }
        public async Task<IActionResult> Dispatch(int id)
        {
            await service.DispatchAsync(id);
            return RedirectToAction(nameof(All));
        }
    }
}
