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
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "16/8-2021", "16/8-2022", 
            ErrorMessage = "registringen skal være efter {1}")]
        public DateTime DateTime { get; set; }
        public string ImageName { get; set; }
        //public int UserId { get; set; }
    }
}
