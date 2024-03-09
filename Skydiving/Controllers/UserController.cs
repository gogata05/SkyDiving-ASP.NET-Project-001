using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skydiving.Extensions;
using Skydiving.Core.Constants;
using Skydiving.Infrastructure.Data.EntityModels;
using Skydiving.Core.ViewModels;

namespace Skydiving.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;

        private readonly SignInManager<User> signInManager;

        private readonly ILogger<UserController> logger;


        public UserController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager,
            ILogger<UserController> _logger)

        {
            userManager = _userManager;
            signInManager = _signInManager;
            logger = _logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            try
            {
                if (User.Identity?.IsAuthenticated ?? false)
                {
                    return RedirectToAction("Index", "Home");
                }

                var model = new RegisterViewModel();

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
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = new User()
                {
                    Email = model.Email,
                    UserName = model.UserName
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, RoleConstants.Jumper);

                    return RedirectToAction("Login", "User");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

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
        [AllowAnonymous]
        public IActionResult Login()
        {
            try
            {
                if (User.Identity?.IsAuthenticated ?? false)
                {
                    return RedirectToAction("Index", "Home");
                }

                var model = new LoginViewModel();

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
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Invalid login");

                return View(model);
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }


        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }

        }

        [Authorize(Roles = RoleConstants.Jumper)]
        public async Task<IActionResult> JoinInstructors()  // becomeInstructor
        {
            try
            {
                var user = await userManager.FindByIdAsync(User.Id());
                await userManager.AddToRoleAsync(user, RoleConstants.Instructor);
                await userManager.RemoveFromRoleAsync(user, RoleConstants.Jumper);
                await signInManager.SignOutAsync();
                await signInManager.SignInAsync(user, isPersistent: false);
                TempData[MessageConstant.SuccessMessage] = "You are instructor now!";

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ms)
            {
                TempData[MessageConstant.ErrorMessage] = "Something went wrong!";
                logger.LogError(ms.Message, ms);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
