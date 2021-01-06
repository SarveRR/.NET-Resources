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
using UsersDirectoryMVC.Application.ViewModels.Assignment;
using UsersDirectoryMVC.Application.ViewModels.Employer;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;
using UsersDirectoryMVC.Infrastructure;
using UsersDirectoryMVC.Infrastructure.Repositories;
using Xunit;

namespace UsersDirectoryMVC.Tests.Services.IntegrationTests
{
    public class AssignmentIntegrationTests
    { 
        [Fact]
        public void CheckAssignmentIfExistAfterAdd()
        {
            //Arrange
            NewAssignmentVm assignmentToAdd = new NewAssignmentVm()
            {
                Id = 1,
                Name = "test"
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
                var assignmentService = new AssignmentService(mapper, new AssignmentRepository(context));
                var result = assignmentService.AddAssignment(assignmentToAdd);

                //Assert
                context.Assignments.FirstOrDefaultAsync(e => e.Id == result).Should().NotBeNull();
            }
        }

        [Fact]
        public void DeletedAssignmentShoundNotExistInDatabase()
        {
            //Arrange
            NewAssignmentVm assignmentToAdd = new NewAssignmentVm()
            {
                Id = 1,
                Name = "test"
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
                var assignmentService = new AssignmentService(mapper, new AssignmentRepository(context));
                var result = assignmentService.AddAssignment(assignmentToAdd);
                assignmentService.DeleteAssignment(1);
                var deletedAssignment = assignmentService.GetAssignmentDetails(1);

                //Assert
                deletedAssignment.Should().BeNull();
            }
        }

        [Fact]
        public void CheckAssignmentListExistAndIncludesProperData()
        {
            //Arrange
            NewAssignmentVm assignment1 = new NewAssignmentVm()
            {
                Id = 1,
                Name = "test"
            };

            NewAssignmentVm assignment2 = new NewAssignmentVm()
            {
                Id = 2,
                Name = "test1"
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
                var assignmentService = new AssignmentService(mapper, new AssignmentRepository(context));
                assignmentService.AddAssignment(assignment1);
                assignmentService.AddAssignment(assignment2);
                var listOfAssignments = assignmentService.GetAllActiveAssignmentsForList(2, 1, "");

                //Assert
                listOfAssignments.Should().NotBeNull();
                listOfAssignments.Assignments.Count.Should().Be(2);
                listOfAssignments.Assignments.Find(e => e.Id == 1).Should().Equals(assignment1);
                listOfAssignments.Assignments.Find(e => e.Id == 2).Should().Equals(assignment2);
            }
        }

        [Fact]
        public void CheckAssignmentDetailsAreEqualLikeModel()
        {
            //Arrange
            NewAssignmentVm assignmentToAdd = new NewAssignmentVm()
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
                var assignmentService = new AssignmentService(mapper, new AssignmentRepository(context));
                var result = assignmentService.AddAssignment(assignmentToAdd);
                var assignemntDetails = assignmentService.GetAssignmentDetails(1);

                //Assert
                assignemntDetails.Should().NotBeNull();
                assignemntDetails.Should().Equals(assignmentToAdd);
                context.Assignments.FirstOrDefaultAsync(e => e.Id == assignemntDetails.Id).Should().NotBeNull();
            }
        }

        [Fact]
        public void CheckAssignmentTagsAreEqualLikeModel()
        {
            //Arrange
            AssignmentTag assTag1 = new AssignmentTag()
            {
                TagId = 1,
                AssignmentId = 1
            };

            AssignmentTag assTag2 = new AssignmentTag()
            {
                TagId = 2,
                AssignmentId = 1
            };

            List<AssignmentTag> listAssTags = new List<AssignmentTag> { assTag1, assTag2 };

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
                var assignmentService = new AssignmentService(mapper, new AssignmentRepository(context));
                context.AssignmentTag.AddRange(listAssTags);
                context.SaveChanges();
                var assignemntTagsList = assignmentService.GetAllAssignmentTags(1);

                //Assert
                assignemntTagsList.Should().NotBeNull();
                assignemntTagsList.Should().Equals(listAssTags);
            }
        }

        [Fact]
        public void CheckAssignmentToEditDetailsAreEqualLikeModel()
        {
            //Arrange
            NewAssignmentVm assignmentToAdd = new NewAssignmentVm()
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
                var assignmentService = new AssignmentService(mapper, new AssignmentRepository(context));
                assignmentService.AddAssignment(assignmentToAdd);
                var result = assignmentService.GetAssignmentForEdit(1);

                //Assert
                result.Should().NotBeNull();
                result.Should().Equals(assignmentToAdd);
                context.Employers.FirstOrDefaultAsync(e => e.Id == result.Id).Should().NotBeNull();
            }
        }

        [Fact]
        public void UpdatedAssignmentShoundBeLikeAssignmentToUpdate()
        {
            //Arrange
            NewAssignmentVm assignment = new NewAssignmentVm()
            {
                Id = 1,
                Name = "test"
            };

            List<int> listOfTagsIds = new List<int> { 1, 2 };

            NewAssignmentVm assignmentToUpdate = new NewAssignmentVm()
            {
                Id = 1,
                Name = "test1",
                TagsId = listOfTagsIds
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
                var assignmentService = new AssignmentService(mapper, new AssignmentRepository(context));
                assignmentService.AddAssignment(assignment);
            }

            using (var context = new Context(options))
            {
                var assignmentService = new AssignmentService(mapper, new AssignmentRepository(context));
                assignmentService.UpdateAssignment(assignmentToUpdate);

                //Assert
                context.Assignments.FirstOrDefaultAsync(e => e.Id == 1).Should().Equals(assignmentToUpdate);
            }
        }

        [Fact]
        public void CheckPrepareNewAssignmentVmReturnsProperModel()
        {
            //Arrange
            NewAssignmentVm assignment = new NewAssignmentVm();            

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
                var assignmentService = new AssignmentService(mapper, new AssignmentRepository(context));
                assignmentService.PrepareNewAssignmentVm();

                //Assert
                assignmentService.Should().Equals(assignment);
            }
        }
    }
}
