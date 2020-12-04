using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UsersDirectory.App.Abstract;
using UsersDirectory.App.Concrete;
using UsersDirectory.Domain.Common;
using UsersDirectory.Domain.Entity;

namespace UsersDirectory.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Users { get; set; }
        public BaseService()
        {
            Users = new List<T>();
        }

        public int GetLastId()
        {
            int lastId;
            if(Users.Any())
            {
                lastId = Users.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public int AddUser(T user)
        {
            Users.Add(user);
            return user.Id;
        }

        public List<T> GetAllUsers()
        {
            foreach (var user in Users)
            {
                Console.WriteLine("Id: " + user.Id + " name: " + user.Name + " surname: " + user.SurName + " city: " + user.City);
            }
            Console.WriteLine("\nPress any key to back to menu...");
            Console.ReadKey();
            Console.Clear();

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
                entity.Name = user.Name;
                entity.SurName = user.SurName;
                entity.City = user.City;
            }
            return entity.Id;
        }

        public int GetUserDetails(T user)
        {
            Console.WriteLine("Id: " + user.Id);
            Console.WriteLine("Name: " + user.Name);
            Console.WriteLine("Surname: " + user.SurName);
            Console.WriteLine("City: " + user.City);
            Console.WriteLine("\nPress any key to back to menu...");
            Console.ReadKey();
            Console.Clear();

            return user.Id;
        }

        public void GetUserByCity(List<T> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine("Id: " + user.Id + " name: " + user.Name + " surname: " + user.SurName + " city: " + user.City);
            }
            Console.WriteLine("\nPress any key to back to menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public T GetUserById(int id)
        {
            var entity = Users.FirstOrDefault(p => p.Id == id);
            return entity;
        }
    }
}
