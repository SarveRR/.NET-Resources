using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectory.App.Abstract
{
    public interface IService<T>
    {
        List<T> Users { get; set; }
        List<T> GetAllUsers();
        int AddUser(T user);
        int UpdateUser(T user);
        void RemoveUser(T user);
    }
}
