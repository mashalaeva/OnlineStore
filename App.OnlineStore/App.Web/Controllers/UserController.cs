using App.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using App.Application;
using App.Domain;
using App.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

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
                User = user
            };

            return View(model);
        }
    }
}