using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.Customer;
using UsersDirectoryMVC.Domain.Interfaces;

namespace UsersDirectoryMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {

        }
        public int AddCustomer(NewCustomerVm customer)
        {
            throw new NotImplementedException();
        }

        public ListCustomerForListVm GetAllCustomersForList()
        {
            var customers = _customerRepository.GetAllActiveCustomers();
            ListCustomerForListVm result = new ListCustomerForListVm();
            result.Customers = new List<CustomerForListVm>();
            foreach(var customer in customers)
            {
                var customerVm = new CustomerForListVm()
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    NIP = customer.NIP
                };
                result.Customers.Add(customerVm);
            }
            result.Count = result.Customers.Count;
            return result;
        }

        public CustomerDetailsVm GetCustomerDetails(int customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var customerVm = new CustomerDetailsVm();
            customerVm.Id = customer.Id;
            customerVm.Name = customer.Name;
            customerVm.NIP = customer.NIP;
            customerVm.CEOFullName = customer.CEOFisrtName + " " + customer.CEOLastName;
            var customerContactInfo = customer.CustomerContactInformation;
            customerVm.FirstLineOfContactInformation = customerContactInfo.FirstName + " " + customerContactInfo.LastName;

            customerVm.Addresses = new List<AddressForListVm>();
            customerVm.PhoneNumbers = new List<ContactDetailListVm>();
            customerVm.Emails = new List<ContactDetailListVm>();

            foreach (var address in customer.Addresses)
            {
                var add = new AddressForListVm
                {
                    Id = address.Id,
                    Country = address.Country,
                    City = address.City
                };
                customerVm.Addresses.Add(add);
            }
            return customerVm;
        }
    }
}
