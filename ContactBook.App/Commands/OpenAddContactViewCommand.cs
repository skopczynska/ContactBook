using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactBook.App.Stores;
using ContactBook.App.ViewModels;

namespace ContactBook.App.Commands
{
    public class OpenAddContactViewCommand : ICommand
    {
        private readonly ContactListViewModel _contactListViewModel;
        private ModalNavigationStore _modalNavigationStore;
        private ContactStore _contactStore;


        public OpenAddContactViewCommand(ContactListViewModel contactListViewModel, ModalNavigationStore modalNavigationStore, ContactStore contactStore)
        {
            _contactListViewModel = contactListViewModel;
            _modalNavigationStore = modalNavigationStore;
            _contactStore = contactStore;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            AddContactViewModel addContactViewModel = new AddContactViewModel(_modalNavigationStore, _contactStore);
            _modalNavigationStore.CurrentViewModel = addContactViewModel;

        }


    }
}
