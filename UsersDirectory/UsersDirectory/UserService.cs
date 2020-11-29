using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectory
{
    public class UserService
    {
        public List<User> Users { get; set; }
        public UserService()
        {
            Users = new List<User>();
        }

        public ConsoleKeyInfo AddNewUserView(MenuActionService actionService)
        {
            var addNewUserMenu = actionService.GetMenuActionsByMenuName("AddNewUserMenu");
            Console.WriteLine("Choose city:");
            for (int i = 0; i < addNewUserMenu.Count; i++)
            {
                Console.WriteLine(addNewUserMenu[i].Id + " " + addNewUserMenu[i].Name);
            }
            var opertion = Console.ReadKey();
            return opertion;
        }

        public int AddNewUser(char userType)
        {
            int cityId;
            Int32.TryParse(userType.ToString(), out cityId);
            User user = new User();
            user.CityId = cityId;
            Console.WriteLine("Enter new user id:");
            var id = Console.ReadKey();
            int userId;
            Int32.TryParse(id.ToString(), out userId);
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Surname:");
            string surname = Console.ReadLine();

            user.Id = userId;
            user.Name = name;
            user.SurName = surname;

            Users.Add(user);
            return userId;
        }
    }
}
