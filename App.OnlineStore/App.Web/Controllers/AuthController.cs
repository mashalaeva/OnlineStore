using System.Threading.Tasks;
using App.Application;
using App.Domain;
using App.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public AuthController(UserService userService, OrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            string tmpId = _userService.GetTmpId();
            User user = null;
            if (!string.IsNullOrEmpty(tmpId))
            {
                user = _userService.FindUserByEmail(tmpId);
            }

            var model = new LoginModel
            {
                User = user
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.FindUserByLogin(model.Email, model.Password);
                var tmpUser = _userService.FindUserByEmail(_userService.GetTmpId());

                _userService.DeleteUser(tmpUser);

                await _userService.Authenticate(user.Surname, user.Email);

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                
                return RedirectToAction("Index", "ProductCatalog");
            }

            string tmpId = _userService.GetTmpId();
            User modelUser = null;

            if (!string.IsNullOrEmpty(tmpId))
            {
                modelUser = _userService.FindUserByEmail(tmpId);
            }

            model.User = modelUser;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            _userService.RemoveTmpId();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}