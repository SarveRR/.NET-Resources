using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectory.App.Common;

namespace UsersDirectory.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach(var menuAction in menuActions)
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
    }
}
