using System.Collections.Generic;
using App.Domain;

namespace App.Web.Models
{
    public class OrderHistoryModel
    {
        public User User { get; set; }
        
        public List<OrderItem> OrderList { get; set; }

        public class OrderItem
        {
            public Order Order { get; set; }
            
            public double TotalPrice { get; set; }

            public List<ProductsInOrder> ProductsInOrders { get; set; }
        }
    }
}