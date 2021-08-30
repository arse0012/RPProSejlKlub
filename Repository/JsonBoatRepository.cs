using ProtoBoatRazorPage.Helpers;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Repository
{
    public class JsonBoatRepository : IBoatRepository
    {
        string JsonFileName = @"Data\JsonBoat.json";

        public void AddBoat(Boat boat)
        {
            Dictionary<int, Boat> boats = GetAllBoats();
            List<int> boatIds = new List<int>();
            foreach (var b in boats)
            {
                boatIds.Add(b.Value.Id);

            }
            if (boatIds.Count != 0)
            {
                int start = boatIds.Max();
                boat.Id = start + 1;
            }
            else
            {
                boat.Id = 1;
            }
            boat.DateTime=DateTime.Now;
            boats.Add(boat.Id, boat);
            JsonFileWriter.WriteToJsonBoat(boats, JsonFileName);
        }
        public void DeleteBoat(Boat boat)
        {
            Dictionary<int, Boat> boats = GetAllBoats();
            boats.Remove(boat.Id);
            JsonFileWriter.WriteToJsonBoat(boats, JsonFileName);
        }

        public Dictionary<int, Boat> FilterBoat(string criteria)
        {
            Dictionary<int, Boat> boats = GetAllBoats();
            Dictionary<int, Boat> filteredBoats = new Dictionary<int, Boat>();
            foreach(var b in boats.Values)
            {
                if (b.Name.StartsWith(criteria))
                {
                    filteredBoats.Add(b.Id, b);
                }
            }
            return filteredBoats;
        }

        public Dictionary<int, Boat> GetAllBoats()
        {
            Dictionary<int, Boat> returnList = JsonFileReader.ReadJsonBoat(JsonFileName);
            return returnList;
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
            Dictionary<int, Boat> boats = GetAllBoats();
            Boat foundBoat = boats[boat.Id];
            foundBoat.Id = boat.Id;
            foundBoat.Name = boat.Name;
            foundBoat.Type = boat.Type;
            foundBoat.Description = boat.Description;
            foundBoat.ImageName = boat.ImageName;
            JsonFileWriter.WriteToJsonBoat(boats, JsonFileName);
        }
    }
}
