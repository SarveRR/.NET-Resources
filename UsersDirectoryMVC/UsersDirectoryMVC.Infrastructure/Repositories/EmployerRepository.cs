using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Infrastructure.Repositories
{
    public class EmployerRepository
    {
        private readonly Context _context;

        public EmployerRepository(Context context)
        {
            _context = context;
        }
    }
}
