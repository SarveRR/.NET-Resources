using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Domain.Model
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AppUser> AppUsers { get; set; }
    }
}
