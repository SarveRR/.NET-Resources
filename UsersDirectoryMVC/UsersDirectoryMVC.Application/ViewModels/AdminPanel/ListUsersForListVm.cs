using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Application.ViewModels.AdminPanel
{
    public class ListUsersForListVm
    {
        public List<UserForListVm> Users { get; set; }
        public int Count { get; set; }
    }
}
