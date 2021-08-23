using System;
using System.Collections.Generic;
using App.Application;
using App.Domain;
using App.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;
        private readonly OrderService _orderService;

        public AdminController(UserService userService, OrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
        }

        /// <summary>
        /// TODO: Попытка была хорошей, но что-то пошло не так...
        /// Хотела сделать переключение статуса заказа покупателя
        /// через аккаунт администратора, но все сожержимое orderItemModel
        /// всегда null. Очень грустная история...
        /// </summary>
        /// <param name="orderItemModel"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        public IActionResult Index([FromForm] OrderItemModel orderItemModel)
        {
            User admin;
            try
            {
                admin = _userService.GetCurrentUser();
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Auth");
            }

            var mainModel = new ChangeUserOrderStatusModel
            {
                UserNavBar = new UserNavBarModel
                {
                    BasketCount = _orderService.CountProductsNumberInBasket(admin.Id),
                    User = admin
                }
            };

            // Собственно, в этот if программа никогда не заходит(
            if (orderItemModel?.Order != null)
            {
                _orderService.ChangeStatus(orderItemModel.Order.Id, orderItemModel.Order.Status);
            }

            mainModel.OrderHistoryList = new List<OrderHistoryModel>();
            try
            {
                var usersList = _userService.GetAllBuyersWithActiveOrders();
                foreach (var user in usersList)
                {
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
                                    User = order.User,
                                    Order = order,
                                    TotalPrice = _orderService.CountTotalPrice(order.Id),
                                    ProductsInOrders = _orderService.OrderedProductsByOrderId(order.Id)
                                });
                        }
                    }
                    catch (Exception)
                    {
                    }

                    mainModel.OrderHistoryList.Add(model);
                }
            }
            catch (Exception)
            {
            }
            return View(mainModel);
        }
    }
}