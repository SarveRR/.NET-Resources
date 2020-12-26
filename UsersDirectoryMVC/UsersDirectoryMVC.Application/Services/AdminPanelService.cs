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
        public AdminPanelService(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            //_roleManager = roleManager;
            _mapper = mapper;
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
    }
}
