using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.Mapping;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Application.ViewModels.AppUser
{
    public class NewAppUserVm : IMapFrom<UsersDirectoryMVC.Domain.Model.AppUser>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int PositionId { get; set; }
        public string Position { get; set; }

        public List<Position> Positions { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewAppUserVm, UsersDirectoryMVC.Domain.Model.AppUser>().ReverseMap();
        }
    }

    public class NewAppUserValidation : AbstractValidator<NewAppUserVm>
    {
        public NewAppUserValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.FirstName).MaximumLength(255);
            RuleFor(x => x.LastName).MaximumLength(255);
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.City).MaximumLength(255);
        }
    }
}
