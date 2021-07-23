using System;
using App.Application;
using App.Domain;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("{controller}")]
    public class ProductDetailController : Controller
    {
        private ProductService _productService;
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public ProductDetailController(ProductService service, UserService userService, OrderService orderService)
        {
            _productService = service;
            _userService = userService;
            _orderService = orderService;
        }

        [HttpGet("{productId?}")]
        [HttpPost("{productId?}")]
        public IActionResult Index(int productId, [FromForm] OrderedProductRequestModel orderedProduct)
        {
            User user;
            try
            {
                user = _userService.GetCurrentUser();
                if (user == null)
                    throw new Exception();
            }
            catch (Exception)
            {
                user = _userService.GetOrCreateAnonymousUser();
            }

            if (orderedProduct.AddButton != null)
            {
                orderedProduct.UserId = user.Id;
                
                _orderService.IncrementProductFromBasket(orderedProduct.ProductId,
                    _orderService.GetBasketId(user.Id), user.Id);
            }

            var model = new ProductModel
            {
                CurrentProductId = productId,
                Product = _productService.FindProductById(productId),
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