using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Application.Mapping;
using UsersDirectoryMVC.Application.Services;
using UsersDirectoryMVC.Application.ViewModels.Customer;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;
using UsersDirectoryMVC.Infrastructure;
using UsersDirectoryMVC.Infrastructure.Repositories;
using Xunit;

namespace UsersDirectoryMVC.Tests.Services
{
    public class CustomerServiceUnitTests
    {
        [Fact]
        public void CheckCustomerIdAfterAdd()
        {
            //Arrange
            NewCustomerVm customerToAdd = new NewCustomerVm()
            {
                Id = 6,
                Name = "aa",
                NIP = "22",
                customerContactInfos = null
            };

            Customer customer = new Customer()
            {
                Id = 6,
                Name = "aa",
                NIP = "22"
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var mock = new Mock<ICustomerRepository>();
            mock.Setup(s => s.AddCustomer(customer)).Returns(customer.Id);

            var manager = new CustomerService(mock.Object, mapper);

            //Act
            var result = manager.AddCustomer(customerToAdd);

            //Assert
            result.Should().Equals(customer.Id);
        }

        [Fact]
        public void CheckCustomerToEditDetails()
        {
            //Arrange
            Customer customer = new Customer()
            {
                Id = 6,
                Name = "aa",
                NIP = "22"
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var mock = new Mock<ICustomerRepository>();
            mock.Setup(s => s.GetCustomer(6)).Returns(customer);

            var manager = new CustomerService(mock.Object, mapper);
            
            //Act
            var result = manager.GetCustomerForEdit(6);
            
            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Equals(customer.Id);
            customer.Id = 7;
            result.Id.Should().Equals(customer.Id);
            result.Name.Should().Equals(customer.Name);
            result.NIP.Should().Equals(customer.NIP);
        }

        [Fact]
        public void CheckCustomerDetails()
        {
            //Arrange
            Customer customer = new Customer()
            {
                Id = 6,
                Name = "aa",
                NIP = "22"
            };

            var config = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            var mock = new Mock<ICustomerRepository>();
            mock.Setup(s => s.GetCustomer(6)).Returns(customer);

            var manager = new CustomerService(mock.Object, mapper);

            //Act
            var result = manager.GetCustomerDetails(6);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Equals(customer.Id);
            customer.Id = 7;
            result.Id.Should().Equals(customer.Id);
            result.Name.Should().Equals(customer.Name);
            result.NIP.Should().Equals(customer.NIP);
        }
    }
}
