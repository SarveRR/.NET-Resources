using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.Mapping;

namespace UsersDirectoryMVC.Application.ViewModels.Customer
{
    public class CustomerContactInfoVm : IMapFrom<UsersDirectoryMVC.Domain.Model.CustomerContactInformation>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UsersDirectoryMVC.Domain.Model.CustomerContactInformation, CustomerContactInfoVm>().ReverseMap();
        }
    }
}
