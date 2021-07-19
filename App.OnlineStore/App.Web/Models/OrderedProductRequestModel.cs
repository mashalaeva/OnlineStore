namespace App.Web.Models
{
    public class OrderedProductRequestModel
    {
        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int UserId { get; set; }

        public int ProductCount { get; set; }

        public string AddButton { get; set; }

        public string RemoveButton { get; set; }

        public string RemoveAllButton { get; set; }

        public int OrderId { get; set; }
    }
}