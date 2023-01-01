using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBook.DomainModel.Models;
using ContactBook.App.Stores;
using System.Windows.Input;
using ContactBook.App.Commands;

namespace ContactBook.App.ViewModels
{
    public class ContactListViewModel : ObservableObject
    {
        private ObservableCollection<ContactListItemViewModel> _contacts;
        private ContactStore _contactStore;
        public IEnumerable<ContactListItemViewModel> Contacts => _contacts;

        public ICommand LoadAllContactsCommand { get; }

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


        public ContactListViewModel(ContactStore contactStore)
        {
            _contactStore = contactStore;
            _contactStore.ContactAdded += ContactStore_ContactAdded;
            _contactStore.ContactDeleted += ContactStore_ContactDeleted;
            _contactStore.ContactsGot += ContactStore_ContactsGot;
            _contactStore.ChangesToContactsCancelled += ContactStore_ChangesToContactsCancelled;
            _contacts = new ObservableCollection<ContactListItemViewModel>();
           
            LoadAllContactsCommand = new GetAllContactsCommand(this, contactStore);
          
        }

        private void ContactStore_ChangesToContactsCancelled()
        {
            ContactStore_ContactsGot();
        }

        private void ContactStore_ContactsGot()
        {
            _contacts.Clear();

            foreach (Contact contact in _contactStore.Contacts)
            {
                ContactListItemViewModel clvim = new ContactListItemViewModel(contact, _contactStore);
                _contacts.Add(clvim);
            }
        }

        public static ContactListViewModel GetInitiatedContactListViewModel(ContactStore contactStore)
        {
            ContactListViewModel contactListViewModel = new ContactListViewModel(contactStore);
            contactListViewModel.LoadAllContactsCommand.Execute(null);
            return contactListViewModel;
        }

        protected void Dispose()
        {
            _contactStore.ContactAdded -= ContactStore_ContactAdded;
            _contactStore.ContactDeleted -= ContactStore_ContactDeleted;
            _contactStore.ContactsGot  -= ContactStore_ContactsGot;
            
        }
        private void ContactStore_ContactAdded(Contact newContact)
        {
            ContactListItemViewModel clvim = new ContactListItemViewModel(newContact, _contactStore);
            _contacts.Add(clvim);
        }

        

        private void ContactStore_ContactDeleted(Contact contactToDelete)
        {
            
            //TODO: Handle missing contact
            var contactViewModelToDelete = _contacts.First(c=> c.Contact.Id == contactToDelete.Id);
            _contacts.Remove(contactViewModelToDelete);
        }
    }
}
