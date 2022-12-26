using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.App.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string StreetName { get; set; }

        public string HouseNumber { get; set; } 

        public string ApartmentNumber { get; set; }

        public string PostalCode { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
