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
            User user = null;
            bool userIsNull = false;
            string tmpId = null;
            try
            {
                user = _userService.GetCurrentUser();
            }
            catch (Exception)
            {
                userIsNull = true;
            }

            try
            {
                tmpId = _userService.GetTmpId();
            }
            catch (Exception)
            {
                // ignored
            }

            if (userIsNull && !string.IsNullOrEmpty(tmpId))
            {
                user = _userService.FindUserByEmail(tmpId);
            }

            if (orderedProduct.AddButton != null)
            {
                if (user == null)
                {
                    user = _userService.GetOrCreateAnonymousUser();
                }

                orderedProduct.UserId = user.Id;
                _orderService.IncrementProductFromBasket(orderedProduct.ProductId,
                    _orderService.GetBasketId(user.Id));
            }

            var model = new ProductModel
            {
                CurrentProductId = productId,
                Product = _productService.FindProductById(productId),
                User = user
            };

            return View(model);
        }
    }
}