using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.ViewModels.Customer;

namespace UsersDirectoryMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        ListCustomerForListVm GetAllActiveCustomersForList(int pageSize, int PageNumber, string searchString);
        int AddCustomer(NewCustomerVm customer);
        CustomerDetailsVm GetCustomerDetails(int customerId);
    }
}
