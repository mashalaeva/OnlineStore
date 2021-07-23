using System;
using App.Domain;
using System.Collections.Generic;
using System.Linq;

namespace App.Application
{
    public class OrderService
    {
        private readonly OnlineStoreDbContext _db;

        public OrderService(OnlineStoreDbContext db)
        {
            _db = db;
        }

        public List<Order> GetOrderListByUserId(int userId, int status)
            => (from order in _db.Orders
                where order.User.Id == userId &&
                      (int) order.Status == status
                select order).ToList();

        public List<Product> GetProductsFromOrder(int orderId)
            => (from productsInOrder in _db.ProductsInOrders
                where productsInOrder.Order.Id == orderId
                select productsInOrder.Product).ToList();

        public List<ProductsInOrder> OrderedProductsByOrderId(int orderId)
        {
            var list = (from productInOrder in _db.ProductsInOrders
                where productInOrder.Order.Id == orderId
                select productInOrder).ToList();
            foreach (var l in list)
            {
                var a = l.Id;
                var b = l.Order;
                var c = l.Product;
                var d = l.NumberOfProduct;
            }
            return list;
        }

        public List<ProductsInOrder> OrderedProductsInBasketByUser(int userId)
            => OrderedProductsByOrderId(GetBasketId(userId));

        public int GetBasketId(int userId)
        {
            var order = GetBasket(userId);
            return order == null ? CreateBasket(userId) : order.Id;
        }

        public Order GetBasket(int userId)
            => _db.Orders.FirstOrDefault(p => p.User.Id == userId)!;

        public int CreateBasket(int userId)
        {
            Order basket = new Order
            {
                User = _db.Users.FirstOrDefault(u => u.Id == userId),
                Status = EStatus.Basket
            };
            _db.Orders.Add(basket);
            _db.SaveChanges();
            return basket.Id;
        }

        public void ChangeStatus(int orderId, EStatus newStatus)
        {
            var order = _db.Orders.FirstOrDefault(p => p.Id == orderId);
            if (order == null)
                return;
            order.Status = newStatus;
            _db.Orders.Update(order);

            // Если статус заказа сменился с "корзины"
            // на "принят", то создаем пользователю
            // новую корзину.
            if (newStatus == EStatus.Accepted)
            {
                _db.Orders.Add(new Order
                {
                    Status = EStatus.Basket,
                    User = order.User
                });
            }

            _db.SaveChanges();
        }

        public void DeleteProductFromBasket(int productId, int basketId)
        {
            Product product = _db.Products.FirstOrDefault(p => p.Id == productId)!;

            var productInOrder = (from productsInOrder in _db.ProductsInOrders
                where productsInOrder.Order.Id == basketId && productsInOrder.Product == product
                select productsInOrder).FirstOrDefault();

            // Если такого товара еще не встречалось в заказе.
            if (productInOrder == null)
                return;

            // Если такой товар встречался, находим его и удаляем.
            _db.ProductsInOrders.Remove(productInOrder);
            _db.SaveChanges();
        }

        public void DecrementProductFromBasket(int productId, int basketId)
        {
            Product product = _db.Products.FirstOrDefault(p => p.Id == productId)!;

            var productInOrder = (from productsInOrder in _db.ProductsInOrders
                where productsInOrder.Order.Id == basketId && productsInOrder.Product == product
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

        public void IncrementProductFromBasket(int productId, int basketId, int userId)
        {
            if (_db.Orders.FirstOrDefault(b => b.Id == basketId) == null)
                CreateBasket(userId);
            Product product = _db.Products.FirstOrDefault(p => p.Id == productId)!;

            var productInOrder = (from productsInOrder in _db.ProductsInOrders
                where productsInOrder.Order.Id == basketId && productsInOrder.Product == product
                select productsInOrder).FirstOrDefault();

            // Если такого товара еще не встречалось в заказе.
            if (productInOrder == null)
            {
                _db.ProductsInOrders.Add(new ProductsInOrder
                {
                    Product = _db.Products.FirstOrDefault(p => p.Id == productId),
                    NumberOfProduct = 1,
                    Order = _db.Orders.FirstOrDefault(p => p.Id == basketId)
                });
            }
            else
            {
                // Если такой товар встречался, увеличиваем его
                // количество.
                productInOrder.NumberOfProduct++;

                _db.ProductsInOrders.Update(productInOrder);
            }

            _db.SaveChanges();
        }

        public int CountProductsNumberInBasket(int userId)
        {
            var orderId = GetBasketId(userId);
            return Decimal.ToInt32(
                (from pio in _db.ProductsInOrders
                    where pio.Order.Id == orderId
                    select pio)
                .Sum(p => p.NumberOfProduct));
        }

        public double CountTotalPrice(int userId)
        {
            var orderId = GetBasketId(userId);
            return (from pio in _db.ProductsInOrders
                where pio.Order.Id == orderId
                select pio).Sum(p => p.Product.Price);
        }
    }
}