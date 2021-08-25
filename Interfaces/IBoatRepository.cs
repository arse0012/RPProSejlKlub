using ProtoBoatRazorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Interfaces
{
    public interface IBoatRepository
    {
        void AddBoat(Boat boat);
        Boat GetBoat(int id);
        void UpdateBoat(Boat boat);
        void DeleteBoat(Boat boat);
        Dictionary<int, Boat> GetAllBoats();
        Dictionary<int, Boat> FilterBoat(string criteria);
    }
}
