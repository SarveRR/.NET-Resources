using AutoMapper;
using FluentAssertions;
using Moq;
using UsersDirectoryMVC.Application.Mapping;
using UsersDirectoryMVC.Application.Services;
using UsersDirectoryMVC.Application.ViewModels.AppUser;
using UsersDirectoryMVC.Application.ViewModels.Employer;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;
using Xunit;

namespace UsersDirectoryMVC.Tests.Services
{
    public class EmployerServiceUnitTests
    {
        [Fact]
        public void CheckEmployerIdAfterAdd()
        {
            //Arrange
            NewEmployerVm employerToAdd = new NewEmployerVm()
            {
                Id = 6,
                Name = "test",
                NIP = "Unit"
            };

            Employer employer = new Employer()
            {
                Id = 6,
                Name = "test",
                NIP = "Unit"
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var mock = new Mock<IEmployerRepository>();
            mock.Setup(s => s.AddEmployer(employer)).Returns(employer.Id);

            var manager = new EmployerService(mapper, mock.Object);

            //Act
            var result = manager.AddEmployer(employerToAdd);

            //Assert
            result.Should().Equals(employer.Id);
        }

        [Fact]
        public void CheckEmployerDetailsAreEqualLikeModel()
        {
            //Arrange
            Employer employer = new Employer()
            {
                Id = 6,
                Name = "test",
                NIP = "unit",
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var mock = new Mock<IEmployerRepository>();
            mock.Setup(s => s.GetEmployer(6)).Returns(employer);

            var manager = new EmployerService(mapper, mock.Object);

            //Act
            var result = manager.GetEmployerDetails(6);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Equals(employer.Id);
            employer.Id = 7;
            result.Id.Should().Equals(employer.Id);
            result.Name.Should().Equals(employer.Name);
            result.NIP.Should().Equals(employer.NIP);
        }

        [Fact]
        public void CheckEmployerToEditDetailsAreEqualLikeModel()
        {
            //Arrange
            Employer employer = new Employer()
            {
                Id = 6,
                Name = "test",
                NIP = "unit",
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var mock = new Mock<IEmployerRepository>();
            mock.Setup(s => s.GetEmployer(6)).Returns(employer);

            var manager = new EmployerService(mapper, mock.Object);

            //Act
            var result = manager.GetEmployerForEdit(6);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Equals(employer.Id);
            employer.Id = 7;
            result.Id.Should().Equals(employer.Id);
            result.Name.Should().Equals(employer.Name);
            result.NIP.Should().Equals(employer.NIP);
        }
    }
}
