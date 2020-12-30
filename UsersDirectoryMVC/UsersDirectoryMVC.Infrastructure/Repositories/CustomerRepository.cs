using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public int AddCustomer(Customer customer)
        {
            customer.IsActive = true;
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer.Id;
        }

        public Customer GetCustomer(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(a => a.Id == customerId);
            return customer;
        }

        public IQueryable<Customer> GetAllActiveCustomers()
        {
            var customers = _context.Customers.Where(a => a.IsActive);
            return customers;
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).Property("Name").IsModified = true;
            _context.Entry(customer).Property("NIP").IsModified = true;
            _context.SaveChanges();
        }

        public CustomerContactInformation GetCustomerContactInfos(int customerId)
        {
            var custInfos = _context.CustomerContactInformations.FirstOrDefault(c => c.CustomerRef == customerId);
            return custInfos;
        }

        public void UpdateCustomerContactInfo(CustomerContactInformation customerInfos)
        {
            var model = _context.CustomerContactInformations.FirstOrDefault(m => m.CustomerRef == customerInfos.CustomerRef);
            model.FirstName = customerInfos.FirstName;
            model.LastName = customerInfos.LastName;
            _context.Attach(model);
            _context.Entry(model).Property("FirstName").IsModified = true;
            _context.Entry(model).Property("LastName").IsModified = true;

            _context.SaveChanges();
        }
    }
}
