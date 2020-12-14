using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Infrastructure.Repositories
{
    public class EmployerRepository : IEmployerRepository
    {
        private readonly Context _context;

        public EmployerRepository(Context context)
        {
            _context = context;
        }

        public void DeleteEmployer(int employerId)
        {
            var employer = _context.Employers.Find(employerId);
            if (employer != null)
            {
                _context.Employers.Remove(employer);
                _context.SaveChanges();
            }
        }

        public int AddEmployer(Employer employer)
        {
            _context.Employers.Add(employer);
            _context.SaveChanges();
            return employer.Id;
        }

        public Employer GetEmployerById(int employerId)
        {
            var employer = _context.Employers.FirstOrDefault(a => a.Id == employerId);
            return employer;
        }

        public IQueryable<Employer> GetAllEmployers()
        {
            var employers = _context.Employers;
            return employers;
        }
    }
}
