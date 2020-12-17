using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.ViewModels.Customer;

namespace UsersDirectoryMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        ListCustomerForListVm GetAllCustomersForList();
        int AddCustomer(NewCustomerVm customer);
        CustomerDetailsVm GetCustomerDetails(int customerId);
    }
}
