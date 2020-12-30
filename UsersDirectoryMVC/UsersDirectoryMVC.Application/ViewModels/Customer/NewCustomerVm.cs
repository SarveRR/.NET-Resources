using AutoMapper;
using FluentValidation;
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
        public CustomerContactInfoVm customerContactInfos { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCustomerVm, UsersDirectoryMVC.Domain.Model.Customer>().ReverseMap();
        }
    }

    public class NewCustomerValidation : AbstractValidator<NewCustomerVm>
    {
        public NewCustomerValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.NIP).Length(10);
            RuleFor(x => x.NIP).NotNull();
            RuleFor(x => x.Name).MaximumLength(255);
        }
    }
}
