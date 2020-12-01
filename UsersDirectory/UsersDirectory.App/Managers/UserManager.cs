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

        public int AddNewUser()
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
    }
}
