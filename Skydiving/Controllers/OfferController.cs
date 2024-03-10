using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skydiving.Core.Constants;
using Skydiving.Core.IServices;
using Skydiving.Core.ViewModels.Offer;
using Skydiving.Extensions;

namespace Skydiving.Controllers
{
    [Authorize]
    public class OfferController : Controller
    {
        private readonly IOfferService service;
        private readonly ILogger<OfferController> logger;

        public OfferController(IOfferService _service, ILogger<OfferController> _logger)
        {
            service = _service;
            logger = _logger;
        }

        [HttpGet]
        [Authorize(Roles = RoleConstants.Instructor)]
        public IActionResult Send()
        {
            var model = new OfferViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RoleConstants.Instructor)]
        public async Task<IActionResult> Send(int id, OfferViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await service.SendOfferAsync(model, id, User.Id());
                TempData[MessageConstant.SuccessMessage] = "Offer sent";
                return RedirectToAction("All", "Jump");
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = ms.Message;
                logger.LogError(ms.Message, ms);
                return RedirectToAction("All", "Jump");
            }


        }



        [HttpGet]
        [Authorize(Roles = RoleConstants.Instructor)]
        public async Task<IActionResult> OffersCondition()
        {
            try
            {
                var offersCondition = await service.OffersConditionAsync(User.Id());
                return View(offersCondition);
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConstants.Administrator}, {RoleConstants.Jumper}")]
        public async Task<IActionResult> Accept(int id)
        {
            try
            {
                await service.AcceptOfferAsync(id);
                return RedirectToAction("JumpOffers", "Jump");
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }


        }


        [HttpGet]
        [Authorize(Roles = $"{RoleConstants.Administrator}, {RoleConstants.Jumper}")]
        public async Task<IActionResult> Decline(int id)
        {
            try
            {
                if (await service.OfferExists(id))
                {
                    var offer = await service.GetOfferAsync(id);
                    await service.DeclineOfferAsync(id);
                }
                return RedirectToAction("JumpOffers", "Jump");
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        [Authorize(Roles = RoleConstants.Instructor)]
        public async Task<IActionResult> Delete(string id, int offerId)
        {
            try
            {
                await service.RemoveOfferAsync(id, offerId);
                return RedirectToAction(nameof(OffersCondition));
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction(nameof(OffersCondition));
            }
        }
    }
}
