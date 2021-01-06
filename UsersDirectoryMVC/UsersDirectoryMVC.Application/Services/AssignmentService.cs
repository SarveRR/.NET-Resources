using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.Assignment;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Application.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public AssignmentService(IMapper mapper, IAssignmentRepository assignmentRepository)
        {
            _mapper = mapper;
            _assignmentRepository = assignmentRepository;
        }

        public int AddAssignment(NewAssignmentVm assignment)
        {
            var assignmentVm = _mapper.Map<Assignment>(assignment);
            var id = _assignmentRepository.AddAssignment(assignmentVm);
            return id;
        }

        private void AddTagsForAssignment(int id, List<int> tagsIdList)
        {
            _assignmentRepository.DeleteTags(id);

            foreach (var item in tagsIdList)
            {
                var add = new AssignmentTagVm
                {
                    AssignmentId = id,
                    TagId = item
                };
                var listOfTags = _mapper.Map<AssignmentTag>(add);
                _assignmentRepository.AddNewTags(listOfTags);
            } 
        }

        public void DeleteAssignment(int id)
        {
            _assignmentRepository.DeleteAssignment(id);
        }

        public ListAssignmentForListVm GetAllActiveAssignmentsForList(int pageSize, int pageNumber, string searchString)
        {
            var assignments = _assignmentRepository.GetAllActiveAssignments().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<AssignmentForListVm>(_mapper.ConfigurationProvider).ToList();
            var assignmentsToShow = assignments.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var assignmentList = new ListAssignmentForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNumber,
                SearchString = searchString,
                Assignments = assignmentsToShow,
                Count = assignments.Count
            };
            return assignmentList;
        }

        public AssignmentDetailsVm GetAssignmentDetails(int id)
        {
            var assignment = _assignmentRepository.GetAssignment(id);
            var assignmentVm = _mapper.Map<AssignmentDetailsVm>(assignment);

            if (assignmentVm == null) return null;

            var tags = GetAllAssignmentTags(id);
            assignmentVm.Tags = new List<TagsVm>();

            foreach (var item in tags)
            {
                var assignmentTagVm = _mapper.Map<AssignmentTagVm>(item);
                var tagForList = _assignmentRepository.GetTag(assignmentTagVm.TagId);
                var tagForListVm = _mapper.Map<TagsVm>(tagForList);

                var add = new TagsVm
                {
                    Id = tagForListVm.Id,
                    Name = tagForListVm.Name
                };
                assignmentVm.Tags.Add(add);
            }
            return assignmentVm;
        }

        public List<AssignmentTag> GetAllAssignmentTags(int id)
        {
            var tags = _assignmentRepository.GetAllTagsForAssignment(id);
            return tags;
        }

        public NewAssignmentVm GetAssignmentForEdit(int id)
        {
            var assignemnt = _assignmentRepository.GetAssignment(id);
            var assignemntVm = _mapper.Map<NewAssignmentVm>(assignemnt);

            var tags = GetAllAssignmentTags(id);
            var listOfTagsId = new List<int>();
            foreach (var tagId in tags)
            {
                listOfTagsId.Add(tagId.TagId);
            }
            assignemntVm.TagsId = listOfTagsId;
            var model = _assignmentRepository.GetAllTags();

            assignemntVm.Tags = new List<Tag>();

            foreach (var tag in model)
            {
                var add = new Tag
                {
                    Id = tag.Id,
                    Name = tag.Name
                };
                assignemntVm.Tags.Add(add);
            }

            return assignemntVm;
        }

        public void UpdateAssignment(NewAssignmentVm model)
        {
            var tagsIdList = new List<int>();
            foreach (var item in model.TagsId)
            {
                tagsIdList.Add(item);
            }
            AddTagsForAssignment(model.Id, tagsIdList);

            var assignment = _mapper.Map<Assignment>(model);
            _assignmentRepository.UpdateAssignment(assignment);
        }

        public NewAssignmentVm PrepareNewAssignmentVm()
        {
            var model = _assignmentRepository.GetAllTags();

            var completeModel = new NewAssignmentVm();

            completeModel.Tags = new List<Tag>();

            foreach (var tag in model)
            {
                var add = new Tag
                {
                    Id = tag.Id,
                    Name = tag.Name
                };
                completeModel.Tags.Add(add);
            }

            return completeModel;
        }
    }
}
