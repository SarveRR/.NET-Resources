using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Application.ViewModels.Customer
{
    public class CustomerDetailsVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string CEOFullName { get; set; }
        public string FirstLineOfContactInformation { get; set; }
        public List<AddressForListVm> Addresses { get; set; }
        public List<ContactDetailListVm> Emails { get; set; }
        public List<ContactDetailListVm> PhoneNumbers { get; set; }
    }
}
