using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsersDirectoryMVC.Application.ViewModels.AdminPanel;

namespace UsersDirectoryMVC.Application.Interfaces
{
    public interface IAdminPanelService
    {
        ListUsersForListVm GetAllUsers();
        Task<IdentityResult> DeleteUser(string id);  
    }
}
