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
        private readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=UsersDirectoryMVC;Trusted_Connection=True;";

        [Fact]
        public void CheckEmployerIfExistAfterAdd()
        {
            //Arrange
            NewEmployerVm employerToAdd = new NewEmployerVm()
            {
                Name = "test",
                NIP = "Unit"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseSqlServer(connectionString)
              .Options;

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            using (var context = new Context(options))
            {
                //Act
                var employerRepository = new EmployerRepository(context);
                var employerService = new EmployerService(mapper, employerRepository);
                var result = employerService.AddEmployer(employerToAdd);

                //Assert
                context.Employers.FirstOrDefaultAsync(e => e.Id == result).Should().NotBeNull();

                //Clear
            }
        }
    }
}
