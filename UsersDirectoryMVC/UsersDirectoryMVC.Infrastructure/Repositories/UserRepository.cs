using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Infrastructure.Repositories
{
    public class UserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }
    }
}
