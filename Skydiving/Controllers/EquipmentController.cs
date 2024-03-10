using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skydiving.Core.Constants;
using Skydiving.Core.IServices;
using Skydiving.Core.ViewModels.Equipment;

namespace Skydiving.Controllers
{
    [AllowAnonymous]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService service;
        private readonly ILogger<EquipmentController> logger;

        public EquipmentController(IEquipmentService _service, ILogger<EquipmentController> _logger)
        {
            service = _service;
            logger = _logger;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllEquipmentsQueryModel query)
        {
            try
            {
                var result = await service.AllEquipmentsAsync(
                query.Category,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllEquipmentsQueryModel.EquipmentsPerPage);

                query.TotalEquipmentsCount = result.TotalEquipmentsCount;
                query.Categories = await service.AllCategoriesNames();
                query.Equipments = result.Equipments;

                return View(query);
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> All()
        //{
        //    try
        //    {
        //        var equipments = await service.GetAllEquipmentsAsync();
        //        return View(equipments);
        //    }
        //    catch (Exception ms)
        //    {
        //        TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
        //        logger.LogError(ms.Message, ms);
        //        return RedirectToAction("Index", "Home");
        //    }          
        //}

    }
}
