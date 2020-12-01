﻿using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectory.Domain.Common;

namespace UsersDirectory.Domain.Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string City { get; set; }
    }
}
