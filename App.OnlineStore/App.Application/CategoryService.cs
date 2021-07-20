using System.Collections.Generic;
using System.Linq;
using App.Domain;
using Microsoft.AspNetCore.Http;

namespace App.Application
{
    public class CategoryService
    {
        private readonly OnlineStoreDbContext _db;

       // private readonly IHttpContextAccessor _contextAccessor;

        public CategoryService(OnlineStoreDbContext db)
        {
            _db = db;
        }

        public Category FindNecessaryCategoryById(int categoryId)
            => _db.Categories.FirstOrDefault(p => p.Id == categoryId)!;

        public Category FindParentCategory(int categoryId)
            => FindParentCategory(FindNecessaryCategoryById(categoryId));

        public Category FindParentCategory(Category category)
            => category.Parent;

        public List<Category> FindSubcategories(int categoryId)
            => FindSubcategories(FindNecessaryCategoryById(categoryId));

        public List<Category> FindSubcategories(Category category)
            => _db.Categories.Where(c =>
                c.Parent != null && c.Parent.Id.Equals(category.Id)
            ).ToList();

        public List<Product> GetCategoryProducts(int categoryId)
            => (from product in _db.Products
                where product.Category.Id.Equals(categoryId)
                select product).ToList();
    }
}