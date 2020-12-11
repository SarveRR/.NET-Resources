using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Domain.Model
{
    public class CustomerContactInformation
    {
        public int Id { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }

        public int CustomerRef { get; set; }
        public Customer Customer { get; set; }
    }
}
