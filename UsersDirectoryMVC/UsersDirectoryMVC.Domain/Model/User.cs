using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }
    }
}
