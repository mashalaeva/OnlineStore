using System.Collections.Generic;
using App.Domain;

namespace App.Web.Models
{
    public class ProductListModel
    {
        public List<Product> Products{ get; set; }
        
        public List<ProductsInOrder> ProductsInOrders { get; set; }

        public string PostActionURL { get; set; }

        public int SelectedCategoryId { get; set; }

        public int UserId { get; set; }
    }
}