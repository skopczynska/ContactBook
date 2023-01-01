using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactBook.App.Stores;
using ContactBook.App.ViewModels;
using ContactBook.DomainModel.Models;

namespace ContactBook.App.Commands
{
    public class SaveAddContactCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private AddContactViewModel _addContactViewModel;
        private ModalNavigationStore _modalNavigationStore;
        private ContactStore _contactStore;

        public SaveAddContactCommand(AddContactViewModel addContactViewModel, ModalNavigationStore modalNavigationStore, ContactStore contactStore)
        {
            _addContactViewModel = addContactViewModel;
            _modalNavigationStore = modalNavigationStore;
            _contactStore = contactStore;
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
                _addContactViewModel.ErrorMessage = "Error while adding a contact. Conact the administrator";
            }
        }

        private async Task ExecuteAsync(object? parameter)
        {
            Contact newContact = _addContactViewModel.NewContact;
            _contactStore.Add(newContact);
            _modalNavigationStore.Close();
        }
    }
}
