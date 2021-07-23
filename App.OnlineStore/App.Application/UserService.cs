using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using App.Domain;

namespace App.Application
{
    public class UserService
    {
        private readonly OnlineStoreDbContext _db;

        private readonly IHttpContextAccessor _contextAccessor;
        private const string TmpIdName = "tmpId";

        public UserService(OnlineStoreDbContext db, IHttpContextAccessor contextAccessor)
        {
            _db = db;
            _contextAccessor = contextAccessor;
        }

        /// <summary>
        /// Получение текущего пользователя.
        /// </summary>
        /// <returns>возвращает объект класса
        /// User с данными текущего
        /// пользователя</returns>
        public User GetCurrentUser()
        {
            var email = _contextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
            return FindUserByEmail(email);
        }

        /// <summary>
        /// Поиск пользователя по адресу
        /// электронной почты.
        /// </summary>
        /// <param name="email">адрес
        /// почты</param>
        /// <returns>возвращает объект
        /// класса User с указанной
        /// почтой</returns>
        public User FindUserByEmail(string email)
            => _db.Users.FirstOrDefault(p => p.Email == email);

        /// <summary>
        /// Поиск пользователя по
        /// идентификационному номеру
        /// (Id).
        /// </summary>
        /// <param name="userId">
        /// идентификационный номер
        /// пользователя</param>
        /// <returns>возвращает объект
        /// класса User с указанным
        /// Id</returns>
        public User FindUserById(int userId)
            => _db.Users.FirstOrDefault(p => p.Id == userId)!;

        /// <summary>
        /// Поиск пользователя по логину (почте)
        /// и паролю.
        /// </summary>
        /// <param name="email">почта</param>
        /// <param name="password">пароль</param>
        /// <returns>возвращает объект
        /// класса User с указанными почтой
        /// и паролем.</returns>
        public User FindUserByLogin(string email, string password)
            => _db.Users.FirstOrDefault(s => s.Email == email && s.Password == password)!;

        /// <summary>
        /// Создание нового авторизованного
        /// пользователя.
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="address">адрес доставки</param>
        /// <param name="email">почта</param>
        /// <param name="password">пароль</param>
        /// <param name="phone">номер телефона</param>
        /// <param name="role">роль</param>
        /// <returns>возвращает нового пользователя</returns>
        public User CreateNewUser(string name, string surname, string login,
            string address, string email, string password, string phone, ERole role)
        {
            var user = new User()
            {
                Name = name,
                Surname = surname,
                Login = login,
                Address = address,
                Email = email,
                Password = password,
                PhoneNumber = phone,
                Role = role
            };
            var entity = _db.Users.Add(user).Entity;
            _db.Orders.Add(new Order
            {
                Status = EStatus.Basket,
                User = entity
            });
            _db.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Создание и получение нового анонимного
        /// пользователя.
        /// </summary>
        /// <returns>возвращает нового
        /// анонимного пользователя</returns>
        public User GetOrCreateAnonymousUser()
        {
            var tmpIdVal = GetTmpId();

            if (!string.IsNullOrEmpty(tmpIdVal))
                return FindUserByEmail(tmpIdVal);
            tmpIdVal = GenerateTmpId();
            var user = CreateAnonymousUser(tmpIdVal);
            return user;
        }

        /// <summary>
        /// Создание нового анонимного
        /// пользователя.
        /// </summary>
        /// <param name="tmpId">временный
        /// идентификационный номер</param>
        /// <returns>возвращает нового
        /// анонимного пользователя</returns>
        private User CreateAnonymousUser(string tmpId)
        {
            var user = new User
            {
                Id = int.Parse(tmpId),
                Name = tmpId,
                Surname = tmpId,
                Address = tmpId,
                Email = tmpId,
                Password = tmpId,
                PhoneNumber = tmpId,
                Role = ERole.AnonymousBuyer
            };
            var entity = _db.Users.Add(user).Entity;
            _db.SaveChanges();
            return entity;
        }

        private string GenerateTmpId()
        {
            int tmpIdVal = (int)(DateTime.Now.Ticks % 2147483647);
            while (IdExisting(tmpIdVal))
                tmpIdVal = (int) ((long) (tmpIdVal + 1) % 2147483647);
            SetTmpId(TmpIdName, tmpIdVal.ToString(), 30);
            return tmpIdVal.ToString();
        }

        private bool IdExisting(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            return user != null;
        }

        public string GetTmpId()
            => _contextAccessor.HttpContext.Request.Cookies[TmpIdName];

        private void SetTmpId(string key, string value, int expireTime)
        {
            var option = new CookieOptions
            {
                Expires = new DateTimeOffset(DateTime.Now.AddDays(expireTime)),
                IsEssential = true
            };
            _contextAccessor.HttpContext?.Response?.Cookies.Append(key, value, option);
        }

        public void RemoveTmpId()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(TmpIdName);
        }

        /// <summary>
        /// Аутентификация пользователя по имени
        /// и адресу электронной почты.
        /// </summary>
        /// <param name="userName">имя
        /// пользователя</param>
        /// <param name="email">адрес
        /// электронной почты пользователя</param>
        /// <returns></returns>
        public async Task Authenticate(string userName, string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, userName)
            };

            var id = new ClaimsIdentity("ApplicationCookie");
            id.AddClaims(claims);
            await _contextAccessor.HttpContext?.SignInAsync
            (CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id))!;
        }

        /// <summary>
        /// Удаление пользователя.
        /// </summary>
        /// <param name="user">объект
        /// класса User, который необходимо
        /// удалить из базы данных</param>
        public void DeleteUser(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        /// <summary>
        /// Получение роли пользователя по
        /// Id.
        /// </summary>
        /// <param name="userId">Id
        /// пользователя</param>
        /// <returns>возвращает роль
        /// пользователя</returns>
        public ERole GetUserRole(int userId)
            => (_db.Users.FirstOrDefault(p => p.Id == userId))
                ?.Role ?? ERole.AnonymousBuyer;

        /// <summary>
        /// Получение всех заказов польователя.
        /// </summary>
        /// <param name="userId">идентификационный
        /// номер пользователя</param>
        /// <returns>возвращает список заказов</returns>
        public List<Order> GetOrdersHistory(int userId)
        {
            var list = (from order in _db.Orders
                where order.User.Id == userId
                select order).ToList();
            return list;
        }
    }
}