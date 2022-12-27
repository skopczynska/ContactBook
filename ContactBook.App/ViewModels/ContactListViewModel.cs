using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBook.App.Models;
using ContactBook.App.Stores;

namespace ContactBook.App.ViewModels
{
    public class ContactListViewModel : ObservableObject
    {
        private ObservableCollection<ContactListItemViewModel> _contacts;
        private ContactRepository _contactRepository;
        public IEnumerable<ContactListItemViewModel> Contacts => _contacts;



        public ContactListViewModel(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            contactRepository.ContactAdded += ContactRepository_ContactAdded;
            contactRepository.ContactDeleted += ContactRepository_ContactDeleted;
            _contacts = new ObservableCollection<ContactListItemViewModel>();
          
        }
        protected void Dispose()
        {
            _contactRepository.ContactAdded -= ContactRepository_ContactAdded;
        }
        private void ContactRepository_ContactAdded(Contact newContact)
        {
            _contacts.Add(new ContactListItemViewModel(newContact, _contactRepository));
        }

        private void ContactRepository_ContactDeleted(Contact contactToDelete)
        {
            //TODO: Improve for guids
            //TODO: Handle missing contact
            var contactViewModelToDelete = _contacts.First(c=> c.Contact.FirstName == contactToDelete.FirstName);
            _contacts.Remove(contactViewModelToDelete);
        }
    }
}
