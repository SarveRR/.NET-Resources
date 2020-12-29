using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Domain.Interfaces
{
    public interface IAppUserRepository
    {
        void DeleteAppUser(int appUserId);

        int AddAppUser(AppUser appUser);

        IQueryable<AppUser> GetAppUserByPositionId(int positionId);

        AppUser GetAppUser(int appUserId);

        IQueryable<AppUser> GetAllActiveAppUsers();

        IQueryable<Position> GetAllPositions();

        void UpdateAppUser(AppUser appUser);

        string GetAppUserPositionName(int id);
    }
}
