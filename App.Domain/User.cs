namespace App.Domain
{
    /// <summary>
    /// Сущность, представляющая из себя
    /// пользователя.
    /// </summary>
    public class User
    {
        // Идентификационный номер пользователя.
        public int Id { get; set; }

        // Имя пользователя.
        public string Name { get; set; }

        // Фамилия пользователя.
        public string Surname { get; set; }
        
        // Номер телефона пользователя.
        public string PhoneNumber { get; set; }
        
        // Почта (логин) покупателя.
        public string Email { get; set; }
        
        // Пароль покупателя.
        public string Password { get; set; }
        
        // Роль пользователя: покупатель или администратор.
        public ERole Role { get; set; }
        
        // Адрес покупателя.
        public string Address { get; set; }
    }
}