using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectory.App.Common;
using UsersDirectory.Domain.Entity;

namespace UsersDirectory.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach(var menuAction in Users)
            {
                if(menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }

        public void ExitProgram()
        {
            Environment.Exit(0);
        }

        private void Initialize()
        {
            AddUser(new MenuAction(1, "Add user", "MainMenu"));
            AddUser(new MenuAction(2, "Remove user", "MainMenu"));
            AddUser(new MenuAction(3, "Show users", "MainMenu"));
            AddUser(new MenuAction(4, "Show user by cities", "MainMenu"));
            AddUser(new MenuAction(5, "Exit", "MainMenu"));
        }
    }
}
