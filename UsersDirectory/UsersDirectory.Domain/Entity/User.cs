using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectory.Domain.Common;

namespace UsersDirectory.Domain.Entity
{
    public class User : BaseEntity
    {
        public User(int id, string name, string surname, string city)
        {
            Name = name;
            SurName = surname;
            City = city;
        }
    }
}
