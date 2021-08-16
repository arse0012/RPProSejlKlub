using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Models
{
    public class Boat
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bådetype mangler")]
        public string Type { get; set; }
        [Required (ErrorMessage = "Navngiv båden")]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Dato skal sættes")]
        public DateTime DateTime { get; set; }
        public string ImageName { get; set; }
        public Dictionary<int, Boat> BoatList { get; set; }

    }
}
