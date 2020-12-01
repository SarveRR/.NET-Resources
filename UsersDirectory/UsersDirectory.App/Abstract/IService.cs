using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectory.Domain.Entity;

namespace UsersDirectory.App.Abstract
{
    public interface IService<T>
    {
        List<T> Users { get; set; }
        List<T> GetAllUsers();
        int AddUser(T user);
        int UpdateUser(T user);
        void RemoveUser(T user);
        int GetUserDetails(T user);
        void GetUserByCity(List<T> users);
        T GetUserById(int id);
        int GetLastId();
    }
}
