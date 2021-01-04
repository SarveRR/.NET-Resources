using AutoMapper;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using UsersDirectoryMVC.Application.Mapping;
using UsersDirectoryMVC.Application.Services;
using UsersDirectoryMVC.Application.ViewModels.AppUser;
using UsersDirectoryMVC.Application.ViewModels.Assignment;
using UsersDirectoryMVC.Application.ViewModels.Employer;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;
using Xunit;

namespace UsersDirectoryMVC.Tests
{
    public class AssignmentServiceUnitTests
    {
        [Fact]
        public void CheckAssignmentIdAfterAdd()
        {
            //Arrange
            NewAssignmentVm assignmentToAdd = new NewAssignmentVm()
            {
                Id = 6,
                Name = "test",
            };

            Assignment assignment = new Assignment()
            {
                Id = 6,
                Name = "test"
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var mock = new Mock<IAssignmentRepository>();
            mock.Setup(s => s.AddAssignment(assignment)).Returns(assignment.Id);

            var manager = new AssignmentService(mapper, mock.Object);

            //Act
            var result = manager.AddAssignment(assignmentToAdd);

            //Assert
            result.Should().Equals(assignment.Id);
        }
    }
}
