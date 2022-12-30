using System.Xml.Linq;
using ContactBook.DomainModel.Models;

namespace ContactBook.FileStorage
{
    internal static class XMLElementContactConverter
    {
        private const string _contactXElementName = "Contact";
        private const string _firstNameAttrName = "FirstName";
        private const string _lastNameAttrName = "LastName";
        private const string _streetNameAttrName = "StreetName";
        private const string _houseNumberAttrName = "HouseNumber";
        private const string _aptNumberAttrName = "AptNumber";
        private const string _postalCodeAttrName = "PostalCode";
        private const string _townAttrName = "Town";
        private const string _phoneAttrName = "Phone";
        private const string _birthDateAttrName = "BirthDate";



        internal static Contact GetContact(XElement element)
        {
            Contact contact = new Contact();

            contact.FirstName = element.Attribute(_firstNameAttrName)?.Value;
            contact.LastName = element.Attribute(_lastNameAttrName)?.Value;
            contact.StreetName = element.Attribute(_streetNameAttrName)?.Value;
            contact.HouseNumber = element.Attribute(_houseNumberAttrName)?.Value;
            contact.ApartmentNumber = element.Attribute(_aptNumberAttrName)?.Value;
            contact.PostalCode = element.Attribute(_postalCodeAttrName)?.Value;
            contact.Town = element.Attribute(_townAttrName)?.Value;
            contact.PhoneNumber = element.Attribute(_phoneAttrName)?.Value;
            contact.DateOfBirth = DateTime.Parse(element.Attribute(_birthDateAttrName)?.Value);

            return contact;
        }

        internal static string GetRootXElName()
        {
            return _contactXElementName;
        }

        internal static XElement GetXElement(Contact contact)
        {
            XElement element = new XElement(_contactXElementName);

            element.Add(new XAttribute(_firstNameAttrName, contact.FirstName));
            element.Add(new XAttribute(_lastNameAttrName, contact.LastName));
            element.Add(new XAttribute(_streetNameAttrName, contact.StreetName));
            element.Add(new XAttribute(_houseNumberAttrName, contact.HouseNumber));
            var aptNumber = string.IsNullOrEmpty(contact.ApartmentNumber) ? string.Empty : contact.ApartmentNumber;
            element.Add(new XAttribute(_aptNumberAttrName, aptNumber));
            element.Add(new XAttribute(_postalCodeAttrName, contact.PostalCode));
            element.Add(new XAttribute(_townAttrName, contact.Town));
            element.Add(new XAttribute(_phoneAttrName, contact.PhoneNumber));
            element.Add(new XAttribute(_birthDateAttrName, contact.DateOfBirth.ToShortDateString()));
            
            return element;

        }
    }
}