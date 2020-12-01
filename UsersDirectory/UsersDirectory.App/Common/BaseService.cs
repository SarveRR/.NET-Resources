using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectory.App.Abstract;
using UsersDirectory.Domain.Common;

namespace UsersDirectory.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
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
            return Users;
        }

        public void RemoveUser(T user)
        {
            Users.Remove(user);
        }

        public int UpdateUser(T user)
        {
            var entity = Users.FirstOrDefault(p => p.Id == user.Id);
            if(entity != null)
            {
                entity = user;
            }
            return entity.Id;
        }
    }
}
