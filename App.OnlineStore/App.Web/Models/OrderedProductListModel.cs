using System.Collections.Generic;
using App.Domain;

namespace App.Web.Models
{
    public class OrderedProductListModel
    {
        public List<ProductsInOrder> ProductsInOrders { get; set; }

        public string PostActionURL { get; set; }

        public int UserId { get; set; }
    }
}