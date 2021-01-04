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
    public class EmployerRepositoryUnitTests
    {
        [Fact]
        public void CheckEmployerExistAfterDelete()
        {
            //Arrange
            Employer employer1 = new Employer()
            {
                Id = 66,
                Name = "test",
                NIP = "unit"
            };
            Employer employer2 = new Employer()
            {
                Id = 77,
                Name = "test",
                NIP = "unit"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var employerRepository = new EmployerRepository(context);
                employerRepository.AddEmployer(employer1);
                employerRepository.AddEmployer(employer2);
                employerRepository.DeleteEmployer(66);
                var gerEmployer1 = employerRepository.GetEmployer(66);
                var gerEmployer2 = employerRepository.GetEmployer(77);
                //Assert
                gerEmployer1.Should().BeNull();
                gerEmployer2.Should().Equals(employer2);
            }
        }

        [Fact]
        public void CheckEmployerIdExistAfterAdd()
        {
            //Arrange
            Employer employer = new Employer()
            {
                Id = 66,
                Name = "test",
                NIP = "unit"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var employerRepository = new EmployerRepository(context);
                var employerResult = employerRepository.AddEmployer(employer);

                //Assert
                employerResult.Should().Equals(employer.Id);
            }
        }

        [Fact]
        public void GetListOfEmployers()
        {
            //Arrange
            Employer employer1 = new Employer()
            {
                Id = 66,
                Name = "test",
                NIP = "unit"
            };

            Employer employer2 = new Employer()
            {
                Id = 67,
                Name = "test1",
                NIP = "unit1"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var employerRepository = new EmployerRepository(context);
                employerRepository.AddEmployer(employer1);
                employerRepository.AddEmployer(employer2);

                var listOfEmployers = employerRepository.GetAllActiveEmployers();

                //Assert
                listOfEmployers.FirstOrDefault(e => e.Id == 66).Should().Equals(employer1);
                listOfEmployers.FirstOrDefault(e => e.Id == 67).Should().Equals(employer2);
            }
        }

        [Fact]
        public void ShouldUpdateEmployerNameAndNIP()
        {
            //Arrange
            Employer employer = new Employer()
            {
                Id = 66,
                Name = "test",
                NIP = "unit"
            };

            Employer updatedEmployer = new Employer()
            {
                Id = 66,
                Name = "test1",
                NIP = "unit1"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var employerRepository = new EmployerRepository(context);
                employerRepository.AddEmployer(employer);
            }

            using (var context = new Context(options))
            {
                //Act
                var employerRepository = new EmployerRepository(context);
                //
                employerRepository.UpdateEmployer(updatedEmployer);
                var employerToCheckAfter = employerRepository.GetEmployer(66);

                //Assert
                employerToCheckAfter.Should().NotBeNull();
                employerToCheckAfter.Name.Should().Equals(updatedEmployer.Name);
                employerToCheckAfter.NIP.Should().Equals(updatedEmployer.NIP);
            }
        }
    }
}
