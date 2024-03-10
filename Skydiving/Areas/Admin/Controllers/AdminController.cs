using Skydiving.Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Skydiving.Areas.Admin.Controllers
{

    public class AdminController : BaseController
    {

        public IActionResult Index()
        {

            return View();
        }

    }
}
