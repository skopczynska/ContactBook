using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactBook.App.DataRepositories;
using ContactBook.App.Models;
using ContactBook.App.Stores;
using ContactBook.App.ViewModels;

namespace ContactBook.App.Commands
{
    public class SaveAddContactCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private AddContactViewModel _addContactViewModel;
        private ModalNavigationStore _modalNavigationStore;
        private ContactRepository _contactRepository;

        public SaveAddContactCommand(AddContactViewModel addContactViewModel, ModalNavigationStore modalNavigationStore, ContactRepository contactRepository)
        {
            _addContactViewModel = addContactViewModel;
            _modalNavigationStore = modalNavigationStore;
            _contactRepository = contactRepository;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch(Exception)
            {
                //TODO: Add Execption logging
            }
        }

        private async Task ExecuteAsync(object? parameter)
        {
            Contact newContact = _addContactViewModel.NewContact;
            _contactRepository.Add(newContact);
            _modalNavigationStore.Close();
        }
    }
}
