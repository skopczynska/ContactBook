using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactBook.App.Stores;
using ContactBook.App.ViewModels;
using ContactBook.DomainModel.Models;

namespace ContactBook.App.Commands
{
    public class DeleteContactCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private ContactListItemViewModel _contactListItemViewModel;
        private ContactStore _contactStore;
        private ContactListViewModel _contactListViewModel;
               

        public DeleteContactCommand(ContactListViewModel contactListViewModel, ContactListItemViewModel contactListItemViewModel, ContactStore contactStore)
        {
            _contactListViewModel = contactListViewModel;
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
                _contactListViewModel.ErrorMessage = "Errrow while deleting contact. Please contact your admin.";
            }
        }

        private async Task ExecuteAsync(object? parameter)
        {
            Contact contactToDelete = _contactListItemViewModel.Contact;
            _contactStore.Delete(contactToDelete);
        }
    }
}
