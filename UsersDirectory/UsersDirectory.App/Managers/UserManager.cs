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

        public int AddUserManager(int lastId = 0, string name = "Name", string surName = "SurName", string city = "City")
        {
            Console.WriteLine("Name:");
            name = Console.ReadLine();
            Console.WriteLine("Surname:");
            surName = Console.ReadLine();
            Console.WriteLine("City:");
            city = Console.ReadLine();
            Console.Clear();
            lastId = _userService.GetLastId();
            User user = new User(lastId+1, name, surName, city);
            _userService.AddUser(user);

            return user.Id;
        }

        public int RemoveUserManager(int userId = 0)
        {
            Console.WriteLine("Enter user id you want to remove:");
            var id = Console.ReadLine();
            Int32.TryParse(id, out userId);
            Console.Clear();

            var user = _userService.GetUserById(userId);
            _userService.RemoveUser(user);

            return userId;
        }

        public int GetUserDetailsManager(int userId = 0)
        {
            Console.WriteLine("Enter user id you want to show:");
            var id = Console.ReadLine();
            Int32.TryParse(id, out userId);
            Console.Clear();

            var user = _userService.GetUserById(userId);
            _userService.GetUserDetails(user);

            return userId;
        }

        public string GetUserByCityManager(string cityName = "City")
        {
            Console.WriteLine("Enter city for users you want to show:");
            cityName = Console.ReadLine();
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

        public void UpdateUserManager(int userId = 0, string name = "Name", string surName = "SurName", string city = "City")
        {
            Console.WriteLine("Enter user id to edit:");
            var id = Console.ReadLine();
            Int32.TryParse(id, out userId);
            Console.WriteLine("New name:");
            name = Console.ReadLine();
            Console.WriteLine("New surname:");
            surName = Console.ReadLine();
            Console.WriteLine("New city:");
            city = Console.ReadLine();
            Console.Clear();
            User user = new User(userId, name, surName, city);

            _userService.UpdateUser(user);
        }
    }
}
