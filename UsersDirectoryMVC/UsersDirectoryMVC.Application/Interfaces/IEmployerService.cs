using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.ViewModels.Employer;

namespace UsersDirectoryMVC.Application.Interfaces
{
    public interface IEmployerService
    {
        ListEmployerForListVm GetAllActiveEmplyersForList(int pageSize, int pageNumber, string searchString);
        int AddEmployer(NewEmployerVm employer);
        EmployerDetailsVm GetEmployerDetails(int id);
        NewEmployerVm GetEmployerForEdit(int id);
        void UpdateEmployer(NewEmployerVm model);
        void DeleteEmployer(int id);
    }
}
