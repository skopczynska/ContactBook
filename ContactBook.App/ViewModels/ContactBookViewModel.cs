using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using ContactBook.App.Commands;
using ContactBook.App.DataRepositories;
using ContactBook.App.Stores;

namespace ContactBook.App.ViewModels
{
    public class ContactBookViewModel : ObservableObject
    {
        private ModalNavigationStore _modalNavigationStore;

        public ContactListViewModel ContactListViewModel { get; }
        public ICommand AddContact { get; }
        public ICommand CancelChanges { get; }

        public ICommand SaveChanges { get; }

        

        public ContactBookViewModel(ModalNavigationStore modalNavigationStore, ContactRepository contactRepository)
        {
            _modalNavigationStore = modalNavigationStore;
            ContactListViewModel = new ContactListViewModel(contactRepository);

            AddContact = new OpenAddContactViewCommand(_modalNavigationStore, contactRepository);
        }
    }
}
