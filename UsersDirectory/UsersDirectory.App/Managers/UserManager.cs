using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectory.App.Concrete;
using UsersDirectory.Domain.Entity;

namespace UsersDirectory.App.Managers
{
    public class UserManager
    {
        private UserService _userService;
        public UserManager()
        {
            _userService = new UserService();
        }

        public User GetUserById(int id)
        {
            var item = _userService.GetUserById(id);
            return item;
        }

        public int AddUserManager()
        {
            Console.WriteLine("Enter new user id:");
            var id = Console.ReadLine();
            int userId;
            Int32.TryParse(id, out userId);
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("City:");
            string city = Console.ReadLine();
            Console.Clear();
            int lastId = _userService.GetLastId();
            User user = new User(lastId + 1, name, surname, city);
            _userService.AddUser(user);

            return user.Id;
        }

        public int RemoveUserManager()
        {
            Console.WriteLine("Enter user id you want to remove:");
            var userId = Console.ReadKey();
            Console.Clear();
            int id;
            Int32.TryParse(userId.KeyChar.ToString(), out id);

            var user = _userService.GetUserById(id);
            _userService.RemoveUser(user);

            return id;
        }

        public int GetUserDetailsManager()
        {
            Console.WriteLine("Enter user id you want to show:");
            var userId = Console.ReadKey();
            Console.Clear();
            int id;
            Int32.TryParse(userId.KeyChar.ToString(), out id);

            var user = _userService.GetUserById(id);
            _userService.GetUserDetails(user);

            return id;
        }

        public int GetUserByCityManager()
        {
            Console.WriteLine("Enter user id you want to show:");
            var userId = Console.ReadKey();
            Console.Clear();
            int id;
            Int32.TryParse(userId.KeyChar.ToString(), out id);

            var user = _userService.GetUserById(id);
            _userService.GetUserDetails(user);

            return id;
        }
    }
}
