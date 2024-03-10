﻿using Skydiving.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Skydiving.Core.Constants;
using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Skydiving.Core.IServices;

namespace Skydiving.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IEquipmentService equipmentService;

        public HomeController(ILogger<HomeController> _logger, IEquipmentService _equipmentService)
        {
            logger = _logger;
            equipmentService = _equipmentService;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await equipmentService.GetLastThreeEquipments();
                return View(model);
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            if (feature != null)
            {
                var statusCode = HttpContext.Response.StatusCode;

                if (statusCode == 404)
                {
                    return View("404");
                }
                if (statusCode == 500)
                {
                    return View("500");
                }
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}