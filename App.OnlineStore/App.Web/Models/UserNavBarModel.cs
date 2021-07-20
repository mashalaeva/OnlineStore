using App.Domain;

namespace App.Web.Models
{
    public class UserNavBarModel
    {
        public User User { get; set; }

        public int BasketCount { get; set; }
    }
}