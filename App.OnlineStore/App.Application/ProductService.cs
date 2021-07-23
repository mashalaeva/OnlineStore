using System.Linq;
using App.Domain;

namespace App.Application
{
    public class ProductService
    {
        private readonly OnlineStoreDbContext _db;

        public ProductService(OnlineStoreDbContext db)
        {
            _db = db;
        }

        public Product FindProductById(int productId)
            => _db.Products.FirstOrDefault(p => p.Id == productId);
    }
}