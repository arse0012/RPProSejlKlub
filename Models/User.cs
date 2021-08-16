using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoBoatRazorPage.Models
{
    public class User
    {
        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Fornavn skal udfyldes")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Efternaven skal udfyldes")]
        public string LastName { get; set; }

        public string Mail { get; set; }
        [Required(ErrorMessage = "Angiv telefon nummer")]
        public int PhoneNumber { get; set; }
    }
}
