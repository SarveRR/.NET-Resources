using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectory.App.Common;

namespace UsersDirectory.App
{
    public class UserService : BaseService<User>
    {
        public List<User> Users { get; set; }
        public UserService()
        {
            Users = new List<User>();
        }

        public (int,string,string,string) AddNewUserView(MenuActionService actionService)
        {
            Console.WriteLine("Enter new user id:");
            var id = Console.ReadLine();
            int userId;
            Int32.TryParse(id, out userId);
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("City:");
            string city = Console.ReadLine();
            Console.Clear();

            return (userId, name, surname, city);
        }

        public int AddNewUser(int userId, string name, string surName, string city)
        {
            User user = new User();

            user.Id = userId;
            user.Name = name;
            user.SurName = surName;
            user.City = city;

            Users.Add(user);

            return user.Id;
        }

        public int RemoveUserView()
        {
            Console.WriteLine("Enter user id you want to remove:");
            var userId = Console.ReadKey();
            Console.Clear();
            int id;
            Int32.TryParse(userId.KeyChar.ToString(), out id);

            return id;
        }

        public void RemoveUser(int removeId)
        {
            User userToRemove = new User();
            foreach (var user in Users)
            {
                if(removeId == user.Id)
                {
                    userToRemove = user;
                    break;
                }
            }
            Users.Remove(userToRemove);
        }

        public int UserDetailSelectionView()
        {
            Console.WriteLine("Enter user id you want to show:");
            var userId = Console.ReadKey();
            Console.Clear();
            int id;
            Int32.TryParse(userId.KeyChar.ToString(), out id);

            return id;
        }

        public void UserDetailView(int detailId)
        {
            User userToShow = new User();
            foreach (var user in Users)
            {
                if (detailId == user.Id)
                {
                    userToShow = user;
                    break;
                }
            }
            Console.WriteLine("Id: " + userToShow.Id);
            Console.WriteLine("Name: " + userToShow.Name);
            Console.WriteLine("Surname: " + userToShow.SurName);
            Console.WriteLine("City: " + userToShow.City);
            Console.WriteLine("\nPress any key to back to menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public string UserByCitySelectionView()
        {
            Console.WriteLine("Enter city for users you want to show:");
            var cityName = Console.ReadLine();
            Console.Clear();

            return cityName.ToString();
        }

        public void UserByCityView(string cityName)
        {
            List<User> usersToShow = new List<User>();
            foreach (var user in Users)
            {
                if (cityName == user.City)
                {
                    usersToShow.Add(user);
                }
            }
            foreach (var user in usersToShow)
            {
                Console.WriteLine("Id: " + user.Id+" name: " + user.Name + " surname: " + user.SurName + " city: " + user.City);
            }
            Console.WriteLine("\nPress any key to back to menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
