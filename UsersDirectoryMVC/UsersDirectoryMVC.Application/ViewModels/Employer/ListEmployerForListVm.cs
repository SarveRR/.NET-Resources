using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Application.ViewModels.Employer
{
    public class ListEmployerForListVm
    {
        public List<EmployerForListVm> Employers { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
