using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UsersDirectoryMVC.Application.Mapping;
using UsersDirectoryMVC.Application.Services;
using UsersDirectoryMVC.Application.ViewModels.AppUser;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;
using UsersDirectoryMVC.Infrastructure;
using UsersDirectoryMVC.Infrastructure.Repositories;
using Xunit;

namespace UsersDirectoryMVC.Tests.Repositories
{
    public class AppUserRepositoryUnitTests
    {
        [Fact]
        public void CheckAppUserExistAfterDelete()
        {
            //Arrange
            AppUser appUser1 = new AppUser()
            {
                Id = 66,
                FirstName = "test",
                LastName = "test"
            };
            AppUser appUser2 = new AppUser()
            {
                Id = 77,
                FirstName = "test",
                LastName = "test"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var appUserRepository = new AppUserRepository(context);
                appUserRepository.AddAppUser(appUser1);
                appUserRepository.AddAppUser(appUser2);
                appUserRepository.DeleteAppUser(66);
                var getAppUser1 = appUserRepository.GetAppUser(66);
                var getAppUser2 = appUserRepository.GetAppUser(77);
                //Assert
                getAppUser1.Should().BeNull();
                getAppUser2.Should().Equals(appUser2);
            }
        }

        [Fact]
        public void CheckAppUserIdExistAfterAdd()
        {
            //Arrange
            AppUser appUser = new AppUser()
            {
                Id = 1,
                FirstName = "test",
                LastName = "test"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var appUserRepository = new AppUserRepository(context);
                var appUserResult = appUserRepository.AddAppUser(appUser);

                //Assert
                appUserResult.Should().Equals(appUser.Id);
            }
        }

        [Fact]
        public void GetListOfAppUserAndCheckAreEqualLikeModelsWherePositionIdIs1()
        {
            //Arrange
            AppUser appUser1 = new AppUser()
            {
                Id = 1,
                FirstName = "test",
                LastName = "test",
                PositionId = 1
            };

            AppUser appUser2 = new AppUser()
            {
                Id = 2,
                FirstName = "test",
                LastName = "test",
                PositionId = 1
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var appUserRepository = new AppUserRepository(context);
                appUserRepository.AddAppUser(appUser1);
                appUserRepository.AddAppUser(appUser2);

                var listOfAppUserWherePositionIdIs1 = appUserRepository.GetAppUserByPositionId(1);

                //Assert
                listOfAppUserWherePositionIdIs1.FirstOrDefault(e => e.Id == 1).Should().Equals(appUser1);
                listOfAppUserWherePositionIdIs1.FirstOrDefault(e => e.Id == 2).Should().Equals(appUser2);
            }
        }

        [Fact]
        public void GetAppUserAndCheckAreEqualLikeModel()
        {
            //Arrange
            AppUser appUser = new AppUser()
            {
                Id = 2,
                FirstName = "test",
                LastName = "test",
                PositionId = 1
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var appUserRepository = new AppUserRepository(context);
                appUserRepository.AddAppUser(appUser);
                var appUserToCheck = appUserRepository.GetAppUser(2);

                //Assert
                appUserToCheck.Should().NotBeNull();
                appUserToCheck.Should().Equals(appUser);
            }
        }

        [Fact]
        public void GetListOfAppUsersAndCheckAreEqualLikeModels()
        {
            //Arrange
            AppUser appUser1 = new AppUser()
            {
                Id = 1,
                FirstName = "test",
                LastName = "test",
                PositionId = 1
            };

            AppUser appUser2 = new AppUser()
            {
                Id = 2,
                FirstName = "test",
                LastName = "test",
                PositionId = 1
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var appUserRepository = new AppUserRepository(context);
                appUserRepository.AddAppUser(appUser1);
                appUserRepository.AddAppUser(appUser2);

                var listOfAppUsers = appUserRepository.GetAllActiveAppUsers();

                //Assert
                listOfAppUsers.FirstOrDefault(e => e.Id == 1).Should().Equals(appUser1);
                listOfAppUsers.FirstOrDefault(e => e.Id == 2).Should().Equals(appUser2);
            }
        }

        [Fact]
        public void ShouldUpdateAppUserFirstAndLastName()
        {
            //Arrange
            AppUser appUser = new AppUser()
            {
                Id = 1,
                FirstName = "test",
                LastName = "test",
                PositionId = 1
            };

            AppUser appUserToUpdate = new AppUser()
            {
                Id = 1,
                FirstName = "test",
                LastName = "test",
                PositionId = 1
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var appUserRepository = new AppUserRepository(context);
                appUserRepository.AddAppUser(appUser);
            }

            using (var context = new Context(options))
            {
                //Act
                var appUserRepository = new AppUserRepository(context);
                appUserRepository.UpdateAppUser(appUserToUpdate);
                var appUserToCheckAfter = appUserRepository.GetAppUser(1);

                //Assert
                appUserToCheckAfter.Should().NotBeNull();
                appUserToCheckAfter.FirstName.Should().Equals(appUserToUpdate.FirstName);
                appUserToCheckAfter.LastName.Should().Equals(appUserToUpdate.LastName);
            }
        }

        [Fact]
        public void GetAppUserPositionNameAndCheckAreEqualLikePositionNameString()
        {
            var positionName = "Junior";

            AppUser appUser = new AppUser()
            {
                Id = 1,
                PositionId = 1
            };

            //Arrange
            Position position = new Position()
            {
                Id = 1,
                Name = "Junior"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var appUserRepository = new AppUserRepository(context);
                appUserRepository.AddPosition(position);
                var positionNameToCheck = appUserRepository.GetAppUserPositionName(appUser.PositionId);

                //Assert
                positionNameToCheck.Should().NotBeNull();
                positionNameToCheck.Should().Equals(positionName);
            }
        }

        [Fact]
        public void CheckPositionExistAfterAddAndIsEqualLikeModelName()
        {
            //Arrange
            Position position = new Position()
            {
                Id = 1,
                Name = "test"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var appUserRepository = new AppUserRepository(context);
                appUserRepository.AddPosition(position);
                var positionResult = appUserRepository.GetAppUserPositionName(1);

                //Assert
                positionResult.Should().NotBeNull();
                positionResult.Should().Equals(position.Name);
            }
        }

        [Fact]
        public void GetAllPositionsAndCheckAreEqualLikeModelsList()
        {
            //Arrange
            Position position1 = new Position()
            {
                Id = 1,
                Name = "Junior"
            };

            Position position2 = new Position()
            {
                Id = 2,
                Name = "Mid"
            };

            List<Position> listOfPositions = new List<Position>();
            listOfPositions.Add(position1);
            listOfPositions.Add(position2);

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var appUserRepository = new AppUserRepository(context);
                appUserRepository.AddPosition(position1);
                appUserRepository.AddPosition(position2);
                var positions = appUserRepository.GetAllPositions().ToList();

                //Assert
                positions.Should().NotBeEmpty();
                positions.Should().Equals(listOfPositions);
            }
        }
    }
}
