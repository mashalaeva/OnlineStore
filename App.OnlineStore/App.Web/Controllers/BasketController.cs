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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        private readonly CategoryService _categoryService;
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public BasketController(CategoryService categoryService, UserService userService, OrderService orderService)
        {
            _categoryService = categoryService;
            _userService = userService;
            _orderService = orderService;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Index([FromForm] OrderedProductRequestModel orderedProduct, int basketId)
        {
            var user = _userService.GetCurrentUser();

            string tmpId = _userService.GetTmpId();

            var userId = user.Id;
            var userRole = _userService.GetUserRole(user.Id);

            string PurchaseMessage = null;

            if (basketId > 0)
            {
                if (userRole != user.Role)
                {
                    return RedirectToAction("Login", "Auth");
                }
                PurchaseMessage = $"Покупка успешно оформлена. Ваш номер заказа: {basketId}";
            }

            if (orderedProduct.AddButton != null)
            {
                _orderService.IncrementProductFromBasket(orderedProduct.ProductId, basketId);
            }

            if (orderedProduct.RemoveButton != null)
            {
                _orderService.DecrementProductFromBasket(orderedProduct.ProductId, basketId);
            }

            if (orderedProduct.RemoveAllButton != null)
            {
                _orderService.DeleteProductFromBasket(orderedProduct.ProductId, basketId);
            }

            var model = new BasketModel
            {
                ProductsInOrder = _orderService.OrderedProductsInBasketByUser(userId),
                User = _userService.FindUserById(userId),
                Basket = _orderService.GetBasket(userId),
                ProductsInBasketCount =  _orderService.CountProductsNumberInBasket(userId),
                TotalPrice = _orderService.CountTotalPrice(userId)
            };

            if (!string.IsNullOrEmpty(PurchaseMessage))
            {
                model.PurchaseMessage = PurchaseMessage;
            }

            return View(model);
        }
    }
}