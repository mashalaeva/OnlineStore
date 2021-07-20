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
            => (from productInOrder in _db.ProductsInOrders
                where productInOrder.Order.Id == orderId
                orderby productInOrder.Product.Name
                select productInOrder).ToList();

        public List<ProductsInOrder> OrderedProductsInBasketByUser(int userId)
            => OrderedProductsByOrderId(GetBasketId(userId));

        public int GetBasketId(int userId)
            => GetBasket(userId).Id;

        public Order GetBasket(int userId) =>
            _db.Orders.FirstOrDefault(p => p.User.Id == userId)!;

        public void ChangeStatus(int orderId, EStatus newStatus)
        {
            var order = _db.Orders.FirstOrDefault(p => p.Id.Equals(orderId));
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

        public void IncrementProductFromBasket(int productId, int basketId)
        {
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
                return;
            }

            // Если такой товар встречался, уменьшаем его
            // количество.
            productInOrder.NumberOfProduct++;

            _db.ProductsInOrders.Update(productInOrder);
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