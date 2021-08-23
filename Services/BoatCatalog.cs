using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Services
{
    public class BoatCatalog
    {
        private Dictionary<int, Boat> boats { get; }
        //private static BoatCatalog _instance;
        public BoatCatalog()
        {
            boats = new Dictionary<int, Boat>();
            boats.Add(1, new Boat() { Id = 1, Name = "test", Type = "Long", 
                Description = "new", DateTime = new DateTime(2020, 6, 9, 10, 0, 0) });
            boats.Add(2, new Boat() { Id = 2, Name = "test2", Type = "Short", 
                Description = "old", DateTime = new DateTime(2020, 2, 3, 12, 0, 0) });
        }
        //public static BoatCatalog Instance
        //{
        //    get
        //    {
        //        if(_instance== null)
        //        {
        //            _instance = new BoatCatalog();
        //        }
        //        return _instance;
        //    }
        //}
        public void AddBoat(Boat boat)
        {
            if (!(boats.Keys.Contains(boat.Id)))
                boats.Add(boat.Id, boat);
        }
        public Dictionary<int, Boat> FilterBoat(string criteria)
        {
            Dictionary<int, Boat> myBoat = new Dictionary<int, Boat>();
            if(criteria != null)
            {
                foreach(var b in boats.Values)
                {
                    if (b.Name.StartsWith(criteria))
                    {
                        myBoat.Add(b.Id, b);
                    }
                }
            }
            return myBoat;
        }
        public void DeleteBoat(Boat boat)
        {
            if(boat != null)
            {
                boats.Remove(boat.Id);
            }
        }
        public Dictionary<int, Boat> GetAllBoats()
        {
            return boats;
        }

        public Boat GetBoat(int id)
        {
            foreach(var b in GetAllBoats())
            {
                if (b.Key == id)
                    return b.Value;
            }
            return new Boat(); 
        }

        public void UpdateBoat(Boat boat)
        {
            foreach(var bt in boats.Values)
            {
                if (bt.Id == boat.Id)
                {
                    bt.Id = boat.Id;
                    bt.Name = boat.Name;
                    bt.Type = boat.Type;
                    bt.Description = boat.Description;
                    bt.DateTime = boat.DateTime;
                }
            }   
        }
    }
}
