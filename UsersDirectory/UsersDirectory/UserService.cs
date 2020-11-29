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
    }
}
