using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Domain.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string FlatNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public CustomerContactInformation CustomerContact { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
