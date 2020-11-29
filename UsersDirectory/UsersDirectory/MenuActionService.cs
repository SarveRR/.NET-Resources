using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectory
{
    public class MenuActionService
    {
        private List<MenuAction> menuActions;

        public void AddNewAction(int id, string name, string menuName)
        {
            MenuAction menuAction = new MenuAction() { Id = id, Name = name, MenuName = menuName };
            menuActions.Add(menuAction);
        }

        
    }
}
