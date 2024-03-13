using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Skydiving.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        public IActionResult LiveChat()
        {
            return View();
        }
    }
}
