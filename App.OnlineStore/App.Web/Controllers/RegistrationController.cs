using System;
using System.Threading.Tasks;
using App.Application;
using App.Domain;
using App.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public RegistrationController(UserService userService, OrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CreateAccountRequestModel newUser)
        {
            if (ModelState.IsValid)
            {
                User user;
                try
                {
                    user = _userService.FindUserByEmail(newUser.Email);
                    if (user == null)
                        throw new Exception();
                }
                catch (Exception)
                {
                    // Добавляем пользователя в БД.
                    user = _userService.CreateNewUser(
                        newUser.FirstName,
                        newUser.SecondName,
                        newUser.Login,
                        newUser.Address,
                        newUser.Email,
                        newUser.Password,
                        newUser.Phone,
                        ERole.Buyer);

                    User tmpUser;
                    try
                    {
                        tmpUser = _userService.FindUserByEmail(_userService.GetTmpId());
                        _userService.DeleteUser(tmpUser);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    // Аутентификация.
                    await _userService.Authenticate(user.Surname, user.Email);

                    return RedirectToAction("Index", "ProductCatalog");
                }

                ModelState.AddModelError("", "Пользователь с введенным email уже существует");
            }

            string tmpId = _userService.GetTmpId();
            User modelUser = null;

            if (!string.IsNullOrEmpty(tmpId))
            {
                modelUser = _userService.FindUserByEmail(tmpId);
            }

            return View("Index", newUser);
        }

        [HttpGet]
        public IActionResult Index()
        {
            string tmpId = _userService.GetTmpId();
            User user = null;
            if (!string.IsNullOrEmpty(tmpId))
            {
                user = _userService.FindUserByEmail(tmpId);
            }

            var model = new CreateAccountRequestModel
            {
                UserNavBar = new UserNavBarModel
                {
                    BasketCount = 0,
                    User = user
                }
            };
            return View(model);
        }
    }
}