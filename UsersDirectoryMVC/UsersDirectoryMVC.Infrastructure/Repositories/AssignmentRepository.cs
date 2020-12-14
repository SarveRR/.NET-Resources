using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Infrastructure.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly Context _context;

        public AssignmentRepository(Context context)
        {
            _context = context;
        }

        public void DeleteAssignment(int assignmentId)
        {
            var assignment = _context.Assignments.Find(assignmentId);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                _context.SaveChanges();
            }
        }

        public int AddAssignment(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            _context.SaveChanges();
            return assignment.Id;
        }

        public Assignment GetAssignmentById(int assignmentId)
        {
            var assignment = _context.Assignments.FirstOrDefault(a => a.Id == assignmentId);
            return assignment;
        }

        public IQueryable<Assignment> GetAllEmployers()
        {
            var assignments = _context.Assignments;
            return assignments;
        }
    }
}
