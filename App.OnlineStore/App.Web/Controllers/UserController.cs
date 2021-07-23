using App.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using App.Domain;
using App.Web.Models;

namespace App.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public UserController(UserService userService, OrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            User user;
            try
            {
                user = _userService.GetCurrentUser();
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Auth");
            }   

            var model = new UserProfileModel
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