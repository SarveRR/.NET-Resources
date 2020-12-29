using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersDirectoryMVC.Application.ViewModels.AdminPanel;

namespace UsersDirectoryMVC.Application.Interfaces
{
    public interface IAdminPanelService
    {
        ListUsersForListVm GetAllUsers();
        IQueryable<RoleVm> GetAllRoles();
        Task<IdentityResult> DeleteUser(string id);
        UserDetailVm GetUserDetails(string id);
        UserDetailVm GetUserRoles(string id);
        Task<IdentityResult> ChangeUserRolesAsync(string idUser, IEnumerable<string> roles);
        void RemoveRoleFromUser(string id, string roles);
        IQueryable<string> GetRolesByUser(string id);
    }
}
