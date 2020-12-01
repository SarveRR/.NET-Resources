using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectory.App.Common;
using UsersDirectory.Domain.Entity;

namespace UsersDirectory.App
{
    public class UserService : BaseService<User>
    {
        //public List<User> Users { get; set; }
        //public UserService()
        //{
        //    Users = new List<User>();
        //}



        //public int UserDetailSelectionView()
        //{
        //    Console.WriteLine("Enter user id you want to show:");
        //    var userId = Console.ReadKey();
        //    Console.Clear();
        //    int id;
        //    Int32.TryParse(userId.KeyChar.ToString(), out id);

        //    return id;
        //}

        //public void UserDetailView(int detailId)
        //{
        //    User userToShow = new User();
        //    foreach (var user in Users)
        //    {
        //        if (detailId == user.Id)
        //        {
        //            userToShow = user;
        //            break;
        //        }
        //    }
        //    Console.WriteLine("Id: " + userToShow.Id);
        //    Console.WriteLine("Name: " + userToShow.Name);
        //    Console.WriteLine("Surname: " + userToShow.SurName);
        //    Console.WriteLine("City: " + userToShow.City);
        //    Console.WriteLine("\nPress any key to back to menu...");
        //    Console.ReadKey();
        //    Console.Clear();
        //}

        //public string UserByCitySelectionView()
        //{
        //    Console.WriteLine("Enter city for users you want to show:");
        //    var cityName = Console.ReadLine();
        //    Console.Clear();

        //    return cityName.ToString();
        //}

        //public void UserByCityView(string cityName)
        //{
        //    List<User> usersToShow = new List<User>();
        //    foreach (var user in Users)
        //    {
        //        if (cityName == user.City)
        //        {
        //            usersToShow.Add(user);
        //        }
        //    }
        //    foreach (var user in usersToShow)
        //    {
        //        Console.WriteLine("Id: " + user.Id+" name: " + user.Name + " surname: " + user.SurName + " city: " + user.City);
        //    }
        //    Console.WriteLine("\nPress any key to back to menu...");
        //    Console.ReadKey();
        //    Console.Clear();
        //}
    }
}
