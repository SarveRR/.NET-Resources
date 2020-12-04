using FluentAssertions;
using Moq;
using System;
using System.Linq;
using UsersDirectory.App.Abstract;
using UsersDirectory.App.Concrete;
using UsersDirectory.App.Managers;
using UsersDirectory.Domain.Entity;
using Xunit;


namespace UsersDirectory.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void AddNewUserTest()
        {
            //Arrange
            User user = new User(33, "Name", "Surname", "City");
            IService<User> userService = new UserService();

            //Act
            userService.AddUser(user);
            //Assert 
            userService.Users.FirstOrDefault(i => i.Id == user.Id).Should().NotBeNull();
        }

        [Fact]
        public void RemoveUserTest()
        {
            //Arrange
            User user = new User(31, "Name", "Surname", "City");
            IService<User> userService = new UserService();

            //Act
            userService.RemoveUser(user);
            //Assert 
            userService.Users.FirstOrDefault(i => i.Id == user.Id).Should().BeNull();
        }

        [Fact]
        public void GetLastIdTest()
        {
            //Arrange
            User user = new User(31, "Name", "Surname", "City");
            IService<User> userService = new UserService();

            //Act
            var id = userService.GetLastId();
            //Assert 
            id.Should().BeOfType(typeof(int));
            id.Should().Equals(user.Id);
        }

        
    }
}
