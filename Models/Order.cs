using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Models
{
    public class Order
    {
        public int Code { get; set; }
        public User User { get; set; }
        public Dictionary<int, Boat> Boats { get; set; }
        public DateTime DateTime { get; set; }
    }
}
