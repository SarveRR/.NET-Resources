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

        public Employer GetEmployer(int employerId)
        {
            var employer = _context.Employers.FirstOrDefault(a => a.Id == employerId);
            return employer;
        }

        public IQueryable<Employer> GetAllActiveEmployers()
        {
            var employers = _context.Employers;
            return employers;
        }

        public void UpdateEmployer(Employer employer)
        {
            _context.Attach(employer);
            _context.Entry(employer).Property("Name").IsModified = true;
            _context.Entry(employer).Property("NIP").IsModified = true;
            _context.SaveChanges();
        }
    }
}
