using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.AdminPanel;

namespace UsersDirectoryMVC.Application.Services
{
    public class AdminPanelService : IAdminPanelService
    {
        private readonly UserManager<IdentityUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public AdminPanelService(UserManager<IdentityUser> userManager,  IMapper mapper)
        {
            _userManager = userManager;
           // _roleManager = roleManager;
            _mapper = mapper;
        }

        public Task<IdentityResult> ChangeUserRolesAsync(string idUser, IEnumerable<string> role)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return await Task.FromResult<IdentityResult>(null);
            }
            return await _userManager.DeleteAsync(user);
        }

        public ListUsersForListVm GetAllUsers()
        {
            var users = _userManager.Users.ProjectTo<UserForListVm>(_mapper.ConfigurationProvider).ToList();
            var usersVm = new ListUsersForListVm()
            {
                Users = users,
                Count = users.Count
            };
            return usersVm;
        }

        public IQueryable<string> GetRolesByUser(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            var roles = _userManager.GetRolesAsync(user).Result.AsQueryable();
            return roles;
        }

        public UserDetailVm GetUserDetails(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            var userVm = _mapper.Map<UserDetailVm>(user);
            userVm.UserRoles = GetRolesByUser(user.Id).ToList();
            return userVm;
        }

        public void RemoveRoleFromUser(string id, string role)
        {
            throw new NotImplementedException();
        }
    }
}
