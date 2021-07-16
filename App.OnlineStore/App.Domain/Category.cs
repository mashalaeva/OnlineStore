namespace App.Domain
{
    /// <summary>
    /// Сущность, представляющая из себя
    /// категорию, к которой относится тот
    /// или иной товар.
    /// </summary>
    public class Category
    {
        // Идентификационный номер категории.
        public int Id { get; set; }

        // Наименование категории товаров.
        public string Name { get; set; }

        // Краткое описание категории товаров.
        public string Description { get; set; }

        // Родительская категория товара.
        public Category Parent { get; set; }
    }
}