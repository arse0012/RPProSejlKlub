using ProtoBoatRazorPage.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Helpers
{
    public class JsonFileWriter
    {
        public static void WriteToJsonUser(Dictionary<int, User> users, string jsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFileName, output);
        }
        public static void WriteToJsonBoat(Dictionary<int, Boat> boats, string jsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(boats, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFileName, output);
        }
        public static void WriteToJsonBooking(Dictionary<int, Booking> orders, string jsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(orders, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFileName, output);
        }
    }
}
