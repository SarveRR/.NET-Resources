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
    public class CustomerRepositoryUnitTests
    {
        [Fact]
        public void CheckCustomerExistAfterDelete()
        {
            //Arrange
            Customer customer1 = new Customer()
            {
                Id = 66,
                Name = "test",
                NIP = "unit"
            };
            Customer customer2 = new Customer()
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
                var customerRepository = new CustomerRepository(context);
                customerRepository.AddCustomer(customer1);
                customerRepository.AddCustomer(customer2);
                customerRepository.DeleteCustomer(66);
                var gerEmployer1 = customerRepository.GetCustomer(66);
                var gerEmployer2 = customerRepository.GetCustomer(77);
                //Assert
                gerEmployer1.Should().BeNull();
                gerEmployer2.Should().Equals(customer2);
            }
        }

        [Fact]
        public void CheckCustomerIdExistAfterAdd()
        {
            //Arrange
            Customer customer = new Customer()
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
                var customerRepository = new CustomerRepository(context);
                var customerResult = customerRepository.AddCustomer(customer);

                //Assert
                customerResult.Should().Equals(customer.Id);
            }
        }

        [Fact]
        public void GetListOfAddedCustomersAndCheckExist()
        {
            //Arrange
            Customer customer1 = new Customer()
            {
                Id = 66,
                Name = "test",
                NIP = "unit"
            };

            Customer customer2 = new Customer()
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
                var customerRepository = new CustomerRepository(context);
                customerRepository.AddCustomer(customer1);
                customerRepository.AddCustomer(customer2);

                var listOfCustomers = customerRepository.GetAllActiveCustomers();

                //Assert
                listOfCustomers.FirstOrDefault(e => e.Id == 66).Should().Equals(customer1);
                listOfCustomers.FirstOrDefault(e => e.Id == 67).Should().Equals(customer2);
            }
        }

        [Fact]
        public void ShouldUpdateCustomerNameAndNIP()
        {
            //Arrange
            Customer customer = new Customer()
            {
                Id = 66,
                Name = "test",
                NIP = "unit"
            };

            Customer updatedCustomer = new Customer()
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
                var customerRepository = new CustomerRepository(context);
                customerRepository.AddCustomer(customer);
            }

            using (var context = new Context(options))
            {
                //Act
                var customerRepository = new CustomerRepository(context);
                //
                customerRepository.UpdateCustomer(updatedCustomer);
                var customerToCheckAfterUpdate = customerRepository.GetCustomer(66);

                //Assert
                customerToCheckAfterUpdate.Should().NotBeNull();
                customerToCheckAfterUpdate.Name.Should().Equals(updatedCustomer.Name);
                customerToCheckAfterUpdate.NIP.Should().Equals(updatedCustomer.NIP);
            }
        }

        [Fact]
        public void GetCustomerContactInfoByCustomerIdAndCheckExist()
        {
            //Arrange
            CustomerContactInformation customerInfo = new CustomerContactInformation()
            {
                Id = 0,
                FirstName = "test",
                LastName = "unit",
                CustomerRef = 6
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var customerRepository = new CustomerRepository(context);
                customerRepository.UpdateCustomerContactInfo(customerInfo);
                var customerInfoFromDatabase = customerRepository.GetCustomerContactInfos(6);

                //Assert
                customerInfoFromDatabase.Should().Equals(customerInfo);
            }
        }

        [Fact]
        public void SelectedCustomerInfoMustBeEqualLikeCustomerInfoToUpdate()
        {
            //Arrange
            CustomerContactInformation customerInfo = new CustomerContactInformation()
            {
                Id = 0,
                FirstName = "test",
                LastName = "unit",
                CustomerRef = 6
            };

            CustomerContactInformation customerInfoToUpdate = new CustomerContactInformation()
            {
                Id = 0,
                FirstName = "test1",
                LastName = "unit1",
                CustomerRef = 6
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var customerRepository = new CustomerRepository(context);
                customerRepository.UpdateCustomerContactInfo(customerInfo);
            }

            using (var context = new Context(options))
            {
                //Act
                var customerRepository = new CustomerRepository(context);
                customerRepository.UpdateCustomerContactInfo(customerInfoToUpdate);
                var customerInfoFromDatabase = customerRepository.GetCustomerContactInfos(6);

                //Assert
                customerInfoFromDatabase.Should().Equals(customerInfoToUpdate);
            }
        }
    }
}
