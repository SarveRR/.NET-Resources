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
            var lastId = _userService.GetLastId();
            User user = new User(lastId+1, name, surname, city);
            _userService.AddUser(user);

            return user.Id;
        }

        public int RemoveUserManager()
        {
            Console.WriteLine("Enter user id you want to remove:");
            var id = Console.ReadLine();
            int userId;
            Int32.TryParse(id, out userId);
            Console.Clear();

            var user = _userService.GetUserById(userId);
            _userService.RemoveUser(user);

            return userId;
        }

        public int GetUserDetailsManager()
        {
            Console.WriteLine("Enter user id you want to show:");
            var id = Console.ReadLine();
            int userId;
            Int32.TryParse(id, out userId);
            Console.Clear();

            var user = _userService.GetUserById(userId);
            _userService.GetUserDetails(user);

            return userId;
        }

        public string GetUserByCityManager()
        {
            Console.WriteLine("Enter city for users you want to show:");
            string cityName = Console.ReadLine();
            Console.Clear();

            User newUser;
            List<User> usersToShow = new List<User>();

            foreach (var user in _userService.Users)
            {
                if (cityName == user.City)
                {
                    newUser = new User(user.Id, user.Name, user.SurName, user.City);
                    usersToShow.Add(newUser);
                }
            }
            _userService.GetUserByCity(usersToShow);

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
