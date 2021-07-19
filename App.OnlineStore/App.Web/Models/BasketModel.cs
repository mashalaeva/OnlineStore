using System.Collections.Generic;
using App.Domain;

namespace App.Web.Models
{
    public class BasketModel
    {
        public List<ProductsInOrder> ProductsInOrder { get; set; }

        public Order Basket { get; set; }

        public User User { get; set; }

        public int ProductsInBasketCount { get; set; }

        public string PurchaseMessage { get; set; }
    }
}