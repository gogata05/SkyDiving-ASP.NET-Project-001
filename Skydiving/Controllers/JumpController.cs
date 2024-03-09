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
        [Authorize(Roles = $"{RoleConstants.Jumper}, {RoleConstants.Administrator}")]
        public async Task<IActionResult> Add()
        {
            try
            {
                var model = new JumpModel()
                {
                    JumpCategories = await service.AllCategories()
                };
                return View(model);
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.Jumper}, {RoleConstants.Administrator}")]
        public async Task<IActionResult> Add(JumpModel model)
        {

            if (await service.CategoryExists(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.JumpCategories = await service.AllCategories();
                return View(model);

            }
            try
            {
                var userId = User.Id();
                await service.AddJumpAsync(userId, model);
                TempData[MessageConstant.SuccessMessage] = "Jump send for review!";
                return RedirectToAction(nameof(MyJumps));
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }
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
        [Authorize(Roles = $"{RoleConstants.Jumper}, {RoleConstants.Administrator}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await service.GetEditAsync(id, User.Id());
                model.JumpCategories = await service.AllCategories();
                return View(model);
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction(nameof(MyJumps));
            }
        }
        [HttpPost]
        [Authorize(Roles = $"{RoleConstants.Jumper}, {RoleConstants.Administrator}")]
        public async Task<IActionResult> Edit(int id, JumpModel model)
        {
            try
            {
                if (await service.CategoryExists(model.CategoryId) == false)
                {
                    ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                    model.JumpCategories = await service.AllCategories();
                    return View(model);
                }

                if (!ModelState.IsValid)
                {
                    model.JumpCategories = await service.AllCategories();
                    return View(model);

                }

                await service.PostEditAsync(id, model);
                return RedirectToAction(nameof(MyJumps));
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction(nameof(MyJumps));
            }
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

        public async Task<IActionResult> MyJumps()
        {
            try
            {
                var model = await service.GetMyJumpsAsync(User.Id());
                return View(model);
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
