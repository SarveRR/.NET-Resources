using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using UsersDirectory.App.Abstract;
using UsersDirectory.App.Common;
using UsersDirectory.Domain.Entity;

namespace UsersDirectory.App.Concrete
{
    public class ListService
    {
        private readonly string path = @"E:\Programowanie\Repos GIT\.NET-Resources\UsersDirectory\UsersDirectory.App\Data\users.json";
        private IService<User> _userService;
        JsonSerializer serializer = new JsonSerializer();
        public ListService(IService<User> userService)
        {
            _userService = userService;
        }
        public void SaveDataToJsonFile()
        {
            StreamWriter sw = new StreamWriter(path);
            JsonWriter writer = new JsonTextWriter(sw);

            serializer.Serialize(writer, _userService.Users);
            writer.Close();
            sw.Close();
        }

        public void ReadDataFromJsonFile()
        {
            if (File.Exists(path) == false)
            {
                StreamWriter createFile = new StreamWriter(path);
                createFile.Close();
            }

            StreamReader sr = new StreamReader(path);
            JsonReader reader = new JsonTextReader(sr);
            var usersList1 = serializer.Deserialize<List<User>>(reader);
            reader.Close();
            sr.Close();

            if (usersList1 == null)
            {
                List<User> listToSave = new List<User>();
                listToSave.Add(new User(1, "Name", "Surname", "City"));
                StreamWriter sw = new StreamWriter(path);
                JsonWriter writer = new JsonTextWriter(sw);
                serializer.Serialize(writer, listToSave);
                sw.Close();
                writer.Close();
            }
            //read file without problem "file doesnt exist" and "empty file"
            StreamReader sr1 = new StreamReader(path);
            JsonReader reader1 = new JsonTextReader(sr1);
            var usersList2 = serializer.Deserialize<List<User>>(reader1);
            _userService.Users.AddRange(usersList2);

            reader1.Close();
            sr1.Close();

        }
    }
}
