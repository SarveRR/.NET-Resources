using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Application.Interfaces
{
    public interface IAdminPanelService
    {
        ListUsersForListVm GetAllUsers();
    }
}
