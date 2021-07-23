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

            if (orderedProduct.ProductId > 0)
            {
                _orderService.IncrementProductFromBasket(orderedProduct.ProductId,
                    _orderService.GetBasketId(user.Id), user.Id);
            }

            var model = new CatalogModel
            {
                SelectedCategoryId = categoryId ?? 0,
                CategoryList = categoryId == null || categoryId <= 0 ? _categoryService.FindAllParentsCategories() 
                    : _categoryService.FindSubcategories((int)categoryId),
                ProductList = _categoryService.GetCategoryProducts(categoryId ?? 0),
                SearchString = searchString,
                UserNavBar = new UserNavBarModel
                {
                    BasketCount = user == null ? 0 : _orderService.CountProductsNumberInBasket(user.Id),
                    User = user
                }
            };
            return View(model);
        }
    }
}