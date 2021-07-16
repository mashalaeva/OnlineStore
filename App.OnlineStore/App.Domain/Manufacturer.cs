 namespace App.Domain
{
    /// <summary>
    /// Сущность, представляющая из себя
    /// произовдителя товара.
    /// </summary>
    public class Manufacturer
    {
        // Идентификационный  номер производителя.
        public int Id { get; set; }

        // Наименование производителя.
        public string Name { get; set; }

        // Страна происхождения товара.
        public string Country { get; set; }

        // Main State Registration Number —
        // Основной Государственный
        // Регистрационный Номер.
        public string MSRN { get; set; }
    }
}