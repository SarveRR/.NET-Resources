using System;

namespace UsersDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            Initialize(actionService);

            Console.WriteLine("USERS DIRECTORY");
            Console.WriteLine("Choose option:");

            var mainMenu = actionService.GetMenuActionsByMenuName("MainMenu");
            for(int i = 0; i < mainMenu.Count; i++)
            {
                Console.WriteLine(mainMenu[i].Id+" "+ mainMenu[i].Name);
            }

            var opertion = Console.ReadKey();
            UserService userService = new UserService();
            switch(opertion.KeyChar)
            {
                case '1':
                    var keyInfo = userService.AddNewUserView(actionService);
                    var id = userService.AddNewUser(keyInfo.KeyChar);
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '5':
                    break;
                default:
                    Console.WriteLine("Wrong option");
                    break;
            }
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add user", "MainMenu");
            actionService.AddNewAction(2, "Remove user", "MainMenu");
            actionService.AddNewAction(3, "Show cities", "MainMenu");
            actionService.AddNewAction(4, "Show user", "MainMenu");
            actionService.AddNewAction(5, "Exit", "MainMenu");

            actionService.AddNewAction(1, "Cracow", "AddNewUserMenu");
            actionService.AddNewAction(2, "Warsaw", "AddNewUserMenu");
            actionService.AddNewAction(3, "Wroclaw", "AddNewUserMenu");
            actionService.AddNewAction(4, "Gdansk", "AddNewUserMenu");
            return actionService;
        }
    }
}
