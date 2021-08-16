using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Services
{
    public class UserCatalog:IUserRepository
    {
        private Dictionary<int, User> users { get; }
        //private static UserCatalog _instance;
        public UserCatalog()
        {
            users = new Dictionary<int, User>();
            users.Add(1, new User() { Id = 1, Name = "Arsen"});
            users.Add(2, new User() { Id = 2, Name = "Jim" });
        }
        //public static UserCatalog Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new UserCatalog();
        //        }
        //        return _instance;
        //    }
        //}
        public Dictionary<int, User> GetAllUsers()
        {
            return users;
        }

        public void AddUser(User user)
        {
            if (!(users.Keys.Contains(user.Id)))
                users.Add(user.Id, user);
        }
        public Dictionary<int, User> FilterUser(string criteria)
        {
            Dictionary<int, User> myUser = new Dictionary<int, User>();
            if(criteria != null)
            {
                foreach(var u in users.Values)
                {
                    if (u.Name.StartsWith(criteria))
                    {
                        myUser.Add(u.Id, u);
                    }
                }
            }
            return myUser;
        }

        public void UpdateUser(User user)
        {
            foreach(var us in users.Values)
            {
                if (us.Id == user.Id)
                {
                    us.Id = user.Id;
                    us.Name = user.Name;
                }
            }
        }

        public User GetUser(int id)
        {
            foreach (var u in GetAllUsers())
            {
                if (u.Key == id)
                    return u.Value;
            }
            return new User();
        }

        public void DeleteUser(User user)
        {
            if(user != null)
            {
                users.Remove(user.Id);
            }
        }
    }
}
