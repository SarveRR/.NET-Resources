using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Domain.Interfaces
{
    public interface IEmployerRepository
    {
        void DeleteEmployer(int employerId);

        int AddEmployer(Employer employer);

        Employer GetEmployer(int employerId);

        IQueryable<Employer> GetAllActiveEmployers();

        void UpdateEmployer(Employer employer);
    }
}
