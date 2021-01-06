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
using UsersDirectoryMVC.Application.ViewModels.Employer;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;
using UsersDirectoryMVC.Infrastructure;
using UsersDirectoryMVC.Infrastructure.Repositories;
using Xunit;

namespace UsersDirectoryMVC.Tests.Services.IntegrationTests
{
    public class EmployerIntegrationTests
    { 
        [Fact]
        public void CheckEmployerIfExistAfterAdd()
        {
            //Arrange
            NewEmployerVm employerToAdd = new NewEmployerVm()
            {
                Id = 1,
                Name = "test",
                NIP = "Unit"
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
                var employerService = new EmployerService(mapper, new EmployerRepository(context));
                var result = employerService.AddEmployer(employerToAdd);

                //Assert
                context.Employers.FirstOrDefaultAsync(e => e.Id == result).Should().NotBeNull();
            }
        }

        [Fact]
        public void DeletedEmployerShoundNotExistInDatabase()
        {
            //Arrange
            NewEmployerVm employerToAdd = new NewEmployerVm()
            {
                Id = 1,
                Name = "test",
                NIP = "Unit"
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
                var employerService = new EmployerService(mapper, new EmployerRepository(context));
                var result = employerService.AddEmployer(employerToAdd);
                employerService.DeleteEmployer(1);
                var deletedEmployer = employerService.GetEmployerDetails(1);

                //Assert
                deletedEmployer.Should().BeNull();
            }
        }

        [Fact]
        public void CheckEmpoyersListExistAndIncludesProperEmployers()
        {
            //Arrange
            NewEmployerVm employer1 = new NewEmployerVm()
            {
                Id = 1,
                Name = "test",
                NIP = "Unit"
            };

            NewEmployerVm employer2 = new NewEmployerVm()
            {
                Id = 2,
                Name = "test2",
                NIP = "Unit2"
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
                var employerService = new EmployerService(mapper, new EmployerRepository(context));
                employerService.AddEmployer(employer1);
                employerService.AddEmployer(employer2);
                var listOfEmplyers = employerService.GetAllActiveEmployersForList(2, 1, "");

                //Assert
                listOfEmplyers.Should().NotBeNull();
                listOfEmplyers.Employers.Count.Should().Be(2);
                listOfEmplyers.Employers.Find(e => e.Id == 1).Should().Equals(employer1);
                listOfEmplyers.Employers.Find(e => e.Id == 2).Should().Equals(employer2);
            }
        }

        [Fact]
        public void CheckEmployerDetailsAreEqualLikeModel()
        {
            //Arrange
            NewEmployerVm employerToAdd = new NewEmployerVm()
            {
                Id = 1,
                Name = "test",
                NIP = "Unit"
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
                var employerService = new EmployerService(mapper, new EmployerRepository(context));
                employerService.AddEmployer(employerToAdd);
                var result = employerService.GetEmployerDetails(1);

                //Assert
                result.Should().NotBeNull();
                result.Should().Equals(employerToAdd);
                context.Employers.FirstOrDefaultAsync(e => e.Id == result.Id).Should().NotBeNull();
            }
        }

        [Fact]
        public void CheckEmployerToEditDetailsAreEqualLikeModel()
        {
            //Arrange
            NewEmployerVm employerToAdd = new NewEmployerVm()
            {
                Id = 1,
                Name = "test",
                NIP = "Unit"
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
                var employerService = new EmployerService(mapper, new EmployerRepository(context));
                employerService.AddEmployer(employerToAdd);
                var result = employerService.GetEmployerForEdit(1);

                //Assert
                result.Should().NotBeNull();
                result.Should().Equals(employerToAdd);
                context.Employers.FirstOrDefaultAsync(e => e.Id == result.Id).Should().NotBeNull();
            }
        }

        [Fact]
        public void UpdatedEmployerShoundBeLikeEmployerToUpdate()
        {
            //Arrange
            NewEmployerVm employer = new NewEmployerVm()
            {
                Id = 1,
                Name = "test",
                NIP = "Unit"
            };

            NewEmployerVm employerToUpdate = new NewEmployerVm()
            {
                Id = 1,
                Name = "test2",
                NIP = "Unit2"
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
                var employerService = new EmployerService(mapper, new EmployerRepository(context));
                employerService.AddEmployer(employer);
            }

            using (var context = new Context(options))
            {
                var employerService = new EmployerService(mapper, new EmployerRepository(context));
                employerService.UpdateEmployer(employerToUpdate);

                //Assert
                context.Employers.FirstOrDefaultAsync(e => e.Id == 1).Should().Equals(employerToUpdate);
            }
        }
    }
}
