using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactBook.App.Stores;
using ContactBook.App.ViewModels;
using ContactBook.DomainModel.Models;

namespace ContactBook.App.Commands
{
    public class AddContactCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private ContactListItemViewModel _contactListItemViewModel;
                private ContactStore _contactStore;

        public AddContactCommand(ContactListItemViewModel contactListItemViewModel,  ContactStore contactStore)
        {
            _contactListItemViewModel = contactListItemViewModel;
            
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
            catch (Exception)
            {
                //TODO: Add Execption logging
            }
        }

        private async Task ExecuteAsync(object? parameter)
        {
            Contact contactToAdd = _contactListItemViewModel.Contact;
            _contactStore.Add(contactToAdd);
        }
    }
}
