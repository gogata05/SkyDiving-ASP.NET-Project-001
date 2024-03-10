using Microsoft.AspNetCore.Mvc;
using Skydiving.Core.Services;

namespace Skydiving.Areas.Admin.Controllers
{
    public class StatisticController : BaseController
    {
        private readonly StatisticAdministrationService service;

        public StatisticController(StatisticAdministrationService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> All()
        {
            var model = await service.StatisticAsync();
            return View(model);
        }
    }
}
