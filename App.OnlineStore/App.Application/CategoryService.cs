using System.Collections.Generic;
using System.Linq;
using App.Domain;
using Microsoft.AspNetCore.Http;

namespace App.Application
{
    public class CategoryService
    {
        private readonly OnlineStoreDbContext _db;

        private readonly IHttpContextAccessor _contextAccessor;

        public CategoryService(OnlineStoreDbContext db, IHttpContextAccessor contextAccessor)
        {
            _db = db;
            _contextAccessor = contextAccessor;
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
        {
            if (category == null)
                return new List<Category>();
            return _db.Categories.Where(c =>
                c != null && c.Parent != null && c.Parent.Id == category.Id
            ).ToList();
        }

        public List<Product> GetCategoryProducts(int categoryId)
        {
            var res = (from product in _db.Products
                where categoryId == 0 || product.Category.Id == categoryId ||
                      FindSubcategories(categoryId).Contains(product.Category)
                select product).ToList();
            return res;
        }

        public List<Category> FindAllParentsCategories()
            => _db.Categories.Where(c => c.Parent == null).ToList();
    }
}