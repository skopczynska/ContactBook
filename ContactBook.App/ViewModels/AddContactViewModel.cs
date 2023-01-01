using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBook.App.Commands;
using ContactBook.App.Helpers;
using ContactBook.App.Stores;
using ContactBook.DomainModel.Models;

namespace ContactBook.App.ViewModels
{
    public class AddContactViewModel : ObservableObject, INotifyDataErrorInfo
    {
        public Contact NewContact { get; set; }

        private Dictionary<string, List<string>> _propertyNameToErrors = new Dictionary<string, List<string>>();
        public bool HasErrors => _propertyNameToErrors.Any();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public string FirstName
        {
            get { return NewContact.FirstName; }
            set
            {
                NewContact.FirstName = value;
                
                OnPropertyChanged(nameof(FirstName));

                ValidateRequiredProperty(NewContact.FirstName, nameof(FirstName));
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
            get { return NewContact.LastName; }
            set
            {
                NewContact.LastName = value;
 
                OnPropertyChanged(nameof(LastName));

                ValidateRequiredProperty(NewContact.LastName, nameof(LastName));
            }
        }


        public string StreetName
        {
            get { return NewContact.StreetName; }
            set
            {
                NewContact.StreetName = value;
 
                OnPropertyChanged(nameof(StreetName));
                ValidateRequiredProperty(NewContact.StreetName, nameof(StreetName));

            }
        }


        public string HouseNumber
        {
            get { return NewContact.HouseNumber; }
            set
            {
                NewContact.HouseNumber = value;
 
                OnPropertyChanged(nameof(HouseNumber));
                ValidateRequiredProperty(NewContact.HouseNumber, nameof(HouseNumber));
            }
        }


        public string ApartmentNumber
        {
            get { return NewContact.ApartmentNumber; }
            set
            {
                NewContact.ApartmentNumber = value;
 
                OnPropertyChanged(nameof(ApartmentNumber));

            }
        }

        public string PostalCode
        {
            get { return NewContact.PostalCode; }
            set
            {
                NewContact.PostalCode = value;
 
                OnPropertyChanged(nameof(PostalCode));

                ValidateRequiredProperty(NewContact.PostalCode, nameof(PostalCode));
            }
        }

        public string Town
        {
            get { return NewContact.Town; }
            set
            {
                NewContact.Town = value;
 
                OnPropertyChanged(nameof(Town));

                ValidateRequiredProperty(NewContact.Town, nameof(Town));
            }
        }

        public string PhoneNumber
        {
            get { return NewContact.PhoneNumber; }
            set
            {
                NewContact.PhoneNumber = value;
 
                OnPropertyChanged(nameof(PhoneNumber));

                ValidateRequiredProperty(NewContact.PhoneNumber, nameof(PhoneNumber));
            }
        }

        public DateTime DateOfBirth
        {
            get { return NewContact.DateOfBirth; }
            set
            {
                NewContact.DateOfBirth = value;
 
                OnPropertyChanged(nameof(DateOfBirth));

                ValidateRequiredProperty(NewContact.DateOfBirth.ToString(), nameof(DateOfBirth));
            }
        }



        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        private string _errorMsg;
        public string ErrorMessage
        {
            get { return _errorMsg; }
            set
            {
                _errorMsg = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(IsErrorPresent));
            }
        }

        public bool IsErrorPresent => !string.IsNullOrEmpty(_errorMsg);

        public bool CanAdd => true;

        public AddContactViewModel(ModalNavigationStore modalNavigationStore, ContactStore contactStore)
        {
            NewContact = new Contact() {  DateOfBirth = DateTime.Now };
            AddCommand = new SaveAddContactCommand(this, modalNavigationStore, contactStore);
            CancelCommand = new CloseModalCommand(modalNavigationStore);
            FirstName = String.Empty;
            LastName = String.Empty;
            StreetName = String.Empty;
            HouseNumber = String.Empty;
            PostalCode = String.Empty;
            PhoneNumber = String.Empty;
            Town = String.Empty;
        }

        private void AddError(string errorMessage, string propertyName)
        {
            if (!_propertyNameToErrors.ContainsKey(propertyName))
           {
                _propertyNameToErrors.Add(propertyName, new List<string>());
            }

            _propertyNameToErrors[propertyName].Add(errorMessage);

           

            OnErrorsChanged(propertyName);
        }

        private void ClearErrors(string propertyName)
        {
            _propertyNameToErrors.Remove(propertyName);
         
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(HasErrors));
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            return _propertyNameToErrors.GetValueOrDefault(propertyName, new List<string>());
        }
    }
}
