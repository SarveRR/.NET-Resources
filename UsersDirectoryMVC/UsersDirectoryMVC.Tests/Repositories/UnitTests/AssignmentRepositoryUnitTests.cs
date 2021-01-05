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
    public class AssignmentRepositoryUnitTests
    {
        [Fact]
        public void CheckAssignmentExistAfterDelete()
        {
            //Arrange
            Assignment assignment1 = new Assignment()
            {
                Id = 66,
                Name = "test",
                Description = "unit"
            };
            Assignment assignment2 = new Assignment()
            {
                Id = 77,
                Name = "test",
                Description = "unit"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var assignmentRepository = new AssignmentRepository(context);
                assignmentRepository.AddAssignment(assignment1);
                assignmentRepository.AddAssignment(assignment2);
                assignmentRepository.DeleteAssignment(66);
                var gerAssignment1 = assignmentRepository.GetAssignment(66);
                var gerAssignment2 = assignmentRepository.GetAssignment(77);
                //Assert
                gerAssignment1.Should().BeNull();
                gerAssignment2.Should().Equals(assignment2);
            }
        }

        [Fact]
        public void CheckAssignmentIdExistAfterAdd()
        {
            //Arrange
            Assignment assignment = new Assignment()
            {
                Id = 66,
                Name = "test",
                Description = "unit"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var assignmentRepository = new AssignmentRepository(context);
                var assignmentResult = assignmentRepository.AddAssignment(assignment);

                //Assert
                assignmentResult.Should().Equals(assignment.Id);
            }
        }

        [Fact]
        public void GetListOfAddedAssignmentsAndCheckAreEqualLikeModels()
        {
            //Arrange
            Assignment assignment1 = new Assignment()
            {
                Id = 66,
                Name = "test",
                Description = "unit"
            };

            Assignment assignment2 = new Assignment()
            {
                Id = 67,
                Name = "test1",
                Description = "unit1"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var assignmentRepository = new AssignmentRepository(context);
                assignmentRepository.AddAssignment(assignment1);
                assignmentRepository.AddAssignment(assignment2);

                var listOfAssignments = assignmentRepository.GetAllActiveAssignments();

                //Assert
                listOfAssignments.FirstOrDefault(e => e.Id == 66).Should().Equals(assignment1);
                listOfAssignments.FirstOrDefault(e => e.Id == 67).Should().Equals(assignment2);
            }
        }

        [Fact]
        public void ShouldUpdateAssignmentNameAnDescription()
        {
            //Arrange
            Assignment assignment = new Assignment()
            {
                Id = 66,
                Name = "test",
                Description = "unit"
            };

            Assignment updatedAssignment = new Assignment()
            {
                Id = 66,
                Name = "test1",
                Description = "unit1"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var assignmentRepository = new AssignmentRepository(context);
                assignmentRepository.AddAssignment(assignment);
            }

            using (var context = new Context(options))
            {
                //Act
                var assignmentRepository = new AssignmentRepository(context);
                //
                assignmentRepository.UpdateAssignment(updatedAssignment);
                var assignmentToCheckAfterUpdate = assignmentRepository.GetAssignment(66);

                //Assert
                assignmentToCheckAfterUpdate.Should().NotBeNull();
                assignmentToCheckAfterUpdate.Name.Should().Equals(updatedAssignment.Name);
                assignmentToCheckAfterUpdate.Description.Should().Equals(updatedAssignment.Description);
            }
        }

        [Fact]
        public void GetAllTagsForAssignmentToListAndCheckAreEqualLikeModelsList()
        {
            //Arrange
            AssignmentTag assignmentTag1 = new AssignmentTag()
            {
                AssignmentId = 1,
                TagId = 1
            };

            AssignmentTag assignmentTag2 = new AssignmentTag()
            {
                AssignmentId = 1,
                TagId = 2
            };

            List<AssignmentTag> listOfTags = new List<AssignmentTag>();
            listOfTags.Add(assignmentTag1);
            listOfTags.Add(assignmentTag2);

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var assignmentRepository = new AssignmentRepository(context);
                assignmentRepository.AddNewTags(assignmentTag1);
                assignmentRepository.AddNewTags(assignmentTag2);
                var assignmentTags = assignmentRepository.GetAllTagsForAssignment(1);

                //Assert
                assignmentTags.Should().Equals(listOfTags);
            }
        }

        [Fact]
        public void GetTagAndCheckAreEqualLikeModel()
        {
            //Arrange
            Tag tag = new Tag()
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
                var assignmentRepository = new AssignmentRepository(context);
                assignmentRepository.AddTag(tag);
                var tagToCheck = assignmentRepository.GetTag(1);

                //Assert
                tagToCheck.Should().Equals(tag);
            }
        }

        [Fact]
        public void GetAllTagsAndCheckAreEqualLikeModelsList()
        {
            //Arrange
            Tag tag1 = new Tag()
            {
                Id = 1,
                Name = "test"
            };

            Tag tag2 = new Tag()
            {
                Id = 2,
                Name = "test1"
            };

            List<Tag> listOfTags = new List<Tag>();
            listOfTags.Add(tag1);
            listOfTags.Add(tag2);

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var assignmentRepository = new AssignmentRepository(context);
                assignmentRepository.AddTag(tag1);
                assignmentRepository.AddTag(tag2);
                var tags = assignmentRepository.GetAllTags();

                //Assert
                tags.Should().Equals(listOfTags);
            }
        }

        [Fact]
        public void CheckAssignmentTagsExistAfterDelete()
        {
            //Arrange
            AssignmentTag assignmentTag1 = new AssignmentTag()
            {
                AssignmentId = 1,
                TagId = 1
            };
            AssignmentTag assignmentTag2 = new AssignmentTag()
            {
                AssignmentId = 1,
                TagId = 2
            };
            AssignmentTag assignmentTag3 = new AssignmentTag()
            {
                AssignmentId = 2,
                TagId = 3
            };
            List<AssignmentTag> thisTagsShouldExist = new List<AssignmentTag>();
            thisTagsShouldExist.Add(assignmentTag3);

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var assignmentRepository = new AssignmentRepository(context);
                assignmentRepository.AddNewTags(assignmentTag1);
                assignmentRepository.AddNewTags(assignmentTag2);
                assignmentRepository.AddNewTags(assignmentTag3);
                assignmentRepository.DeleteTags(1);
                var gerAssignmentTags1 = assignmentRepository.GetAllTagsForAssignment(1);
                var gerAssignmentTags2 = assignmentRepository.GetAllTagsForAssignment(2);
                //Assert
                gerAssignmentTags1.Should().BeEmpty();
                gerAssignmentTags2.Should().Equals(thisTagsShouldExist);
            }
        }

        [Fact]
        public void CheckTagExistAfterDelete()
        {
            //Arrange
            Tag tag1 = new Tag()
            {
                Id = 66,
                Name = "test"
            };
            Tag tag2 = new Tag()
            {
                Id = 77,
                Name = "test"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var assignmentRepository = new AssignmentRepository(context);
                assignmentRepository.AddTag(tag1);
                assignmentRepository.AddTag(tag2);
                assignmentRepository.DeleteTag(66);
                var gerAssignment1 = assignmentRepository.GetTag(66);
                var gerAssignment2 = assignmentRepository.GetTag(77);
                //Assert
                gerAssignment1.Should().BeNull();
                gerAssignment2.Should().Equals(tag2);
            }
        }

        [Fact]
        public void CheckTagExistAfterAdd()
        {
            //Arrange
            Tag tag = new Tag()
            {
                Id = 66,
                Name = "test"
            };

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var assignmentRepository = new AssignmentRepository(context);
                assignmentRepository.AddTag(tag);
                var assignmentResult = assignmentRepository.GetTag(66);

                //Assert
                assignmentResult.Should().NotBeNull();
                assignmentResult.Should().Equals(tag);
            }
        }

        [Fact]
        public void CheckAssignmentTagsListExistAfterAdd()
        {
            //Arrange
            AssignmentTag assignmentTag1 = new AssignmentTag()
            {
                AssignmentId = 1,
                TagId = 1
            };

            AssignmentTag assignmentTag2 = new AssignmentTag()
            {
                AssignmentId = 1,
                TagId = 2
            };

            List<AssignmentTag> thisTagsShouldExist = new List<AssignmentTag>();
            thisTagsShouldExist.Add(assignmentTag1);
            thisTagsShouldExist.Add(assignmentTag2);

            var options = new DbContextOptionsBuilder<Context>()
              .UseInMemoryDatabase(databaseName: "UsersDirectoryMVC")
              .Options;

            using (var context = new Context(options))
            {
                //Act
                var assignmentRepository = new AssignmentRepository(context);
                assignmentRepository.AddNewTags(assignmentTag1);
                assignmentRepository.AddNewTags(assignmentTag2);
                var assignmentResult = assignmentRepository.GetAllTagsForAssignment(1);

                //Assert
                assignmentResult.Should().NotBeNull();
                assignmentResult.Should().Equals(thisTagsShouldExist);
            }
        }
    }
}
