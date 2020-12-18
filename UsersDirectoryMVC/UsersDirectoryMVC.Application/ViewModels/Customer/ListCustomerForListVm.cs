using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Application.ViewModels.Customer
{
    public class ListCustomerForListVm
    {
        public List<CustomerForListVm> Customers { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
