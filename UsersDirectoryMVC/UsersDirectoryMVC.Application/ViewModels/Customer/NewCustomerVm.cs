using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.Mapping;

namespace UsersDirectoryMVC.Application.ViewModels.Customer
{
    public class NewCustomerVm : IMapFrom<UsersDirectoryMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCustomerVm, UsersDirectoryMVC.Domain.Model.Customer>();
        }
    }
}
