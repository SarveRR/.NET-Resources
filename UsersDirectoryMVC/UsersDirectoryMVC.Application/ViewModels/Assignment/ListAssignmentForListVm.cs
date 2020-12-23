using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Application.ViewModels.Assignment
{
    public class ListAssignmentForListVm
    {
        public List<AssignmentForListVm> Assignments { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
