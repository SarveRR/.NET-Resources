using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Infrastructure.Repositories
{
    public class AssignmentRepository
    {
        private readonly Context _context;

        public AssignmentRepository(Context context)
        {
            _context = context;
        }
    }
}
