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
        [Required(ErrorMessage = "Efternavn skal udfyldes")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        //[Required(ErrorMessage = "angiv mailladresse")]
        public string Mail { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Angiv telefon nummer")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{2})$", ErrorMessage = "Ikke gyldig telefonnummer")]
        public string PhoneNumber { get; set; }
        public Dictionary<int, Boat> BoatList { get; set; }
    }
}
