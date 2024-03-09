using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skydiving.Core.Constants;
using Skydiving.Core.IServices;
using Skydiving.Core.ViewModels;
using Skydiving.Extensions;
namespace Skydiving.Controllers
{
    [Authorize]
    public class JumpController : Controller
    {
        private readonly IJumpService service;

        public JumpController(IJumpService _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new JumpModel();
            var userId = User.Id();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(JumpModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            var userId = User.Id();

            await service.AddJumpAsync(userId, model);
            return RedirectToAction(nameof(All));
        }
    }
}
