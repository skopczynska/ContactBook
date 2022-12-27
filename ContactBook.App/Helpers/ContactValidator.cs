using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactBook.DomainModel.Models;

namespace ContactBook.App.Helpers
{
    internal static class ContactValidator
    {
        internal static bool Validate(Contact contact)
        {
            if (contact == null)
                return false;

            return !string.IsNullOrEmpty(contact.FirstName) && !string.IsNullOrEmpty(contact.LastName) && !string.IsNullOrEmpty(contact.ApartmentNumber) && !string.IsNullOrEmpty(contact.StreetName) && !string.IsNullOrEmpty(contact.HouseNumber) && !string.IsNullOrEmpty(contact.PostalCode) && !string.IsNullOrEmpty(contact.Town) && !string.IsNullOrEmpty(contact.PhoneNumber);
        }
    }
}
