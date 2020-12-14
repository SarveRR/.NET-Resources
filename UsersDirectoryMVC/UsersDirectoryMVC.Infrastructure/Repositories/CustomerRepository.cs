using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Infrastructure.Repositories
{
    public class CustomerRepository
    {
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }
    }
}
