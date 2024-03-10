using Microsoft.AspNetCore.Mvc;
using Skydiving.Core.Constants;
using Skydiving.Core.IServices;
using Skydiving.Core.ViewModels.Equipment;
using Skydiving.Extensions;

namespace Skydiving.Areas.Admin.Controllers
{
    public class EquipmentController : BaseController
    {
        private readonly IEquipmentService service;
        private readonly IAdminEquipmentService adminService;
        private readonly ILogger<EquipmentController> logger;

        public EquipmentController(IEquipmentService _service, IAdminEquipmentService _adminService, ILogger<EquipmentController> _logger)
        {
            service = _service;
            adminService = _adminService;
            logger = _logger;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                var model = new EquipmentModel();
                model.EquipmentCategories = await adminService.AllCategories();
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
        public async Task<IActionResult> Add(EquipmentModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData[MessageConstant.ErrorMessage] = "Invalid model data!";
                    model.EquipmentCategories = await adminService.AllCategories();
                    return View(model);

                }

                await adminService.AddEquipmentAsync(model, User.Id());
                TempData[MessageConstant.SuccessMessage] = "Equipment added successfully";
                return RedirectToAction(nameof(All));
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var equipments = await service.GetAllEquipmentsAsync();
                return View(equipments);
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await adminService.GetEditAsync(id, User.Id());
                model.EquipmentCategories = await adminService.AllCategories();
                return View(model);
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = ms.Message;
                logger.LogError(ms.Message, ms);
                return RedirectToAction(nameof(All));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EquipmentModel model)
        {
            try
            {
                if (await adminService.CategoryExists(model.CategoryId) == false)
                {
                    ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
                    model.EquipmentCategories = await adminService.AllCategories();
                    return View(model);
                }

                if (!ModelState.IsValid)
                {
                    model.EquipmentCategories = await adminService.AllCategories();
                    return View(model);

                }

                await adminService.PostEditAsync(id, model);
                TempData[MessageConstant.SuccessMessage] = "Equipment edited successfully";

                return RedirectToAction(nameof(All));
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction(nameof(All));
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await adminService.RemoveEquipmentAsync(id, User.Id());
                TempData[MessageConstant.SuccessMessage] = "Equipment removed successfully";
                return RedirectToAction(nameof(All));
            }
            catch (Exception ms)
            {
                logger.LogError(ms.Message, ms);
                TempData[MessageConstant.ErrorMessage] = ms.Message;
                return RedirectToAction(nameof(All));
            }
        }
    }
}
