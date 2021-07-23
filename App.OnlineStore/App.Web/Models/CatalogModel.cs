using System.Collections.Generic;
using App.Domain;

namespace App.Web.Models
{
    public class CatalogModel
    {
        public List<Product> ProductList { get; set; }

        public List<Category> CategoryList { get; set; }

        public int SelectedCategoryId { get; set; }

        public string SearchString { get; set; }

        public UserNavBarModel UserNavBar { get; set; }

        public OrderedProductRequestModel OrderedProductRequest { get; set; }
    }
}