using System;
using UsersDirectory.App.Concrete;
using UsersDirectory.App.Managers;

namespace UsersDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            UserManager userManager = new UserManager();

            while (true)
            {
                Console.WriteLine("USERS DIRECTORY");
                Console.WriteLine("Choose option:");

                var mainMenu = actionService.GetMenuActionsByMenuName("MainMenu");
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine(mainMenu[i].Id + " " + mainMenu[i].Name);
                }

                var opertion = Console.ReadKey();
                Console.Clear();

                switch (opertion.KeyChar)
                {
                    case '1':
                        var newId = userManager.AddUserManager();
                        break;
                    case '2':
                        var removeId = userManager.RemoveUserManager();
                        break;
                    case '3':
                        var detailId = userService.UserDetailSelectionView();
                        userService.UserDetailView(detailId);
                        break;
                    case '4':
                        var cityName = userService.UserByCitySelectionView();
                        userService.UserByCityView(cityName);
                        break;
                    case '5':
                        actionService.ExitProgram();
                        break;
                    default:
                        Console.WriteLine("Wrong option");
                        Console.WriteLine("\nPress any key to back to menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
