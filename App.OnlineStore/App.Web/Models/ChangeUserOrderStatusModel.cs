using System.Collections.Generic;
using App.Domain;

namespace App.Web.Models
{
    public class ChangeUserOrderStatusModel
    {
        public UserNavBarModel UserNavBar { get; set; }

        public List<OrderHistoryModel> OrderHistoryList { get; set; }
    }
}