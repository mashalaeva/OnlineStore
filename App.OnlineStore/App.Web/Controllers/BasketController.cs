using System.Diagnostics;
using App.Application;
using App.Domain;
using Microsoft.AspNetCore.Mvc;
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

        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public BasketController(UserService userService, OrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Index([FromForm] OrderedProductRequestModel orderedProduct, int basketId)
        {
            var user = _userService.GetCurrentUser();
            var userId = user == null ? 0 : user.Id;
            var userRole = _userService.GetUserRole(user.Id);

            string PurchaseMessage = null;

            if (basketId > 0)
            {
                if (userRole != user.Role)
                {
                    return RedirectToAction("Login", "Auth");
                }

                PurchaseMessage = $"Покупка успешно оформлена. Ваш номер заказа: {basketId}";
                _orderService.ChangeStatus(_orderService.GetBasketId(userId), EStatus.Accepted);
            }

            if (orderedProduct.AddButton != null)
            {
                _orderService.IncrementProductFromBasket(orderedProduct.ProductId, basketId, userId);
            }

            if (orderedProduct.RemoveButton != null)
            {
                _orderService.DecrementProductFromBasket(orderedProduct.ProductId, basketId, userId);
            }

            if (orderedProduct.RemoveAllButton != null)
            {
                _orderService.DeleteProductFromBasket(orderedProduct.ProductId, basketId, userId);
            }

            var model = new BasketModel
            {
                ProductsInOrder = _orderService.OrderedProductsInBasketByUser(userId),
                UserNavBar = new UserNavBarModel
                {
                    BasketCount = user == null ? 0 : _orderService.CountProductsNumberInBasket(userId),
                    User = _userService.FindUserById(userId)
                },
                Basket = _orderService.GetBasket(userId),
                ProductsInBasketCount = _orderService.CountProductsNumberInBasket(userId),
                TotalPrice = _orderService.CountTotalPrice(_orderService.GetBasketId(userId))
            };

            if (!string.IsNullOrEmpty(PurchaseMessage))
            {
                model.PurchaseMessage = PurchaseMessage;
            }

            return View(model);
        }
    }
}