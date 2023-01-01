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
using System.ComponentModel;
using System.Collections;

namespace ContactBook.App.ViewModels
{
    public class ContactListItemViewModel : ObservableObject, INotifyDataErrorInfo
    {
        public Contact Contact { get; private set; }
        
        public ICommand UpdateContactCommand;
        private readonly ContactListViewModel _contactListViewModel;
        private ContactStore _contactStore;
        private Dictionary<string, List<string>> _propertyNameToErrors = new Dictionary<string, List<string>>();

        public bool HasErrors => _propertyNameToErrors.Any();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public string FirstName
        {
            get { return Contact.FirstName; }
            set
            {
                Contact.FirstName = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged(nameof(FirstName));

                ValidateRequiredProperty(Contact.FirstName, nameof(FirstName));
            }
        }

        private void ValidateRequiredProperty(string value, string nameOfProperty)
        {
            ClearErrors(nameOfProperty);

            if (string.IsNullOrEmpty(value))
            {
                AddError("Cannot be empty.", nameOfProperty);
            }
        }

        public string LastName
        {
            get { return Contact.LastName; }
            set
            {
                Contact.LastName = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged(nameof(LastName));

                ValidateRequiredProperty(Contact.LastName, nameof(LastName));
            }
        }


        public string StreetName
        {
            get { return Contact.StreetName; }
            set
            {
                Contact.StreetName = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged(nameof(StreetName));
                ValidateRequiredProperty(Contact.StreetName, nameof(StreetName));

            }
        }


        public string HouseNumber
        {
            get { return Contact.HouseNumber; }
            set
            {
                Contact.HouseNumber = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged(nameof(HouseNumber));
                ValidateRequiredProperty(Contact.HouseNumber, nameof(HouseNumber));
            }
        }


        public string ApartmentNumber
        {
            get { return Contact.ApartmentNumber; }
            set
            {
                Contact.ApartmentNumber = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged(nameof(ApartmentNumber));
                
            }
        }

        public string PostalCode
        {
            get { return Contact.PostalCode; }
            set
            {
                Contact.PostalCode = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged(nameof(PostalCode));

                ValidateRequiredProperty(Contact.PostalCode, nameof(PostalCode));
            }
        }

        public string Town
        {
            get { return Contact.Town; }
            set
            {
                Contact.Town = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged(nameof(Town));

                ValidateRequiredProperty(Contact.Town, nameof(Town));
            }
        }

        public string PhoneNumber
        {
            get { return Contact.PhoneNumber; }
            set
            {
                Contact.PhoneNumber = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged(nameof(PhoneNumber));

                ValidateRequiredProperty(Contact.PhoneNumber, nameof(PhoneNumber));
            }
        }

        public DateTime DateOfBirth
        {
            get { return Contact.DateOfBirth; }
            set
            {
                Contact.DateOfBirth = value;
                UpdateContactCommand.Execute(null);
                OnPropertyChanged(nameof(DateOfBirth));

                ValidateRequiredProperty(Contact.DateOfBirth.ToString(), nameof(DateOfBirth));
            }
        }

    



        public ICommand DeleteCommand { get; }


        public ContactListItemViewModel(ContactListViewModel contactListViewModel, Contact contact, ContactStore contactStore)
        {
            _contactListViewModel = contactListViewModel;
            _contactStore = contactStore;
            Contact = contact;
            DeleteCommand = new DeleteContactCommand(_contactListViewModel, this, contactStore);
            UpdateContactCommand = new UpdateContactCommand(this, contactStore);
         
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyNameToErrors.GetValueOrDefault(propertyName, new List<string>());
        }


        private void AddError(string errorMessage, string propertyName)
        {
            if (!_propertyNameToErrors.ContainsKey(propertyName))
            {
                _propertyNameToErrors.Add(propertyName, new List<string>());
            }

            _propertyNameToErrors[propertyName].Add(errorMessage);

            _contactStore.HasValidationError = true;

            OnErrorsChanged(propertyName);
        }

        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrors.Remove(propertyName);
            _contactStore.HasValidationError = false;

            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
