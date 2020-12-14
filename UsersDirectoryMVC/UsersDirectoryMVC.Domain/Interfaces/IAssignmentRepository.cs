using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Domain.Interfaces
{
    public interface IAssignmentRepository
    {
        void DeleteAssignment(int assignmentId);

        int AddAssignment(Assignment assignment);

        Assignment GetAssignmentById(int assignmentId);

        IQueryable<Assignment> GetAllEmployers();
    }
}
