using System.Collections.Generic;
using App.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Web.Models
{
    public class ProductModel
    {
        public int CurrentProductId { get; set; }
        
        public Product Product { get; set; }

        public List<PropertyValues> PropertyValuesList { get; set; }

        public UserNavBarModel UserNavBar { get; set; }
    }
}