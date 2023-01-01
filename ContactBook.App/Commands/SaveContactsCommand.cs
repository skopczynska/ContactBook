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
    public class SaveContactsCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private ContactStore _contactStore;
        private ContactListViewModel _contactListViewModel;

        public SaveContactsCommand(ContactListViewModel contactListViewModel, ContactStore contactStore)
        {
            _contactStore = contactStore;
            _contactListViewModel = contactListViewModel;
        }


        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                if (!_contactStore.HasValidationError)
                    await ExecuteAsync();
                else
                    _contactListViewModel.ErrorMessage = "Cannot save because there are validation errors. Correct the marked data.";
            }
            catch
            {
                _contactListViewModel.ErrorMessage = "Error while saving contacts. Contact your admin and restart the application.";
            }
            
        }

        private async Task ExecuteAsync()
        {
            List<Contact> contacts = new List<Contact>();
            foreach (var contactVM in _contactListViewModel.Contacts)
            {
                contacts.Add(contactVM.Contact);
            }
            await _contactStore.UpdateContacts(contacts);
        }
    }
}
