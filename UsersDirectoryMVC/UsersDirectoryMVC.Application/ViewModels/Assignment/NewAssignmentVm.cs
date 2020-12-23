using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.Mapping;

namespace UsersDirectoryMVC.Application.ViewModels.Assignment
{
    public class NewAssignmentVm : IMapFrom<UsersDirectoryMVC.Domain.Model.Assignment>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewAssignmentVm, UsersDirectoryMVC.Domain.Model.Assignment>().ReverseMap();
        }
    }

    public class NewAssignmentValidation : AbstractValidator<NewAssignmentVm>
    {
        public NewAssignmentValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).MaximumLength(255);
            RuleFor(x => x.Description).MaximumLength(255);
        }
    }
}
