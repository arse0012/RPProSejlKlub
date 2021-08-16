using ProtoBoatRazorPage.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Helpers
{
    public class JsonFileWritter
    {
        public static void WriteToJsonUser(Dictionary<int, User> users, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
        public static void WriteToJsonBoat(Dictionary<int, Boat> boats, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(boats, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}
