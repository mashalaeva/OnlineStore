﻿using System.Collections.Generic;

namespace App.Web.Models
{
    public class OrderHistoryModel
    {
        public UserNavBarModel UserNavBar { get; set; }

        public List<OrderItemModel> OrderList { get; set; }
    }
}