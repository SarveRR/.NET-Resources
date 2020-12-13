using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Infrastructure.Repositories
{
    public class AppUserRepository
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
            _context.AppUsers.Add(appUser);
            _context.SaveChanges();
            return appUser.Id;
        }

        public IQueryable<AppUser> GetAppUserByPositionId(int positionId)
        {
            var appUsers = _context.AppUsers.Where(a => a.PositionId == positionId);
            return appUsers;
        }

        public AppUser GetAppUserById(int appUserId)
        {
            var appUser = _context.AppUsers.FirstOrDefault(a => a.Id == appUserId);
            return appUser;
        }

        public IQueryable<Tag> GetAllTags()
        {
            var tags = _context.Tags;
            return tags;
        }

        public IQueryable<AppUser> GetAllAppUsers()
        {
            var appUsers = _context.AppUsers;
            return appUsers;
        }

        public IQueryable<Position> GetAllPositions()
        {
            var positions = _context.Positions;
            return positions;
        }
    }
}