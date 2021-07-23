using System.ComponentModel.DataAnnotations;
using App.Domain;

namespace App.Web.Models
{
    public class CreateAccountRequestModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана Фамилия")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Фамилия")]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Не указан email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан адрес")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Адрес доставки")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Не указан номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public UserNavBarModel UserNavBar { get; set; }

    }
}