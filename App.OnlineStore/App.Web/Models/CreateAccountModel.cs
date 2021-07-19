using App.Domain;

namespace App.Web.Models
{
    public class CreateAccountModel
    {
        public User User { get; set; }

        public string OkButton { get; set; }

        public CreateAccountRequestModel AccountRequest { get; set; }
    }
}