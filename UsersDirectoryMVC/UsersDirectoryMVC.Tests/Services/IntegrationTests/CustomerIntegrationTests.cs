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
using UsersDirectoryMVC.Application.ViewModels.Customer;
using UsersDirectoryMVC.Application.ViewModels.Employer;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;
using UsersDirectoryMVC.Infrastructure;
using UsersDirectoryMVC.Infrastructure.Repositories;
using Xunit;

namespace UsersDirectoryMVC.Tests.Services.IntegrationTests
{
    public class CustomerIntegrationTests
    { 
        [Fact]
        public void CheckCustomerIfExistAfterAdd()
        {
            //Arrange
            NewCustomerVm customerToAdd = new NewCustomerVm()
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
                var customerService = new CustomerService(new CustomerRepository(context), mapper);
                var result = customerService.AddCustomer(customerToAdd);

                //Assert
                context.Customers.FirstOrDefaultAsync(e => e.Id == result).Should().NotBeNull();
            }
        }

        [Fact]
        public void DeletedCustomerShoundNotExistInDatabase()
        {
            //Arrange
            NewCustomerVm customerToAdd = new NewCustomerVm()
            {
                Id = 1,
                Name = "test",
                NIP = "Unit",
                customerContactInfos = null
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
                var customerService = new CustomerService(new CustomerRepository(context), mapper);
                var result = customerService.AddCustomer(customerToAdd);
                customerService.DeleteCustomer(1);
                var deletedCustomer = customerService.GetCustomerDetails(1);

                //Assert
                deletedCustomer.Should().BeNull();
            }
        }

        [Fact]
        public void CheckCustomersListExistAndIncludesProperCustomers()
        {
            //Arrange
            NewCustomerVm customer1 = new NewCustomerVm()
            {
                Id = 1,
                Name = "test",
                NIP = "Unit"
            };

            NewCustomerVm customer2 = new NewCustomerVm()
            {
                Id = 2,
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
                var customerService = new CustomerService(new CustomerRepository(context), mapper);
                customerService.AddCustomer(customer1);
                customerService.AddCustomer(customer2);
                var listOfCustomers = customerService.GetAllActiveCustomersForList(2, 1, "");

                //Assert
                listOfCustomers.Should().NotBeNull();
                listOfCustomers.Customers.Count.Should().Be(2);
                listOfCustomers.Customers.Find(e => e.Id == 1).Should().Equals(customer1);
                listOfCustomers.Customers.Find(e => e.Id == 2).Should().Equals(customer2);
            }
        }

        [Fact]
        public void CheckCustomerDetailsAreEqualLikeModel()
        {
            //Arrange
            NewCustomerVm customerToAdd = new NewCustomerVm()
            {
                Id = 1,
                Name = "test",
                NIP = "Unit",
                customerContactInfos = null
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
                var customerService = new CustomerService(new CustomerRepository(context), mapper);
                customerService.AddCustomer(customerToAdd);
                var result = customerService.GetCustomerDetails(1);

                //Assert
                result.Should().NotBeNull();
                result.Should().Equals(customerToAdd);
                context.Employers.FirstOrDefaultAsync(e => e.Id == result.Id).Should().NotBeNull();
            }
        }

        [Fact]
        public void CheckCustomerToEditDetailsAreEqualLikeModel()
        {
            //Arrange
            NewCustomerVm customerToAdd = new NewCustomerVm()
            {
                Id = 1,
                Name = "test",
                NIP = "Unit",
                customerContactInfos = null
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
                var customerService = new CustomerService(new CustomerRepository(context), mapper);
                customerService.AddCustomer(customerToAdd);
                var result = customerService.GetCustomerForEdit(1);

                //Assert
                result.Should().NotBeNull();
                result.Should().Equals(customerToAdd);
                context.Customers.FirstOrDefaultAsync(e => e.Id == result.Id).Should().NotBeNull();
            }
        }

        [Fact]
        public void UpdatedCustomerShoundBeLikeCustomerToUpdate()
        {
            CustomerContactInformation infoToDatabase = new CustomerContactInformation()
            {
                Id = 1,
                FirstName = "test",
                LastName = "test",
                CustomerRef = 1
            };
            CustomerContactInfoVm info = new CustomerContactInfoVm()
            {
                Id = 1,
                FirstName = "test1",
                LastName = "test1",
                CustomerRef = 1
            };
            //Arrange
            NewCustomerVm customer = new NewCustomerVm()
            {
                Id = 1,
                Name = "test",
                NIP = "Unit",
                customerContactInfos = info
            };

            NewCustomerVm customerToUpdate = new NewCustomerVm()
            {
                Id = 1,
                Name = "test1",
                NIP = "Uni1t",
                customerContactInfos = info
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
                var customerService = new CustomerService(new CustomerRepository(context), mapper);
                customerService.AddCustomer(customer);
                context.CustomerContactInformations.Add(infoToDatabase);
                context.SaveChanges();
            }

            using (var context = new Context(options))
            {
                var customerService = new CustomerService(new CustomerRepository(context), mapper);
                customerService.UpdateCustomer(customerToUpdate);

                //Assert
                context.Customers.FirstOrDefaultAsync(e => e.Id == 1).Should().Equals(customerToUpdate);
            }
        }
    }
}
