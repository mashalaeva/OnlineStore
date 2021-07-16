using App.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Application
{
    public class OrderService
    {
        private readonly OnlineStoreDbContext _db;

        private readonly IHttpContextAccessor _contextAccessor;

        public OrderService(OnlineStoreDbContext db, IHttpContextAccessor contextAccessor)
        {
            _db = db;
            _contextAccessor = contextAccessor;
        }

        public List<Product> GetProductsFromOrder(int orderId)
            => (from productsInOrder in _db.ProductsInOrders
                where productsInOrder.Order.Id == orderId
                select productsInOrder.Product).ToList();

        public void ChangeStatus(int orderId, EStatus newStatus)
            => _db.Orders.FirstOrDefault(p => p.Id.Equals(orderId))!.Status = newStatus;
    }
}