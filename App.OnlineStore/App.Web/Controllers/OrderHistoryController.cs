using System;
using System.Collections.Generic;
using App.Application;
using App.Domain;
using App.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    [Authorize]
    public class OrderHistoryController : Controller
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public OrderHistoryController(UserService userService, OrderService orderService)
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

            var model = new OrderHistoryModel
            {
                UserNavBar = new UserNavBarModel
                {
                    BasketCount = 0,
                    User = user
                }
            };

            try
            {
                var orderList = _orderService.GetOrderListByUserId(user.Id, 2);
                model.OrderList = new List<OrderItemModel>();

                foreach (var order in orderList)
                {
                    model.OrderList.Add(
                        new OrderItemModel
                        {
                            Order = order,
                            TotalPrice = _orderService.CountTotalPrice(order.Id),
                            ProductsInOrders = _orderService.OrderedProductsByOrderId(order.Id)
                        });
                }
            }
            catch (Exception)
            {
            }

            return View(model);
        }
    }
}