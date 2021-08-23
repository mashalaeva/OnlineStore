using System.Collections.Generic;
using App.Domain;

namespace App.Web.Models
{
    public class OrderItemModel
    {
        public User User { get; set; }

        public Order Order { get; set; }

        public double TotalPrice { get; set; }

        public List<ProductsInOrder> ProductsInOrders { get; set; }
    }
}