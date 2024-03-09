using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<JumpController> logger;
        public JumpController(IJumpService _service, ILogger<JumpController> _logger)
        {
            service = _service;
            logger = _logger;
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


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            try
            {
                var jump = await service.GetAllJumpsAsync();
                return View(jump);
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id,string userId)
        {
            var model = await service.GetEditAsync(id,userId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, JumpModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            await service.PostEditAsync(id, model);
            return RedirectToAction("All", "Jump");
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (await service.JumpExistAsync(id) == false)
                {
                    TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                    return RedirectToAction("All", "Jump");
                }

                var model = await service.JumpDetailsAsync(id);
                return View(model);
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
