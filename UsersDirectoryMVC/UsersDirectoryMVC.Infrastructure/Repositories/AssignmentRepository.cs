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

        public Assignment GetAssignment(int assignmentId)
        {
            var assignment = _context.Assignments.FirstOrDefault(a => a.Id == assignmentId);
            return assignment;
        }

        public IQueryable<Assignment> GetAllActiveAssignments()
        {
            var assignments = _context.Assignments;
            return assignments;
        }

        public void UpdateAssignment(Assignment assignment)
        {
            _context.Attach(assignment);
            _context.Entry(assignment).Property("Name").IsModified = true;
            _context.Entry(assignment).Property("Description").IsModified = true;
            _context.SaveChanges();
        }

        public List<AssignmentTag> GetAllTagsForAssignment(int id)
        {
            var tagsForAssignment = _context.AssignmentTag.Where(t => t.AssignmentId == id).ToList();
            return tagsForAssignment;
        }

        public Tag GetTag(int tagId)
        {
            var tag = _context.Tags.FirstOrDefault(t => t.Id == tagId);
            return tag;
        }
    }
}
 