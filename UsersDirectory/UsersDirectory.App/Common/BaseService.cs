using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectory.App.Abstract;

namespace UsersDirectory.App.Common
{
    public class BaseService<T> : IService<T>
    {
        public List<T> Users { get; set; }

        public BaseService()
        {
            Users = new List<T>();
        }

        public int AddUser(T user)
        {
            Users.Add(user);
            return user.Id;
        }

        public List<T> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(T user)
        {
            throw new NotImplementedException();
        }

        public int UpdateUser(T user)
        {
            throw new NotImplementedException();
        }
    }
}
