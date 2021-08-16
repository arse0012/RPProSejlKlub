using ProtoBoatRazorPage.Helpers;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Repository
{
    public class JsonUserRepository : IUserRepository
    {
        string JsonFileName = @"C:\Users\arsen\source\repos\ProtoBoatRazorPage\Data\JsonUser.json";
        public void AddUser(User user)
        {
            Dictionary<int, User> users = GetAllUsers();
            List<int> userIds = new List<int>();
            foreach (var u in users)
            {
                userIds.Add(u.Value.Id);

            }
            if (userIds.Count != 0)
            {
                int start = userIds.Max();
                user.Id = start + 1;
            }
            else
            {
                user.Id = 1;
            }
            users.Add(user.Id, user);
            JsonFileWritter.WriteToJsonUser(users, JsonFileName);
        }

        public void DeleteUser(User user)
        {
            Dictionary<int, User> users = GetAllUsers();
            users.Remove(user.Id);
            JsonFileWritter.WriteToJsonUser(users, JsonFileName);
        }

        public Dictionary<int, User> FilterUser(string criteria)
        {
            Dictionary<int, User> users = GetAllUsers();
            Dictionary<int, User> filteredUsers = new Dictionary<int, User>();
            foreach (var u in users.Values)
            {
                if (u.Name.StartsWith(criteria))
                {
                    filteredUsers.Add(u.Id, u);
                }
            }
            return filteredUsers;
        }

        public Dictionary<int, User> GetAllUsers()
        {
            Dictionary<int, User> returnList = JsonFileReader.ReadJsonUser(JsonFileName);
            return returnList;
        }

        public User GetUser(int id)
        {
            foreach(var u in GetAllUsers())
            {
                if (u.Key == id)
                    return u.Value;
            }
            return new User();
        }
        public void UpdateUser(User user)
        {
            Dictionary<int, User> users = GetAllUsers();
            User foundUser = users[user.Id];
            foundUser.Id = user.Id;
            foundUser.Name = user.Name;
            foundUser.LastName = user.LastName;
            foundUser.Mail = user.Mail;
            foundUser.PhoneNumber = user.PhoneNumber;
            JsonFileWritter.WriteToJsonUser(users, JsonFileName);
        }
    }
}
