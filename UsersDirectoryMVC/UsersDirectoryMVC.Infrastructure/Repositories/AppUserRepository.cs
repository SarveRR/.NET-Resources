using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Infrastructure.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;
        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public void DeleteAppUser(int appUserId)
        {
            var appUser = _context.AppUsers.Find(appUserId);
            if(appUser != null)
            {
                _context.AppUsers.Remove(appUser);
                _context.SaveChanges();
            }
        }

        public int AddAppUser(AppUser appUser)
        {
            appUser.PositionId = 1;
            _context.AppUsers.Add(appUser);
            _context.SaveChanges();
            return appUser.Id;
        }

        public IQueryable<AppUser> GetAppUserByPositionId(int positionId)
        {
            var appUsers = _context.AppUsers.Where(a => a.PositionId == positionId);
            return appUsers;
        }

        public AppUser GetAppUser(int appUserId)
        {
            var appUser = _context.AppUsers.FirstOrDefault(a => a.Id == appUserId);
            return appUser;
        }

        public IQueryable<Tag> GetAllTags()
        {
            var tags = _context.Tags;
            return tags;
        }

        public IQueryable<AppUser> GetAllActiveAppUsers()
        {
            var appUsers = _context.AppUsers;
            return appUsers;
        }

        public IQueryable<Position> GetAllPositions()
        {
            var positions = _context.Positions;
            return positions;
        }

        public void UpdateAppUser(AppUser appUser)
        {
            _context.Attach(appUser);
            _context.Entry(appUser).Property("FirstName").IsModified = true;
            _context.Entry(appUser).Property("LastName").IsModified = true;
            _context.Entry(appUser).Property("City").IsModified = true;
            _context.SaveChanges();
        }

        public string GetAppUserPositionName(int id)
        {
            var appUserPositionName = _context.Positions.FirstOrDefault(a => a.Id == id).Name.ToString();
            return appUserPositionName;
        }
    }
}