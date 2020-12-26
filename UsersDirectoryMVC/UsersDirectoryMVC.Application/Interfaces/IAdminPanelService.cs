using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.ViewModels.AdminPanel;

namespace UsersDirectoryMVC.Application.Interfaces
{
    public interface IAdminPanelService
    {
        ListUsersForListVm GetAllUsers();
    }
}
