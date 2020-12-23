using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Application.Interfaces
{
    public interface IAssignmentService
    {
        ListAssignmentForListVm GetAllActiveAssignmentsForList(int pageSize, int pageNumber, string searchString);
        int AddAssignment(NewAssignmentVm assignment);
        AssignmentDetailsVm GetAssignmentDetails(int id);
        NewAssignmentVm GetAssignmentForEdit(int id);
        void UpdateAssignment(NewAssignmentVm model);
        void DeleteAssignment(int id);
    }
}
