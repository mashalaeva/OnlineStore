using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using App.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Web.Models;

namespace App.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public BasketController(CategoryService categoryService, UserService userService, OrderService orderService)
        {
            _categoryService = categoryService;
            _userService = userService;
            _orderService = orderService;
        }

        /*public IActionResult Index()
        {
           // return View();
        }

        public IActionResult Privacy()
        {
            //return View();
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}