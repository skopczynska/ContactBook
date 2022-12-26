using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactBook.App.DataRepositories;
using ContactBook.App.Stores;
using ContactBook.App.ViewModels;

namespace ContactBook.App.Commands
{
    public class OpenAddContactViewCommand : ICommand
    {
        private ModalNavigationStore _modalNavigationStore;
        private  ContactRepository _contactRepository;


        public OpenAddContactViewCommand(ModalNavigationStore modalNavigationStore, ContactRepository contactRepository)
        {
            _modalNavigationStore = modalNavigationStore;
            _contactRepository = contactRepository;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            AddContactViewModel addContactViewModel = new AddContactViewModel(_modalNavigationStore, _contactRepository);
            _modalNavigationStore.CurrentViewModel = addContactViewModel;

        }


    }
}
