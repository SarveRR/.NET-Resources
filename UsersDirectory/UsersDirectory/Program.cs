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
        }

        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add user", "Main");
            actionService.AddNewAction(2, "Remove user", "Main");
            actionService.AddNewAction(3, "Show cities", "Main");
            actionService.AddNewAction(4, "Show user", "Main");
            return actionService;
        }
    }
}
