using System;
using System.Collections.Generic;
using System.Text;

namespace UsersDirectory
{
    public class UserService
    {
        public List<User> Users { get; set; }
        public UserService()
        {
            Users = new List<User>();
        }

        public ConsoleKeyInfo AddNewUserView(MenuActionService actionService)
        {
            var addNewUserMenu = actionService.GetMenuActionsByMenuName("AddNewUserMenu");
            Console.WriteLine("Choose city:");
            for (int i = 0; i < addNewUserMenu.Count; i++)
            {
                Console.WriteLine(addNewUserMenu[i].Id + " " + addNewUserMenu[i].Name);
            }
            var opertion = Console.ReadKey();
            Console.Clear();
            return opertion;
        }

        public int AddNewUser(char userType)
        {
            int cityId;
            Int32.TryParse(userType.ToString(), out cityId);
            User user = new User();
            Console.WriteLine("Enter new user id:");
            var id = Console.ReadLine();
            int userId;
            Int32.TryParse(id, out userId);
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Surname:");
            string surname = Console.ReadLine();
            Console.Clear();

            user.CityId = cityId;
            user.Id = userId;
            user.Name = name;
            user.SurName = surname;

            Users.Add(user);
            return userId;
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
            Console.WriteLine("City: " + userToShow.CityId);
            Console.WriteLine("\nPress any key to back to menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public int UserByCitySelectionView()
        {
            Console.WriteLine("Enter city id for users you want to show:");
            var cityId = Console.ReadKey();
            Console.Clear();
            int id;
            Int32.TryParse(cityId.KeyChar.ToString(), out id);

            return id;
        }

        public void UserByCityView(int cityId)
        {
            List<User> usersToShow = new List<User>();
            foreach (var user in Users)
            {
                if (cityId == user.CityId)
                {
                    usersToShow.Add(user);
                }
            }
            foreach (var user in usersToShow)
            {
                Console.WriteLine("Id: " + user.Id+" name: " + user.Name + " surname: " + user.SurName + " city id: " + user.CityId);
            }
            Console.WriteLine("\nPress any key to back to menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
