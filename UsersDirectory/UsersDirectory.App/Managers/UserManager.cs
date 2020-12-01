using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectory.App.Abstract;
using UsersDirectory.App.Concrete;
using UsersDirectory.Domain.Entity;

namespace UsersDirectory.App.Managers
{
    public class UserManager
    {
        private readonly MenuActionService _actionService;
        private IService<User> _userService;
        public UserManager(MenuActionService actionService, IService<User> userService)
        {
            _userService = userService;
            _actionService = actionService;
        }

        public User GetUserById(int id)
        {
            var item = _userService.GetUserById(id);
            return item;
        }

        public int AddUserManager()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("City:");
            string city = Console.ReadLine();
            Console.Clear();
            int lastId = _userService.GetLastId();
            lastId++;
            User user = new User(lastId, name, surname, city);
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

        public string GetUserByCityManager()
        {
            Console.WriteLine("Enter city for users you want to show:");
            string cityName = Console.ReadLine();
            Console.Clear();
            _userService.GetUserByCity(cityName);

            return cityName;
        }

        public void GetAllUsersManager()
        {
            _userService.GetAllUsers();
        }

        public void UpdateUserManager()
        {
            Console.WriteLine("Enter user id to edit:");
            var id = Console.ReadLine();
            int userId;
            Int32.TryParse(id, out userId);
            Console.WriteLine("New name:");
            string name = Console.ReadLine();
            Console.WriteLine("New surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("New city:");
            string city = Console.ReadLine();
            Console.Clear();
            User user = new User(userId, name, surname, city);

            _userService.UpdateUser(user);
        }
    }
}
