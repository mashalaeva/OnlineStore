using System.ComponentModel.DataAnnotations;
using App.Domain;

namespace App.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [Display(Name ="Адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public UserNavBarModel UserNavBar { get; set; }
    }
}