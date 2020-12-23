using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.Mapping;

namespace UsersDirectoryMVC.Application.ViewModels.Employer
{
    public class NewEmployerVm : IMapFrom<UsersDirectoryMVC.Domain.Model.Employer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewEmployerVm, UsersDirectoryMVC.Domain.Model.Employer>().ReverseMap();
        }
    }

    public class NewEmployerValidation : AbstractValidator<NewEmployerVm>
    {
        public NewEmployerValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.NIP).Length(10);
            RuleFor(x => x.NIP).NotNull();
            RuleFor(x => x.Name).MaximumLength(255);
        }
    }
}
