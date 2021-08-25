using Newtonsoft.Json;
using ProtoBoatRazorPage.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Helpers
{
    public class JsonFileReader
    {
        public static Dictionary<int, User> ReadJsonUser(string jsonFileName)
        {
            string jsonString = File.ReadAllText(jsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<int, User>>(jsonString);
        }
        public static Dictionary<int, Boat> ReadJsonBoat(string jsonFileName)
        {
            string jsonString = File.ReadAllText(jsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<int, Boat>>(jsonString);
        }
        public static Dictionary<int, Order> ReadJsonOrder(string jsonFileName)
        {
            string jsonString = File.ReadAllText(jsonFileName);
            return JsonConvert.DeserializeObject<Dictionary<int, Order>>(jsonString);
        }
    }
}
