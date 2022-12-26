using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBook.App.Models;

namespace ContactBook.App.ViewModels
{
    public class ContactListViewModel : ObservableObject
    {
        private ObservableCollection<ContactListItemViewModel> _contacts;
        public IEnumerable<ContactListItemViewModel> Contacts => _contacts;

        public ContactListViewModel()
        {
            _contacts = new ObservableCollection<ContactListItemViewModel>()
            {
                new ContactListItemViewModel(new Contact() { FirstName = "Sylwia", LastName="Nowak", StreetName="Grzybowa", HouseNumber="14", ApartmentNumber="01", PostalCode="60-600", Town="Poznań", PhoneNumber="123-45-65", DateOfBirth=new DateTime(1988,01,13)}),
                new ContactListItemViewModel(new Contact() { FirstName = "Adam", LastName="Kowalski", StreetName="Makowa", HouseNumber="10", PostalCode="60-600", Town="Warszawa", PhoneNumber="150 508 588", DateOfBirth=new DateTime(1983,06,14)}),
                  new ContactListItemViewModel(new Contact() { FirstName = "Wiktoria", LastName="Kowalski", StreetName="Rybna", HouseNumber="20", PostalCode="60-600", Town="Warszawa", PhoneNumber="340 123 444", DateOfBirth=new DateTime(2022,08,15)}),
            };
        }
    }
}
