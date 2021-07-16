namespace App.Domain
{
    /// <summary>
    /// Сущность, представляющая из себя
    /// заказ, оформленный покупателем.
    /// </summary>
    public class Order
    {
        // Идентификационный номер заказа.
        public int Id { get; set; }

        // Пользователь, к которому
        // привязана данная корзина.
        public User User { get; set; }

        // Статус заказа.
        public EStatus Status { get; set; }
    }
}