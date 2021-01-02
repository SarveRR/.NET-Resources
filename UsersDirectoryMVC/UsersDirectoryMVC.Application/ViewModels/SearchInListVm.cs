using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectoryMVC.Application.ViewModels
{
    public class SearchInListVm
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public string searchString { get; set; }
    }
}
