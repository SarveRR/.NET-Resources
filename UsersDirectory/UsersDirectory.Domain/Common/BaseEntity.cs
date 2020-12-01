using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectory.Domain.Common
{
    public class BaseEntity : AuditableModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
    }
}
