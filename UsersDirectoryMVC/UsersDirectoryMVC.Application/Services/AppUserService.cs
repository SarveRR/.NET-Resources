using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.AppUser;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Application.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;
        public AppUserService(IMapper mapper, IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        public int AddAppUser(NewAppUserVm appUser)
        {
            var appUserVm = _mapper.Map<AppUser>(appUser);
            var id = _appUserRepository.AddAppUser(appUserVm);
            return id;
        }

        public void DeleteAppUser(int id)
        {
            _appUserRepository.DeleteAppUser(id);
        }

        public ListAppUserForListVm GetAllActiveAppUsersForList(int pageSize, int pageNumber, string searchString)
        {
            var appUsers = _appUserRepository.GetAllActiveAppUsers().Where(p => p.FirstName.StartsWith(searchString))
                .ProjectTo<AppUserForListVm>(_mapper.ConfigurationProvider).ToList();
            var aappUsersToShow = appUsers.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var appUserList = new ListAppUserForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNumber,
                SearchString = searchString,
                AppUsers = aappUsersToShow,
                Count = appUsers.Count
            };
            return appUserList;
        }

        public AppUserDetailsVm GetAppUserDetails(int id)
        {
            var appUser = _appUserRepository.GetAppUser(id);
            var appUserVm = _mapper.Map<AppUserDetailsVm>(appUser);

            return appUserVm;
        }

        public NewAppUserVm GetAppUserForEdit(int id)
        {
            var appUser = _appUserRepository.GetAppUser(id);
            var appUserVm = _mapper.Map<NewAppUserVm>(appUser);
            return appUserVm;
        }

        public void UpdateAppUser(NewAppUserVm model)
        {
            var appUser = _mapper.Map<AppUser>(model);
            _appUserRepository.UpdateAppUser(appUser);
        }
    }
}
