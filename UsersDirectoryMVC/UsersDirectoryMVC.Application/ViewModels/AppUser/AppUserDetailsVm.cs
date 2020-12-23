using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.Mapping;

namespace UsersDirectoryMVC.Application.ViewModels.AppUser
{
    public class AppUserDetailsVm : IMapFrom<UsersDirectoryMVC.Domain.Model.AppUser>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int PositionId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UsersDirectoryMVC.Domain.Model.AppUser, AppUserDetailsVm>();
        }
    }
}
