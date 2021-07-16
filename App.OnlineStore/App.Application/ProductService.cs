using System.Linq;
using App.Domain;
using Microsoft.AspNetCore.Http;

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

        public Product FindProductById(int productId)
        {
            return _db.Products.FirstOrDefault(p => p.Id == productId)!;
        }

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

        public void DeleteProductFromBasket(int productId, Order basket)
        {
            Product product = FindProductById(productId);

            var productInOrder = (from productsInOrder in _db.ProductsInOrders
                where productsInOrder.Order == basket && productsInOrder.Product == product
                select productsInOrder).FirstOrDefault();

            // Если такого товара еще не встречалось в заказе.
            if (productInOrder == null)
                return;

            // Если такой товар встречался, находим его и удаляем.
            _db.ProductsInOrders.Remove(productInOrder);
            _db.SaveChanges();
        }

        public void DecrementProductFromBasket(int productId, Order basket)
        {
            Product product = FindProductById(productId);

            var productInOrder = (from productsInOrder in _db.ProductsInOrders
                where productsInOrder.Order == basket && productsInOrder.Product == product
                select productsInOrder).FirstOrDefault();

            // Если такого товара еще не встречалось в заказе.
            if (productInOrder == null)
                return;

            // Если такой товар встречался, уменьшаем его
            // количество.
            productInOrder.NumberOfProduct--;
            _db.ProductsInOrders.Update(productInOrder);

            if (productInOrder.NumberOfProduct <= 0)
            {
                _db.ProductsInOrders.Remove(productInOrder);
            }

            _db.SaveChanges();
        }

        public void IncrementProductFromBasket(int productId, Order basket)
        {
            Product product = FindProductById(productId);

            var productInOrder = (from productsInOrder in _db.ProductsInOrders
                where productsInOrder.Order == basket && productsInOrder.Product == product
                select productsInOrder).FirstOrDefault();

            // Если такого товара еще не встречалось в заказе.
            if (productInOrder == null)
            {
                _db.ProductsInOrders.Add(new ProductsInOrder
                {
                    Product = _db.Products.FirstOrDefault(p => p.Id == productId),
                    NumberOfProduct = 1,
                    Order = basket
                });
                return;
            }

            // Если такой товар встречался, уменьшаем его
            // количество.
            productInOrder.NumberOfProduct++;

            _db.ProductsInOrders.Update(productInOrder);
            _db.SaveChanges();
        }
    }
}