using ProtoBoatRazorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Interfaces
{
    public interface IUserRepository
    {
        Dictionary<int,User> GetAllUsers();
        Dictionary<int, User> FilterUser(string criteria);
        void AddUser(User user);
        void UpdateUser(User user);
        User GetUser(int id);
        void DeleteUser(User user);

    }
}
