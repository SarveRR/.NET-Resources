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

        public CustomerContactInformation CustomerContact { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
    }
}
