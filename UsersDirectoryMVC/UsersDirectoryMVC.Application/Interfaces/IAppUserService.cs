using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.ViewModels.AppUser;

namespace UsersDirectoryMVC.Application.Interfaces
{
    public interface IAppUserService
    {
        ListAppUserForListVm GetAllActiveAppUsersForList(int pageSize, int pageNumber, string searchString);
        int AddAppUser(NewAppUserVm appUser);
        AppUserDetailsVm GetAppUserDetails(int id);
        NewAppUserVm GetAppUserForEdit(int id);
        void UpdateAppUser(NewAppUserVm model);
        void DeleteAppUser(int id);
    }
}
