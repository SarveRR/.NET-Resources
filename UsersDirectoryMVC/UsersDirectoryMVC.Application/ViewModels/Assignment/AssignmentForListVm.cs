using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.Mapping;

namespace UsersDirectoryMVC.Application.ViewModels.Assignment
{
    public class AssignmentForListVm : IMapFrom<UsersDirectoryMVC.Domain.Model.Assignment>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UsersDirectoryMVC.Domain.Model.Assignment, AssignmentForListVm>();
        }
    }
}
