using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skydiving.Core.Constants;
using Skydiving.Core.IServices;
using Skydiving.Core.ViewModels.Instructor;
using Skydiving.Extensions;

namespace Skydiving.Controllers
{


    [Authorize]
    public class InstructorController : Controller
    {
        private readonly IInstructorService service;
        private readonly ILogger<InstructorController> logger;

        public InstructorController(
            IInstructorService _service,
            ILogger<InstructorController> _logger)
        {
            service = _service;
            logger = _logger;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var model = await service.AllInstructorsAsync();
                return View(model);
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.Jumper)]
        public IActionResult Become()
        {
            var model = new BecomeInstructorViewModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.Jumper)]
        public async Task<IActionResult> Become(BecomeInstructorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await service.AddInstructorAsync(User.Id(), model);
                return RedirectToAction("JoinInstructors", "User");
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public IActionResult RateInstructor(string id, int jumpId)
        {
            var model = new InstructorRatingModel()
            {
                InstructorId = id,
                UserId = User.Id(),
                JumpId = jumpId
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> RateInstructor(string id, int jumpId, InstructorRatingModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await service.RateInstructorAsync(User.Id(), id, jumpId, model);
                return RedirectToAction("MyJumps", "Jump");
            }
            catch (Exception ms)
            {
                logger.LogError(ms.Message, ms);
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                return RedirectToAction("Index", "Home");
            }

        }
    }
}
