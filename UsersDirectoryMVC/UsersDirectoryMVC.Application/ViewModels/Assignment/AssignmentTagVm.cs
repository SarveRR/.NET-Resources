using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.Mapping;

namespace UsersDirectoryMVC.Application.ViewModels.Assignment
{
    public class AssignmentTagVm : IMapFrom<UsersDirectoryMVC.Domain.Model.AssignmentTag>
    {
        public int AssignmentId { get; set; }
        public int TagId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UsersDirectoryMVC.Domain.Model.AssignmentTag, AssignmentTagVm>();
        }
    }
}
