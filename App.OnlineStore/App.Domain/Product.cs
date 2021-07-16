namespace App.Domain
{
    /// <summary>
    /// Сущность, представляющая из себя товар.
    /// </summary>
    public class Product
    {
        // Идентификационный  номер товара.
        public int Id { get; set; }

        // Наименование товара.
        public string Name { get; set; }

        // Объект класса Category,
        // соответсвующий категории
        // текущего товара.
        public Category Category { get; set; }

        // Объект класса Manufacturer,
        // соответсвующий текущему товару.
        public Manufacturer Manufacturer { get; set; }
        
        // Описание товара.
        public string Description { get; set; }
        
        // Модель товара.
        public string Model { get; set; }
        
        // Цена товара.
        public double Price { get; set; }
        
        // Наличие товара на складе.
        public bool Availability { get; set; }
        
        // Ссылка на фото товара.
        public string PictureReference { get; set; }
    }
}