using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBook.App.Commands;
using ContactBook.DomainModel.Models;
using ContactBook.App.Stores;

namespace ContactBook.App.ViewModels
{
    public class ContactListItemViewModel : ObservableObject
    {
        public Contact Contact { get; private set; }
        
        public ICommand UpdateContactCommand;

        public string FirstName
        {
            get { return Contact.FirstName; }
            set { 
                Contact.FirstName = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return Contact.LastName; }
            set
            {
                Contact.LastName = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged("LastName");
            }
        }


        public string StreetName
        {
            get { return Contact.StreetName; }
            set
            {
                Contact.StreetName = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged("StreetName");
            }
        }


        public string HouseNumber
        {
            get { return Contact.HouseNumber; }
            set
            {
                Contact.HouseNumber = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged("HouseNumber");
            }
        }


        public string ApartmentNumber
        {
            get { return Contact.ApartmentNumber; }
            set
            {
                Contact.ApartmentNumber = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged("ApartmentNumber");
            }
        }

        public string PostalCode
        {
            get { return Contact.PostalCode; }
            set
            {
                Contact.PostalCode = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged("PostalCode");
            }
        }

        public string Town
        {
            get { return Contact.Town; }
            set
            {
                Contact.Town = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged("Town");
            }
        }

        public string PhoneNumber
        {
            get { return Contact.PhoneNumber; }
            set
            {
                Contact.PhoneNumber = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged("PhoneNumber");
            }
        }

        public DateTime DateOfBirth
        {
            get { return Contact.DateOfBirth; }
            set
            {
                Contact.DateOfBirth = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged("DateOfBirth");
            }
        }

    



        public ICommand DeleteCommand { get; }

        public ContactListItemViewModel(Contact contact, ContactStore contactStore)
        {
            Contact = contact;
            DeleteCommand = new DeleteContactCommand(this, contactStore);
            UpdateContactCommand = new UpdateContactCommand(this, contactStore);
         
        }
    }
}
