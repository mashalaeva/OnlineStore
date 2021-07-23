using App.Domain;

namespace App.Web.Models
{
    public class CreateAccountModel
    {
        public UserNavBarModel UserNavBar { get; set; }

        public string OkButton { get; set; }

        public CreateAccountRequestModel AccountRequest { get; set; }
    }
}