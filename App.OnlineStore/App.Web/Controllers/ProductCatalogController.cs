using System;
using App.Application;
using App.Domain;
using App.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Route("")]
    [Route("{controller}")]
    [AllowAnonymous]
    public class ProductCatalogController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public ProductCatalogController(CategoryService categoryService, UserService userService,
            OrderService orderService)
        {
            _categoryService = categoryService;
            _userService = userService;
            _orderService = orderService;
        }

        [HttpGet("{categoryId?}")]
        [HttpPost("{categoryId?}")]
        public IActionResult Index(int? categoryId, string searchString,
            [FromForm] OrderedProductRequestModel orderedProduct)
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

            if (orderedProduct.ProductId > 0)
            {
                user ??= _userService.GetOrCreateAnonymousUser();

                _orderService.IncrementProductFromBasket(orderedProduct.ProductId,
                    _orderService.GetBasketId(user.Id));
            }


            var model = new CatalogModel
            {
                SelectedCategoryId = categoryId ?? 0,
                CategoryList = _categoryService.FindSubcategories(categoryId ?? 0),
                ProductList = _categoryService.GetCategoryProducts(categoryId ?? 0),
                SearchString = searchString,
                User = user
            };
            return View(model);
        }
    }
}