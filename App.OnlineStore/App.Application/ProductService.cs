using System.Collections.Generic;
using System.Linq;
using App.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace App.Application
{
    public class ProductService
    {
        private readonly OnlineStoreDbContext _db;

        private readonly IHttpContextAccessor _contextAccessor;

        public ProductService(OnlineStoreDbContext db, IHttpContextAccessor contextAccessor)
        {
            _db = db;
            _contextAccessor = contextAccessor;
        }

        public Product FindProductById(int productId) =>
            _db.Products.FirstOrDefault(p => p.Id == productId)!;

        public void PutProductToBasket(int productId, Order basket)
        {
            var product = FindProductById(productId);
            var list1 = (from productsInOrder in _db.ProductsInOrders
                where productsInOrder.Order == basket && productsInOrder.Product == product
                select productsInOrder).ToList();
            // Если такого товара еще не встречалось в заказе.
            if (list1.Count == 0)
            {
                _db.ProductsInOrders.Add(new ProductsInOrder
                {
                    Product = product,
                    NumberOfProduct = 1,
                    Order = basket
                });
            }
            else
            {
                // Если такой товар встречался, находим его и увеличиваем
                // количество.
                var list = (from productsInOrder in _db.ProductsInOrders
                    where productsInOrder.Order == basket
                    select productsInOrder).ToList();

                foreach (var item in list.Where
                    (item => item.Product == product))
                    item.NumberOfProduct++;
            }

            _db.SaveChanges();
        }
    }
}