using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBook.App.Commands;
using ContactBook.App.Stores;

namespace ContactBook.App.ViewModels
{
    public class ContactBookViewModel : ObservableObject
    {
        private ModalNavigationStore _modalNavigationStore;

        private bool _isAnythingToSave = false;

        public bool IsAnythingToSave
        {
            get { return _isAnythingToSave; }
            set
            {
                _isAnythingToSave = value;
                OnPropertyChanged(nameof(IsAnythingToSave));
            }
        }
        public ContactListViewModel ContactListViewModel { get; }
        public ICommand AddContact { get; }
        public ICommand CancelChanges { get; }

        public ICommand SaveChanges { get; }

        

        public ContactBookViewModel(ModalNavigationStore modalNavigationStore, ContactStore contactStore)
        {
            _modalNavigationStore = modalNavigationStore;
            ContactListViewModel = ContactListViewModel.GetInitiatedContactListViewModel(contactStore);

            AddContact = new OpenAddContactViewCommand(ContactListViewModel, _modalNavigationStore, contactStore);
            SaveChanges = new SaveContactsCommand(ContactListViewModel, contactStore);
            CancelChanges = new CancelContactsCommand(ContactListViewModel, contactStore);

            contactStore.ContactsUpdated += ContactStore_ContactsUpdated;
            contactStore.ContactAdded += ContactStore_ContactAdded;
            contactStore.ContactUpdated += ContactStore_ContactUpdated;
            contactStore.ChangesToContactsCancelled += ContactStore_ChangesToContactsCancelled;
        }

        private void ContactStore_ChangesToContactsCancelled()
        {
            IsAnythingToSave = false;
        }

        private void ContactStore_ContactUpdated(DomainModel.Models.Contact obj)
        {
            IsAnythingToSave = true;
        }

        private void ContactStore_ContactAdded(DomainModel.Models.Contact obj)
        {
            IsAnythingToSave = true;
        }

        private void ContactStore_ContactsUpdated()
        {
            IsAnythingToSave = false;
        }
    }
}
