using AutoMapper;
using FluentAssertions;
using Moq;
using UsersDirectoryMVC.Application.Mapping;
using UsersDirectoryMVC.Application.Services;
using UsersDirectoryMVC.Application.ViewModels.AppUser;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;
using Xunit;

namespace UsersDirectoryMVC.Tests.Services
{
    public class EmployerRepositoryUnitTests
    {
        [Fact]
        public void CheckEmployerIdExistAfterAdd()
        {
            //Arrange
            NewAppUserVm appUserToAdd = new NewAppUserVm()
            {
                Id = 6,
                FirstName = "test",
                LastName = "unit"
            };

            AppUser appUser = new AppUser()
            {
                Id = 6,
                FirstName = "test",
                LastName = "unit"
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var mock = new Mock<IAppUserRepository>();
            mock.Setup(s => s.AddAppUser(appUser)).Returns(appUser.Id);

            var manager = new AppUserService(mapper, mock.Object);

            //Act
            var result = manager.AddAppUser(appUserToAdd);

            //Assert
            result.Should().Equals(appUser.Id);
        }

        [Fact]
        public void CheckAppUserDetailsAreEqualLikeModel()
        {
            //Arrange
            AppUser appuser = new AppUser()
            {
                Id = 6,
                FirstName = "test",
                LastName = "unit",
                City = "test"
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var mock = new Mock<IAppUserRepository>();
            mock.Setup(s => s.GetAppUser(6)).Returns(appuser);

            var manager = new AppUserService(mapper, mock.Object);

            //Act
            var result = manager.GetAppUserDetails(6);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Equals(appuser.Id);
            appuser.Id = 7;
            result.Id.Should().Equals(appuser.Id);
            result.FirstName.Should().Equals(appuser.FirstName);
            result.LastName.Should().Equals(appuser.LastName);
        }

        [Fact]
        public void CheckAppUserPositionNameAreEqualLikeVariable()
        {
            //Arrange
            var position = "Junior";

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var mock = new Mock<IAppUserRepository>();
            mock.Setup(s => s.GetAppUserPositionName(12)).Returns(position);

            var manager = new AppUserService(mapper, mock.Object);

            //Act
            var result = manager.GetAppUserPositionName(12);

            //Assert
            result.Should().BeSameAs(position);
        }

        [Fact]
        public void CheckAppUserToEditDetailsAreEqualLikeModel()
        {
            //Arrange
            AppUser appuser = new AppUser()
            {
                Id = 6,
                FirstName = "test",
                LastName = "unit",
                City = "test"
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var mock = new Mock<IAppUserRepository>();
            mock.Setup(s => s.GetAppUser(6)).Returns(appuser);

            var manager = new AppUserService(mapper, mock.Object);

            //Act
            var result = manager.GetAppUserForEdit(6);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Equals(appuser.Id);
            appuser.Id = 7;
            result.Id.Should().Equals(appuser.Id);
            result.FirstName.Should().Equals(appuser.FirstName);
            result.LastName.Should().Equals(appuser.LastName);
        }
    }
}
