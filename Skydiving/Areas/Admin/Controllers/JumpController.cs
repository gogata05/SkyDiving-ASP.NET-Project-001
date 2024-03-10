using Microsoft.AspNetCore.Mvc;
using Skydiving.Core.IServices;

namespace Skydiving.Areas.Admin.Controllers
{
    public class JumpController : BaseController
    {
        private readonly IJumpAdministrationService service;

        public JumpController(IJumpAdministrationService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> All()
        {
            var allJumps = await service.GetAllJumpsAsync();

            return View(allJumps);
        }

        public async Task<IActionResult> Active()
        {
            var jumps = await service.ReviewActiveJumps();
            return View(jumps);
        }

        public async Task<IActionResult> Pending()
        {
            var jumps = await service.ReviewPendingJumps();
            return View(jumps);
        }

        public async Task<IActionResult> Declined()
        {
            var jumps = await service.ReviewDeclinedJumps();
            return View(jumps);
        }


        public async Task<IActionResult> Details(int id)
        {
            //if ((await service.JumpExistAsync(id)) == false)
            //{
            //    TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
            //    return RedirectToAction("All", "Jump");
            //}

            var model = await service.JumpDetailsAsync(id);
            return View(model);
        }

        public async Task<IActionResult> Approve(int id)
        {
            //if ((await service.JumpExistAsync(id)) == false)
            //{
            //    TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
            //    return RedirectToAction("All", "Jump");
            //}

            await service.ApproveJumpAsync(id);
            var jumps = await service.ReviewPendingJumps();
            return View("Pending", jumps);
        }

        public async Task<IActionResult> Decline(int id)
        {
            //if ((await service.JumpExistAsync(id)) == false)
            //{
            //    TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
            //    return RedirectToAction("All", "Jump");
            //}

            await service.DeclineJumpAsync(id);
            var jumps = await service.ReviewPendingJumps();
            return View("Pending", jumps);
        }


    }
}
