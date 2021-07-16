namespace App.Domain
{
    /// <summary>
    /// Сущность, представляющая из себя
    /// таблицу товаров в том или ином
    /// заказе.
    /// </summary>
    public class ProductsInOrder
    {
        // Идентификационный номер строчки
        // в таблице ProductsInOrder.
        public int Id { get; set; }
        
        // Заказ.
        public Order Order { get; set; }
        
        // Товар.
        public Product Product { get; set; }

        // Количество данного товара в
        // данном заказе.
        public uint NumberOfProduct { get; set; }
    }
}