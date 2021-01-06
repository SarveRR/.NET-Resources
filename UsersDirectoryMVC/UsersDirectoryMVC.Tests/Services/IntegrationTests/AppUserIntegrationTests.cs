using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Transactions;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.Mapping;
using UsersDirectoryMVC.Application.Services;
using UsersDirectoryMVC.Application.ViewModels.AppUser;
using UsersDirectoryMVC.Application.ViewModels.Employer;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;
using UsersDirectoryMVC.Infrastructure;
using UsersDirectoryMVC.Infrastructure.Repositories;
using Xunit;

namespace UsersDirectoryMVC.Tests.Services.IntegrationTests
{
    public class AppUserIntegrationTests
    {
        [Fact]
        public void CheckAppUserIfExistAfterAdd()
        {
            //Arrange
            NewAppUserVm appUserToAdd = new NewAppUserVm()
            {
                Id = 1,
                FirstName = "test",
                PositionId = 1
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase("UsersDirectoryMVC")
              .Options;

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            using (var context = new Context(options))
            {
                //Act
                var appUserService = new AppUserService(mapper, new AppUserRepository(context));
                var result = appUserService.AddAppUser(appUserToAdd);

                //Assert
                context.AppUsers.FirstOrDefaultAsync(e => e.Id == result).Should().NotBeNull();
            }
        }

        [Fact]
        public void DeletedAppUserShoundNotExistInDatabase()
        {
            //Arrange
            NewAppUserVm appUserToAdd = new NewAppUserVm()
            {
                Id = 1,
                FirstName = "test",
                PositionId = 1
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase("UsersDirectoryMVC")
              .Options;

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            using (var context = new Context(options))
            {
                //Act
                var appUserService = new AppUserService(mapper, new AppUserRepository(context));
                var result = appUserService.AddAppUser(appUserToAdd);
                appUserService.DeleteAppUser(1);
                var deletedAppUser = appUserService.GetAppUserDetails(1);

                //Assert
                deletedAppUser.Should().BeNull();
            }
        }

        [Fact]
        public void CheckAppUsersListExistAndIncludesProperAppUsers()
        {
            //Arrange
            NewAppUserVm appUser1 = new NewAppUserVm()
            {
                Id = 1,
                FirstName = "test",
                PositionId = 1
            };

            NewAppUserVm appUser2 = new NewAppUserVm()
            {
                Id = 2,
                FirstName = "test2",
                PositionId = 2
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase("UsersDirectoryMVC")
              .Options;

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            using (var context = new Context(options))
            {
                //Act
                var appUserService = new AppUserService(mapper, new AppUserRepository(context));
                appUserService.AddAppUser(appUser1);
                appUserService.AddAppUser(appUser2);
                var listOfAppUsers = appUserService.GetAllActiveAppUsersForList(2, 1, "");

                //Assert
                listOfAppUsers.Should().NotBeNull();
                listOfAppUsers.AppUsers.Count.Should().Be(2);
                listOfAppUsers.AppUsers.Find(e => e.Id == 1).Should().Equals(appUser1);
                listOfAppUsers.AppUsers.Find(e => e.Id == 2).Should().Equals(appUser2);
            }
        }

        [Fact]
        public void CheckAppUserDetailsAreEqualLikeModel()
        {
            Position position = new Position()
            {
                Id = 1,
                Name = "test"
            };
            //Arrange
            NewAppUserVm appUser = new NewAppUserVm()
            {
                Id = 1,
                FirstName = "test2",
                PositionId = 1
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase("UsersDirectoryMVC")
              .Options;


            using (var context = new Context(options))
            {
                //Act
                var appUserService = new AppUserService(mapper, new AppUserRepository(context));
                appUserService.AddAppUser(appUser);
                context.Positions.Add(position);
                context.SaveChanges();
                var result = appUserService.GetAppUserDetails(1);

                //Assert
                result.Should().NotBeNull();
                result.Should().Equals(appUser);
                context.AppUsers.FirstOrDefaultAsync(e => e.Id == result.Id).Should().NotBeNull();
            }
        }

        [Fact]
        public void CheckPositionNameAreEqualLikePositionName()
        {
            //Arrange
            var positionName = "test";

            Position position = new Position()
            {
                Id = 1,
                Name = "test"
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase("UsersDirectoryMVC")
              .Options;


            using (var context = new Context(options))
            {
                //Act
                var appUserService = new AppUserService(mapper, new AppUserRepository(context));
                context.Positions.Add(position);
                context.SaveChanges();
                var result = appUserService.GetAppUserPositionName(1);

                //Assert
                result.Should().NotBeNull();
                result.Should().Equals(positionName);
            }
        }

        [Fact]
        public void CheckAppUserToEditDetailsAreEqualLikeModel()
        {
            //Arrange
            NewAppUserVm appUser = new NewAppUserVm()
            {
                Id = 1,
                FirstName = "test2",
                PositionId = 1
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase("UsersDirectoryMVC")
              .Options;


            using (var context = new Context(options))
            {
                //Act
                var appUserService = new AppUserService(mapper, new AppUserRepository(context));
                appUserService.AddAppUser(appUser);
                var result = appUserService.GetAppUserForEdit(1);

                //Assert
                result.Should().NotBeNull();
                result.Should().Equals(appUser);
                context.AppUsers.FirstOrDefaultAsync(e => e.Id == result.Id).Should().NotBeNull();
            }
        }

        [Fact]
        public void UpdatedAppUserShoundBeLikeAppUserToUpdate()
        {
            //Arrange
            NewAppUserVm appUser = new NewAppUserVm()
            {
                Id = 1,
                FirstName = "test",
                PositionId = 1
            };

            NewAppUserVm appUserToUpdate = new NewAppUserVm()
            {
                Id = 1,
                FirstName = "test",
                PositionId = 1
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase("UsersDirectoryMVC")
              .Options;

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            using (var context = new Context(options))
            {
                //Act
                var appUserService = new AppUserService(mapper, new AppUserRepository(context));
                appUserService.AddAppUser(appUser);
            }

            using (var context = new Context(options))
            {
                var appUserService = new AppUserService(mapper, new AppUserRepository(context));
                appUserService.UpdateAppUser(appUserToUpdate);

                //Assert
                context.AppUsers.FirstOrDefaultAsync(e => e.Id == 1).Should().Equals(appUserToUpdate);
            }
        }

        [Fact]
        public void CheckPrepareNewAppUserReturnsProperModel()
        {
            //Arrange
            NewAppUserVm appUser = new NewAppUserVm();

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase("UsersDirectoryMVC")
              .Options;

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            using (var context = new Context(options))
            {
                var appUserService = new AppUserService(mapper, new AppUserRepository(context));
                appUserService.PrepareNewAppUserVm();

                //Assert
                appUserService.Should().Equals(appUser);
            }
        }
    }
}
