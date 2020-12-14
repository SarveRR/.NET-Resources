using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        void DeleteCustomer(int customerId);

        int AddCustomer(Customer customer);

        Customer GetCustomerById(int customerId);

        IQueryable<Customer> GetAllCustomers();
    }
}
